#pragma once
#include "IState.h"
#include "MakeMapState.h"
#include <irrKlang.h>	
using namespace irrklang;
class GameManager
{
private:
	IState* _currState;
	IState* _prevState;
	GameManager(IState* initState);

public:
	static GameManager& GetInstance();
	ISoundEngine* engine = createIrrKlangDevice(); //Creates engine

	void Run();
	void SetState(IState* newState);

	~GameManager();
};

