
open System

// Curried Parameter
let add a b = 
    a + b
let addFive =
    add 5
// addFive は add 5と置き変えることができるので、結果add 5 10 となって結果は15になる。
// [<EntryPoint>]
// let main argv = 
//     addFive 10 |> printfn "%d"
//     0

let quote symbol s = 
    sprintf "%c%s%c" symbol s symbol

let singleQuote = quote '\'' 
let doubleQuote = quote '"' 

[<EntryPoint>]
let main argv = 
    printfn "%s" (singleQuote "It was ths best of times, it was the worst of times.")
    printfn "%s" (doubleQuote "It was ths best of times, it was the worst of times.")
    0