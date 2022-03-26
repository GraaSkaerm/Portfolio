import { canvas, context, x, y } from "./gameWindow.js";
import { Circle } from "./js/Components/Circle.js";
import { Player } from "./js/Components/Player.js";
import { Composit } from "./js/CompositPattern/Composit.js";
import { spawnEnemyRoutine, spawnRoutineId, spawnRoutineId2 } from "./js/enemySpawner.js";
import { makeEnemy } from "./js/Factories/EnemyFactory.js";

export var gameIntervalId = null
export let scoreEl = document.getElementById("score")
export let startBtn = document.getElementById("startGameBtn")
export let restartMenu = document.getElementById("restartMenu")
export let highscoreText = document.getElementById("highscoreText")
export let score = 0

export function increseScore(value){
    score += value
}

export function updateScore(){
    scoreEl.innerText = score
}
export function endGame(){

    clearInterval(gameIntervalId)
    clearInterval(spawnRoutineId)
    clearInterval(spawnRoutineId2)

    highscoreText.innerText = score
}

var compositsToDestroy = []
var composits = []
export const msBetweenFrames = 1

export function run(){
    score = 0
    composits = []
    compositsToDestroy = []
    makePlayer()

    spawnEnemyRoutine(1000)
    
    restartMenu.style.display = 'none'
    gameIntervalId = setInterval(() => {
        clear()
        checkCollision()
        composits.forEach(c => {
            
            
            try{
                c.update()
                c.draw()
            }
            catch{
                
            }
            
        });
        
        
        onDestroy()
    }, msBetweenFrames);


}

function makePlayer(){
    
    var player = new Composit(x, y);
    player.addComponent(new Circle(20, 'white'))
    player.addComponent(new Player())
    instantiate(player)
}

function checkCollision(){


    composits.forEach(current => {
        composits.forEach(other => {

            if (current !== other){

                const a = current.transform.position
                const b = other.transform.position
                const dist = getDistance(a, b)


                if((dist - getRadius(other) - getRadius(current)) < 1){
                    current.onCollision(other)
                }
              
               
            }
        });
    });
}


// var arr = [1,2,3,4,5]

// console.log(hegne())

// hegne()
// function hegne(){

//     arr.forEach(c => {
//         console.log(c);
//         return c;
//     });

// }

function getRadius(composit){
    return composit.getComponent("Circle").radius
}
function getDistance(vecA, vecB){
    return Math.hypot(vecA.x - vecB.x, vecA.y - vecB.y)
}

export function instantiate(composit){
    composits.push(composit)
    return composit
}

function onDestroy(){

    compositsToDestroy.forEach(c =>{

        composits = composits.filter(item => item !== c)

    })
}

export function destroy(composit){


    compositsToDestroy.push(composit)
}

function clear(){
    context.fillStyle = 'rgba(0,0,0, 0.1)'
    context.fillRect(0,0, canvas.width, canvas.height)
    // might have solution to fade problem
    // http://rectangleworld.com/blog/archives/871 
}


startBtn.addEventListener('click', (event) => {
    run()
})
