using System;
using System.IO;
using System.Windows;
using UpperSystem.Infrasture;
using IO = System.IO;

namespace UpperSystem
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string fileName = IO.Path.Combine(baseDirectory, "log4net.config");
            if (!File.Exists(fileName))
            {
                string tempFileFullName = Path.GetTempFileName();
                string tempFileName = Path.GetTempFileName().Substring(tempFileFullName.LastIndexOf("\\") + 1);

                File.WriteAllText(Path.Combine(baseDirectory, tempFileName), $"日志配置文件不存在,请检查文件路径\n,{fileName}");
            }
                
            LogHelper.SetConfig(new FileInfo(fileName));
        }
    }
}
