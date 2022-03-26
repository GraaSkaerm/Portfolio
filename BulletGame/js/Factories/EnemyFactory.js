import { instantiate } from "../../game.js";
import { Bullet } from "../Components/Bullet.js";
import { Circle } from "../Components/Circle.js";
import { Enemy } from "../Components/Enemy.js";
import { Composit } from "../CompositPattern/Composit.js";

export function makeEnemy(x, y, velocity, radius){
    var c = new Composit(x, y)
    c.addComponent(new Bullet(velocity))

   
    const color = `hsl(${Math.random() * 360}, 80%, 50%)`
    
    const circle = new Circle(radius, color)
    c.addComponent(circle)
    c.addComponent(new Enemy(circle))
    instantiate(c)
    return c;
}