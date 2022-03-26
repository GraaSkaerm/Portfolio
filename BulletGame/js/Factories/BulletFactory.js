import { Bullet } from "../Components/Bullet.js"
import { Circle } from "../Components/Circle.js"
import { Composit } from "../CompositPattern/Composit.js"

 export function makeBullet(x, y, velocity, color){
    var bullet = new Composit(x, y)
    bullet.addComponent(new Circle(5, color))
    bullet.addComponent(new Bullet(velocity))
    return bullet
}