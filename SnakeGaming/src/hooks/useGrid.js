import { useEffect, useState } from "react"


export const useGrid = (intitialJaggedArray) => {
    const [grid, setGrid] = useState(intitialJaggedArray);
    const [rowLength, setRowLength] = useState(0);
    const [colLength, setColLength] = useState(0);


    useEffect(() => {
        try {
            setRowLength(grid.length);
            setColLength(grid[0].length);
        }
        catch{}
       
    }, [grid])

    return {grid: {grid, setGrid, rowLength, colLength} }
}