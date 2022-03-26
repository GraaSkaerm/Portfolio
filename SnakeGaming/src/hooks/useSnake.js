import { useEffect, useState } from "react"
import { GAME_OVER } from "../gameState";
import { getKey, lastPressedKey } from "../handlers/inputHandler";
import { getColLength, ROW_LENGTH } from "../helpers/getGridLength";
import { addResetListener } from "../helpers/resetEvent";
import { useInterval } from "./useInterval";
import { usePosition } from "./usePosition";


export const useSnake = (initialX, initialY) => {

    const {x, setX, y, setY} = usePosition(initialX, initialY);
    const [body, setBody] = useState([{x: x, y: y}]);
    const [direction, setDirection] = useState("null");


    const onReset = (() => {
        setBody([{x: initialX, y: initialY}]);
        setX(initialX);
        setY(initialY);
        setDirection("null");
        GAME_OVER.value = false;
    })

    addResetListener(onReset);

    useInterval(() => {onUpdate()}, 0);
    useInterval(() => {onMove()}, 80)

    const isPositionBoddy = () => {

        try {
            var tile = document.getElementById(`row: ${y} col: ${x}`);

            if (tile.title === "tile-snake-body"){
                GAME_OVER.value = true;
            }
        }
        catch{
            // good error handling :)
        }
        

    }


    const onMove = () => {
        var copy = [...body];

        for (let i = body.length - 1; i > 0; i--){
            copy[i].x = copy[i - 1].x;
            copy[i].y = copy[i - 1].y;
        }

        setBody([...copy]);

        switch(direction){
            case "right": 
            setX(prevX => prevX + 1);  

          

            break;
            case "left": 
            setX(prevX => prevX - 1);  

      

            break;
            case "up": 
            
     
      
            setY(prevY => prevY - 1);     

            break;
            case "down": 
            
          
            setY(prevY => prevY + 1);     


            break;
            default: break;
        }

        if (x >= getColLength()){
            GAME_OVER.value = true;

            // setX(0); 
        }
        if (x < 0){

            GAME_OVER.value = true;

            // setX(getColLength() - 1);
        }
        if (y < 0){
            GAME_OVER.value = true;

            // setY(ROW_LENGTH - 1);
        }

        if (y >= ROW_LENGTH){
            GAME_OVER.value = true;

            // setY(0);     
        }
        var arr = [...body];
        arr[0].x = x;
        arr[0].y = y;
        setBody([...arr]);
        isPositionBoddy();
    }

    const onUpdate = () => {
        if (getKey("d") && lastPressedKey == "d"){
            setDirection("right");
        }
        
        if (getKey("a") && lastPressedKey == "a"){
            setDirection("left");
        }

        if (getKey("w") && lastPressedKey == "w"){
            setDirection("up");
        }

        if (getKey("s") && lastPressedKey == "s"){
            setDirection("down");
        }
    }

    const incrementBody = () => {
        setBody([...body, {x: x, y: y}])   
    }



    return {snake: {x, setX, y, setY, body, onMove, onUpdate, incrementBody}}

}