#pragma once
#include <vector>
#include "Map.h"
using namespace std;


class IMapBuilder
{
private:
	void Reset();
	virtual vector<pair<int, int>> GetUseableTiles() { throw; }

protected:
	int _rowLength = 0;
	int _colLength = 0;
	int _startRow = 0;
	int _startCol = 0;

	Map * _map = new Map();

	bool InBounds(int row, int col);

	vector<pair<int, int>> GetNeighboursPoints(int startRow, int startCol);

	vector<Tile *> GetTilesNeighbours(vector<pair<int, int>> neighboursPoints);

public:
	void SetStartPoint(int row, int col);
	void SetSize(int rowLength, int colLength);
	virtual void SetSafeZone(int size) { throw; }
	virtual void SetMines(int count) { throw; }
	virtual void SetTilesVariabels() { throw; }
	Map * GetMap();
	IMapBuilder();
};

