#pragma once
#include "IState.h"
#include "DrawUtility.h";
#include "MapHolder.h"

class PlayState	: public IState
{
private:
	bool leftClick;
	bool rightClick;
	bool inputDown;
public:
	void OnUpdate();
};

