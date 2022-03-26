import { instantiate } from "../../game.js";
import { Component } from "../CompositPattern/Component.js";
import { addOnClick } from "../Events/eventHandler.js";
import { makeBullet } from "../Factories/BulletFactory.js";


export class Player extends Component{

    constructor(){
        super("Player")
        addOnClick(this)
    }

    onClick(event){
        const angle = Math.atan2(event.clientY - this.getY() , event.clientX - this.getX())

        const velocity = {
            x: Math.cos(angle) * 4,
            y: Math.sin(angle) * 4,
        }    

        var bullet = makeBullet(this.getX(), this.getY(), velocity, 'white')
        instantiate(bullet)
    }


}