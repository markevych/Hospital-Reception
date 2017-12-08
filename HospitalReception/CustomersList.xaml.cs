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
using System.Windows.Shapes;

namespace HospitalReception
{
    /// <summary>
    /// Логика взаимодействия для CustomersList.xaml
    /// </summary>
    public partial class CustomersList : Window
    {
        public CustomersList()
        {
            InitializeComponent();

            /*using (HospitalContext db = new HospitalContext())
            {
                // They are already added

                */
                //Customer cust1 = new Customer { Surname = "Kovalenko", Name = "Halyna", Age = 29, Complaints = "Headache", Adress = "Lviv, Nalyvaika, 4"};
                //Customer cust2 = new Customer { Surname = "Trubadur", Name = "Yura", Age = 21, Complaints = "Headache", Adress = "Busk, Pertrushevycha, 7" };
                /*Customer cust3 = new Customer { Surname = "Liubov", Name = "Anatoliy", Age = 43, Complaints = "Teethache, headache, temparature", Adress="Lviv, Pechera, 39"};
                Customer cust4 = new Customer { Surname = "Kravezc", Name = "Denis", Age = 7, Complaints = "Temparature", Adress="Dublyany, Holovna, 1" };

                db.Customers.Add(cust1);
                db.Customers.Add(cust2);
                db.Customers.Add(cust3);
                db.Customers.Add(cust4);

                db.SaveChanges();*/
            /*
            var Customers = db.Customers;
            */

            UnitOfWork unit = new UnitOfWork();

            unit.Customers.Create(new Customer { Surname = "Trubadur", Name = "Yura", Age = 21, Complaints = "Headache", Adress = "Busk, Pertrushevycha, 7" });
            unit.Customers.Save();

            var Customers = unit.Customers.GetList();

            foreach (Customer item in Customers)
            {
                if (item.Adress != null)
                {
                    list_view.Items.Add(item);
                }
            }
            //}            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {        
            var item = list_view.SelectedItem;

            if (item == null)
            {
                Error error = new Error();
                error.error_box.Text = "You don't select any item";
                error.Show();
            }
            
            else
            {
                Review review = new Review();

                review.name_box.Text = ((Customer)item).Name;
                review.surname_box.Text = ((Customer)item).Surname;
                review.age_box.Text = ((Customer)item).Age.ToString();
                review.comp_box.Text = ((Customer)item).Complaints;
                review.id_box.Text = ((Customer)item).Id.ToString();

                review.Show();
                this.Close();
            }
        }
    }
}
