#include "Tile.h"

#include <iostream>
#include "MapHolder.h"
#include <thread>
#include <functional>
#include "DrawUtility.h"
#include <Windows.h>
#include "GameManager.h"
#include "GameOverState.h"
#include <irrKlang.h>

using namespace irrklang;



void Tile::SetNeighbours(vector<Tile *> neighbours)
{
	_neighbours = neighbours;

	value = 0;
	for (int i = 0; i < _neighbours.size(); i++)
	{
		if (_neighbours[i]->isBomb == true)
		{
			value++;
		}
	}
}

void Tile::OnTrigger()
{
	if (isOpen == true || isFlagged == true)
	{
		return;
	}

	if (isBomb == true) {
		Map* map = MapHolder::GetInstance().map;



		GameManager::GetInstance().engine->stopAllSounds(); //Play sound


		for (int row = 0; row < map->rowLength; row++)
		{
			for (int col = 0; col < map->colLength; col++)
			{
				if (map->tiles[row][col].isBomb) {
					map->tiles[row][col].isOpen = true;
					map->tiles[row][col].Render();

					Sleep(100);
					GameManager::GetInstance().engine->play2D("nein.mp3"); //Play sound

				}
			}
		}



		GameManager::GetInstance().SetState(new GameOverState());

	}

	isOpen = true;
	if (this->value == 0)
	{
		for (int i = 0; i < _neighbours.size(); i++)
		{
			if (_neighbours[i]->isBomb == false)
			{
				_neighbours[i]->OnTrigger();
			}
		}
	}

	
	Render();
}

void Tile::OnFlag()
{
	isFlagged = !isFlagged;
	Render();
}

Tile::Tile(int row, int col)
{
	this->row = row;
	this->col = col;
	this->value = 1;
}

void Tile::Render() {

	COORD position = { col, row };

	DrawUtility::GetInstance().Draw(position, isOpen, value, isFlagged, isBomb);
}

Tile::Tile(){
}

Tile::~Tile() {

	
}