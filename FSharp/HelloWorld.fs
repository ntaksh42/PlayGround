
open System.IO

let printMeamScore (row:string) =
    let elements =  row.Split('\t')
    let name = elements.[0]
    let id = elements.[1]
    let scores = 
        elements
        |> Array.skip 2
        |> Array.map float
    let meanScore = scores |> Array.averageBy float
    let minScore = scores |> Array.min
    let maxScore = scores |> Array.max
    printfn "%s,%s,mean:%0.1f, min:%0.1f, max:%0.1f" name id meanScore minScore maxScore

let showSummry (filePath : string) =
    filePath 
    |> File.ReadAllLines
    |> Array.skip 1
    |> Array.iter printMeamScore
    
[<EntryPoint>]
let main argv = 
    let isExists = argv.[0] |> File.Exists 
    if isExists then
        argv.[0]
        |> showSummry
    else   
        printfn "File is not Exists"
    0

