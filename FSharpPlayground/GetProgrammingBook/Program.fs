open System
open System.Windows.Forms

open Car

///
/// Generate Random Number, and with Memoizing ///
///
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

let printGenerateRandomNumber() =
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
    
///
/// Ch8 Capstone, Car
///

let getDestination() =
    Console.Write("Enter destination: ")
    Console.ReadLine()

let mutable petrol = 100

let runCapstoneCar() =
    while true do
        try
            let destination = getDestination()
            printfn "Trying to drive to %s" destination
            petrol <- driveTo(petrol, destination)
            printfn "Made it to %s! You have %d petrol left" destination petrol
        with ex -> printfn "ERROR: %s" ex.Message

[<EntryPoint>]
let main argv =
    // Generate Random Number
    //printGenerateRandomNumber()
    //Console.ReadKey() |> ignore
    //0

    // Ch8
    runCapstoneCar()
    0

    