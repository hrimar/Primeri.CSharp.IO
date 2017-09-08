using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;


namespace IOXMLFiles
{
    class Program
    {
        static void Main()
        {
            string value = "", property = "";

            string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.xml");

            // Прочитане на xml файл:
            using (XmlReader reader = XmlReader.Create(path))
            {
                while (reader.Read())
                {
                    switch (reader.Name)
                    {
                        case "row": property = reader["property"];
                            value = reader.ReadInnerXml();

                            Console.WriteLine("value = " + value);
                            Console.WriteLine("property = " + property);

                            break;

                        case "simpleRow":
                            //property = reader["property"];
                            value = reader.ReadInnerXml();

                            Console.WriteLine("value = " + value);
                            //Console.WriteLine("property = " + property);

                            break;
                    }
                }
            }

            Console.ReadKey();

            // Запис на xml файл:

            //string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.xml");

            //using (XmlWriter writer = XmlWriter.Create(path))
            //{
            //    writer.WriteStartDocument();

            //    writer.WriteStartElement("settings");

            //    //Съдържание на файла
            //    writer.WriteStartElement("row");
           
            //    writer.WriteAttributeString("property", property);  // <row property="...">... </row>
            //    writer.WriteString(value);  // <row> value </row>

            //    writer.WriteEndElement();


            //    writer.WriteEndElement();

            //    writer.WriteEndDocument();

            //}

            //XDocument document = XDocument.Load(path);
            //document.Save(path);


            //// И автоматично стартиране на xml файла:
            //System.Diagnostics.Process.Start(path);
        }
    }
}
