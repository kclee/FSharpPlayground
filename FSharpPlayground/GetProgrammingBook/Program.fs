// Learn more about F# at http://fsharp.org

open System

// M1 T1
let deg2rad (deg : float) = deg * Math.PI /  180.0
let rad2deg (rad : float) = rad * 180.0 / Math.PI

let testa = deg2rad 67.0
let testb = rad2deg 67.0

// M1 T2
let hexarea t : float = (3.0 * Math.Sqrt(3.0) / 2.0) * Math.Pow(t,2.0)


[<EntryPoint>]
let main argv =
    
    // M1 T2
    //printfn "%A" argv    
    //let value = Console.ReadLine()
    //let f = float value
    //let calc = hexarea f
    //printf "%f" calc
    //printfn "%f" testa

    let pause = Console.ReadLine()
    0
