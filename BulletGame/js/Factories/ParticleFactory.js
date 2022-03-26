import { instantiate } from "../../game.js";
import { Bullet } from "../Components/Bullet.js";
import { Circle } from "../Components/Circle.js";
import { Particle } from "../Components/Particle.js";
import { Composit } from "../CompositPattern/Composit.js";
import { Vector2 } from "../DataTypes/Vector2.js";


export function makeParticle(x, y, color){

    var instance = new Composit(x,y)
    var radius = getRandomeNumber(3, 5)

    var newX = Math.random() -0.5
    var newY = Math.random() -0.5

    var circle = new Circle(radius, color)

    instance.addComponent(circle)

    var speed = getRandomeNumber(2, 5)


    instance.addComponent(new Bullet({x: newX * speed, y: newY * speed,}))

    instance.addComponent(new Particle(circle))


    instantiate(instance)
    return instance
}

function getRandomeNumber(min, max){

    return Math.random() * (max - min) + min
}