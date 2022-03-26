import { useState } from "react"

export const useWindow = () => {
    const [width, setWidth] = useState(window.innerWidth);
    const [height, setHeight] = useState(window.innerWidth);

    

    const onResize = () => {
        setWidth(window.innerWidth);
        setHeight(window.innerHeight);
    }

    window.addEventListener('resize', onResize);

    return {window: {width, height}}
}