*# ショートカット術
--
## Windowsの検索機能を生かす
1. 任意のフォルダ/ファイルのショートカットを作成する。 
2. ProgramData>Microsoft>Windows>Start Menuにショートカットを置いておく
   C:\ProgramData\Microsoft\Windows\Start Menu
3. Winキーから検索するとひっかけられる。

## EdgeからWebアプリとしてURLにアクセスする
1. Edgeを開いて、ALT + EからWebを作成
2. Winキーから起動できるようになる。

## Win検索にWeb検索を含まない方法

管理者権限でPowerShellを開いて以下のコマンドを実行する。
REG ADD HKCU\SOFTWARE\Policies\Microsoft\Windows\Explorer /v DisableSearchBoxSuggestions /t REG_DWORD /d 1 /f

## printScreenキーでキャプチャとる設定
 setting > SPrintScreenキーを使用して画面領域の切り取りを起動する。 

## microSoft PowerToys
Micro Soft Stores からインストールする
・PowerToys RunはOff
・Win + SFT + Tで画像からテキスト抽出。
・KeyboardMangerで任意のショートカットを割り当て直しができる。

## Winキーでウィンドウをスナップした後に横に配置するものを出さない
setting > マルチタスクの設定 > ウィンドウのスナップ > ウィンドウをスナップしたときに横に配置できるものを表示する。

## ショートカットメモ
・ALT＋ENTER → プロパティを開く

Edge : 
ALT + ENTER 新しいタブで開く
CTL + D ブックマークに追加

## 検索エンジンの編集
1. 検索エンジンで検索かけた状態でアドレスバーから検索フィルタの設定を開く
2. アドレスバーと検索>検索エンジンの管理を開く
3. アドレスバーの検索エンジン> 検索エンジン > 編集 
4. アドレスバーにショートカットを入力して、Space押すとそのエンジンで検索できる。

## 変換無変換キーでIME切り替えをする
1. win+iで設定を開く
2. 検索BOXに”IME”と入力して”日本語IME設定”を選択
3. キータッチのカスタマイズを選択
4. 使いやすいものにカスタマイズする
5. 変換キーをオン・オフにしておくのが好みではある。

## EveryThingで高速検索
・検索>フィルタ編集　で任意の種類のファイルに絞り込みができる。
Excel ext:xlsx;xls;xlsm;

・ツール>オプション>キー割り当て からフォルダを開く→CTL+Enterとしておくと便利
