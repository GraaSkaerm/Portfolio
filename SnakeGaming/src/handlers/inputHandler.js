const _currentKeyState = {}

const _pressed = {}
const _released = {}

export var lastPressedKey = null;

window.addEventListener('keydown', (event) =>{
    _currentKeyState[event.key] = true;
    _released[event.key] = false;
    lastPressedKey = event.key;
}, true)

window.addEventListener('keyup', (event) =>{
    _currentKeyState[event.key] = false;

    if (_pressed[event.key] !== undefined){
        _pressed[event.key] = false;
    }

    if (_released[event.key] !== undefined){
        _released[event.key] = true;
    }

    
}, true)



export function getKey(key){
    return _currentKeyState[key];
}



export function getKeyDown(key){

    if (_currentKeyState[key] === false || _currentKeyState[key] === undefined){
        return false;
    }

    if(_pressed[key] === false || _pressed[key] === undefined){
        _pressed[key] = true;
        return true;
    }
   
    return false;
}


export function getKeyUp(key){

    if (_currentKeyState[key] === true || _currentKeyState[key] === undefined){
        return false;
    }

    if (_released[key]){
        _released[key] = false;
        return true;
    }

    return false;
}


