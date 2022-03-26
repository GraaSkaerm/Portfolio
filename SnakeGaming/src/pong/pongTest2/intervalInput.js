import React from "react";

function removeItemOnce(arr, value) {
    
    arr = arr.filter(item => item !== value);

    return arr;
}

export class IntervalInput{
    constructor(moveUp, moveDown, keyUp, keyDown){
        this.moveDownInterval = null;
        this.moveUpInterval = null;

        this.DownKey = keyDown;
        this.UpKey = keyUp;

        this.moveUp = moveUp;
        this.moveDown = moveDown;
        
        this.handleKeyPress = this.handleKeyPress.bind(this);
        this.handleKeyLift = this.handleKeyLift.bind(this);

        this.startMoveDown = this.startMoveDown.bind(this);
        this.stopMoveDown = this.stopMoveDown.bind(this);
        this.startMoveUp = this.startMoveUp.bind(this);
        this.stopMoveUp = this.stopMoveUp.bind(this);
    }

    mountInput(){
        window.addEventListener("keydown", this.handleKeyPress, true);
        window.addEventListener("keyup",this.handleKeyLift, true);
        console.log("event listeners mounted");
    }

    clearInput(){
        window.removeEventListener("keydown", this.handleKeyPress, true);
        window.removeEventListener("keyup",this.handleKeyLift, true);
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

    startMoveDown(){
        if(this.moveDownInterval === null){
            
            this.moveDownInterval = setInterval(() => {
                this.moveDown();
            }, 20)
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
                this.moveUp();
            }, 20)
        }
    }
    stopMoveUp(){
        if(this.moveUpInterval !== null){
            clearInterval(this.moveUpInterval);
            this.moveUpInterval = null;
        }
    }
}