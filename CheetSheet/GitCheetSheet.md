# Git Commnad Cheet Sheet

## Gitの設定ファイル
- System(/etc/gitconfig)
- Global(~/.gitconfig)
- User(repository/.git/config)

書き込める設定は以下を参考。

https://git-scm.com/docs/git-config.html#_variables

## 基本コマンド

- ローカルリポジトリを作成して、RemoteにPushする。

        $ git init
        $ git add .
        $ git commit -m "Initial commit"
        $ git remote add origin https://github.com/XXXX/XXXXXX.git
        $ git push -u origin master

- ローカルの変更内容をすべて元に戻す

        $ git checkout .

- 特定のファイルのローカルの変更を元に戻す

        $ git checkout <filename>

- ブランチの検索

        $ git branch --list **

- ブランチ切り替え

        $ git switch **branchName**

- 現在のブランチ以外のすべてのローカルブランチを削除する（PowerShell)
  # 現在のブランチを取得
$currentBranch = & git rev-parse --abbrev-ref HEAD

# ローカルブランチのリストを取得
$localBranches = & git branch | ForEach-Object { $_.Trim() }

        # 現在のブランチ以外のすべてのブランチをループ処理
        foreach ($branch in $localBranches) {
        if ($branch -ne $currentBranch) {
                # ブランチの削除を確認
                $confirmation = Read-Host "Are you sure you want to delete branch $branch? (y/n)"
                if ($confirmation -eq 'y') {
                # ブランチを削除
                & git branch -d $branch
                }
                }
        }

## Alias設定
~/.gitconfig

[alias]
        ci = commit
        st = status
        br = branch
        co = checkout
        cob = checkout -b
        logg = log --graph --pretty=format:'%Cred%h%Creset -%C(yellow)%d%Creset %s %Cgreen(%cr) %C(bold blue)<%an>%Creset' --abbrev-commit