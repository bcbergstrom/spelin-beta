export default function Header({bingus, setBingus} : {bingus: number, setBingus: any}) {
    return (
        <header>
            <h1 onClick={() => setBingus(bingus + 1)}>{bingus}</h1>
        </header>
    )
}   