#include "IMapBuilder.h"
#include <iostream>
using namespace std;
#include <vector>


void IMapBuilder::Reset()
{
	_rowLength = 0;
	_colLength = 0;



	_map = new Map();
}

vector<pair<int, int>> IMapBuilder::GetNeighboursPoints(int startRow, int startCol) {
	
	vector<pair<int, int>> neighboursPoints;

	int row = startRow - 1;
	int col = startCol - 1;



	for (int i = 0; i < 3; i++)
	{
		for (int j = 0; j < 3; j++)
		{
			if (row == startRow && col == startCol) { col++; continue; }

			if (InBounds(row, col))
			{
				neighboursPoints.emplace_back(pair<int, int>(row, col));
			}

			col++;
		}
		col = startCol - 1;
		row++;
	}

	return neighboursPoints;
}

vector<Tile*>  IMapBuilder::GetTilesNeighbours(vector<pair<int, int>> neighboursPoints) {

	int length = neighboursPoints.size();

	vector<Tile *>  neighbours =  vector<Tile*>();

	//Tile** neighbours = new  Tile *[length];

	for (int i = 0; i < length; i++)
	{
		int row = neighboursPoints[i].first;
		int col = neighboursPoints[i].second;

		neighbours.emplace_back(&_map->tiles[row][col]);
		//neighbours[i] = &_map->tiles[row][col];
	}


	return neighbours;
}


bool IMapBuilder::InBounds(int row, int col)
{
	if (row < 0 || col < 0 || row > _rowLength - 1 || col > _colLength - 1)
	{
		return false;
	}

	return true;
}

void IMapBuilder::SetStartPoint(int row, int col)
{
	_startRow = row;
	_startCol = col;
}

void IMapBuilder::SetSize(int rowLength, int colLength)
{
	_rowLength = rowLength;
	_colLength = colLength;

	_map = new Map(rowLength, colLength);
}



Map * IMapBuilder::GetMap()
{
	Map * map = _map;
	Reset();
	return map;
}

IMapBuilder::IMapBuilder()
{
	delete _map;
}
