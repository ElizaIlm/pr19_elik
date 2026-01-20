using pr19_elik.Classes;
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

namespace pr19_elik.Pages.Kinoteatr.Items
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        KinoteatrContext Kinoteatr;
        public Item(KinoteatrContext Kinoteatr)
        {
            InitializeComponent();
            name.Text = Kinoteatr.Name;
            countZal.Text = Kinoteatr.CountZal.ToString();
            count.Text = Kinoteatr.Count.ToString();
            this.Kinoteatr = Kinoteatr;
        }

        private void EditRecord(object sender, RoutedEventArgs e) =>
            MainWindow.init.OpenPage(new Pages.Kinoteatr.Add(this.Kinoteatr));
    }
}
