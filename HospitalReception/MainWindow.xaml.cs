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

namespace HospitalReception
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void login_btn_Click(object sender, RoutedEventArgs e)
        {
            /*
            using (HospitalContext db = new HospitalContext())
            {
                // They are already added
                
                /*
                Doctor admin = new Doctor { Login = "admin", Password = "admin" };
                Doctor surgeon = new Doctor { Login = "surgeon", Password = "surgeon" };
                Doctor dentist = new Doctor { Login = "dentist", Password = "dentist" };

                db.Doctors.Add(admin);
                db.Doctors.Add(surgeon);
                db.Doctors.Add(dentist);                

                db.SaveChanges();
                */
                
                //var Doctors = db.Doctors;

            UnitOfWork unit = new UnitOfWork();
            var Doctors = unit.Doctors.GetList();

            bool login = false;
            bool password = false;

            foreach (Doctor item in Doctors)
            {
                if (login_box.Text == item.Login)
                {
                    login = true;

                    if (password_box.Password == item.Password)
                    {
                        password = true;
                        break;
                    }
                }
            }

            if (login == false)
            {
                Error error = new Error();
                error.error_box.Text = "Bad login";
                error.Show();
            }
            else if (password == false)
            {
                Error error = new Error();
                error.error_box.Text = "Bad password";
                error.Show();
            }
            else
            {
                CustomersList cl_window = new CustomersList();
                cl_window.Show();
                this.Close();
            }
            //}
        }
    }
}
