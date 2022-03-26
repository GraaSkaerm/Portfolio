import React, { useEffect, useState } from "react";
import PongGame from "../pong/pongTest2/pongApp";
import GameGrid from "./oldGrid";
import Header from "./Search";
import "./MainScreenStyle.css";
import { SnakeGame } from "../components/SnakeGame";



function BrowserApp(){
    
    const [site, setSite] = useState("home");

    function changeSite(name){
        var item = null; 

        item = games.find(x => x.name.toLowerCase() === name.toLowerCase());

        if(item !== null){
            setSite(x => x = item.name);
        }
    }

    function backToMain(){
        setSite(x => x = "home");   
    }

    const games = 
    [
        {
            name: "PONG", 
            src: "https://www.imaginarycloud.com/blog/content/images/2019/02/Pong.jpg",
            getSite: x => {return <PongGame back = {() => backToMain()}/>},
            changeGame: changeSite
        },
        {
            name: "Snake", 
            src: "https://maksimivanov.com/static/3915d0d233a14576cf653183dbc2aff4/0f696/snake-final.png",
            getSite: x => {return <SnakeGame back = {() => backToMain()}/>},
            changeGame: changeSite 
        }
    ]

    const mainSite = (<>
        <Header/>
        <GameGrid games = {games}/>
    </>)

    function SiteToRender(){
        if(site === "home"){
            return mainSite;
        }
        else{
            var item = null; 

            item = games.find(x => x.name.toLowerCase() === site.toLowerCase());

            return item.getSite(item.back);
        }
    }

    return (<>

        {SiteToRender()}
        {/* <PongGame back = {() => backToMain()}/> */}
    </>);
}

function getRandomString(length) {
    var randomChars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    var result = '';
    for ( var i = 0; i < length; i++ ) {
        result += randomChars.charAt(Math.floor(Math.random() * randomChars.length));
    }
    return result;
}

export default BrowserApp; 
