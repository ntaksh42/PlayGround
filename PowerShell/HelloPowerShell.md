# PowerShell 入門

### PSの基本文法
    $hoge = 1
    Write-Host $hoge // hoge に格納した値を出力

  型定義はなくかける

    $varInt = 15       # 整数
    $varDouble = 0.5      # 小数
    $varStr = "Hello"  # 文字列

    Write-Host $varInt.GetType()     # System.Int32
    Write-Host $vrDouble.GetType()     # System.Double
    Write-Host $varStr.GetType()     # System.String

配列
  
    $a = "a","b","c","d","e"  # 要素をカンマ区切りで列挙する
    $b = 1..5                 # 連続した数値の場合、「..」で定義可能(1～5までの配列)
    $c = @()                     # 空の配列の定義
    
    Write-Host $b[3]        # 要素の参照
    $a[2] = "C"             # 要素の代入

    $arr = 10..20
    Write-Host $arr[1, 3, 5]      # 1,3,5番目の要素を切り出し
    Write-Host $arr[1, 4, 2, 8]   # 順番を入れ替えてもOK
    Write-Host $arr[2..7]         # 連続した要素は「..」を使うと便利

条件判定

    $x = [int](Read-Host "数値を入力")
    if($x -ge 0){
        Write-Host "0以上です。"
    }elseif($x -lt 0){
        Write-Host "0より小さいです。"
    }

| PS  | 意味 |
| --- | ---- |
| -eq | ==   |
| -ne | !=   |
| -gt | > |
| -ge| >= |
| -lt | < |
| -le | <= |

論理演算子

| PS       | 意味     |
| -------- | -------- |
| A -and B | A && B   |
| A -or B  | A \|\| B |
| -not A   | !A       |

ループ処理

    for($i=0; $i -lt 10; $i++){
      Write-Host $i
    }

文字列操作

    $x = 5 + 3
    $a = '5 + 3 = ${x}'
    $b = "5 + 3 = ${x}"
    Write-Host $a        # 5 + 3 = ${x}
    Write-Host $b        # 5 + 3 = 8

Path の扱い

結合にはJoin-Pathが使える。

    $x = Join-Path -Path "D:\Powershell\data" -ChildPath "sample1.py"
    $y = "D:\Powershell\data" + "sample1.py"
    Write-Host $x   # D:\Powershell\data\sample1.py
    Write-Host $y   # D:\Powershell\datasample1.py

パイプライン
コマンドレットの処理結果や、変数の処理を次の処理に渡すための仕組み
「｜」で次の処理にコレクションのエントリを渡すことができる。

    Get-ChildItem | ForEach-Object{
        Write-Host $_.FullName
    }

関数
「function」キーワードで記述できる。他は割愛。

### コマンド
  Get-Commandで使用可能なコマンドの一覧を取得することができる。
  // mada よく使うコマンド

### Windows PowerShell ISE
[Windows PowerShell ISE](https://learn.microsoft.com/ja-jp/powershell/scripting/windows-powershell/ise/introducing-the-windows-powershell-ise?view=powershell-7.4)

候補表示なども効くし、スクリプトとして保存/デバック実行もできるので便利。
