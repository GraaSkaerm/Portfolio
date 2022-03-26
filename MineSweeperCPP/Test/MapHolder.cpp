#include "MapHolder.h"


MapHolder::MapHolder()
{
	map = new Map(0, 0);
}



MapHolder& MapHolder::GetInstance()
{
	static MapHolder instance = MapHolder();

	return instance;
}

MapHolder::~MapHolder()
{
	delete map;
}


