import { useEffect } from 'react';
import { useState } from 'react';
import '../css/grid.css'
import { GAME_OVER } from '../gameState';
import { makeGrid } from '../helpers/gridFactory';
import { useWindow } from '../hooks/useWindow';
import { Tile } from './Tile';


export const Grid = ({grid, snake, apple}) => {

    const {window} = useWindow();
    const [rowLength, setRowLength] = useState()

    

    useEffect(() => {
        let rowLengthFloat = (window.width/2 - 34)/25;
        let rowLegnthInt = parseInt(rowLengthFloat);

        if (rowLegnthInt !== rowLength){
            setRowLength(rowLegnthInt);
            
        }

    },[window.width])

    useEffect(() => {
        grid.setGrid(makeGrid(22, rowLength, snake, apple))
    }, [snake.x , snake.y, rowLength, apple.x, apple.y])


    return <div className="grid grid-container--fill">
        {grid.grid}
    </div>
}



