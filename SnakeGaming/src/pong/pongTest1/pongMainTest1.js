import React from "react";
import "./pongStyle.css";

class PongApp extends React.Component{
    constructor(props){
        super(props)
        this.state = {
            score: {player1: 0, player2: 0},

            
        }

    }




    render(){
        return (<>
            <div id = "pongTitle">
                <h1 >PONG: {this.state.paddle1}</h1>
            </div>
            <div id="pongBackGround" >
            <Paddle 
                x = {0} 
                UpKey = "w"
                DownKey = "s"
                className = "paddle"
                />
            <Paddle 
                x = {1240} 
                UpKey = "ArrowUp"
                DownKey = "ArrowDown"
                className = "paddle"
            />
                
            </div>
        
        </>)
    }
}

export default PongApp;

class Paddle extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            x: props.x,
            y: (window.innerHeight / 2)
        }

        this.UpKey = props.UpKey;
        this.DownKey = props.DownKey;

        this.speed = 5;

        this.moveDownInterval = null;
        this.moveUpInterval = null;
        
        
        this.handleKeyPress = this.handleKeyPress.bind(this);
        this.handleKeyLift = this.handleKeyLift.bind(this);

        this.startMoveDown = this.startMoveDown.bind(this);
        this.stopMoveDown = this.stopMoveDown.bind(this);
        this.startMoveUp = this.startMoveUp.bind(this);
        this.stopMoveUp = this.stopMoveUp.bind(this);
        
    }

    startMoveDown(){
        if(this.moveDownInterval === null){
            this.moveDownInterval = setInterval(() => {
                this.setState((prevState) => 
                {
                    if(this.moveUpInterval !== null){ return; }
                    let newY = clamp(prevState.y + this.speed, 0, 620);
                    return {y: newY}
                });
            }, 10)
        }
    }
    stopMoveDown(){
        if(this.moveDownInterval !== null){
            clearInterval(this.moveDownInterval);
            this.moveDownInterval = null;
        }
    }

    startMoveUp(){
        if(this.moveUpInterval === null){
            this.moveUpInterval = setInterval(() => {
                this.setState((prevState) => 
                {
                    if(this.moveDownInterval !== null){ return; }
                    let newY = clamp(prevState.y - this.speed, 0, 620);
                    return {y: newY}
                });
            }, 10)
        }
    }
    stopMoveUp(){
        if(this.moveUpInterval !== null){
            clearInterval(this.moveUpInterval);
            this.moveUpInterval = null;
        }
    }

    componentDidMount(){
        // window.addEventListener("keyDown", this.handleKeyPress)     
        window.addEventListener("keydown", this.handleKeyPress, true);
        window.addEventListener("keyup",this.handleKeyLift, true);
    }

    handleKeyLift(event){
        if (event.defaultPrevented) {
            return; // Do nothing if the event was already processed
            }
        
            switch (event.key) {
            case this.DownKey:
                this.stopMoveDown();                
                break;
            case this.UpKey:
                this.stopMoveUp();
                break;
            default:
                return; // Quit when this doesn't handle the key event.
            }
        
            // Cancel the default action to avoid it being handled twice
            event.preventDefault();
    }

    handleKeyPress(event){
        if (event.defaultPrevented) {
        return; // Do nothing if the event was already processed
        }
    
        switch (event.key) {
        case this.DownKey:
            this.startMoveDown();            
            break;
        case this.UpKey:
            this.startMoveUp();
            break;
        default:
            return; // Quit when this doesn't handle the key event.
        }
    
        // Cancel the default action to avoid it being handled twice
        event.preventDefault();
    }

    render(){
        return (<div className={this.props.className}>
            <Sprite 
                x = {this.state.x}
                y = {this.state.y}
                className = "paddleSprite"
            />
        </div>
        );
    }
}

function Sprite(props){
    let left = props.x;
    let top = props.y;

    return (
        <>  
            <div className = {props.className} style={{left, top}}/>
        </>
    );
}

const clamp = (num, min, max) => Math.min(Math.max(num, min), max);