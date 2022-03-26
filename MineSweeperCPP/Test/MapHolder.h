#pragma once
#include "Map.h"
#include "MapDirector.h"
#include "MapBuilder.h"
class MapHolder
{

public:
	static MapHolder& GetInstance();
	Map* map;
	~MapHolder();
	MapHolder();

};

