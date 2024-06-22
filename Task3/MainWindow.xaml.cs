using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            DirectoryInfo directory = new DirectoryInfo(@"C:\Temp\ispp21");
            FileInfo[] files = directory.GetFiles("*", SearchOption.AllDirectories);
            DirectoryInfo[] directories = directory.GetDirectories("*", SearchOption.AllDirectories);

            var monthInfo = files.GroupBy(_file => new { Year = _file.CreationTime.Year, Month = _file.CreationTime.Month })
                 .Select(_group => new { Year = _group.Key.Year, Month = _group.Key.Month, FileCount = _group.Count() });

            resultDataGrid.ItemsSource = monthInfo;
        }

    }
}
