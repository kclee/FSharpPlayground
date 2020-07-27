// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open System
    
let generateStamp =
    let mutable count = 0
    count <- count + 1
    count

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    let pause = Console.ReadLine()
    0 // return an integer exit code
