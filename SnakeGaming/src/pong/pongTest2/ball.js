import React from "react";

class Ball{
    constructor(x, y, radius, color){
        this.color = color;
        this.board = undefined;

        this.velocity = {x: 3, y: -3};
        this.rect = {x: x, y: y, r: radius}

    }

    GetRect(){
        return this.rect;
    }

    Draw(ctx, scale){
        ctx.beginPath();
        ctx.arc(
            this.rect.x * scale,
            this.rect.y * scale,
            this.rect.r * scale,
            Math.PI * 2,
            false
        );
        ctx.fillStyle = this.color;
        ctx.fill();
    }

    EnvironmentBounce(){
        
        if(this.rect.y + this.rect.r > this.board.size.y){
            this.velocity.y = 0 - this.velocity.y;
        }

        if(this.rect.y - this.rect.r < 0){
            this.velocity.y = 0 - this.velocity.y;
        }

    }

    PaddleBounce(){

        // Get paddles
        let paddles = this.board.objects.filter(x => x !== this);
        
        // Get colliders
        // let colliders = paddles.map(x => x.GetRect());
        // console.log(colliders[0]);
        
        
        paddles.forEach(element => {
            //Check left.
            if(element.IsPointInRect(this.rect.x - this.rect.r,this.rect.y)){
                if(this.velocity.x < 0){
                    this.velocity.x = 0 - this.velocity.x;
                }
            }

            //Check right.
            if(element.IsPointInRect(this.rect.x + this.rect.r,this.rect.y)){
                if(this.velocity.x > 0){
                    this.velocity.x = 0 - this.velocity.x;
                }
                return;
            }
        });
    }

    CheckOutOfBounds(){
        if(this.rect.x - this.rect.r < 0){
            this.board.leftPoint(this);
        }
        if(this.rect.x + this.rect.r > this.board.size.x){
            this.board.rightPoint(this);
        }
    }

    Update(){
        this.rect.x = this.rect.x + this.velocity.x;
        this.rect.y = this.rect.y + this.velocity.y;

        this.EnvironmentBounce();
        this.PaddleBounce();
        this.CheckOutOfBounds();
    }
}

export default Ball;