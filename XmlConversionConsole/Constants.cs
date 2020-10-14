using System;
namespace XmlConversionConsole
{
    public static class Constants
    {
        public static string GetParaElementDeclaration(int id, int counter)
        {
            return @$"<ParaStyle>
                        <Id>{id}</Id>
                        <Name>Normal {counter}</Name>
                        <Comment />
                        <ParentId>Def.ParaStyleGroup</ParentId>
                        <IndexInParent>{counter}</IndexInParent>
                        <SecurityDescriptorId>-1</SecurityDescriptorId>
                        <Forward />
                      </ParaStyle>";
        }

        public static string GetTextStyleDeclaration(int id, int counter)
        {
            return @$"<TextStyle>
                      <Id>{id}</Id>
                        <Name>Normal {counter}</Name>
                        <Comment />
                        <ParentId>Def.TextStyleGroup</ParentId>
                        <IndexInParent>{counter}</IndexInParent>
                        <SecurityDescriptorId>-1</SecurityDescriptorId>
                        <Forward />
                      </TextStyle>";
        }

        public static string GetFontDeclaration(string fontName,int id, int counter)
        {
            return @$"<Font>
                        <Id>{id}</Id>
                        <Name>{fontName}</Name>
                        <Comment />
                        <ParentId>Def.FontGroup</ParentId>
                        <IndexInParent>{counter}</IndexInParent>
                        <SecurityDescriptorId>-1</SecurityDescriptorId>
                        <Forward />
                      </Font>";
        }

        public static string GetFillStyleDeclaration(string color, int id, int counter)
        {
            return @$"<FillStyle>
                        <Id>{id}</Id>
                        <Name>{color} FillStyle</Name>
                        <Comment />
                        <ParentId>Def.FillStyleGroup</ParentId>
                        <IndexInParent>{counter}</IndexInParent>
                        <SecurityDescriptorId>-1</SecurityDescriptorId>
                        <Forward />
                      </FillStyle>";
        }

        public static string GetColorDeclaration(string color, int id, int counter)
        {
            return @$"<Color>
                        <Id>{id}</Id>
                        <Name>{color}</Name>
                        <Comment />
                        <ParentId>Def.ColorGroup</ParentId>
                        <IndexInParent>{counter}</IndexInParent>
                        <SecurityDescriptorId>-1</SecurityDescriptorId>
                       <Forward />
                      </Color>";
        }

        public static string GetFlowDefination(string id) {
            return @$"<Flow>
                        <Id>{id}</Id>
                        <Type>Simple</Type>
                        <FlowContent Width='0.20000000000000001'>
                        </FlowContent>             
                        <DocxLock>Inherit</DocxLock>              
                        <IsInsertPoint> False </IsInsertPoint>              
                        <SectionFlow> False </SectionFlow>              
                        <TriggerBefore/>              
                        <TriggerInside/>              
                        <TriggerAfter/>              
                        <FlowUsageLogging>False</FlowUsageLogging>
                      </Flow> ";
        }
    }
}
