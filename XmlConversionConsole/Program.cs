using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;
using System.Xml;
using System.Collections.Generic;
using System.Xml.Linq;

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
                var inputJsonString = File.ReadAllText(configuration.GetSection("InputJsonFilePath").Value);
                //var myJObject = JObject.Parse(myJsonString);
                var inputJtoken = JToken.Parse(inputJsonString);
                //dynamic jsonInput = JsonConvert.DeserializeObject(myJsonString);
                XmlDocument xmlDocOutput = new XmlDocument();
                xmlDocOutput.Load(configuration.GetSection("CoreXmlFilePath").Value);
                var lastStaticId = int.Parse(xmlDocOutput.SelectSingleNode("//Layout/Flow/Id").InnerText);
                int counter = 0;
                foreach (var item in inputJtoken)
                {
                    counter++;
                    var paraStyle = Constants.GetParaElement(++lastStaticId, counter);
                    XmlDocumentFragment xfrag = xmlDocOutput.CreateDocumentFragment();
                    xfrag.InnerXml = paraStyle;
                    xmlDocOutput.DocumentElement.AppendChild(xfrag);
                    //var test = item;
                }  
                                                   
                xmlDocOutput.Save(configuration.GetSection("OutputXmlFilePath").Value);               
                Console.WriteLine("Finished Quadient XML formation successfully.");
            }
            catch(Exception ex)
            {
                Console.WriteLine("An error occured while creating Quadient XML !!! Check the error below");
                Console.WriteLine($"Error Stacktrace - {ex.StackTrace}");
            }
        }
    }
}
