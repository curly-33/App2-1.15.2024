using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace App2_1._15._2024
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
        string sqlCon = @"Data Source= LAB108PC05\SQLEXPRESS; Initial Catalog=Login; Integrated Security=True;";





        private void Button_Click(object sender, RoutedEventArgs e)
        {
            char[] arr = { '!', '@', '_' };
            string ran = arr.ToString();
            if (txtPasswordBox.Password.Length < 8 && !txtPasswordBox.Password.Contains(ran))
            {
                MessageBox.Show("Try again");
            }
            else
            {
                MessageBox.Show("Success");
            }
        }



        private void Usertxt(object sender, RoutedEventArgs e)
        {
            txtUsername.Text = "";
        }

        private void Insert(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(sqlCon);
            try
            {
                conn.Open();
                string Query = $"Insert into Credential_table (Username, FirstName, LastName, Email, Password)" + $"values('{txtUsername.Text}', '{txtFirstName.Text}', '{txtLastName.Text}','{txtEmail.Text}', '{txtPasswordBox.Password}')";

                SqlCommand sqlCommand = new SqlCommand(Query, conn);
                sqlCommand.ExecuteNonQuery();

                MessageBox.Show("You have succesfully inserted data");
                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(sqlCon);
            try
            {
                conn.Open();
               
                string UpdateQuery = $"UPDATE Credential_table SET FirstName = '{txtFirstName.Text}', LastName = '{txtLastName.Text}', Email = '{txtEmail.Text}', Password = '{txtPasswordBox.Password}' WHERE Username = '{txtUsername.Text}'";

                SqlCommand sqlCommand = new SqlCommand(UpdateQuery, conn);
                sqlCommand.ExecuteNonQuery();

            
                    MessageBox.Show("Username updated successfully");
               
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void Delete(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(sqlCon);
            try
            {
                conn.Open();


                    string DeleteQuery = $"DELETE FROM Credential_table WHERE Username = '{txtUsername.Text}'";
                    SqlCommand sqlCommand = new SqlCommand(DeleteQuery, conn);
                sqlCommand.ExecuteNonQuery();

                MessageBox.Show("Username deleted successfully");
                 
                     

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }

}

    


