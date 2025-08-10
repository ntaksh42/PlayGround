# Claude Code デスクトップ通知設定ガイド

このガイドでは、Claude CodeのNotificationイベント発生時にWindowsデスクトップ通知を表示するHooks設定の手順を説明します。

## 前提条件

- Windows 10/11
- Claude Code CLI がインストール済み
- PowerShell実行権限

## セットアップ手順

### 1. Claude設定ディレクトリの確認

Claude Codeの設定ディレクトリを確認します：

```powershell
# Windowsの場合
C:\Users\[ユーザー名]\.claude\
```

ディレクトリが存在しない場合は作成してください。

### 2. PowerShell通知スクリプトの作成

`.claude`ディレクトリに`claude-notification.ps1`ファイルを作成します：

```powershell
param(
    [string]$Title = "Claude Code",
    [string]$Message = "通知メッセージ"
)

# プロジェクト名を取得（CLAUDE_PROJECT_DIR環境変数から）
$ProjectDir = $env:CLAUDE_PROJECT_DIR
if ($ProjectDir -and $ProjectDir -ne "") {
    $ProjectName = Split-Path -Leaf $ProjectDir
    $Title = "Claude Code - $ProjectName"
} else {
    # フォールバック：現在のディレクトリ名を使用
    $ProjectName = Split-Path -Leaf (Get-Location)
    if ($ProjectName -and $ProjectName -ne "") {
        $Title = "Claude Code - $ProjectName"
    }
}

# Toast通知を表示
try {
    [Windows.UI.Notifications.ToastNotificationManager, Windows.UI.Notifications, ContentType = WindowsRuntime] | Out-Null
    [Windows.Data.Xml.Dom.XmlDocument, Windows.Data.Xml.Dom.XmlDocument, ContentType = WindowsRuntime] | Out-Null
    
    $template = "<toast><visual><binding template=`"ToastText02`"><text id=`"1`">$Title</text><text id=`"2`">$Message</text></binding></visual></toast>"
    
    $xml = New-Object Windows.Data.Xml.Dom.XmlDocument
    $xml.LoadXml($template)
    $toast = New-Object Windows.UI.Notifications.ToastNotification($xml)
    
    $notifier = [Windows.UI.Notifications.ToastNotificationManager]::CreateToastNotifier('Claude Code')
    $notifier.Show($toast)
    
    Write-Host "Toast notification sent successfully"
    
} catch {
    # Toast通知が失敗した場合はメッセージボックス
    Add-Type -AssemblyName System.Windows.Forms
    [System.Windows.Forms.MessageBox]::Show($Message, $Title)
    Write-Host "Fallback to MessageBox"
}
```

### 3. Claude設定ファイル（settings.json）の作成・編集

`.claude`ディレクトリに`settings.json`ファイルを作成または編集します：

```json
{
  "$schema": "https://json.schemastore.org/claude-code-settings.json",
  "hooks": {
    "Notification": [
      {
        "hooks": [
          {
            "type": "command",
            "command": "powershell.exe -ExecutionPolicy Bypass -File \"C:\\Users\\[ユーザー名]\\.claude\\claude-notification.ps1\" -Title \"Claude Code\" -Message \"Your Action Needed\""
          }
        ]
      }
    ]
  }
}
```

**注意**: `[ユーザー名]`部分を実際のWindowsユーザー名に置き換えてください。

### 4. 設定のテスト

PowerShellスクリプトが正しく動作することを確認：

```powershell
powershell.exe -ExecutionPolicy Bypass -File "C:\Users\[ユーザー名]\.claude\claude-notification.ps1" -Message "Test notification"
```

### 5. Claude Codeの再起動

設定を反映するため、Claude Codeを再起動してください。

## 動作確認

Notificationイベントは以下の場面で発生します：

1. **ツール使用許可が必要な場合**: Claude Codeが危険な操作（ファイル削除など）を実行しようとする際
2. **入力待機時間が60秒を超えた場合**: プロンプトで何も入力せずに60秒経過した場合

## トラブルシューティング

### 通知が表示されない場合

1. **PowerShell実行ポリシーの確認**:
   ```powershell
   Get-ExecutionPolicy
   # RemoteSigned または Unrestricted である必要があります
   ```

2. **ファイルパスの確認**: `settings.json`内のファイルパスが正確であることを確認

3. **Claude Codeの再起動**: 設定変更後は必ずClaude Codeを再起動

### Toast通知が表示されない場合

- Windows通知設定でトースト通知が有効になっていることを確認
- フォールバックとしてメッセージボックスが表示されます

## 機能説明

- **プロジェクト名表示**: 通知タイトルに現在のプロジェクト名が含まれます
- **Toast通知**: Windowsネイティブのトースト通知を使用
- **フォールバック**: Toast通知が失敗した場合、メッセージボックスを表示
- **カスタマイズ可能**: メッセージ内容やタイトルを自由に変更可能

## カスタマイズ

### メッセージの変更

`settings.json`の`-Message`パラメータを変更：

```json
"command": "powershell.exe -ExecutionPolicy Bypass -File \"...\" -Message \"カスタムメッセージ\""
```

### 音声付き通知

PowerShellスクリプトに音声再生コードを追加可能：

```powershell
# 通知音を再生
[System.Media.SystemSounds]::Asterisk.Play()
```

## 参考情報

- [Claude Code Hooks Documentation](https://docs.anthropic.com/en/docs/claude-code/hooks)
- [Claude Code Settings](https://docs.anthropic.com/en/docs/claude-code/settings)