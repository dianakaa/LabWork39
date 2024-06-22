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

namespace Task5
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

            //GroupJoin: выполняет одновременно соединение коллекций и группировку элементов по ключу
            var foldersAndFileCount = directories.GroupJoin(files,
                                                _directory => _directory.FullName,
                                                _file => _file.DirectoryName,
                                                (_directory, _file) => new { Name = _directory.Name, FileCount = _file.Count() });
            resultDataGrid.ItemsSource = foldersAndFileCount;
        }
    }
}
