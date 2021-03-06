﻿using System;
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
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Data;
namespace ModernDiagnosticCenter.Admin
{
    /// <summary>
       /// Interaction logic for Test.xaml
    /// </summary>
    public partial class TestName : UserControl
    {
        public TestName()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           /* string dbConnectionString = @"Data Source=patient.db;Version=3;";
            SQLiteConnection sqlite_connection = new SQLiteConnection(dbConnectionString);

            try
            {
                sqlite_connection.Open();
                string query = "select age,name,phone from patient_table";

                SQLiteCommand create_command = new SQLiteCommand(query, sqlite_connection);
                create_command.ExecuteNonQuery();
                //SQLiteDataReader dr = create_command.ExecuteReader();

                SQLiteDataAdapter dataAdapt = new SQLiteDataAdapter(query, sqlite_connection);
                var ds = new DataSet();

                dataAdapt.Fill(ds,"patient_table");
                listView1.DataContext = ds.Tables["patient_table"].DefaultView;

                sqlite_connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            * */
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void fill_combobox()
        {
            string dbConnectionString = @"Data Source=patient.db;Version=3;";
            SQLiteConnection sqlite_connection = new SQLiteConnection(dbConnectionString);

            try
            {
                sqlite_connection.Open();
                string query = "select * from test_name order by test_name.test_name asc";

                SQLiteCommand create_command = new SQLiteCommand(query, sqlite_connection);
                //create_command.ExecuteNonQuery();
                SQLiteDataReader dr = create_command.ExecuteReader();

                while (dr.Read())
                {
                    string name = dr.GetString(1);
                    admin_test_name_combobox_update.Items.Add(name);
                
                }

                sqlite_connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void SaveInDatabase()
        {
            string dbConnectionString = @"Data Source=patient.db;Version=3;";
            SQLiteConnection sqlite_connection = new SQLiteConnection(dbConnectionString);

            try
            {
                sqlite_connection.Open();
                string query = "INSERT INTO test_name (test_name,test_price)   VALUES('" + this.admin_add_price.Text + "','"  + this.admin_test_name_add.Text + "')";

                SQLiteCommand create_command = new SQLiteCommand(query, sqlite_connection);
                create_command.ExecuteNonQuery();
                /*SQLiteDataReader dr = create_command.ExecuteReader();

                while (dr.Read())
                {
                    string name = dr.GetString(1);
                    combo_box.Items.Add(name);
                }*/

                sqlite_connection.Close();
                MessageBox.Show("Saved!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void admin_test_name_combobox_update_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //fill_combobox();
        }

        private void admin_test_name_combobox_update_DropDownOpened(object sender, EventArgs e)
        {
           
            
        }

        private void fillPrice()
        {
            string dbConnectionString = @"Data Source=patient.db;Version=3;";
            SQLiteConnection sqlite_connection = new SQLiteConnection(dbConnectionString);

            try
            {
                sqlite_connection.Open();
                string query = "select * from test_name where test_name='" + admin_test_name_combobox_update.Text + "'";

                SQLiteCommand create_command = new SQLiteCommand(query, sqlite_connection);
                //create_command.ExecuteNonQuery();
                SQLiteDataReader dr = create_command.ExecuteReader();

                while (dr.Read())
                {
                    //string name = dr.GetString(2);
                    int price = dr.GetInt32(2);
                    admin_price_update.Text = price.ToString();
                }

                sqlite_connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void admin_test_name_combobox_update_GotFocus(object sender, RoutedEventArgs e)
        {
            fill_combobox();
            fillPrice();
        }
    }
}
