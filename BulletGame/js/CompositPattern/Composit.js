import { Transform } from "../Components/Transform.js"

export class Composit{

    constructor(x, y){
        this.components = []
        this.transform = new Transform(x, y)
        this.addComponent(this.transform)
    }

    addComponent(c){
        this.components.push(c)
        c.parent = this
 
    }

    getComponent(type){

        var temp = null
        this.components.forEach(c => {
            if (c.type === type){
                temp = c
            }
        });


        return temp
    }


    onCollision(other){
        this.components.forEach(c => {
            c.onCollision(other);
        });
    }

    update(){
        this.components.forEach(c => {
            c.update();
        });
    }

    draw(){
        this.components.forEach(c => {
            c.draw();
        });
    }

}