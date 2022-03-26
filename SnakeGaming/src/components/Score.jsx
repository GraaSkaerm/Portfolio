import '../css/color.css'
import { addResetListener } from '../helpers/resetEvent';

export const SCORE = {
    value: 0,

    set setValue(v){
        this.value = v;
    }
}

export const HIGHSCORE = {
    value: 0,

    set setValue(v){
        this.value = v;
    }
}

const onReset = () => {
    SCORE.value = 0;
}


addResetListener(onReset);


const style = {
    gap: `${window.innerWidth/3}px`,
}


export const Score = () => {
    return <div style={{...style}} className='flex justify-center items-center '>
        <div className='flex  justify-center items-center gap-2'>
            <p className="text-green font-bold">Score: </p>
            <p className="text-white">{SCORE.value}</p>
        </div>
        
        <div className='flex justify-center items-center gap-2'>
            <p className="text-green font-bold">Highscore: </p>
            <p className="text-white">{HIGHSCORE.value}</p>
        </div>
       
    </div>
}