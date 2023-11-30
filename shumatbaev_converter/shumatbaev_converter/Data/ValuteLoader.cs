using System;
using System.Collections.Generic;
using System.Linq;
using shumatbaev_converter.Data;
using shumatbaev_converter.Model;
using System.Text;
using System.Threading.Tasks;
using static shumatbaev_converter.MainWindow;
using System.Xml;
using System.Windows;

namespace shumatbaev_converter.Data
{
    public static class ValuteLoader
    {
        public static List<Valute> LoadValutes(string XMLText)
        {
            List<Valute> valutes = new List<Valute>();

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(XMLText);

                foreach (XmlNode valuteNode in doc.SelectNodes("//Valute"))
                {
                    Valute valute = new Valute
                    {
                        CharCode = valuteNode.SelectSingleNode("CharCode")?.InnerText,
                        Name = valuteNode.SelectSingleNode("Name")?.InnerText,
                        Value = Convert.ToDouble(valuteNode.SelectSingleNode("Value")?.InnerText.Replace('.', ',')),
                        Nominal = Convert.ToInt32(valuteNode.SelectSingleNode("Nominal")?.InnerText.Replace('.', ',')),
                        Date = Convert.ToDateTime(valuteNode.SelectSingleNode("Date")?.InnerText.Replace('.', ','))
                    };

                    valutes.Add(valute);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки валют: {ex.Message}");
     
            }
            DateTime localDate = DateTime.Today;
            
          
             
            return valutes;
        }
    }
}
