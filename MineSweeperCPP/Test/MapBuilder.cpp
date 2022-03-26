#include "MapBuilder.h"

vector<pair<int, int>> MapBuilder::GetUseableTiles()
{
    vector<pair<int, int>> useableTiles;

    for (int row = 0; row < _rowLength; row++)
    {
        for (int col = 0; col < _colLength; col++)
        {
            if (_map->tiles[row][col].value != 9)
            {
                useableTiles.emplace_back(pair<int, int>(row, col));
            }
        }
    }


    return useableTiles;
}


void MapBuilder::SetSafeZone(int size)
{
    int row = _startRow - size / 2;
    int col = _startCol - size / 2;

    for (int i = 0; i < size; i++) {

        for (int j = 0; j < size; j++) {

            if (InBounds(row, col))
            {
                _map->tiles[row][col].value = 9;
            }

            col++;
        }

        col = _startCol - size / 2;
        row++;
    }

}

void MapBuilder::SetMines(int count)
{
    vector<pair<int, int>> useableTiles = GetUseableTiles();

    for (int i = 0; i < count; i++)
    {
        int r = rand() % useableTiles.size() + 0;

        int row = useableTiles[r].first;
        int col = useableTiles[r].second;

        _map->tiles[row][col].value = 7;
        _map->tiles[row][col].isBomb = true;

        useableTiles.erase(useableTiles.begin() + r);
    }
}

void MapBuilder::SetTilesVariabels()
{
    for (int row = 0; row < _rowLength; row++)
    {
        for (int col = 0; col < _colLength; col++)
        {
            vector<pair<int,int>> points = GetNeighboursPoints(row, col);

             vector<Tile *> neighbours = GetTilesNeighbours(points);

            _map->tiles[row][col].SetNeighbours(neighbours);

        }
    }
}

MapBuilder::MapBuilder() : IMapBuilder()
{
}
