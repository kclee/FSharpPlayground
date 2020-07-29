open System
open System.Windows.Forms

let generateRandomNumber max =
    let r = System.Random()
    let getRnd m =
        let nextValue = r.Next(1, m)
        nextValue
    getRnd max    

let generateRandomNumberCached =
    let r = System.Random()
    let getRndCached max =
        let nextValue = r.Next(1, max)
        nextValue    
    fun m -> getRndCached m

printfn "No Memoizing"
printfn "%d" (generateRandomNumber 10)
printfn "%d" (generateRandomNumber 9)
printfn "%d" (generateRandomNumber 10)
printfn "%d" (generateRandomNumber 9)
printfn "%d" (generateRandomNumber 10)
printfn "Memoizing"
printfn "%d" (generateRandomNumberCached 10)
printfn "%d" (generateRandomNumberCached 9)
printfn "%d" (generateRandomNumberCached 10)
printfn "%d" (generateRandomNumberCached 9)
printfn "%d" (generateRandomNumberCached 10)


//[<EntryPoint>]
//let main argv = 
//    printfn "%d" (generateRandomNumber 10)
//    printfn "%d" (generateRandomNumber 9)
//    printfn "%d" (generateRandomNumber 10)
//    printfn "%d" (generateRandomNumber 9)
//    printfn "%d" (generateRandomNumber 10)
    
Console.ReadKey() |> ignore
//    0