#pragma once
#include "IMapBuilder.h"
class MapBuilder : public IMapBuilder
{
private:
	vector<pair<int, int>> GetUseableTiles();

public:
	void SetSafeZone(int size);
	void SetMines(int count);
	void SetTilesVariabels();
	MapBuilder();
};

