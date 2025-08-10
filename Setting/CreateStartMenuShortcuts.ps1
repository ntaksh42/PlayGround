# Create desktop shortcuts in Windows Start Menu
# Run this script as Administrator

$StartMenuPath = "C:\ProgramData\Microsoft\Windows\Start Menu"
$WshShell = New-Object -ComObject WScript.Shell

Write-Host "Creating shortcuts in: $StartMenuPath"

# Check if we have write permissions
try {
    $testFile = Join-Path $StartMenuPath "test.tmp"
    New-Item -Path $testFile -ItemType File -Force | Out-Null
    Remove-Item $testFile -Force
    Write-Host "✓ Write permissions confirmed"
}
catch {
    Write-Host "✗ Error: Administrator privileges required to write to Start Menu folder"
    Write-Host "Please run PowerShell as Administrator and try again."
    exit 1
}

# Helper function to create shortcut
function Create-Shortcut {
    param(
        [string]$ShortcutPath,
        [string]$TargetPath,
        [string]$Description = ""
    )
    
    if (Test-Path $TargetPath) {
        try {
            $Shortcut = $WshShell.CreateShortcut($ShortcutPath)
            $Shortcut.TargetPath = $TargetPath
            if ($Description) {
                $Shortcut.Description = $Description
            }
            $Shortcut.Save()
            Write-Host "✓ Created: $(Split-Path -Leaf $ShortcutPath) -> $TargetPath"
            return $true
        }
        catch {
            Write-Host "✗ Failed to create $(Split-Path -Leaf $ShortcutPath): $($_.Exception.Message)"
            return $false
        }
    }
    else {
        Write-Host "✗ Target path does not exist: $TargetPath"
        return $false
    }
}

# Create shortcuts for important folders
$shortcuts = @(
    @{ Name = "Desktop.lnk"; Path = [Environment]::GetFolderPath("Desktop"); Desc = "Desktop folder" },
    @{ Name = "Documents.lnk"; Path = [Environment]::GetFolderPath("MyDocuments"); Desc = "Documents folder" },
    @{ Name = "Downloads.lnk"; Path = "$env:USERPROFILE\Downloads"; Desc = "Downloads folder" },
    @{ Name = "Pictures.lnk"; Path = [Environment]::GetFolderPath("MyPictures"); Desc = "Pictures folder" },
    @{ Name = "OneDrive.lnk"; Path = "$env:USERPROFILE\OneDrive"; Desc = "OneDrive folder" }
)

$successCount = 0
foreach ($shortcut in $shortcuts) {
    $shortcutPath = Join-Path $StartMenuPath $shortcut.Name
    if (Create-Shortcut -ShortcutPath $shortcutPath -TargetPath $shortcut.Path -Description $shortcut.Desc) {
        $successCount++
    }
}

Write-Host ""
Write-Host "Summary: $successCount out of $($shortcuts.Count) shortcuts created successfully."
Write-Host "Location: $StartMenuPath"
Write-Host ""
Write-Host "These shortcuts will now appear in the Windows Start Menu."