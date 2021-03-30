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

namespace Student1
{
    public partial class AddWindow : Window
    {
        public Student Student { get; private set; }

        public AddWindow(Student s)
        {
            InitializeComponent();
            Student = s;
            this.DataContext = Student;
        }

        private void Accept(object sender, RoutedEventArgs e)
        {
            if (TextBox1.Text == "" || TextBox2.Text == "" || TextBox3.Text == "0" || TextBox4.Text == "0" || TextBox5.Text == "0")
                MessageBox.Show("Заполните все поля");
            else
                this.DialogResult = true;
        }
    }
}
