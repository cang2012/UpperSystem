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

            string fileName = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config");
            if (!File.Exists(fileName))
            {
                File.WriteAllText(fileName, $"日志配置文件不存在,请检查文件路径\n,{fileName}");
            }
                
            LogHelper.SetConfig(new FileInfo(fileName));
        }
    }
}
