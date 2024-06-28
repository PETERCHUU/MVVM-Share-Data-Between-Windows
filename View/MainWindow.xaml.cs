using model;
using System;
using System.Collections.Generic;
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

namespace MVVMtest.View
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        private PersonData personData = new PersonData();
        public MainWindow(PersonData personData)
        {
            this.personData = personData;
            this.DataContext = new ViewModel.PersonListViewModel(personData);
            InitializeComponent();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            Add add = new Add(personData);
            if(add.ShowDialog() == true)
            {
                // 更新列表
            }
        }
    }
}
