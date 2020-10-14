using System;
using System.IO;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;
using System.Xml.Linq;
using System.Linq;
using Newtonsoft.Json;
using System.Drawing;
using System.Xml.XPath;

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
                var inputJtoken = JToken.Parse(inputJsonString);
                //var inputJObject = JsonConvert.DeserializeObject<JObject>(inputJsonString);
                XDocument xDocOutput = XDocument.Load(fileDirectory+configuration.GetSection("CoreXmlFilePath").Value);               
                var lastIdFrmCoreXml = int.Parse((from data in xDocOutput.Descendants("Flow") orderby data.Element("Id").Value select data).LastOrDefault().Element("Id").Value);
                //var lastIdFrmCoreXml = xDocOutput.XPathSelectElement("Layout/Flow/Id").Value; //XPATH approch
                //int counter = 0;
                var objectCount = inputJtoken.Count();
                for (var i=0;i< objectCount; i++)
                {
                    //counter++;
                    var paraStyle = Constants.GetParaElementDeclaration(++lastIdFrmCoreXml, i+1);
                    XElement xElement = XElement.Parse(paraStyle);
                    xDocOutput.Root.Add(xElement);                   
                }

                for (var i = 0; i < objectCount; i++)
                {
                    //counter++;
                    var textStyle = Constants.GetTextStyleDeclaration(++lastIdFrmCoreXml, i + 1);
                    XElement xElement = XElement.Parse(textStyle);
                    xDocOutput.Root.Add(xElement);
                }

                for (var i = 0; i < objectCount; i++)
                {
                    var font = inputJtoken[i].SelectToken("styles").SelectToken("fontFamily").ToString();                   
                    //counter++;
                    var fontStyle = Constants.GetFontDeclaration(font,++lastIdFrmCoreXml, i+1);
                    XElement xElement = XElement.Parse(fontStyle);
                    xDocOutput.Root.Add(xElement);                   
                }

                for (var i = 0; i < objectCount; i++)
                {
                    var rgbString = inputJtoken[i].SelectToken("styles").SelectToken("backgroundColor").ToString();
                    var rgb = rgbString.Substring(rgbString.IndexOf("(")+1, rgbString.IndexOf(")") - (rgbString.IndexOf("(")+1)).Split(",");
                    var fillStyle = Constants.GetFillStyleDeclaration(GetColorFromRGB(rgb), ++lastIdFrmCoreXml, i + 1);
                    XElement xElement = XElement.Parse(fillStyle);
                    xDocOutput.Root.Add(xElement);
                }

                for (var i = 0; i < objectCount; i++)
                {
                    var rgbString = inputJtoken[i].SelectToken("styles").SelectToken("backgroundColor").ToString();
                    var rgb = rgbString.Substring(rgbString.IndexOf("(") + 1, rgbString.IndexOf(")") - (rgbString.IndexOf("(") + 1)).Split(",");
                    var color = Constants.GetColorDeclaration(GetColorFromRGB(rgb), ++lastIdFrmCoreXml, i + 1);
                    XElement xElement = XElement.Parse(color);
                    xDocOutput.Root.Add(xElement);
                }

                var xDocStatic = XElement.Load(fileDirectory + configuration.GetSection("StaticContentXml").Value);
                //var firstFlowId = xDocOutput.Elements("FillStyleId").FirstOrDefault().Value;
                var firstFlowId = xDocOutput.XPathSelectElements("Layout/FillStyle/Id").FirstOrDefault().Value;
                var pathObjects = xDocStatic.Elements("PathObject");
                foreach (var pathObjElement in pathObjects) {
                    pathObjElement.Element("FillStyleId").Value = firstFlowId;
                }
                xDocOutput.Root.Add(xDocStatic.Elements());
                //xDocOutput.Root.Add(from data in xDocStatic.Elements() select data);

                var flowDefination = Constants.GetFlowDefination(xDocOutput.XPathSelectElement("Layout/Flow/Id").Value);
                var xElementFlow = XElement.Parse(flowDefination);
                var xElementFlowContent = xElementFlow.Element("FlowContent");
                var paraStyleIds = from data in xDocOutput.Descendants("ParaStyle") select data.Element("Id").Value;
                var textStyleIds = from data in xDocOutput.Descendants("TextStyle") select data.Element("Id").Value;
                for (var i = 0; i < objectCount; i++)
                {                    
                    string para = @$"<P Id='{paraStyleIds.ToArray()[i]}'><T xml:space='preserve' Id='{textStyleIds.ToArray()[i]}'>{inputJtoken[i].SelectToken("text")}</T></P>";
                    xElementFlowContent.Add(XElement.Parse(para));
                    var rgbString = inputJtoken[i].SelectToken("styles").SelectToken("backgroundColor").ToString();
                }
                xDocOutput.Root.Add(xElementFlow);

                //ParaStyle Defination
                var paraGrpStaticElmnt= XElement.Parse(@"<Group><Id Name='InvisibleParaStyles'>Def.InvisibleParaStyleGroup</Id></Group>");
                xDocOutput.Root.Add(paraGrpStaticElmnt);
                var paraStyleDefinationDefaultElmnt = Constants.GetParaStyleDefination();
                xDocOutput.Root.Add(XElement.Parse(paraStyleDefinationDefaultElmnt));
                for (var i = 0; i < objectCount; i++)
                {
                    var paraStyleDefination= Constants.GetParaStyleDefination(paraStyleIds.ToArray()[i]);
                    xDocOutput.Root.Add(XElement.Parse(paraStyleDefination));
                }


                xDocOutput.Save(fileDirectory+configuration.GetSection("OutputXmlFilePath").Value);
                //Console.WriteLine($"Output XML - {xDocOutput.ToString()}");
                Console.WriteLine("Finished Quadient XML formation successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured while creating Quadient XML !!! Check the error below");
                Console.WriteLine($"Error Message - {ex.Message}");
                Console.WriteLine($"Error Stacktrace - {ex.StackTrace}");
            }
        }

        private static string GetColorFromRGB(string[] rgb) {
            Color color = Color.FromArgb(int.Parse(rgb[0]), int.Parse(rgb[1]), int.Parse(rgb[2]));
            //Console.WriteLine(color.Name); // ffff0000

            var colorLookup = Enum.GetValues(typeof(KnownColor))
                   .Cast<KnownColor>()
                   .Select(Color.FromKnownColor)
                   .ToLookup(c => c.ToArgb());
            var colorString = colorLookup[color.ToArgb()].LastOrDefault().Name;
            return colorString;
            // There are some colours with multiple entries...
            //foreach (var namedColor in colorLookup[color.ToArgb()])
            //{
            //    Console.WriteLine(namedColor.Name);
            //}
        }
    }
}