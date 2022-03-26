#include "MapDirector.h"

MapDirector::MapDirector(IMapBuilder* initBuilder)
{
	_builder = initBuilder;
}



Map* MapDirector::MakeMap(int startRow, int startCol)
{
	_builder->SetStartPoint(startRow, startCol);
	_builder->SetSize(20, 20);
	_builder->SetSafeZone(7);
	_builder->SetMines(60);
	_builder->SetTilesVariabels();

	return _builder->GetMap();
}

Map* MapDirector::MakeEmptyMap()
{
	_builder->SetStartPoint(0, 0);
	_builder->SetSize(20, 20);
	_builder->SetSafeZone(0);
	_builder->SetMines(0);

	return _builder->GetMap();
}

void MapDirector::SetBuilder(IMapBuilder* newBuilder)
{
	_builder = newBuilder;
}


MapDirector::~MapDirector()
{
	delete _builder;
}
