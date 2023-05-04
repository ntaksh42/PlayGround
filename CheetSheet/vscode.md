# Visual Studio Code Cheet Sheet
---

## ショートカット系

| Cmd                          |                                      説明                                      |
| :--------------------------- | :----------------------------------------------------------------------------: |
| Ctrl+K,Ctrl+S                |                            ショートカット一覧を開く                            |
| Ctrl+Alt+P                   |                             コマンドパレットを開く                             |
| Ctrl+,                       |                                 user設定を開く                                 |
| Alt+Down/Up                  |                             カーソル行を上下に移動                             |
| Ctrl+Alt+カーソル            | マルチカーソル。マルチカーソル状態で、End/Homeで行末、行頭にカーソル合わせる。 |
| Ctrl+Shift+O                 |                            ファイル内のブロック検索                            |
| (カーソルあてた状態で)Ctrl+D |                               連続で、同種選択。                               |
| Ctrl+Space                   |                                 サジェスト表示                                 |
| Shift+Alt+F                  |                             ファイルのフォーマット                             |
| Ctrl+1,2,3...                |                            分割したウィンドウに移動                            |
| Ctrl+`                |                            Terminalを起動                            |

## C#の実行環境
1. 作業ディレクトリに移動し、CMDで`dotnet new console -o \"ProjectName\"`を実行。
2. code \"ProjectName\" (VSCODEでプロジェクトを開く)
3. 開いたときに左下に出るポップアップでYESを選択する。

## C++の実行環境
[参考URL](https://www.freecodecamp.org/japanese/news/how-to-compile-your-c-code-in-visual-studio-code/)

1. MinGWをInstallする。(g++.exeをオプションで追加)
2. フォルダを新規作成し、そこに`.cpp`フォイルを追加。
3. `Ctrl+Shift+B`で、`c/c++ g++.exe build active file`を選択。

## JavaScriptの実行環境
1. node.jsをインストールする。
2. .jsファイルを作成する。
3. `Debug and Run`を選択し、node.jsを選択する。(`.vscode`フォルダ内に設定ファイルが作成される。)
4. F5で、デバック実行できる。


