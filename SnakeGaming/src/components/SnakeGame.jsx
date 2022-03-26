import '../css/color.css'
import React from "react"
import { Header } from "./Header"
import { GameBorder } from "./GameBorder"
import { useGrid } from "../hooks/useGrid"
import { useSnake } from "../hooks/useSnake"
import { useApple } from "../hooks/useApple"
import { Score } from './Score'


export const SnakeGame = props => {

    
    const {grid} = useGrid();
    const {snake} = useSnake(0,0);
    const {apple} = useApple({snake});

    return <div className="w-screen h-screen bg-dark-blue">
        <Header back = {() => props.back()}></Header>
        <GameBorder grid={grid} snake={snake} apple={apple}></GameBorder>
        <Score></Score>
    </div>


}


