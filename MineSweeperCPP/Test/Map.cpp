#include "Map.h"
#include <iostream>
Map::Map() {
	this->rowLength = 0;
	this->colLength = 0;
}

Map::Map(int rowLength, int colLength)
{
	this->rowLength = rowLength;
	this->colLength = colLength;

	tiles = new Tile * [rowLength];

	for (int row = 0; row < rowLength; row++)
	{
		tiles[row] = new Tile[colLength];

		for (int col = 0; col < colLength; col++)
		{
			tiles[row][col].row = row;
			tiles[row][col].col = col;
		}
	}
}



void Map::Render() {
	for (int row = 0; row < rowLength; row++) {

		for (int col = 0; col < colLength; col++)
		{

			//std:: cout << " " << tiles[row][col].value;
			tiles[row][col].Render();
		}
		//std::cout << std::endl;
	}
}

Map::~Map() {

	for (int row = 0; row < rowLength; row++)
	{
		delete tiles[row];
		tiles = nullptr;

	}

	delete[] tiles;
	tiles = nullptr;

}