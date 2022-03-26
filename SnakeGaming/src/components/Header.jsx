import '../css/color.css'
import "../css/backbutton.css"

export const Header = props => {
    return <div>
        <div className="flex text-2xl font-bold pt-10 gap-1 justify-center items-center">
            <h1 className="text-green overline">Snake</h1>
            <h1 className="text-white underline">gameing!</h1>
        </div>
        <i id = "exitS" className="arrow left" onClick={() => props.back()}/>
    </div>
}