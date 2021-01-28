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
using System.Data.SqlClient;

namespace APP_XX
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string[] title;
        UIElement label;
        private void Sql()
        {
            SqlConnection connection = new SqlConnection(App.MainConnection);
            connection.Open();
            string sqlQuery = "Select Title from Product";
            SqlCommand com = new SqlCommand(sqlQuery, connection);
            SqlDataReader dr = com.ExecuteReader();

            for (int i = 1; i < 101; i += 15)
            {
                while (dr.Read())
                {
                    for (int j = 1; j > 101; j++)
                    {
                        title[j] = dr.GetString(1);
                        label = new Label() { Content = "label" };
                        Console.WriteLine(j);
                    }
                }
                label = new Label() { Margin = new Thickness(0, i, 0, 0) }; // Creating label
                myGrid.Children.Add(label); //Adding to grid or other parent
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Sql();
        }
    }
}
