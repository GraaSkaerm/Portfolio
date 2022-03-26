import { useState } from "react"


export const usePosition = (initialX, initialY) => {
    const [x, setX] = useState(initialX)
    const [y, setY] = useState(initialY)


    // {console.log(x)}

    return {x: x, setX: setX, y: y, setY: setY}
}