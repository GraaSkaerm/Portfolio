
// Expected: games, back
function GameGrid(props){
    console.log(props.games);
    return(<>
        <div id= "gitterContainer">
            <div className="gitter"> {props.games.map(x => <Game object = {x} key = {"Grid_" + getRandomString(4)} back = {props.back}/>)} </div>
        </div>
    </>)
}

function getRandomString(length) {
    var randomChars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    var result = '';
    for ( var i = 0; i < length; i++ ) {
        result += randomChars.charAt(Math.floor(Math.random() * randomChars.length));
    }
    return result;
}

// Expected: object: {name, image src, game}
function Game(props){
    console.log(props.object);

    return(<>
        <div className= "SpilDiver">
            <h1 className = "Spil Navn">{props.object.name}</h1>
            <img className = "Spil Billed" src = {props.object.src} alt = "Image Not Found!" onClick={() => props.object.changeGame(props.object.name)}/>
        </div>
    </>)
}

export default GameGrid;