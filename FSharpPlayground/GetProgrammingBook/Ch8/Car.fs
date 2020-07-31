module Car

open System

//Helper functions to provide the building blocks to implement driveTo.
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

/// Drives to a given destination given a starting amount of petrol
let driveTo (petrol:int, destination:string) : int =
    let remainingPetrol = calculateRemainingPetrol(petrol, getDistance(destination))
    if destination = "Gas" then remainingPetrol + 50
    else remainingPetrol