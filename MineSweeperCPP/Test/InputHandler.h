#ifndef INPUTHANDLE
#define INPUTHANDLE
#include <Windows.h>

class InputHandler
{
public:

	inline void fullscreen()
	{
		keybd_event(VK_MENU, 0x38, 0, 0);
		keybd_event(VK_RETURN, 0x1c, 0, 0);
		keybd_event(VK_RETURN, 0x1c, KEYEVENTF_KEYUP, 0);
		keybd_event(VK_MENU, 0x38, KEYEVENTF_KEYUP, 0);
	}

	InputHandler() {
		fullscreen();
		// Mouse pos thingy only works at 24. Offset is not consistent so we force known font size.
		SetFontSize(24);
		GetConsoleMode(hInput, &prev_mode);
		SetConsoleMode(hInput, ENABLE_EXTENDED_FLAGS |
			(prev_mode & ~ENABLE_QUICK_EDIT_MODE));
		//SetConsoleDisplayMode(GetStdHandle(STD_OUTPUT_HANDLE), CONSOLE_FULLSCREEN_MODE, 0);
	}
	~InputHandler() {
		SetConsoleMode(hInput, prev_mode);
	}

	static InputHandler& GetInstance() {
		static InputHandler instance;

		return instance;
	}


	DWORD prev_mode;

	int lMB = VK_LBUTTON;
	int rMB = VK_RBUTTON;

	HANDLE out = GetStdHandle(STD_OUTPUT_HANDLE);
	HANDLE hInput = GetStdHandle(STD_INPUT_HANDLE);

	bool GetMouseInput(int key);
	COORD GetMousePosInConsoleGrid();
	void GoToCOORD(COORD pos);

	COORD GetFontSize();
	void SetFontSize(int size);

};

#endif