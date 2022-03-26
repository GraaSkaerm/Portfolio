

const LISTENERS = [];


export const addResetListener = (listener) => {
    LISTENERS.push(listener);
}

export const Reset = () => {
    LISTENERS.forEach((onReset) => {
        onReset();
    })
}