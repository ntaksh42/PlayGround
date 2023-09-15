# F#の入門
## 環境構築

1. VSCode 入れて,「Ionide for F#」入れておけばOK.
2. プロジェクト作りたいFolderをVSCodeで開く。
3. [dotnet new console -lang F#]コマンドでプロジェクト作成
4. [dotnet run]で実行できる
5.  launch.jsonを↓で書いておけばOK。あとはF5でデバック実行できる。
      "configurations": [
        {
            "name": ".NET Core Launch (console)",
            "type": "coreclr",
            "request": "launch",
            "program": "${workspaceFolder}/bin/Debug/net7.0/HelloFSharp.exe",
            "args": [],
            "cwd": "${workspaceFolder}",
            "stopAtEntry": false,
            "console": "internalConsole"
        }
    ]

terminalで[dotnet watch run]で編集&Ctrl+Sで勝手にリビルドして実行してくれる。

## 構文ざっとメモ
・ open　はusingみたいなもん。
・ let はバインド（関数、変数）
・ ほかの言語みたいにreturnキーワードはない。
・ 配列は [|1,2,3,|]　みたいな感じで書く。
・ パイプライン演算子 引数→結果を数珠つなぎみたいな感じで書ける
　　let main args = 
    args 
    |> Array.filter isValidName 
    |> Array.filter isAllowed
    |> Array.iter sayHello
    printfn "Nice to meet you."
    0
