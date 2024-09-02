using System.Windows;
using UpperSystem.Infrasture;

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
            LogHelper.Info(Properties.Resources.LogMainWindowInit);
        }
    }
}
