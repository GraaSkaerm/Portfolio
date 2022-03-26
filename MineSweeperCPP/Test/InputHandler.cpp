#include "InputHandler.h"



/// <summary>
/// Returns the position to set a cursor where the mouse is.
/// </summary>
/// <returns>COORD with X, Y as grid positions</returns>
COORD InputHandler::GetMousePosInConsoleGrid() {

	// Get size of font
	COORD fS = GetFontSize();

	// Get mouse pixel pos
	POINT p;
	GetCursorPos(&p);

	// Convert pixel pos to Logic Unit pos
	ScreenToClient(GetConsoleWindow(), &p);

	// Offset mouse pos to work with the small gap between letters.
	int amountOfUnitsFromTheLeft = (p.x / fS.X);
	float letterGapAt24FontSize = 0.2;
	float offset = letterGapAt24FontSize * amountOfUnitsFromTheLeft;

	// Calculate COORD from size of screen and mouse position.
	COORD output =
	{
		((p.x - offset) / fS.X),
		(p.y / fS.Y)
	};


	return output;
}

/// <summary>
/// Returns a COORD with the logical unit size of the letters.
/// </summary>
/// <returns> COORD with X, Y as Logical Units. </returns>
COORD InputHandler::GetFontSize()
{

	// Instantiate value
	PCONSOLE_FONT_INFOEX lpConsoleCurrentFontEx = new CONSOLE_FONT_INFOEX();
	lpConsoleCurrentFontEx->cbSize = sizeof(CONSOLE_FONT_INFOEX);

	// Get the current font
	GetCurrentConsoleFontEx(out, 0, lpConsoleCurrentFontEx);

	// Return dat font size COORD.
	return lpConsoleCurrentFontEx->dwFontSize;
}


/// <summary>
/// Sets console cursor the the given position
/// </summary>
/// <param name="pos"></param>
void InputHandler::GoToCOORD(COORD pos) {
	SetConsoleCursorPosition(out, pos);
}

/// <summary>
/// Method used to check for mouse input
/// </summary>
/// <param name="key">keycode for the key to check for</param>
/// <returns>True if key is pressed</returns>
bool InputHandler::GetMouseInput(int key)
{
	return (GetAsyncKeyState(key) >> 15);
}

/// <summary>
/// Method to set the font size :)
/// </summary>
/// <param name="a"></param>
void InputHandler::SetFontSize(int size) {
	// Initialize variable
	PCONSOLE_FONT_INFOEX lpConsoleCurrentFontEx = new CONSOLE_FONT_INFOEX();
	lpConsoleCurrentFontEx->cbSize = sizeof(CONSOLE_FONT_INFOEX);

	// Assign variable
	GetCurrentConsoleFontEx(out, 0, lpConsoleCurrentFontEx);

	// Change variable values
	lpConsoleCurrentFontEx->dwFontSize.X = size;
	lpConsoleCurrentFontEx->dwFontSize.Y = size;

	// Set console font to be changed variable
	SetCurrentConsoleFontEx(out, 1, lpConsoleCurrentFontEx);
}