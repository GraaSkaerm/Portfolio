#pragma once
#include <vector>

using namespace std;

class Tile
{
private:
	

public:
	int value = 0;
	int row = 0;
	int col = 0;
	bool isBomb = false;
	bool isOpen = false;
	bool isFlagged = false;

	vector<Tile *> _neighbours;

	void SetNeighbours(vector<Tile *> neighbours);
	void OnTrigger();
	void OnFlag();
	void Render();

	Tile(int row, int col);
	Tile();
	~Tile();

};

