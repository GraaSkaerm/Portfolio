#include "GameManager.h"
#include <iostream>
GameManager::GameManager(IState * initState)
{
	_currState = initState;
}

GameManager& GameManager::GetInstance() {

	static GameManager instance = GameManager(new MakeMapState());
	return instance;
}

void GameManager::Run()
{
	while (true)
	{
		_prevState = _currState;
		while (_prevState == _currState)
		{
			_currState->OnUpdate();
		}
	}

	MakeMapState* hihiSnytVar = dynamic_cast<MakeMapState*>(_currState);

	if (hihiSnytVar != NULL)
	{
		std:: cout << "its a make map state mate.";
	}
}

void GameManager::SetState(IState* newState)
{
	_currState = newState;

}

GameManager::~GameManager()
{
	engine->drop();
	delete _currState;
	delete _prevState;
}


