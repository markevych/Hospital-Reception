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
    /// Логика взаимодействия для Review.xaml
    /// </summary>
    public partial class Review : Window
    {
        public Review()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*using (HospitalContext db = new HospitalContext())
            {*/

            UnitOfWork unit = new UnitOfWork();
            unit.Conclusions.Create(new Conclusion { 
                //db.Conclusions.Add(new Conclusion {
                    Name = name_box.Text,
                    Surname = surname_box.Text,
                    Analyzes = analyzes_box.Text,
                    Complaints = comp_box.Text,
                    Conclusion_str = conc_box.Text,
                    Recipe = recipe_box.Text
                });
            //db.SaveChanges();
            unit.Conclusions.Save();
            //}

            //using (HospitalContext db = new HospitalContext())
            //{
            //    var report = (from c in db.Customers
            //where c.Id.ToString() == id_box.Text
            //select c).Single();

            //db.Customers.Remove(report);
            unit.Customers.Delete(Convert.ToInt32(id_box.Text));
            //db.SaveChanges();
            unit.Customers.Save();
            //}

            CustomersList cl_window = new CustomersList();
            cl_window.Show();
            this.Close();
        }
    }
}
