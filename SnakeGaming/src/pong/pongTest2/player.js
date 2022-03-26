import { IntervalInput } from "./intervalInput";

const clamp = (num, min, max) => Math.min(Math.max(num, min), max);

export class Player{
    constructor(x, y, width, height, color, moveSpeed, UpKey, DownKey){
        this.color = color;
        this.moveSpeed = moveSpeed;

        this.rect = {x: x, y: y, w: width, h: height}

        this.board = undefined;

        this.UpKey = UpKey;
        this.DownKey = DownKey;
        
        this.input = new IntervalInput(() => this.moveUp(), () => this.moveDown(), UpKey, DownKey);

        // this.AddMounts = this.AddMounts.bind(this);
        this.Draw = this.Draw.bind(this);
        
        this.moveDown = this.moveDown.bind(this);
        this.moveUp = this.moveUp.bind(this);
    }

    IsPointInRect(x, y){
        if(x > this.rect.x && x < this.rect.x + this.rect.w){
            if(y > this.rect.y && y < this.rect.y + this.rect.h){
                return true;
            }
        }
        return false;
    }

    // GetRect(){
    //     return this.rect;
    // }

    AddMount(){
        // console.log("players addmount called");
        this.input.mountInput();
    }

    ClearMount(){
        this.input.clearInput();
    }

    Update(){}

    Draw(ctx, scale){
        
        // console.log(scale);
        ctx.beginPath();

        ctx.rect(
            this.rect.x * scale,
            this.rect.y * scale,
            this.rect.w * scale,
            this.rect.h * scale
        );

        ctx.fillStyle = this.color;
        ctx.fill();
        // console.log("drawn");
    }

    maxY() 
    { 
        // console.log((this.board.size.y - (this.height)) + "/" + (this.y))
        return this.board.size.y - this.rect.h; 
    }

    moveDown(){
        let newY = clamp(
            this.rect.y + this.moveSpeed,
             0, 
             this.maxY()
            );
        this.rect.y = newY;
        // console.log("DOWN2" + newY);
    }

    moveUp(){
        let newY = clamp(this.rect.y - this.moveSpeed, 0, this.maxY());
        this.rect.y = newY;
    }


}