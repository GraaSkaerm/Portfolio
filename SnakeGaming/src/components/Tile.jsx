import '../css/tile.css'
import '../css/height.css'

export const Tile = ({state}) =>{


    return <div className="flex h-25 justify-center items-center w-full">

        <div title={`${state.type}`} id={`row: ${state.row} col: ${state.col}`} className={`${state.type} m-auto`}></div>


    </div>
}