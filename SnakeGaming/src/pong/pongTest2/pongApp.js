import React, { useEffect, useState } from "react";
import Ball from "./ball";
import Board from "./board";
import { Player } from "./player";
import "./stylesheet.css";

const clamp = (num, min, max) => Math.min(Math.max(num, min), max);

class PongGame extends React.Component{

    constructor(props){
        super(props)
        this.state = 
        {
            canvasSize: 
            {
                x: this.getWidth(), 
                y: this.getHeight()
            },
            windowOffset: this.getOffset(),
            updateIntervalID: null,
            points: {left: 0, right: 0}
        }
        this.ExitFunction = () => props.back();
        this.board = new Board(() => this.leftPoint(),() => this.rightPoint());

        this.canvasElement = null;

        this.Update = this.Update.bind(this);
        this.Draw = this.Draw.bind(this);

        this.getOffset = this.getOffset.bind(this);
        this.updateCanvas = this.updateCanvas.bind(this);
        this.leftPoint = this.leftPoint.bind(this);
        this.rightPoint = this.rightPoint.bind(this);


    }

    leftPoint(){
        this.setState((prevState) => {
            return {
                points: { 
                    left: prevState.points.left + 1,
                    right: prevState.points.right
                }
            }
        });
    }

    rightPoint(){
        this.setState((prevState) => {
            return {
                points: { 
                    left: prevState.points.left,
                    right: prevState.points.right + 1
                }
            }
        });
    }

    updateCanvas(){
        this.setState(() => {
            return{
                canvasSize: 
                {
                    x: this.getWidth(), 
                    y: this.getHeight()
                },
                windowOffset: this.getOffset()
            }
        })
    }

    getHeight(){
        return window.innerHeight * 0.75;
    }
    getWidth(){
        return ((window.innerHeight * 0.75) / 9) * 16;
    }
    getOffset(){
        return (window.innerWidth - this.getWidth()) / 2;
    }

    Update(){
        this.board.Update();
        // console.log("updated");
        this.Draw();
        // console.log("drawn");
    }


    Draw(){
        this.canvasElement = document.getElementById("canvas");
        const c = this.canvasElement.getContext("2d");
        c.clearRect(0, 0, this.canvasElement.width, this.canvasElement.height);
        
        this.board.Draw(c, this.canvasElement);
    }

    // Called after thing updates. basically conditional late update.
    componentDidUpdate(){}

    // Start/Event setup
    componentDidMount(){
        window.addEventListener('resize', this.updateCanvas);
        window.addEventListener("keydown", event => {if(event.key === "Escape"){this.stopUpdate();}})
        
        this.canvasElement = document.getElementById("canvas");
        
        this.board.Add(new Player(10, 100, 10, 75, "#9CDCDB", 5, "w", "s"));
        this.board.Add(new Player(780, 100, 10, 75, "#9CDCDB", 5, "ArrowUp", "ArrowDown"));

        this.board.Add(new Ball(400,225,10,"white"));
        
        console.log(this.board);
        this.board.AddMounts();




        if(this.state.updateIntervalID === null){
            this.setState(() => {
                // console.log("???????");
                return {updateIntervalID: setInterval(() => this.Update(), 20)};
            });
        }
        
    }

    stopUpdate(){
        clearInterval(this.state.updateIntervalID);
        this.setState(() => {return {updateIntervalID: null}});
    }

    // Event unmount/OnDestroy ish
    componentWillUnmount(){
        this.board.ClearMounts();
        this.stopUpdate();
        // console.log("!!!!")
    }


    // Draw function.
    render() {
        const ExitButton = (<>
            <i id = "exit" className="arrow left" onClick={() => this.ExitFunction()}/>
        </>)

        const pointsDisplay = (
            <div id = "points">
                <h1 id = "leftP">{this.state.points.left}</h1>
                <h1 if = "rightP">{this.state.points.right}</h1>
            </div>
        )

        const canvas = (<canvas 
            id = "canvas" 
            width={this.state.canvasSize.x} 
            height={this.state.canvasSize.y} 
            style= 
            {{
                left: this.state.windowOffset
            }}>
        </canvas>);
     
        return (<>
            <h1 id = "title">Pong!</h1>
            {pointsDisplay}
            {canvas}
            {ExitButton}
        </>)
    }
}

export default PongGame;