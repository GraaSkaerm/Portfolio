#include "MakeMapState.h"
#include <iostream>
#include "Map.h"
#include "MapBuilder.h"
#include "MapDirector.h"
#include "MapHolder.h"
#include "GameManager.h"
#include "PlayState.h"
#include "DrawUtility.h"

void MakeMapState::OnUpdate()
{

    MapDirector* director = new MapDirector(new MapBuilder());


    Map* map = MapHolder::GetInstance().map;

    *map = *director->MakeEmptyMap();

	map->Render();



    while (true)
    {
		InputHandler::GetInstance().GoToCOORD(
			InputHandler::GetInstance().GetMousePosInConsoleGrid()
		);

	


		// Returns true if M_Left is held.
		if (InputHandler::GetInstance().GetMouseInput(VK_LBUTTON)) {
			if (inputDown == false) {

				COORD tile = DrawUtility::GetInstance().GetGridPosition();

				//Testing
				InputHandler::GetInstance().GoToCOORD(COORD{ 0,0 });
				cout << tile.X << "," << tile.Y;

				if (tile.X < 0 || tile.Y < 0) {
					inputDown = true;
					return;
				}

				*map = *director->MakeMap(tile.Y, tile.X);

				map->tiles[tile.Y][tile.X].OnTrigger();


				MapHolder::GetInstance().map->Render();

				delete director;
				GameManager::GetInstance().SetState(new PlayState());

				return;
				//map[tileCurrentlyHovering.Y][tileCurrentlyHovering.X]->OnClick();

			}
			inputDown = true;
		}
		else {
			inputDown = false;
		}
    }



   

}


