#include "GameOverState.h"

void GameOverState::OnUpdate()
{
	Sleep(200);
	if (InputHandler::GetInstance().GetMouseInput(VK_LBUTTON)) {
		exit(EXIT_SUCCESS);
	}
}
