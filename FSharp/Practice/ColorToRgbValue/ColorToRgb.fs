
open System
open System.IO

type Color = 
    | Red
    | Green
    | Blue
    | Black
    | White
    | Yellow
    | NoDefined

module Color = 

    let tryFromString s = 
        if s = "r" then
            Red
        elif s = "g" then 
            Green
        elif s = "b" then
            Blue
        elif s = "y" then
            Yellow
        elif s = "w" then
            White
        elif s = "bl" then
            Black
        else
            NoDefined

    let cnvToColorRgbStr (color : Color) = 
        match color with
        | Red -> printfn "(255,0,0)"
        | Green -> printfn "(0,255,0)"
        | Blue -> printfn "(0,0,255)"
        | Black -> printfn "(0,0,0)"
        | White -> printfn "(255,255,255)"
        | Yellow -> printfn "(255,255,0)"
        | NoDefined -> printfn "No Match Difine"

[<EntryPoint>]
let main argv = 
    if argv.[0].Length > 0 && File.Exists argv.[0] then
        argv.[0] 
        |> File.ReadAllLines
        |> Array.map Color.tryFromString
        |> Array.iter Color.cnvToColorRgbStr
    0