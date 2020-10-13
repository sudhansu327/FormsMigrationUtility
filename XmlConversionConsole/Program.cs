using System;
using System.IO;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;
using System.Xml.Linq;
using System.Linq;


namespace XmlConversionConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Initiating Quadient XML formation...");
                
                var builder = new ConfigurationBuilder()
                    .AddJsonFile($"appsettings.json", true, true)
                    .AddEnvironmentVariables();
                var configuration = builder.Build();
                var fileDirectory = configuration.GetSection("FileDirectory").Value;
                var inputJsonString = File.ReadAllText(fileDirectory+configuration.GetSection("InputJsonFilePath").Value);              
                var inputJtoken = JToken.Parse(inputJsonString);              ;
                XDocument xDocOutput = XDocument.Load(fileDirectory+configuration.GetSection("CoreXmlFilePath").Value);               
                var lastIdFrmCoreXml = int.Parse((from data in xDocOutput.Descendants("Flow") orderby data.Element("Id").Value select data).LastOrDefault().Element("Id").Value);
                //var lastIdFrmCoreXml = xmlDocOutput.XPathSelectElement("Layout/Flow/Id").Value; //XPATH approch
                int counter = 0;
                foreach (var item in inputJtoken)
                {
                    counter++;
                    var paraStyle = Constants.GetParaElement(++lastIdFrmCoreXml, counter);
                    XElement xElement = XElement.Parse(paraStyle);
                    xDocOutput.Root.Add(xElement);                   
                }

                xDocOutput.Save(fileDirectory+configuration.GetSection("OutputXmlFilePath").Value);
                Console.WriteLine($"Output XML - {xDocOutput.ToString()}");
                Console.WriteLine("Finished Quadient XML formation successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured while creating Quadient XML !!! Check the error below");
                Console.WriteLine($"Error Message - {ex.Message}");
                Console.WriteLine($"Error Stacktrace - {ex.StackTrace}");
            }
        }
    }
}
