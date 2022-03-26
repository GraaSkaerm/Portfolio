import { destroy } from "../../game.js";
import { canvas } from "../../gameWindow.js";
import { Component } from "../CompositPattern/Component.js";

export class Bullet extends Component {

    constructor(velocity){
        super("Bullet")
        this.velocity = velocity
    }

    update(){
        this.setX(this.getX() + this.velocity.x) 
        this.setY(this.getY() + this.velocity.y) 
    }


}