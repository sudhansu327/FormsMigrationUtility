using System;
namespace XmlConversionConsole
{
    public static class Constants
    {          
        public static string GetParaElement(int id, int counter)
        {
            return $"<ParaStyle><Id>{id}</Id><Name>Normal {counter}</Name>" +
            "<Comment/><ParentId>Def.ParaStyleGroup</ParentId>" +
            $"<IndexInParent>{counter}</IndexInParent><SecurityDescriptorId>-1</SecurityDescriptorId><Forward/></ParaStyle>";
        }
    }
}
