using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Shapes;

namespace LabWork39
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

            //Union: объединяет две однородные коллекции
            //Select: определяет проекцию выбранных значений
            var namesAndDates = files.Select(_file => new { Name = _file.Name, CreationDate = _file.CreationTime })
                         .Union(directories.Select(_directory => new { Name = _directory.Name, CreationDate = _directory.CreationTime }));

            resultDataGrid.ItemsSource = namesAndDates;
        }

    }
}
