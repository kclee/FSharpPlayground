module Capstone2.Auditing

open Capstone2.Capstone2Domain

/// Logging

let fileSystemAudit account message =
    failwith ""
   
let consoleAudit account message =
    printfn "%s" (sprintf "Account %O : %s" (account.AccountId) message)