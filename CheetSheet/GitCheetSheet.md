# Git Commnad Cheet Sheet

## Gitの設定ファイル
- System(/etc/gitconfig)
- Global(~/.gitconfig)
- User(repository/.git/config)

書き込める設定は以下を参考。

https://git-scm.com/docs/git-config.html#_variables

## 基本コマンド

1.ローカルリポジトリを作成して、RemoteにPushする。

$ git init

$ git add .

$ git commit -m "Initial commit"

$ git remote add origin https://github.com/XXXX/XXXXXX.git

$ git push -u origin master

2.ローカルの変更内容をすべて元に戻す

$ git checkout .

3.特定のファイルのローカルの変更を元に戻す

$ git checkout <filename>

## Alias設定
~/.gitconfig

[alias]
        ci = commit
        st = status
        br = branch
        co = checkout
        cob = checkout -b
        logg = log --graph --pretty=format:'%Cred%h%Creset -%C(yellow)%d%Creset %s %Cgreen(%cr) %C(bold blue)<%an>%Creset' --abbrev-commit