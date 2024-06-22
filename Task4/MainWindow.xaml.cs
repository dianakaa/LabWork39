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

namespace Task4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            DirectoryInfo directory = new DirectoryInfo(@"C:\Temp\ispp21\РПМ");
            FileInfo[] files = directory.GetFiles(" * ", SearchOption.AllDirectories);
            DirectoryInfo[] directories = directory.GetDirectories("*", SearchOption.AllDirectories);

            //Join: соединяет две коллекции по определенному признаку
            var todayDirectories = directories.Where(_directory => _directory.CreationTime.Date == DateTime.Today);

            var filesInToday = files.Join(todayDirectories,
                                         _file => Directory.GetParent(_file.FullName).Name,
                                         _directiry => _directiry.Name,
                                        (_file, _directory) => new { _file.Name, directory.CreationTime});

            resultDataGrid.ItemsSource = filesInToday;
        }
    }
}
