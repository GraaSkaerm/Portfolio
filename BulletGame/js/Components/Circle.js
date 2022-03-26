import { destroy } from "../../game.js";
import { canvas, context } from "../../gameWindow.js";
import { Component } from "../CompositPattern/Component.js"

export class Circle extends Component {

    constructor(radius, color){
        super("Circle")
        this.radius = radius
        this.color = color
        this.alpha = 1
    }

    update(){ 
        if(this.getX() < 0 - this.radius || this.getX() > canvas.width + this.radius){
            destroy(this.parent)
            return
        }
        
        if(this.getY() < 0 - this.radius || this.getY() > canvas.height + this.radius){
            destroy(this.parent)
            return
        }
    }

    draw(){
        context.save()
        context.globalAlpha = this.alpha
        var x = this.getX()
        var y = this.getY() 

        context.beginPath();

        context.arc(x, y, this.radius, 0, Math.PI * 2, false);
        context.fillStyle = this.color;
        context.fill();
        context.restore();

    }
}   