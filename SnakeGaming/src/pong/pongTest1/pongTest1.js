import React from "react";
import "./pongStyle.css";


export class PongTest1 extends React.Component{
    

    componentDidMount(){
        const canvas = document.getElementById("canvas");
        const ctx = canvas.getContext("2d")
        const img = document.getElementById("image");

        img.onload = () => {
            ctx.drawImage(img,0,0);
            ctx.font = "40px Courier";
            ctx.fillText(this.props.text, 210, 75);
        }

        this.dataURL = canvas.toDataURL()
    }

    render(){
       
        return(<>
            <img id = "image" src = "https://www.valdemarsro.dk/wp-content/2020/06/jordbaer-cheesecake-1.jpg" hidden/>
            <canvas id="canvas" width={640} hidden height={425} />
            <img src={this.dataURL}/>
        
        </>)
    }
}

