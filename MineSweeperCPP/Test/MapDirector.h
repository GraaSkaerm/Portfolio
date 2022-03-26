#pragma once
#include "IMapBuilder.h"
#include "Map.h"
#include "MapBuilder.h"

class MapDirector
{
private:
	IMapBuilder * _builder;

public:
	MapDirector(IMapBuilder * initBuilder);
	Map * MakeMap(int startRow, int startCol);
	Map* MakeEmptyMap();
	void SetBuilder(IMapBuilder * newBuilder);
	~MapDirector();
};

