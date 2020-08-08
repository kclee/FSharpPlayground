module Capstone2.Operations

open Capstone2.Capstone2Domain
open Capstone2.Auditing

/// Opreations

let exampleAccount = 
    { Balance = 0m
      AccountId = System.Guid.Empty
      Owner = { Name = "A" }}

let deposit (amount:decimal) (account:Account) : Account =
    { AccountId = account.AccountId; 
      Balance = account.Balance + amount
      Owner = account.Owner }
     // { account with Balance = account.Balance - amount }

let withdraw (amount:decimal) (account:Account) : Account =
    if account.Balance - amount >= 0m then
        { AccountId = account.AccountId; 
          Balance = account.Balance - amount
          Owner = account.Owner }
        // { account with Balance = account.Balance + amount }
    else
        account

// Run and check this value
let testOperationResult = 
    exampleAccount
    |> withdraw 10m  // 0
    |> deposit 10m   // 10
    |> deposit 90m   // 100
    |> withdraw 50m  // 50
    |> withdraw 60m  // 50

//let auditAs (operationName:string) (audit:Account -> string -> unit) (operation:decimal -> Account -> Account) (amount:decimal) (account:Account) : Account =
let auditAs operationName audit operation amount account : Account =    
    audit account (sprintf "Performing %s %M for balance=%M" operationName amount account.Balance)
    
    let updatedAccount = operation amount account
    if updatedAccount.Balance <> account.Balance
    then 
        audit account (sprintf "Transaction accepted. Balance=%M" updatedAccount.Balance)
    else
        audit account (sprintf "Transaction rejected! Balance=%M" updatedAccount.Balance)
    updatedAccount
    
let withdrawWithConsoleAudit = auditAs "withdraw" consoleAudit withdraw
let depositWithConsoleAudit = auditAs "deposit" consoleAudit deposit

// Run and check this value
let testOperationAuditResult = 
    exampleAccount
    |> depositWithConsoleAudit 100M  // Accept. Balance=100
    |> withdrawWithConsoleAudit 150M // Reject. Balance=100
    |> withdrawWithConsoleAudit 50M  // Accept. Balance=50
    |> withdrawWithConsoleAudit 50M  // Accept. Balance=0
    |> withdrawWithConsoleAudit 50M  // Reject. Balance=0