
open System 

[<EntryPoint>]
let main argv = 
    // 配列使って1~1000までの二乗の合計値求める。
    [| for i in 1..1000 -> i * i|]
    |> Array.sum
    |> printfn "%d"

    // 別解
    Array.init 1000 (fun i -> i * i)
    |> Array.sum
    |> printfn "%d"

    // Sequence 
    // C#でいうIEnumrable
    // 遅延実行になる。
    seq { for i in 1..10 -> i + 2 }
    |> Seq.sum
    |> printfn "%d"
    0