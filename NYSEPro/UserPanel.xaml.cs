﻿using System;
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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Microsoft.Win32;
using System.Collections;
using System.Windows.Controls.Primitives;
using iTextSharp;
using System.Globalization;

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

            try
            {
                HttpResponseMessage message = client.GetAsync("UsersDateSearch?startDate=" + FromDatePicker.SelectedDate.Value.ToString("MM/dd/yyyy") + "&endDate=" + ToDatePicker.SelectedDate.Value.ToString("MM/dd/yyyy") + "").Result;
                string userJson = message.Content.ReadAsStringAsync().Result;
                var table = splitString(userJson);
                UserDataGrid.ItemsSource = table.DefaultView;
                MessageBox.Show(ToDatePicker.SelectedDate.Value.ToString());
               // MessageBox.Show(userJson);
            }
            catch (Exception ex)

            {
                MessageBox.Show("The following error just occurred: " + ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);

            }



        }


        private void HelpBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(@"You can get a pdf of your search result by clicking on the save button.
For more enquries contact our IT team");

        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            WebServicesSetting();

            try
            {
                HttpResponseMessage message = client.GetAsync("UsersDateSearch?startDate=" + FromDatePicker.SelectedDate.Value.ToString("MM/dd/yyyy") + "&endDate=" + ToDatePicker.SelectedDate.Value.ToString("MM/dd/yyyy") + "").Result;
                string userJson = message.Content.ReadAsStringAsync().Result;
                var table = splitString(userJson);
                UserDataGrid.ItemsSource = table.DefaultView;
                MessageBox.Show(ToDatePicker.SelectedDate.Value.ToString());
                //MessageBox.Show(userJson);
            }
            catch (Exception ex)

            {
                MessageBox.Show("The following error just occurred: " + ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);

            }



        }
    

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            ExportToPdf(UserDataGrid);

        }
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        public static childItem FindVisualChild<childItem>(DependencyObject obj)
            where childItem : DependencyObject
        {
            foreach (childItem child in FindVisualChildren<childItem>(obj))
            {
                return child;
            }
            return null;
        }

        private void ExportToPdf(DataGrid grid)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files|*.pdf";
            saveFileDialog.FilterIndex = 0;
            bool? result = saveFileDialog.ShowDialog();


            string fileName = string.Empty;
            if (result == true)

            {
                fileName = saveFileDialog.FileName;
                PdfPTable table = new PdfPTable(grid.Columns.Count);
                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                PdfWriter writer = PdfWriter.GetInstance(doc, new System.IO.FileStream(fileName, System.IO.FileMode.Create));
                doc.Open();
                for (int j = 0; j < grid.Columns.Count; j++)
                {
                    table.AddCell(new Phrase(grid.Columns[j].Header.ToString()));
                }
                table.HeaderRows = 1;
                IEnumerable itemsSource = grid.ItemsSource as IEnumerable;
                if (itemsSource != null)
                {
                    foreach (var item in itemsSource)
                    {
                        DataGridRow row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                        if (row != null)
                        {
                            DataGridCellsPresenter presenter = FindVisualChild<DataGridCellsPresenter>(row);
                            for (int i = 0; i < grid.Columns.Count; ++i)
                            {
                                DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(i);
                                TextBlock txt = cell.Content as TextBlock;
                                if (txt != null)
                                {
                                    table.AddCell(new Phrase(txt.Text));
                                }
                            }
                        }
                    }

                    doc.Add(table);
                    doc.Close();
                }
            }
        }
    }
}