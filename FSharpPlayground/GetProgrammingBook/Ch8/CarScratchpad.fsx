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