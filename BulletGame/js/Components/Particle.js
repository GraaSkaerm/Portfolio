import { destroy } from "../../game.js";
import { context } from "../../gameWindow.js";
import { Component } from "../CompositPattern/Component.js";

export class Particle extends Component{



    constructor(circle){
        super("Particle")
        this.circle = circle
    }

    update(){
        this.circle.alpha -= 0.004

        if(this.circle.alpha <= 0.005){
            destroy(this.parent)
        }
    }



}