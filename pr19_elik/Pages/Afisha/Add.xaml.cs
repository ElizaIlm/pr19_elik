using pr19_elik.Classes;
using pr19_elik.Model;
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

namespace pr19_elik.Pages.Afisha
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        List<KinoteatrContext> AllKinoteats = KinoteatrContext.Select();

        AfishaContext afisha;

        public Add(AfishaContext afisha = null)
        {
            InitializeComponent();

            foreach (var item in AllKinoteats)
                kinoteatrs.Items.Add(item.Name);
            kinoteatrs.Items.Add("выберите плиз...");

            if (afisha != null)
            {
                this.afisha = afisha;
                kinoteatrs.SelectedIndex = AllKinoteats.FindIndex(x => x.Id == afisha.IdKinoteatr);
                name.Text = afisha.Name;
                date.Text = afisha.Time.ToString("yyyy-MM-dd");
                time.Text = afisha.Time.ToString("HH:mm");
                price.Text = afisha.Price.ToString();
            }
            else
            {
                kinoteatrs.SelectedIndex = kinoteatrs.Items.Count - 1;
            }
        }

        private void AddRecord(object sender, RoutedEventArgs e)
        {

        }
    }
}
