#pragma once
#include "IState.h"

class MakeMapState : public IState
{
public:
	bool inputDown;
	void OnUpdate();
};

