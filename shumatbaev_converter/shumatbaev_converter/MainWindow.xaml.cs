using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using shumatbaev_converter.Model;
using shumatbaev_converter.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;
using System.Xml;
using static shumatbaev_converter.MainWindow;

namespace shumatbaev_converter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Valute> valutes;
        public MainWindow()
        {
            InitializeComponent();
            LoadValutes();
            FromComboBox.ItemsSource = valutes;
            ToComboBox.ItemsSource = valutes;
        }
        private void LoadValutes()
        {
            string xmlText = null;
            DateTime localDate = DateTime.Today;
            DateTime DateXML;


                try
                {
                    HttpClient client = new HttpClient();
                    var response = client.GetAsync("https://www.cbr.ru/scripts/XML_daily.asp").GetAwaiter().GetResult();
                    xmlText = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    if (xmlText != null)
                    {
                        try
                        {

                            File.WriteAllText("C:\\Users\\st310-09\\Desktop\\shumatbaev_converter\\shumatbaev_converter\\Data\\valutes.xml", xmlText, Encoding.UTF8);
                        } 
                    catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}");
                        }
                    }
                }
            catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке данных из интернета: {ex.Message}");
                }
            
  
            valutes = ValuteLoader.LoadValutes(xmlText);
            valutes.Insert(0, new Valute { Name = "Российский Рубль", Value = 1, CharCode = "RUB" });
        }



        private void FilterText(object sender, TextCompositionEventArgs e)
        {
            if (!int.TryParse(e.Text, out int x))
            {
                e.Handled = true;
            }
        }
        private void Calculate(object sender, TextChangedEventArgs e)
        {
            Valute inValute = FromComboBox.SelectedItem as Valute;
            Valute outValute = ToComboBox.SelectedItem as Valute;
            if (inValute == null || outValute == null)
            {
                return;
            }
            if (int.TryParse(InputBox.Text, out int value))
            {
                double rubles = value * inValute.Value;
                double result = rubles / outValute.Value;

         
                string formattedResult = result.ToString("F2");

                OutputBox.Text = formattedResult;
            }
            else
            {
                OutputBox.Text = "Введите корректное число";
            }
        }
    }
}
