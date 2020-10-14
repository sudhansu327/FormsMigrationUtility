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

        public static string GetParaStyleDefination(string id="")
        {
            return id.Equals(string.Empty)?@"<ParaStyle>
                        <Id Name='Normal'>Def.ParaStyle</Id>
                        <AncestorId/>
                        <LeftIndent>0</LeftIndent>
                        <RightIndent>0</RightIndent>
                        <FirstLineLeftIndent>0</FirstLineLeftIndent>
                        <SpaceBefore>0</SpaceBefore>
                        <SpaceAfter>0</SpaceAfter>
                        <LineSpacing>0</LineSpacing>
                        <LineSpacingType>Aditional</LineSpacingType>
                        <DefaultTextStyleId>Def.TextStyleDelta</DefaultTextStyleId>
                        <NextParagraphStyleId/>
                        <BorderStyleId/>
                        <NewAreaPageAfter>None</NewAreaPageAfter>
                        <HAlign>Left</HAlign>
                        <IsVisible>True</IsVisible>
                        <ConnectBorders>False</ConnectBorders>
                        <WithLineGap>False</WithLineGap>
                        <BullettingId/>
                        <IgnoreEmptyLines>False</IgnoreEmptyLines>
                        <TabulatorProperties>
                          <Default>1.2500000000000001e-002</Default>
                          <UseOutsideTabs>False</UseOutsideTabs>
                        </TabulatorProperties>
                        <Hyphenation>
                          <Hyphenate>False</Hyphenate>
                          <MinLeft>2</MinLeft>
                          <MinRight>2</MinRight>
                          <MaxConsecutive>2</MaxConsecutive>
                        </Hyphenation>
                        <Orphan>1</Orphan>
                        <Widow>1</Widow>
                        <NumberingType>None</NumberingType>
                        <NumberingVariableId/>
                        <NumberingFrom>1</NumberingFrom>
                        <SpaceBeforeFirst>False</SpaceBeforeFirst>
                        <KeepLinesTogether>No</KeepLinesTogether>
                        <KeepWithNext>False</KeepWithNext>
                        <KeepWithPrevious>False</KeepWithPrevious>
                        <DontWrap>False</DontWrap>
                        <RightReadingOrder>False</RightReadingOrder>
                        <Reversed>False</Reversed>
                        <CutFreely>False</CutFreely>
                        <CalcMaxSpaceBeforeAfter>False</CalcMaxSpaceBeforeAfter>
                        <NewAreaPageBefore>None</NewAreaPageBefore>
                        <DistributeLineSpace>False</DistributeLineSpace>
                        <Type>Simple</Type>
                        <Css>
                          <File/>
                          <ClassSelectorType>None</ClassSelectorType>
                        </Css>
                      </ParaStyle>":
                      @$"<ParaStyle>
                        <Id Name='Normal'>{id}</Id>
                        <AncestorId/>
                        <LeftIndent>0</LeftIndent>
                        <RightIndent>0</RightIndent>
                        <FirstLineLeftIndent>0</FirstLineLeftIndent>
                        <SpaceBefore>0</SpaceBefore>
                        <SpaceAfter>0</SpaceAfter>
                        <LineSpacing>0</LineSpacing>
                        <LineSpacingType>Aditional</LineSpacingType>
                        <DefaultTextStyleId>Def.TextStyleDelta</DefaultTextStyleId>
                        <NextParagraphStyleId/>
                        <BorderStyleId/>
                        <NewAreaPageAfter>None</NewAreaPageAfter>
                        <HAlign>Left</HAlign>
                        <IsVisible>True</IsVisible>
                        <ConnectBorders>False</ConnectBorders>
                        <WithLineGap>False</WithLineGap>
                        <BullettingId/>
                        <IgnoreEmptyLines>False</IgnoreEmptyLines>
                        <TabulatorProperties>
                          <Default>1.2500000000000001e-002</Default>
                          <UseOutsideTabs>False</UseOutsideTabs>
                        </TabulatorProperties>
                        <Hyphenation>
                          <Hyphenate>False</Hyphenate>
                          <MinLeft>2</MinLeft>
                          <MinRight>2</MinRight>
                          <MaxConsecutive>2</MaxConsecutive>
                        </Hyphenation>
                        <Orphan>1</Orphan>
                        <Widow>1</Widow>
                        <NumberingType>None</NumberingType>
                        <NumberingVariableId/>
                        <NumberingFrom>1</NumberingFrom>
                        <SpaceBeforeFirst>False</SpaceBeforeFirst>
                        <KeepLinesTogether>No</KeepLinesTogether>
                        <KeepWithNext>False</KeepWithNext>
                        <KeepWithPrevious>False</KeepWithPrevious>
                        <DontWrap>False</DontWrap>
                        <RightReadingOrder>False</RightReadingOrder>
                        <Reversed>False</Reversed>
                        <CutFreely>False</CutFreely>
                        <CalcMaxSpaceBeforeAfter>False</CalcMaxSpaceBeforeAfter>
                        <NewAreaPageBefore>None</NewAreaPageBefore>
                        <DistributeLineSpace>False</DistributeLineSpace>
                        <Type>Simple</Type>
                        <Css>
                          <File/>
                          <ClassSelectorType>None</ClassSelectorType>
                        </Css>
                      </ParaStyle>";
        }
    }
}
