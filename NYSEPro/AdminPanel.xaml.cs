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
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Management;
using System.IO;
using System.Diagnostics;




namespace NYSEPro
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Admin_Panel : Window
    {
        public Admin_Panel()
        {
            InitializeComponent();
        }



        //Helper Functions
        //Functon to load data on start up 
        private void loadData()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=.\main;Initial Catalog=NYSE;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter(@"SELECT *
                     FROM [dbo].[Stocks]", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                AdminDataGrid.ItemsSource = dt.DefaultView;
            }
            catch (SqlException ex)

            {
                MessageBox.Show("The following error just occurred when trying to connect to database: " + ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);

            }


        }

        //Function to check if a stock exists in the database
        public bool ifExists(SqlConnection con, string stockId)
        {
            con = new SqlConnection(@"Data Source=.\main;Initial Catalog=NYSE;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select 1 From [dbo].[Stocks] WHERE [StockID]='" + stockId + "' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Function to clear all the text boxes after add/delete/update
        private void resetData()
        {
            StIdTxt.Clear();
            StSymbolTxt.Clear();
            StPriceCloseTxt.Clear();
            StPriceHighTxt.Clear();
            StPriceLowTxt.Clear();
            StPriceOpenTxt.Clear();
            StPriceAdjCloseTxt.Clear();
            StVolumeTxt.Clear();
            StExchangeTxt.Clear();
            StockDatePicker.SelectedDate = null;
        }

        //Main Functions

        //Start up form
        private void AdminPanel_Loaded(object sender, RoutedEventArgs e)
        {
            loadData();

        }

        //Add button
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=.\main;Initial Catalog=NYSE;Integrated Security=True");
                con.Open();
                SqlCommand sc = new SqlCommand(@"INSERT INTO [dbo].[Stocks]
                   ([StockID]
                   ,[Date]
                   ,[StockSymbol]
                   ,[StockPriceOpen]
                   ,[StockPriceClose]
                   ,[StockPriceIo]
                   ,[StockPriceHigh]
                   ,[StockPriceAdjClose]
                   ,[StockVolume]
                   ,[StockExchange])
             VALUES
                   ('" + Convert.ToInt32(StIdTxt.Text) + "', '" + StockDatePicker.SelectedDate.Value.ToString("MM/dd/yyyy") + "', '" + StSymbolTxt.Text + "', '" + StPriceOpenTxt.Text + "', '" + StPriceCloseTxt.Text + "', '" + StPriceLowTxt.Text + "', '" + StPriceHighTxt.Text + "', '" + StPriceAdjCloseTxt.Text + "', '" + StVolumeTxt.Text + "', '" + StExchangeTxt.Text + "')", con);
                sc.ExecuteNonQuery();

                con.Close();
            }
            catch (SqlException ex)

            {
                MessageBox.Show("The following error just occurred when trying to connect to database: " + ex.Message, "ERROR on adding a new entity", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            finally
            {
                resetData();
                loadData();
            }
        }

        //Delete Button
        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        //Datagrid built in event to get the data from selected row
        private void AdminDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView selectedRow = dg.SelectedItem as DataRowView;

            if (selectedRow != null)
            {
                StIdTxt.Text = selectedRow["StockID"].ToString();
                StSymbolTxt.Text = selectedRow["StockSymbol"].ToString(); ;
                StPriceCloseTxt.Text = selectedRow["StockPriceClose"].ToString(); ;
                StPriceHighTxt.Text = selectedRow["StockPriceHigh"].ToString(); ;
                StPriceLowTxt.Text = selectedRow["StockPriceIo"].ToString(); ;
                StPriceOpenTxt.Text = selectedRow["StockPriceOpen"].ToString(); ;
                StPriceAdjCloseTxt.Text = selectedRow["StockPriceAdjClose"].ToString(); ;
                StVolumeTxt.Text = selectedRow["StockVolume"].ToString(); ;
                StExchangeTxt.Text = selectedRow["StockExchange"].ToString(); ;
                StockDatePicker.SelectedDate = Convert.ToDateTime(selectedRow["Date"]);
            }

        }

        //Delete button functionality
        private void DelBtn_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=.\main;Initial Catalog=NYSE;Integrated Security=True");
                con.Open();
                SqlCommand sc = new SqlCommand(@"DELETE FROM  [dbo].[Stocks] Where [StockID] = '" + StIdTxt.Text + "'  ", con);
                sc.ExecuteNonQuery();
                con.Close();
            }
            catch (SqlException ex)

            {
                MessageBox.Show("The following error just occurred when trying to connect to database: " + ex.Message, "ERROR on deleting an entity", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            finally
            {
                resetData();
                loadData();
            }
        }
        //Update button functionality

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=.\main;Initial Catalog=NYSE;Integrated Security=True");
                con.Open();
                SqlCommand sc = new SqlCommand(@"UPDATE [dbo].[Stocks] SET [StockID] ='" + Convert.ToInt32(StIdTxt.Text) + "' , [Date] = '" + StockDatePicker.SelectedDate.Value.ToString("MM/dd/yyyy") + "',[StockSymbol] = '" + StSymbolTxt.Text + "',[StockPriceOpen] = '" + StPriceOpenTxt.Text + "',[StockPriceClose] = '" + StPriceCloseTxt.Text + "',[StockPriceIo] = '" + StPriceLowTxt.Text + "',[StockPriceHigh] = '" + StPriceHighTxt.Text + "',[StockPriceAdjClose] = '" + StPriceAdjCloseTxt.Text + "', [StockVolume] = '" + StVolumeTxt.Text + "',[StockExchange] = '" + StExchangeTxt.Text + "'Where [StockID] = '" + StIdTxt.Text + "'", con);
                sc.ExecuteNonQuery();
                con.Close();
            }
            catch (SqlException ex)

            {
                MessageBox.Show("The following error just occurred when trying to connect to database: " + ex.Message, "ERROR On updating an entity", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            finally
            {
                MessageBox.Show("Record Updated Successfully");
                resetData();
                loadData();
            }

        }
       


        // Server Info button functionality
        private void ServerInfo_Click(object sender, RoutedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }
        public static void WriteEventLogEntry(string message)
        {
            // Create an instance of EventLog
            System.Diagnostics.EventLog eventLog = new System.Diagnostics.EventLog();

            // Check if the event source exists. If not create it.
            if (!System.Diagnostics.EventLog.SourceExists("NYSEPROApplication"))
            {
                System.Diagnostics.EventLog.CreateEventSource("NYSEPROApplication", "Application");
            }

            // Set the source name for writing log entries.
            eventLog.Source = "NYSEPROApplication";

            // Create an event ID to add to the event log
            int eventID = 8;

            // Write an entry to the event log.
            eventLog.WriteEntry(message,
                                System.Diagnostics.EventLogEntryType.Error,
                                eventID);

            // Close the Event Log
            eventLog.Close();
        }

        //Log an Event button functionality
        private void LogAanEventButton_Click(object sender, RoutedEventArgs e)
        {
            //WriteEventLogEntry("The application is successfully logged in windows.");
            //MessageBox.Show("Logged successfully! Please go to Control Panel->Administrative Tools->Event Viewer->From the left panel, under windows logs->double click on the Application and on the right panel you will see the logged event! ");
            var result = MessageBox.Show("Do you have administrator previliges?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                WriteEventLogEntry("The application is successfully logged in windows.");
                MessageBox.Show("Logged successfully! Please go to Control Panle->Administrative Tools->Event Viewer->From the left panel, under windows logs->double click on the Application and on the right panel you will see the logged event! ");
            }
            else
            {
                MessageBox.Show("Please re enter as an administrator.");
            }
        }

    }
}

