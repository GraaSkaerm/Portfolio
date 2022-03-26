import { destroy, endGame, gameIntervalId, increseScore, restartMenu, score, scoreEl, updateScore } from "../../game.js";
import { Component } from "../CompositPattern/Component.js";
import { spawnEnemyRoutine } from "../enemySpawner.js";
import { makeParticle } from "../Factories/ParticleFactory.js";


export class Enemy extends Component{

    constructor(circle){
        super("Enemy")
        this.circle = circle
    }

    update(){

       
        if (this.circle.radius < 10){
            this.onDeath()
        }
      
    }

    onCollision(other){
        if (other.getComponent("Bullet") !== null){
            destroy(other)
            this.damage()
        }

        if (other.getComponent("Player")){
            restartMenu.style.display = 'flex'
            endGame()
        }
    }

    damage(){

        if (this.circle.radius > 25){

            gsap.to(this.circle, {
                radius: this.circle.radius - 25,
            })
        }
        else{
            this.onDeath()
        }
        
    }

    onDeath(){
        increseScore(100)
        updateScore()
        this.spawnParitcles()
        destroy(this.parent)
    }

    spawnParitcles(){
        
        for (let index = 0; index < 9; index++) {
            var intsance = makeParticle(this.getX(), this.getY(), this.circle.color)
        }
    }
}