
open System 
open System.IO

type Person = 
    {
        Surname : string
        GivenName : string
        Age : int
    }

module Person =

    let getNameParts (s : string) = 
        let elements = s.Split(',')
        match elements with
        | [|surname; givenName|] ->
                {| Surname = surname.Trim()
                   GiveName = givenName.Trim()
                |}
        | [|surname|] -> 
                {| Surname = surname.Trim()
                   GiveName = "None"
                |}
        | _ -> raise (FormatException("it is invalid format"))

    let tryFromString (s : string) = 
        let elements = s.Split('\t')
        let name = elements.[0] |> getNameParts
        let age = elements.[1] |> int
        {
            Surname = name.Surname
            GivenName = name.GiveName
            Age = age
        }
        
    let showSummary (p : Person) = 
        printfn "surname:%s givenName:%s age:%d" p.Surname p.GivenName p.Age

[<EntryPoint>]
let main argv = 
    if argv.[0].Length > 0 && File.Exists argv.[0] then
        argv.[0] 
        |> File.ReadAllLines
        |> Array.skip 1 // Skip Header
        |> Array.map Person.tryFromString
        |> Array.iter Person.showSummary
    0
