# Data Base


## 3層スキーマ
- 外部スキーマ(ビュー)
- 概念スキーマ(テーブル)
- 内部スキーマ(内部ファイル)

データ独立性を実現するための仕組み。
内部、外部スキーマそれぞれの独立性（互いの変更の影響が影響しない状態）
  
## 論理設計と物理設計
- 論理設計(概念スキーマの設計)
- 物理設計(内部スキーマの設計)

## 論理設計のステップ
① エンティティの抽出

② エンティティの定義

③ 正規化

④ ER図の作成

 ・エンティティとは
   システムにおいて管理する必要があるデータのこと
   日本語でいうと実態
 ・エンティティの定義
 　各エンティティがどのような属性（データ）を保持するか決定するプロセス

 ## テーブルの構成要素
 - 行と列
 - key
   →主キーと外部キーがある

・主キー
　その値を指定すれば、必ず1行のレコードを特定できるような列（の組み合わせ）

・外部キー
　2つのテーブル間の列同士の関係性を表現するもの。
　参照整合性制約→参照しているテーブルに存在していない値を設定できないという制約を課す。

## 正規化
システムでの利用がスムーズにできるようにエンティティを整理するプロセス。
データの重複を削除する。
テーブルのすべての列が関数従属性を満たすように整理していくこと。

① 第一正規形

  1つのフィールドには1つの値しか含まない。という原則が守られた形。

② 第二正規形

　部分関数従属が解消されていて、完全関数従属のみのテーブルになっている形

　部分関数従属：複数列からなる主キーの一部の列に対して従属する列がある状態。

　完全関数従属：主キーを構成するすべての列に対して従属性がある状態。

③ 第三正規形

　推移的関数従属が解消されている形。

　





