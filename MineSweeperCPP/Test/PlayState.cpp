#include "PlayState.h"

void PlayState::OnUpdate()
{
	InputHandler::GetInstance().GoToCOORD(InputHandler::GetInstance().GetMousePosInConsoleGrid());

	if (InputHandler::GetInstance().GetMouseInput(VK_LBUTTON)) {

		if (leftClick == false) {
			COORD tileCurrentlyHovering = DrawUtility::GetInstance().GetGridPosition();
			MapHolder::GetInstance().map->tiles[tileCurrentlyHovering.Y][tileCurrentlyHovering.X].OnTrigger();
		}
		
		leftClick = true;
	}
	else { leftClick = false; }

	if (InputHandler::GetInstance().GetMouseInput(VK_RBUTTON)) {

		if (rightClick == false) {
			COORD tileCurrentlyHovering = DrawUtility::GetInstance().GetGridPosition();
			MapHolder::GetInstance().map->tiles[tileCurrentlyHovering.Y][tileCurrentlyHovering.X].OnFlag();
		}

		rightClick = true;
	}
	else { rightClick = false; }

}
