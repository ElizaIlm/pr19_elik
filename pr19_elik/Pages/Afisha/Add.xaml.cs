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
            DateTime dateAfisha;
            TimeSpan timeAfisha;
            int Price = -1;

            if (name.Text == "")
            {
                MessageBox.Show("Необходимо указать наименование");
                return;
            }

            if (kinoteatrs.SelectedIndex == kinoteatrs.Items.Count - 1)
            {
                MessageBox.Show("Выберите кинотеатр");
                return;
            }

            if (date.Text == "")
            {
                MessageBox.Show("Необходимо указать дату");
                return;
            }

            if (time.Text == "" || TimeSpan.TryParse(time.Text, out timeAfisha) == false)
            {
                MessageBox.Show("Необходимо указать время");
                return;
            }

            if (price.Text == "" || int.TryParse(price.Text, out Price) == false)
            {
                MessageBox.Show("Необходимо указать стоимость");
                return;
            }

            DateTime.TryParse(date.Text, out dateAfisha);
            dateAfisha.Add(timeAfisha);

            if (afisha == null)
            {
                AfishaContext newAfisha = new AfishaContext(
                    0,
                    AllKinoteats.Find(x => x.Name == kinoteatrs.SelectedItem).Id,
                    name.Text,
                    dateAfisha,
                    Price);
                newAfisha.Add();
                MessageBox.Show("Запись успешно добавлена.");
            }
            else
            {
                afisha = new AfishaContext(
                    afisha.Id,
                    AllKinoteats.Find(x => x.Name == kinoteatrs.SelectedItem).Id,
                    name.Text,
                    dateAfisha,
                    Price);
                afisha.Update();
                MessageBox.Show("Запись успешно обновлена.");
            }

            MainWindow.init.OpenPage(new Pages.Afisha.Main());
        }
    }
}
