open System

/// Gets the distance to a given destination 
let getDistance(destination) =
    if destination = "Home" then 25
    elif destination = "Office" then 50
    elif destination = "Stadium" then 25
    elif destination = "Gas" then 10
    else failwith "Unknown destination!"

let calculateRemainingPetrol(currentPetrol:int, distance:int) : int =
    let remaining = currentPetrol - distance
    if remaining >= 0 then remaining
    else failwith "Oops! Run out of petrol."

let driveTo (petrol:int, destination:string) : int =
    let remainingPetrol = calculateRemainingPetrol(petrol, getDistance(destination))
    if destination = "Gas" then remainingPetrol + 50
    else remainingPetrol


// Couple of quick tests
getDistance("Home") = 25
getDistance("Stadium") = 25

//
calculateRemainingPetrol(10, 10) = 0
calculateRemainingPetrol(20, 10) = 10
calculateRemainingPetrol(10, 20) = 10 // exception

//
let distanceToGas = getDistance("Gas")
calculateRemainingPetrol(25, distanceToGas) = 15 // should return 15
calculateRemainingPetrol(5, distanceToGas) // should throw

//
let a = driveTo(100, "Office")
let b = driveTo(a, "Stadium")
let c = driveTo(b, "Gas")
let answer = driveTo(c, "Home")

//
//
//let drive(petrol, distance) =
//    if distance = "far" then petrol / 2.0
//    elif distance = "medium" then petrol - 10.0
//    else petrol - 1.0

//let petrol = 100.0
//let firstState = drive(petrol, "far")
//let secondState = drive(firstState, "medium")
//let finalState = drive(secondState, "short")

let drive distance petrol = 
    if distance = "far" then petrol / 2.0
    elif distance = "medium" then petrol - 10.0
    else petrol - 1.0

let startingPetrol = 100.0

let xx = drive "far" startingPetrol |> drive "medium" |> drive "short"
let xxx = startingPetrol |> drive "far" |> drive "medium" |> drive "short"

