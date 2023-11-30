using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace zad4
{
    internal class Program
    {
        static void Main (string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("students.xml");

            var root = doc.DocumentElement;

            var first = root.ChildNodes[0]; // или можно использовать root.FirstChild

            Console.WriteLine("Первый узел");
            Console.WriteLine($"Имя: {first.Name}");
            Console.WriteLine($"Количество дочерних элементов: {first.ChildNodes.Count}");
            Console.WriteLine($"Id: {first.Attributes["id"].Value}");
        }
    }
}
