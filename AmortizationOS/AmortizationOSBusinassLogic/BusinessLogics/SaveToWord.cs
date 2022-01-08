using System;
using System.Collections.Generic;
using System.Text;
using AmortizationOSBusinessLogic.HelperModels;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace AmortizationOSBusinessLogic.BusinessLogics
{
    static class SaveToWord
    {
        public static void CreateDocument(WordInfoes info)
        {
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(info.FileName, WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body docBody = mainPart.Document.AppendChild(new Body());

                Table table = new Table();
                TableProperties tblProp = new TableProperties(
                    new TableBorders(
                        new TopBorder
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 14
                        },
                        new BottomBorder
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 14
                        },
                        new LeftBorder
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 14
                        },
                        new RightBorder
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 14
                        },
                        new InsideHorizontalBorder
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 10
                        },
                        new InsideVerticalBorder
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 12
                        }
                    )
                );
                table.AppendChild(tblProp);
                docBody.AppendChild(CreateParagraph(new WordParagraph
                {
                    Texts = new List<(string, WordTextProperties)> { (info.Title, new WordTextProperties { Bold = true, Size = "24", }) },
                    TextProperties = new WordTextProperties
                    {
                        Size = "24",
                        JustificationValues = JustificationValues.Center
                    }
                }));

                TableRow tableRowHeader = new TableRow();

                TableCell cellHeader1 = new TableCell();
                cellHeader1.Append(new TableCellProperties(
                    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                cellHeader1.Append(new Paragraph(new Run(new Text("Инв. ном."))));

                TableCell cellHeader2 = new TableCell();
                cellHeader2.Append(new TableCellProperties(
                    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                cellHeader2.Append(new Paragraph(new Run(new Text("Наименование ОС"))));

                TableCell cellHeader3 = new TableCell();
                cellHeader3.Append(new TableCellProperties(
                    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                cellHeader3.Append(new Paragraph(new Run(new Text("Сумма износа"))));

                TableCell cellHeader4 = new TableCell();
                cellHeader4.Append(new TableCellProperties(
                    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                cellHeader4.Append(new Paragraph(new Run(new Text("Остаточная стоимость на начало месяца"))));

                TableCell cellHeader5 = new TableCell();
                cellHeader5.Append(new TableCellProperties(
                    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                cellHeader5.Append(new Paragraph(new Run(new Text("Остаточная стоимость на конец месяца"))));

                TableCell cellHeader6 = new TableCell();
                cellHeader6.Append(new TableCellProperties(
                    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                cellHeader6.Append(new Paragraph(new Run(new Text("Сумма износа с начала года"))));

                tableRowHeader.Append(cellHeader1);
                tableRowHeader.Append(cellHeader2);
                tableRowHeader.Append(cellHeader3);
                tableRowHeader.Append(cellHeader4);
                tableRowHeader.Append(cellHeader5);
                tableRowHeader.Append(cellHeader6);

                table.Append(tableRowHeader);

                decimal sum = 0;

                foreach (var report in info.ReportCalculation)
                {
                    TableRow tableRow = new TableRow();

                    TableCell cell1 = new TableCell();
                    cell1.Append(new TableCellProperties(
                        new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                    cell1.Append(new Paragraph(new Run(new Text(report.Id.ToString()))));

                    TableCell cell2 = new TableCell();
                    cell2.Append(new TableCellProperties(
                        new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                    cell2.Append(new Paragraph(new Run(new Text(report.OsName))));

                    TableCell cell3 = new TableCell();
                    cell3.Append(new TableCellProperties(
                        new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                    cell3.Append(new Paragraph(new Run(new Text(report.Sum.ToString()))));

                    sum += report.Sum;

                    TableCell cell4 = new TableCell();
                    cell4.Append(new TableCellProperties(
                        new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                    cell4.Append(new Paragraph(new Run(new Text(report.OstSumStart.ToString()))));

                    TableCell cell5 = new TableCell();
                    cell5.Append(new TableCellProperties(
                        new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                    cell5.Append(new Paragraph(new Run(new Text(report.OstSumEnd.ToString()))));

                    TableCell cell6 = new TableCell();
                    cell6.Append(new TableCellProperties(
                        new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                    cell6.Append(new Paragraph(new Run(new Text(report.SumIznosa.ToString()))));

                    tableRow.Append(cell1);
                    tableRow.Append(cell2);
                    tableRow.Append(cell3);
                    tableRow.Append(cell4);
                    tableRow.Append(cell5);
                    tableRow.Append(cell6);

                    table.Append(tableRow);
                }
                TableRow tableRow2 = new TableRow();
                TableCell cellItog = new TableCell();
                cellItog.Append(new TableCellProperties(
                    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                cellItog.Append(new Paragraph(new Run(new Text("Итого:"))));
                TableCell cellItog2 = new TableCell();
                cellItog2.Append(new TableCellProperties(
                    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                cellItog2.Append(new Paragraph(new Run(new Text(sum.ToString()))));
                TableCell cellItog3 = new TableCell();
                cellItog3.Append(new TableCellProperties(
                    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                cellItog3.Append(new Paragraph(new Run(new Text(" "))));
                TableCell cellItog4 = new TableCell();
                cellItog4.Append(new TableCellProperties(
                    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                cellItog4.Append(new Paragraph(new Run(new Text(" "))));
                TableCell cellItog5 = new TableCell();
                cellItog5.Append(new TableCellProperties(
                    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                cellItog5.Append(new Paragraph(new Run(new Text(" "))));
                TableCell cellItog6 = new TableCell();
                cellItog6.Append(new TableCellProperties(
                    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                cellItog6.Append(new Paragraph(new Run(new Text(" "))));

                tableRow2.Append(cellItog3);
                tableRow2.Append(cellItog);
                tableRow2.Append(cellItog2);
                tableRow2.Append(cellItog4);
                tableRow2.Append(cellItog5);
                tableRow2.Append(cellItog6);

                table.Append(tableRow2);

                docBody.AppendChild(table);
                wordDocument.MainDocumentPart.Document.Save();
            }
        }
        public static void CreateDoc(WordInfo info)
        {
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(info.FileName, WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body docBody = mainPart.Document.AppendChild(new Body());

                Table table = new Table();
                TableProperties tblProp = new TableProperties(
                    new TableBorders(
                        new TopBorder
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 14
                        },
                        new BottomBorder
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 14
                        },
                        new LeftBorder
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 14
                        },
                        new RightBorder
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 14
                        },
                        new InsideHorizontalBorder
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 10
                        },
                        new InsideVerticalBorder
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 12
                        }
                    )
                );
                table.AppendChild(tblProp);
                docBody.AppendChild(CreateParagraph(new WordParagraph
                {
                    Texts = new List<(string, WordTextProperties)> { (info.Title, new WordTextProperties { Bold = true, Size = "24", }) },
                    TextProperties = new WordTextProperties
                    {
                        Size = "24",
                        JustificationValues = JustificationValues.Center
                    }
                }));

                TableRow tableRowHeader = new TableRow();

                TableCell cellHeader1 = new TableCell();
                cellHeader1.Append(new TableCellProperties(
                    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                cellHeader1.Append(new Paragraph(new Run(new Text("Месяц"))));

                TableCell cellHeader2 = new TableCell();
                cellHeader2.Append(new TableCellProperties(
                    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                cellHeader2.Append(new Paragraph(new Run(new Text("Счет затрат(20)"))));

                TableCell cellHeader3 = new TableCell();
                cellHeader3.Append(new TableCellProperties(
                    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                cellHeader3.Append(new Paragraph(new Run(new Text("Счет затрат(23)"))));

                TableCell cellHeader4 = new TableCell();
                cellHeader4.Append(new TableCellProperties(
                    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                cellHeader4.Append(new Paragraph(new Run(new Text("Счет затрат(25)"))));

                TableCell cellHeader5 = new TableCell();
                cellHeader5.Append(new TableCellProperties(
                    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                cellHeader5.Append(new Paragraph(new Run(new Text("Счет затрат(26)"))));

                TableCell cellHeader6 = new TableCell();
                cellHeader6.Append(new TableCellProperties(
                    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                cellHeader6.Append(new Paragraph(new Run(new Text("Итого за месяц"))));

                TableCell cellHeader7 = new TableCell();
                cellHeader7.Append(new TableCellProperties(
                    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                cellHeader7.Append(new Paragraph(new Run(new Text("Сумма износа с начала года"))));

                tableRowHeader.Append(cellHeader1);
                tableRowHeader.Append(cellHeader2);
                tableRowHeader.Append(cellHeader3);
                tableRowHeader.Append(cellHeader4);
                tableRowHeader.Append(cellHeader5);
                tableRowHeader.Append(cellHeader6);
                tableRowHeader.Append(cellHeader7);

                table.Append(tableRowHeader);

                decimal sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0;

                foreach (var report in info.ReportDistribution)
                {
                    TableRow tableRow = new TableRow();

                    TableCell cell1 = new TableCell();
                    cell1.Append(new TableCellProperties(
                        new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                    cell1.Append(new Paragraph(new Run(new Text(report.Month))));

                    TableCell cell2 = new TableCell();
                    cell2.Append(new TableCellProperties(
                        new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                    cell2.Append(new Paragraph(new Run(new Text(report.SumAccount1.ToString()))));
                    sum1 += report.SumAccount1;

                    TableCell cell3 = new TableCell();
                    cell3.Append(new TableCellProperties(
                        new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                    cell3.Append(new Paragraph(new Run(new Text(report.SumAccount2.ToString()))));

                    sum2 += report.SumAccount2;

                    TableCell cell4 = new TableCell();
                    cell4.Append(new TableCellProperties(
                        new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                    cell4.Append(new Paragraph(new Run(new Text(report.SumAccount3.ToString()))));

                    sum3 += report.SumAccount3;

                    TableCell cell5 = new TableCell();
                    cell5.Append(new TableCellProperties(
                        new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                    cell5.Append(new Paragraph(new Run(new Text(report.SumAccount4.ToString()))));

                    sum4 += report.SumAccount4;

                    TableCell cell6 = new TableCell();
                    cell6.Append(new TableCellProperties(
                        new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                    cell6.Append(new Paragraph(new Run(new Text(report.SumItog.ToString()))));

                    TableCell cell7 = new TableCell();
                    cell7.Append(new TableCellProperties(
                        new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                    cell7.Append(new Paragraph(new Run(new Text(report.SumStartYear.ToString()))));

                    tableRow.Append(cell1);
                    tableRow.Append(cell2);
                    tableRow.Append(cell3);
                    tableRow.Append(cell4);
                    tableRow.Append(cell5);
                    tableRow.Append(cell6);
                    tableRow.Append(cell7);

                    table.Append(tableRow);
                }
                TableRow tableRow2 = new TableRow();
                TableCell cellItog = new TableCell();
                cellItog.Append(new TableCellProperties(
                    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                cellItog.Append(new Paragraph(new Run(new Text("Итого:"))));
                TableCell cellItog2 = new TableCell();
                cellItog2.Append(new TableCellProperties(
                    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                cellItog2.Append(new Paragraph(new Run(new Text(sum1.ToString()))));
                TableCell cellItog3 = new TableCell();
                cellItog3.Append(new TableCellProperties(
                    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                cellItog3.Append(new Paragraph(new Run(new Text(sum2.ToString()))));
                TableCell cellItog4 = new TableCell();
                cellItog4.Append(new TableCellProperties(
                    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                cellItog4.Append(new Paragraph(new Run(new Text(sum3.ToString()))));
                TableCell cellItog5 = new TableCell();
                cellItog5.Append(new TableCellProperties(
                    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                cellItog5.Append(new Paragraph(new Run(new Text(sum4.ToString()))));
                TableCell cellItog6 = new TableCell();
                cellItog6.Append(new TableCellProperties(
                    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                cellItog6.Append(new Paragraph(new Run(new Text(" "))));
                TableCell cellItog7 = new TableCell();
                cellItog7.Append(new TableCellProperties(
                    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                cellItog7.Append(new Paragraph(new Run(new Text(" "))));

                tableRow2.Append(cellItog);
                tableRow2.Append(cellItog2);
                tableRow2.Append(cellItog3);
                tableRow2.Append(cellItog4);
                tableRow2.Append(cellItog5);
                tableRow2.Append(cellItog6);
                tableRow2.Append(cellItog7);

                table.Append(tableRow2);

                docBody.AppendChild(table);
                wordDocument.MainDocumentPart.Document.Save();
            }
        }
        public static void CreateDocumention(WordInformation info)
        {
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(info.FileName, WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body docBody = mainPart.Document.AppendChild(new Body());

                Table table = new Table();
                TableProperties tblProp = new TableProperties(
                    new TableBorders(
                        new TopBorder
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 14
                        },
                        new BottomBorder
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 14
                        },
                        new LeftBorder
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 14
                        },
                        new RightBorder
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 14
                        },
                        new InsideHorizontalBorder
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 10
                        },
                        new InsideVerticalBorder
                        {
                            Val = new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 12
                        }
                    )
                );
                table.AppendChild(tblProp);
                docBody.AppendChild(CreateParagraph(new WordParagraph
                {
                    Texts = new List<(string, WordTextProperties)> { (info.Title, new WordTextProperties { Bold = true, Size = "24", }) },
                    TextProperties = new WordTextProperties
                    {
                        Size = "24",
                        JustificationValues = JustificationValues.Center
                    }
                }));

                TableRow tableRowHeader = new TableRow();

                TableCell cellHeader1 = new TableCell();
                cellHeader1.Append(new TableCellProperties(
                    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                cellHeader1.Append(new Paragraph(new Run(new Text("Счет"))));

                TableCell cellHeader2 = new TableCell();
                cellHeader2.Append(new TableCellProperties(
                    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                cellHeader2.Append(new Paragraph(new Run(new Text("Начальный дебет"))));

                TableCell cellHeader3 = new TableCell();
                cellHeader3.Append(new TableCellProperties(
                    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                cellHeader3.Append(new Paragraph(new Run(new Text("Начальный кредит"))));

                TableCell cellHeader4 = new TableCell();
                cellHeader4.Append(new TableCellProperties(
                    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                cellHeader4.Append(new Paragraph(new Run(new Text("Дебетовый оборот"))));

                TableCell cellHeader5 = new TableCell();
                cellHeader5.Append(new TableCellProperties(
                    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                cellHeader5.Append(new Paragraph(new Run(new Text("Кредитовый оборот"))));

                TableCell cellHeader6 = new TableCell();
                cellHeader6.Append(new TableCellProperties(
                    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                cellHeader6.Append(new Paragraph(new Run(new Text("Остаток дебет"))));

                TableCell cellHeader7 = new TableCell();
                cellHeader7.Append(new TableCellProperties(
                    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                cellHeader7.Append(new Paragraph(new Run(new Text("Остаток кредит"))));

                tableRowHeader.Append(cellHeader1);
                tableRowHeader.Append(cellHeader2);
                tableRowHeader.Append(cellHeader3);
                tableRowHeader.Append(cellHeader4);
                tableRowHeader.Append(cellHeader5);
                tableRowHeader.Append(cellHeader6);
                tableRowHeader.Append(cellHeader7);

                table.Append(tableRowHeader);

                foreach (var report in info.TurnoverBalance)
                {
                    TableRow tableRow = new TableRow();

                    TableCell cell1 = new TableCell();
                    cell1.Append(new TableCellProperties(
                        new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                    cell1.Append(new Paragraph(new Run(new Text(report.Account))));

                    TableCell cell2 = new TableCell();
                    cell2.Append(new TableCellProperties(
                        new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                    cell2.Append(new Paragraph(new Run(new Text(report.DebetStart.ToString()))));

                    TableCell cell3 = new TableCell();
                    cell3.Append(new TableCellProperties(
                        new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                    cell3.Append(new Paragraph(new Run(new Text(report.KreditStart.ToString()))));

                    TableCell cell4 = new TableCell();
                    cell4.Append(new TableCellProperties(
                        new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                    cell4.Append(new Paragraph(new Run(new Text(report.DebetObr.ToString()))));

                    TableCell cell5 = new TableCell();
                    cell5.Append(new TableCellProperties(
                        new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                    cell5.Append(new Paragraph(new Run(new Text(report.KreditObr.ToString()))));

                    TableCell cell6 = new TableCell();
                    cell6.Append(new TableCellProperties(
                        new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                    cell6.Append(new Paragraph(new Run(new Text(report.DebetOst.ToString()))));

                    TableCell cell7 = new TableCell();
                    cell7.Append(new TableCellProperties(
                        new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                    cell7.Append(new Paragraph(new Run(new Text(report.KreditOst.ToString()))));

                    tableRow.Append(cell1);
                    tableRow.Append(cell2);
                    tableRow.Append(cell3);
                    tableRow.Append(cell4);
                    tableRow.Append(cell5);
                    tableRow.Append(cell6);
                    tableRow.Append(cell7);

                    table.Append(tableRow);
                }

                docBody.AppendChild(table);
                wordDocument.MainDocumentPart.Document.Save();
            }
        }
        private static Paragraph CreateParagraph(WordParagraph paragraph)
        {
            if (paragraph != null)
            {
                Paragraph docParagraph = new Paragraph();
                docParagraph.AppendChild(CreateParagraphProperties(paragraph.TextProperties));
                foreach (var run in paragraph.Texts)
                {
                    Run docRun = new Run();
                    RunProperties properties = new RunProperties();
                    properties.AppendChild(new FontSize { Val = run.Item2.Size });
                    if (run.Item2.Bold)
                    {
                        properties.AppendChild(new Bold());
                    }
                    docRun.AppendChild(properties);
                    docRun.AppendChild(new Text { Text = run.Item1, Space = SpaceProcessingModeValues.Preserve });
                    docParagraph.AppendChild(docRun);
                }
                return docParagraph;
            }
            return null;
        }

        private static ParagraphProperties CreateParagraphProperties(WordTextProperties paragraphProperties)
        {
            if (paragraphProperties != null)
            {
                ParagraphProperties properties = new ParagraphProperties();
                properties.AppendChild(new Justification()
                {
                    Val = paragraphProperties.JustificationValues
                });
                properties.AppendChild(new SpacingBetweenLines
                {
                    LineRule = LineSpacingRuleValues.Auto
                });
                properties.AppendChild(new Indentation());
                ParagraphMarkRunProperties paragraphMarkRunProperties = new ParagraphMarkRunProperties();
                if (!string.IsNullOrEmpty(paragraphProperties.Size))
                {
                    paragraphMarkRunProperties.AppendChild(new FontSize { Val = paragraphProperties.Size });
                }
                properties.AppendChild(paragraphMarkRunProperties);
                return properties;
            }
            return null;
        }
    }
}
