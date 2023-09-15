
open System.IO

module Float = 
    let tryFormString s = 
        if s = "N/A" then  
            None
        else
            Some (float s)

    let tryFormStringOrDefault (d, s)  = 
        s
        |> tryFormString
        |> Option.defaultValue d

type Student = 
    {
        Name : string
        Id : string
        MeanScore : float
        MinScore : float
        MaxScore : float
    }

module Student = 
    let CreateFormString(s:string) = 
        let elements =  s.Split('\t')
        let name = elements.[0]
        let id = elements.[1]
        let scores = 
            elements
            |> Array.skip 2
            |> Array.map (fun s -> Float.tryFormStringOrDefault (50, s))
        let meanScore = scores |> Array.averageBy float
        let minScore = scores |> Array.min
        let maxScore = scores |> Array.max
        {
            Name = name
            Id = id
            MeanScore = meanScore
            MinScore = minScore
            MaxScore = maxScore
        }

    let printSummay (s : Student) =
        printfn "%s,%s,mean:%0.1f, min:%0.1f, max:%0.1f" s.Name s.Id s.MeanScore s.MinScore s.MaxScore

let showSummry (filePath : string) =
    filePath 
    |> File.ReadAllLines
    |> Array.skip 1
    |> Array.map Student.CreateFormString
    |> Array.sortBy (fun student -> student.Name) 
    |> Array.iter Student.printSummay

[<EntryPoint>]
let main argv = 
    let isExists = argv.[0] |> File.Exists 
    if isExists then
        argv.[0]
        |> showSummry
    else   
        printfn "File is not Exists"
    0

