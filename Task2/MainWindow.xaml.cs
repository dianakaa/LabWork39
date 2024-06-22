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
using static System.Net.WebRequestMethods;

namespace Task2
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
            DirectoryInfo directory = new DirectoryInfo(@"C:\Temp\ispp21");
            FileInfo[] files = directory.GetFiles("*", SearchOption.AllDirectories);
            DirectoryInfo[] directories = directory.GetDirectories("*", SearchOption.AllDirectories);

            //GroupBy: группирует элементы по ключу
            //Count: подсчитывает количество элементов коллекции, которые удовлетворяют определенному условию
            //Sum: подсчитывает сумму числовых значений в коллекции
            var extensionsInfo = files.GroupBy(_file => _file.Extension.ToLower())
                                       .Select(_group => new { Extension = _group.Key, Size = _group.Sum(_file => _file.Length), FileCount = _group.Count() });

            resultDataGrid.ItemsSource = extensionsInfo;
        }
    }
}