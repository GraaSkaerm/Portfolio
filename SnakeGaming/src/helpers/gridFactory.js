import { Tile } from "../components/Tile";


export const makeGrid = (rowLength, colLength, snake, apple) =>{



    var array = [];


    for (let row = 0; row < rowLength; row++){

        array.push([]); 

        for (let col = 0; col < colLength; col++){
            array[row].push(getTile(row, col, snake, apple));
        }
    }


    var i = 0;

    snake.body.forEach(part => {

        array.map(row => {
            row.map(tile => {
                
                if  (tile.props.state.col === part.x && tile.props.state.row === part.y) {
                    if (i === 0){
                        tile.props.state.type = 'tile-snake';
                        i = 1;
                    }
                    else{
                        tile.props.state.type = 'tile-snake-body';
                    }
                }
            })

        })
   

    });

    return array;
}


const getTile = (row, col, snake, apple) => {


    if (row === apple.y && col === apple.x){
        return <Tile state={{type: 'tile-apple', row: row, col: col}} key={col}></Tile>;
    }

    return <Tile state={{type: 'tile', row: row, col: col}} key={col}></Tile>;
}
