import "../css/color.css"
import { GAME_OVER } from "../gameState"
import { Reset } from "../helpers/resetEvent"
import { HIGHSCORE, SCORE } from "./Score"

export const GameOverText = () => {
    return <div className="w-full h-full">
<       div className="grid justify-center items-center w-full h-full gap-x-1 gap-y-0">
            
            <h1 className="mt-60 mb-0 text-white text-5xl  m-auto font-bold ">GAME OVER</h1>
            <div className="flex m-auto mt-20 mb-0 text-white gap-4">
                <p className="text-green font-bold">Score:</p>
                <p className="">{SCORE.value}</p>
            </div>
            <div className="flex m-auto mt-0 mb-60 text-white gap-4">
                <p className="text-green font-bold">Highscore:</p>
                <p className="">{HIGHSCORE.value}</p>
            </div>
            {/* <h1 className="text-white text-xl font-bold">OVER</h1> */}


            <button onClick={() => Reset()} style={{width: '120px', marginLeft: '80px'}}  className="rounded-full bg-green text-white font-bold">RESTART!</button>
        </div>

    </div> 
}

const restart = () => {
    console.log("here")
    GAME_OVER.value = false;
}