import { Component } from "../CompositPattern/Component.js";
import { Vector2 } from "../DataTypes/Vector2.js";

export class Transform extends Component{

    constructor(x, y){
        super("Transform")
        this.position = new Vector2(x, y)
    }

}