export class Component{

    

    constructor(type){
        this.type = type
        this.parent
    }


    getType(){
        return this.type;
    }


    setX(value){
        this.parent.transform.position.x = value;
    }
    getX(){
        return this.parent.transform.position.x
    }

    setY(value){
        this.parent.transform.position.y = value
    }
    getY(){
        return this.parent.transform.position.y
    }

    onCollision(other){}
    update(){}
    draw(){}
}