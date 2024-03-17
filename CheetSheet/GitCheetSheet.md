# Git Commnad Cheet Sheet

参考
<https://learn.microsoft.com/ja-jp/azure/devops/repos/git/command-prompt?view=azure-devops>

## Gitの設定ファイル
- System(/etc/gitconfig)
- Global(~/.gitconfig)
- User(repository/.git/config)

書き込める設定は以下を参考。

https://git-scm.com/docs/git-config.html#_variables

## よく使うコマンド

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

# 現在のローカルブランチ以外のローカルブランチを削除

        git branch | ? {$_.StartsWith('*') -eq $False}| % {git branch -D $_.Trim()}


## Alias設定
~/.gitconfig

[alias]
        ci = commit
        st = status
        br = branch
        co = checkout
        cob = checkout -b
        logtree = git log --graph --pretty=format:'%x09%C(auto) %h %Cgreen %ar %Creset%x09by"%an%Creset" %x09%C(auto)%s %d'

[def]: https://learn.microsoft.com/ja-jp/azure/devops/repos/git/command-prompt?view=azure-devops