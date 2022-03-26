#include "GameManager.h"
#include <irrKlang.h>
using namespace irrklang;
int main()
{
    GameManager::GetInstance().engine->play2D("loon-bird-call.mp3"); //Play sound


    GameManager::GetInstance().Run();


}