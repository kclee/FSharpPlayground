namespace Capstone2.Capstone2Domain

type Customer = 
    { Name : string }

type Account = 
    { Balance : decimal
      AccountId : System.Guid
      Owner: Customer }