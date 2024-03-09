# PowerShell 入門

### 変数の書き方
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






