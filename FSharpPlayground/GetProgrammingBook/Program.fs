module main.main

open System
open System.Windows.Forms

open Ch8.Car
open Misc.ActivePatterns

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

let mutable petrol = 100

let getDestination() =
    Console.Write("Enter destination: ")
    Console.ReadLine()

let runCapstoneCar() =
    while true do
        try
            let destination = getDestination()
            printfn "Trying to drive to %s" destination
            petrol <- driveTo(petrol, destination)
            printfn "Made it to %s! You have %d petrol left" destination petrol
        with ex -> printfn "ERROR: %s" ex.Message

///
/// Ch15 // run in F# interactive
///

type FootballResult =
    { HomeTeam : string
      AwayTeam : string
      HomeGoals : int
      AwayGoals : int }
let create (ht, hg) (at, ag) =
    { HomeTeam = ht; AwayTeam = at; HomeGoals = hg; AwayGoals = ag }
let results =
    [ create ("Messiville", 1) ("Ronaldo City", 2)
      create ("Messiville", 1) ("Bale Town", 3)
      create ("Bale Town", 3) ("Ronaldo City", 1)
      create ("Bale Town", 2) ("Messiville", 1)
      create ("Ronaldo City", 4) ("Messiville", 2)
      create ("Ronaldo City", 1) ("Bale Town", 2) ]

let teamsWonMostAwayGames = 
    results 
    |> List.where (fun x -> (x.HomeGoals < x.AwayGoals)) |> Seq.map (fun x -> x.AwayTeam)  // teams won away game    
    |> Seq.groupBy (fun team -> team) |> Seq.map (fun x -> fst x, (snd x) |> Seq.length)   // group by team name, so the sum of each group is the win count of each team. (team, #AwayWon).
    |> Seq.sortByDescending (fun (_, wins) -> wins)

let isAwayWin result = result.AwayGoals > result.HomeGoals
let teamsWonMostAwayGamesV2 = 
    results
    |> List.filter isAwayWin
    |> List.countBy (fun result -> result.AwayTeam)
    |> List.sortByDescending (fun (_, awayWins) -> awayWins)

///
/// Ch18 (fold)// run in F# interactive
///

let foldSum inputs =
    Seq.fold
        (fun state input -> 
            let newState = state + input
            printfn "%d %d %d" state input newState
            newState)
        0
        inputs

type Rule = string -> bool * string
let rules : Rule list =
    [ fun text -> (text.Split ' ').Length = 3, "Must be three words"
      fun text -> text.Length <= 30, "Max length is 30 characters"
      fun text -> text
                  |> Seq.filter Char.IsLetter
                  |> Seq.forall Char.IsUpper, "All letters must be caps" ]
let buildValidator (rules : Rule list) =
    rules
    |> List.reduce(fun firstRule secondRule ->
        fun word ->
            let passed, error = firstRule word
            if passed then
                let passed, error = secondRule word
                if passed then true, "" else false, error
            else false, error)  

            


///
type Disk =                               
| HardDisk of RPM:int * Platters:int      
| SolidState                              
| MMC of NumberOfPins:int                 

let myHardDisk = HardDisk(RPM = 250, Platters = 7)       
let myHardDiskShort = HardDisk(250, 7)                   
let args = 250, 7
let myHardDiskTupled = HardDisk args                     
let myMMC = MMC 5
let mySsd = SolidState                                   

[<EntryPoint>]
let main argv =
    // Generate Random Number
    //printGenerateRandomNumber()
    //Console.ReadKey() |> ignore
    //0

    // Ch8
    //runCapstoneCar()
    
    runActivePatternsExample
    

    0

    