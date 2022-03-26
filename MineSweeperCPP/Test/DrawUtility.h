#ifndef DRAWUTIL
#define DRAWUTIL

#include <color.h>
#include <iostream>
#include <windows.h>
#include "InputHandler.h";
#include <chrono>
#include <thread>
//#include "GameManager.h"
#include "MapHolder.h";
using namespace std;



class DrawUtility {
private:
	DrawUtility() {
		SetupDraw();
	}

public:
	static DrawUtility& GetInstance() {
		static DrawUtility instance;

		return instance;
	}



	inline COORD ConsoleGridSize();
	inline COORD GetGridPosition();
	inline dye::R<const char*>GetTilePieceToDraw(int number, COORD pos, bool light, bool isBomb);
	inline void Draw(COORD tilePosition, bool isOpen, int number, bool hasFlag, bool isBomb);

	COORD TopLeft;

	const int TILE_WIDTH = 3;
	//Maybe make this a coord to support non square maps. non x = y maps.
	//int MAP_SIZE = GameManager::GetInstance()->_mapSize.X;

	//int MAP_SIZE = 20;
	int MAP_SIZE = MapHolder::GetInstance().map->rowLength;

	/// <summary>
	/// Can be called multiple times.
	/// </summary>
	inline void SetupDraw() {

		std::this_thread::sleep_for(200ms);

		TopLeft = { 0,0 };

		COORD sizeOfScreen = ConsoleGridSize();

		TopLeft.X = (sizeOfScreen.X / 2) - ((MAP_SIZE * TILE_WIDTH / 2) - (TILE_WIDTH / 2));

		TopLeft.Y = (sizeOfScreen.Y / 2) - (MAP_SIZE / 2);
	}
};

COORD DrawUtility::GetGridPosition() {

	COORD mousePos = InputHandler::GetInstance().GetMousePosInConsoleGrid();
	// Within map.
	if (mousePos.X >= TopLeft.X && mousePos.Y >= TopLeft.Y) {

		if (mousePos.X <= (TopLeft.X + (MAP_SIZE * TILE_WIDTH)) && mousePos.Y <= TopLeft.Y + MAP_SIZE) {

			//COORD tilePos = { (((mousePos.X - (TILE_WIDTH - 1)) / 3) % MAP_SIZE), mousePos.Y };
			COORD tilePos = { ((mousePos.X - TopLeft.X) / 3), ((mousePos.Y - TopLeft.Y)) };
			return tilePos;
		}
	}
	return COORD{ -1,-1 };
}

void DrawUtility::Draw(COORD tilePosition, bool isOpen, int number, bool hasFlag, bool isBomb) {

	dye::R<const char*> lightGreen = dye::black_on_light_green((hasFlag) ? "F" : " ");
	dye::R<const char*> darkGreen = dye::white_on_green((hasFlag) ? "F" : " ");

	// current position do draw at.
	COORD currentDrawPos = { (tilePosition.X * TILE_WIDTH) + TopLeft.X, tilePosition.Y + TopLeft.Y };

	// To draw a light or a dark tile
	bool light = ((tilePosition.X + tilePosition.Y) % 2 == 1);

	//actual drawing
	for (int i = 0; i < TILE_WIDTH; i++)
	{
		InputHandler::GetInstance().GoToCOORD(currentDrawPos);

		if (!isOpen) {
			cout << (light ? lightGreen : darkGreen);
		}
		else {
			int newNumber = isBomb ? 1 : number;
			int drawNumber = (i == TILE_WIDTH / 2 ? newNumber : 0);

			cout << GetTilePieceToDraw(drawNumber, tilePosition, light, isBomb);
		}
		currentDrawPos.X += 1;
	}
}

dye::R<const char*> DrawUtility::GetTilePieceToDraw(int number, COORD pos, bool light, bool isBomb) {

	//If tile should have value, output string should be wither * or number. * if bomb, number if not. 
	string output = (number > 0 ? ((isBomb) ? "*" : to_string(number)) : " ");


	auto outputColoured = (light ? dye::grey_on_bright_white(output) : dye::grey_on_white(output));
	if (!isBomb) {

		switch (number)
		{
		case 1:
			outputColoured = (light ? dye::blue_on_bright_white(output) : dye::blue_on_white(output));

			break;
		case 2:
			outputColoured = (light ? dye::green_on_bright_white(output) : dye::green_on_white(output));
			break;
		case 3:
			outputColoured = (light ? dye::red_on_bright_white(output) : dye::red_on_white(output));
			break;
		case 4:
			outputColoured = (light ? dye::purple_on_bright_white(output) : dye::purple_on_white(output));
			break;
		case 5:
			outputColoured = (light ? dye::yellow_on_bright_white(output) : dye::yellow_on_white(output));
			break;
		case 6:
			outputColoured = (light ? dye::aqua_on_bright_white(output) : dye::aqua_on_white(output));
			break;
		case 7:
			outputColoured = (light ? dye::black_on_bright_white(output) : dye::black_on_white(output));
			break;
		default:
			break;
		}
	}
	else {
		outputColoured = (light ? dye::red_on_bright_white(output) : dye::red_on_white(output));
	}

	return outputColoured;
}

/// <summary>
/// Returns a COORD with width and height of the visible grid.
/// </summary>
/// <returns></returns>
COORD DrawUtility::ConsoleGridSize() {

	CONSOLE_SCREEN_BUFFER_INFO csbi;

	COORD output;

	GetConsoleScreenBufferInfo(GetStdHandle(STD_OUTPUT_HANDLE), &csbi);
	output.X = csbi.srWindow.Right - csbi.srWindow.Left + 1;
	output.Y = csbi.srWindow.Bottom - csbi.srWindow.Top + 1;

	return output;
}
#endif

