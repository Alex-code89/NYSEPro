using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
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
using Newtonsoft.Json;
using System.Net.Http;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Microsoft.Win32;
using System.Collections;
using System.Windows.Controls.Primitives;

namespace NYSEPro
{
    /// <summary>
    /// Interaction logic for User_Panel.xaml
    /// </summary>
    public partial class User_Panel : Window
    {
        HttpClient client = new HttpClient();

        public User_Panel()
        {
            InitializeComponent();
        }
        private DataTable splitString(string jsonString)
        {
            string[] json = jsonString.Split('>');
            string[] finalJson = json[2].Split('<');
            DataTable dt = JsonConvert.DeserializeObject<DataTable>(finalJson[0]);
            return dt;
        }
        private void WebServicesSetting()
        {
            client.BaseAddress = new Uri("https://localhost:44385/clientAPI.asmx/");
        }

        private void SearchBtn_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Load our web services base url

            WebServicesSetting();
          
            //Search by date
            DateTime fromDate = DateTime.Parse(FromTxt.Text);
            DateTime toDate = DateTime.Parse(ToTxt.Text);
            HttpResponseMessage message = client.GetAsync("UsersDateSearch?startDate=" + fromDate + "&endDate=" + toDate + "").Result;
            string userJson = message.Content.ReadAsStringAsync().Result;
            var table = splitString(userJson);
            UserDataGrid.ItemsSource = table.DefaultView; ;



        }
      

        private void HelpBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(@"Date format for search is : yyyy/dd/mm
You can get a pdf of your search result by clicking on the save button.
For more enquries contact our IT team");

        }
    }
}