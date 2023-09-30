# VS Code で、.Net kernel のjupyter notebook 使う

1. Kernelの準備
   
・.NET Core 3.1 SDKが必要。

 dotnet --list-sdks　でバージョン確認できる　

   
　　・以下のコマンドを実行する。

> dotnet tool install --global Microsoft.dotnet-interactive


> dotnet interactive jupyter install

> jupyter kernelspec list

※ここでC#のカーネルが入ってるか確認できる。


2. VSCodeの拡張機能で以下をインストールする。
- Jupyter
- C# Dev Kit








