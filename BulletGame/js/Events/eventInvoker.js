import { onClickEvent } from "./eventHandler.js"

// export function onClick(){
//     console.log("Hegne")

//     onClickEvent.forEach(c => {
//         c.onClick()
//     });

// }

addEventListener('click', (event) => {
    onClickEvent.forEach(c => {
        c.onClick(event)
    });
})