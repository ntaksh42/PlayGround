namespace SampleForm
{
    public partial class Form1 : Form
    {
        public interface INeed
        {
            bool StartWatch(string targetDirFullPath);
            void FinishWatch();
        }

        private readonly INeed _need;

        public Form1(INeed need)
        {
            InitializeComponent();

            _need = need;
            this.FormClosing += Form1_FormClosing;
        }

        private void _buttonStartWatch_Click(object sender, EventArgs e)
        {
            var targetFolderFullPath = _textBoxDirPath.Text;
            _need.StartWatch(targetFolderFullPath);
        }

        private void _buttonFinishWatch_Click(object sender, EventArgs e)
        {
            _need.FinishWatch();
        }

        private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
            => _need.FinishWatch();
    }



    internal class FormAgent : Form1.INeed
    {
        private enum EventType
        {
            Changed,
            Created,
            Deleted,
        }

        private FileSystemWatcher _watcher;
        private void SetWacherIfNotExist(string targetDirFullPath)
        {
            if (_watcher != null) return;

            _watcher = new FileSystemWatcher(targetDirFullPath);
            _watcher.EnableRaisingEvents = true;
            _watcher.IncludeSubdirectories = true;

            _watcher.NotifyFilter = NotifyFilters.DirectoryName |
                                    NotifyFilters.CreationTime |
                                    NotifyFilters.LastAccess |
                                    NotifyFilters.FileName;
            _watcher.Changed += _watcher_Changed;
            _watcher.Created += _watcher_Created;
            _watcher.Deleted += _watcher_Deleted;
        }

        private void _watcher_Deleted(object sender, FileSystemEventArgs e)
            => ShowMsg(e.FullPath);


        private void _watcher_Created(object sender, FileSystemEventArgs e)
            => ShowMsg(e.FullPath);

        private void _watcher_Changed(object sender, FileSystemEventArgs e)
            => ShowMsg(e.FullPath);

        private void ShowMsg(string msg) => MessageBox.Show(msg);

        public void FinishWatch()
        {
            _watcher?.Dispose();
        }

        public bool StartWatch(string targetDirFullPath)
        {
            if (!Directory.Exists(targetDirFullPath))
            {
                MessageBox.Show("存在するフォルダを指定してください。");
                return false;
            }

            SetWacherIfNotExist(targetDirFullPath);

            return true;
        }
    }
}