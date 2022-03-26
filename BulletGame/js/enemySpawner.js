import { canvas, x, y } from "../gameWindow.js";
import { makeEnemy } from "./Factories/EnemyFactory.js";

export var spawnRoutineId = null
export var spawnRoutineId2 = null
var amountToSpawn = 1
var i = 0

export function spawnEnemyRoutine(msBetweenFrames){

    amountToSpawn = 1

    spawnRoutineId = setInterval(() => {

        const radius = getRandomRadius(10, 40)

        let newX = getRandomX(radius)
        // Random vertical canvas value
        let newY = Math.random() * canvas.height

        if (Math.random() < 0.5){
            newX = Math.random() * canvas.width
            newY = getRandomY(radius)
        }


        const angle = Math.atan2(y - newY, x - newX)


        var velocity = {
            x: Math.cos(angle),
            y: Math.sin(angle),
        }


        makeEnemy(newX, newY, velocity, radius); 

    }, msBetweenFrames);
    
    spawnRoutineId2 = setInterval(() => {
        msBetweenFrames -= 50

        if(msBetweenFrames < 250) {
            clearInterval(spawnRoutineId2)
            return;
        }
        clearInterval(spawnRoutineId)
        spawnRoutineId = setInterval(() => {
            const radius = getRandomRadius(10, 40)

            let newX = getRandomX(radius)
            // Random vertical canvas value
            let newY = Math.random() * canvas.height
    
            if (Math.random() < 0.5){
                newX = Math.random() * canvas.width
                newY = getRandomY(radius)
            }
    
    
            const angle = Math.atan2(y - newY, x - newX)
    
    
            var velocity = {
                x: Math.cos(angle),
                y: Math.sin(angle),
            }
    
    
            makeEnemy(newX, newY, velocity, radius); 
        }, msBetweenFrames);
    }, 5000);
}



// Random X between canvas widt.
function getRandomX(radius){
    return Math.random() < 0.5 ? 0 - radius : canvas.width + radius

}

function getRandomY(radius){
    return Math.random() < 0.5 ? 0 - radius : canvas.height + radius
}


function getRandomRadius(min, max){

    return Math.random() * (max - min) + min
}