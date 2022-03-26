import React from "react";
import Ball from "./ball";

const clamp = (num, min, max) => Math.min(Math.max(num, min), max);

class Board{
    constructor(addPointLeft, addPointRight){
        this.size = {
            x: 800,
            y: 450
        };
        this.objects = [];
        this.addPointLeft = addPointLeft;
        this.addPointRight = addPointRight;
    }

    leftPoint(ball){
        this.addPointLeft();
        this.ResetBall(-1, ball);
    }

    rightPoint(ball){
        this.addPointRight();
        this.ResetBall(1, ball);
    }

    ResetBall(startX, ball){
        ball.rect.x = this.size.x / 2;
        ball.rect.y = this.size.y / 2;
        ball.velocity.x = ball.velocity.x * startX;
    }

    scaleFactorOfBoardToCanvas(element){
        // console.log("element "+ element.width);
        let toReturn = element.width / this.size.x 
        // console.log(toReturn)
        return toReturn;
    }

    Add(object){
        this.objects.push(object);
        object.board = this;
    }

    Update(){
        this.objects.forEach(element => element.Update?.());
    }

    Draw(context, element){
        let scale = this.scaleFactorOfBoardToCanvas(element);
        // console.log("draw in board");
        this.objects.forEach(element => {
            
            element.Draw?.(context, scale)}
        
        );
    }

    AddMounts(){
        // console.log("Addmount called");
        this.objects.forEach(element => element.AddMount?.());
    }

    ClearMounts(){
        this.objects.forEach(element => element.ClearMount?.());
    }
}

export default Board;