#pragma once
#include "Tile.h"


class Map
{

public:
	Tile** tiles;
	int rowLength;
	int colLength;
	
	Map(int rowLength, int colLength);
	Map();
	~Map();

	void Render();
};

