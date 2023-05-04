# <span style = "colo:red;">Markdown Cheet Sheet</span>

- [Markdown Cheet Sheet](#markdown-cheet-sheet)
  - [参考サイト](#参考サイト)
  - [List](#list)
    - [箇条書きList](#箇条書きlist)
    - [番号付きList](#番号付きlist)
  - [引用](#引用)
  - [協調](#協調)
  - [斜体](#斜体)
  - [リンク](#リンク)
  - [ファイル](#ファイル)
  - [テーブル](#テーブル)
    - [小技](#小技)
  - [チェックボックス](#チェックボックス)
  - [応用](#応用)
    - [コードの挿入](#コードの挿入)
    - [差分表示](#差分表示)

※コマンドパレットから目次が自動で作れる(Table Of Contents)


---
## 参考サイト
- [Markdown記法 Cheet Sheet](https://qiita.com/Qiita/items/c686397e4a0f4f11683d)
- [Markdwon記法一覧表](https://qiita.com/kamorits/items/6f342da395ad57468ae3)

---
## List
### 箇条書きList
- list1
- list2
- list3
- list4
  
### 番号付きList
1. item1
2. item2
3. item3
---
## 引用
> [地球温暖化](https://ja.wikipedia.org/wiki/%E5%9C%B0%E7%90%83%E6%B8%A9%E6%9A%96%E5%8C%96)

---
## 協調
**ほげほげ**  

---
## 斜体
*ぴよぴよ*

---
## リンク

[Google](https://google.com)

---
## ファイル

![image](img01.png)

---
## テーブル

[table用拡張機能](https://marketplace.visualstudio.com/items?itemName=TakumiI.markdowntable)

[Excel To Markdown](https://marketplace.visualstudio.com/items?itemName=TakumiI.markdowntable)

|左揃え|中央揃え|右揃え|
|:---|:---:|--:|
|align-left|align-center|align-right|

- 「:」を左→左揃え
- 「:」を右→右揃え
- 「:」を左右→中央揃え

### 小技
1. URLをコピーした状態でMD内のテキストを選択してペーストすると、
そのままリンク化してくれる。
2. タブ区切りの要素を用意して、右クリックからテーブル化できる。

---
## チェックボックス

- [ ] タスク1

- [x] タスク1

---
## 応用
### コードの挿入

```csharp
public static void Function(){
}
```
---
### 差分表示
```diff
- public void Fuga()
+ public void Hoge()
```
---
