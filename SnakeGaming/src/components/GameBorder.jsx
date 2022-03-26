import '../css/height.css'
import { GAME_OVER } from '../gameState'
import { GameOverText } from './GameOverText'
import {Grid} from './Grid'

export const GameBorder = ({grid, snake, apple}) => {


    return <div className="m-auto h-600 mt-4 p-4 w-1/2 border-dotted border">
        {getInnerDisplay(grid, snake, apple)}
    </div>
}

const getInnerDisplay = (grid, snake, apple) => {

    // console.log(GAME_OVER)
    if (GAME_OVER.value === false){
        return <Grid grid={grid} snake={snake} apple={apple}></Grid>

    }
    else{
        return <GameOverText></GameOverText>
    }


}