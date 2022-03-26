import { useEffect, useState } from "react";
import { HIGHSCORE, SCORE } from "../components/Score";
import { lastPressedKey } from "../handlers/inputHandler";
import { colLength, getColLength, ROW_LENGTH } from "../helpers/getGridLength";
import { random } from "../helpers/random";
import { addResetListener } from "../helpers/resetEvent";
import { useInterval } from "./useInterval";
import { usePosition } from "./usePosition"
import { useWindow } from "./useWindow";


export const useApple = ({snake}) => {
    const {x, setX, y, setY} = usePosition(0,0);
    const [onGrid, setOnGrid] = useState(false);
  

    const onReset = (() => {
        spawnApple(ROW_LENGTH, getColLength());      
    })

    addResetListener(onReset);

    useEffect(() => {

        if (onGrid === false){
            spawnApple(ROW_LENGTH, getColLength());      
        }
      
    }, [onGrid])




    useInterval(() => {
        let rowLength = ROW_LENGTH - 1;
        let colLength = getColLength() - 1;

        if (y > rowLength || x > colLength){
            setOnGrid(false);
        }

        if (snake.x === x && snake.y === y){
            snake.incrementBody();
            SCORE.value += 100;

            if (SCORE.value > HIGHSCORE.value){
                HIGHSCORE.value = SCORE.value;
            }
            setOnGrid(false);
        }

    }, 0)

    const spawnApple = (rowLength, colLength) => {
        let row = random(0, rowLength - 1);
        let col = random(0, colLength - 1)
        



        while (posIsUsed(row, col)){
            row = random(0, rowLength - 1);
            col = random(0, colLength - 1)
        }




        setX(col);
        setY(row);
        setOnGrid(true);
    }

    const posIsUsed = (x, y) => {

        let used = false;

        snake.body.forEach(part => {
            if (part.x === x && part.y === y){
                used = true;
            }
        });
        return used;
    }

    return {apple: {x, y, spawnApple}}
}