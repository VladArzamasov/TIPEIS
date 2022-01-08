using AmortizationOSBusinessLogic.HelperModels;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System.Collections.Generic;

namespace AmortizationOSBusinessLogic.BusinessLogics
{
    class SaveToPdf
    {
        public static void CreateDoc(PdfInfo info)
        {
            Document document = new Document();
            DefineStyles(document);
            Section section = document.AddSection();
            Paragraph paragraph = section.AddParagraph(info.Title);
            paragraph.Format.SpaceAfter = "1cm";
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Style = "Normal";
            paragraph.Format.SpaceAfter = "1cm";
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            var table = document.LastSection.AddTable();
            List<string> columns = new List<string> { "2cm", "2cm", "2cm", "2cm", "2cm", "3cm", "3cm" };
            foreach (var elem in columns)
            {
                table.AddColumn(elem);
            }
            CreateRow(new PdfRowParameters
            {
                Table = table,
                Texts = new List<string> { "Месяц", "Счет затрат (20)", "Счет затрат (23)", "Счет затрат (25)", "Счет затрат (26)", "Итого за месяц", "Итого с начала года" },
                Style = "NormalTitle",
                ParagraphAlignment = ParagraphAlignment.Center
            });
            decimal sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0;
            foreach (var rd in info.ReportDistribution)
            {
                CreateRow(new PdfRowParameters
                {
                    Table = table,
                    Texts = new List<string> { rd.Month,
                    rd.SumAccount1.ToString(), rd.SumAccount2.ToString(), rd.SumAccount3.ToString(), rd.SumAccount4.ToString(), rd.SumItog.ToString(), rd.SumStartYear.ToString()
                    },
                    Style = "Normal",
                    ParagraphAlignment = ParagraphAlignment.Center
                });
                sum1 += rd.SumAccount1;
                sum2 += rd.SumAccount2;
                sum3 += rd.SumAccount3;
                sum4 += rd.SumAccount4;
            }
            CreateRow(new PdfRowParameters
            {
                Table = table,
                Texts = new List<string> { "Итого:", sum1.ToString(), sum2.ToString(), sum3.ToString(), sum4.ToString() },
                Style = "Normal",
                ParagraphAlignment = ParagraphAlignment.Center
            });
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always)
            {
                Document = document
            };
            renderer.RenderDocument();
            renderer.PdfDocument.Save(info.FileName);
        }
        public static void CreateDocument(PdfIfoes info)
        {
            Document document = new Document();
            DefineStyles(document);
            Section section = document.AddSection();
            Paragraph paragraph = section.AddParagraph(info.Title);
            paragraph.Format.SpaceAfter = "1cm";
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Style = "Normal";
            paragraph.Format.SpaceAfter = "1cm";
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            var table = document.LastSection.AddTable();
            List<string> columns = new List<string> { "1cm", "3cm", "3cm", "3cm", "3cm", "3cm" };
            foreach (var elem in columns)
            {
                table.AddColumn(elem);
            }
            CreateRow(new PdfRowParameters
            {
                Table = table,
                Texts = new List<string> { "Инв. ном.", "Наименование ОС", "Сумма износа", "Остаточная стоимость на нач. месяца", 
                    "Остаточная стоимость на кон. месяца",   "Сумма износа с начала года" },
                Style = "NormalTitle",
                ParagraphAlignment = ParagraphAlignment.Center
            });
            decimal summa = 0;
            foreach (var rd in info.ReportCalculation)
            {
                CreateRow(new PdfRowParameters
                {
                    Table = table,
                    Texts = new List<string> { rd.Id.ToString(), rd.OsName, rd.Sum.ToString(), rd.OstSumStart.ToString(), rd.OstSumEnd.ToString(), rd.SumIznosa.ToString() },
                    Style = "Normal",
                    ParagraphAlignment = ParagraphAlignment.Center
                });
                summa += rd.Sum;
            }
            CreateRow(new PdfRowParameters
            {
                Table = table,
                Texts = new List<string> { " ", "Итого:", summa.ToString(), " ", " ", " " },
                Style = "Normal",
                ParagraphAlignment = ParagraphAlignment.Center
            });
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always)
            {
                Document = document
            };
            renderer.RenderDocument();
            renderer.PdfDocument.Save(info.FileName);
        }
        public static void CreateDocumention(PdfInformation info)
        {
            Document document = new Document();
            DefineStyles(document);
            Section section = document.AddSection();
            Paragraph paragraph = section.AddParagraph(info.Title);
            paragraph.Format.SpaceAfter = "1cm";
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Style = "Normal";
            paragraph.Format.SpaceAfter = "1cm";
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            var table = document.LastSection.AddTable();
            List<string> columns = new List<string> { "1.5cm", "2.5cm", "2.5cm", "2.5cm", "2.5cm", "2.5cm", "2.5cm" };
            foreach (var elem in columns)
            {
                table.AddColumn(elem);
            }
            CreateRow(new PdfRowParameters
            {
                Table = table,
                Texts = new List<string> { "Счет", "Начальный дебет", "Начальный кредит", "Дебетовый оборот", "Кредитовый оборот",   "Остаток дебет", "Остаток кредит" },
                Style = "NormalTitle",
                ParagraphAlignment = ParagraphAlignment.Center
            });
            foreach (var rd in info.TurnoverBalance)
            {
                CreateRow(new PdfRowParameters
                {
                    Table = table,
                    Texts = new List<string> { rd.Account, rd.DebetStart.ToString(), rd.KreditStart.ToString(), rd.DebetObr.ToString(), 
                        rd.KreditObr.ToString(), rd.DebetOst.ToString(), rd.KreditOst.ToString() },
                    Style = "Normal",
                    ParagraphAlignment = ParagraphAlignment.Center
                });
            }
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always)
            {
                Document = document
            };
            renderer.RenderDocument();
            renderer.PdfDocument.Save(info.FileName);
        }
        // Создание стилей для документа
        private static void DefineStyles(Document document)
        {
            Style style = document.Styles["Normal"];
            style.Font.Name = "Times New Roman";
            style.Font.Size = 12;
            style = document.Styles.AddStyle("NormalTitle", "Normal");
            style.Font.Bold = true;
        }
        // Создание и заполнение строки
        private static void CreateRow(PdfRowParameters rowParameters)
        {
            Row row = rowParameters.Table.AddRow();
            for (int i = 0; i < rowParameters.Texts.Count; ++i)
            {
                FillCell(new PdfCellParameters
                {
                    Cell = row.Cells[i],
                    Text = rowParameters.Texts[i],
                    Style = rowParameters.Style,
                    BorderWidth = 0.5,
                    ParagraphAlignment = rowParameters.ParagraphAlignment
                });
            }
        }
        // Заполнение ячейки
        private static void FillCell(PdfCellParameters cellParameters)
        {
            cellParameters.Cell.AddParagraph(cellParameters.Text);
            if (!string.IsNullOrEmpty(cellParameters.Style))
            {
                cellParameters.Cell.Style = cellParameters.Style;
            }
            cellParameters.Cell.Borders.Left.Width = cellParameters.BorderWidth;
            cellParameters.Cell.Borders.Right.Width = cellParameters.BorderWidth;
            cellParameters.Cell.Borders.Top.Width = cellParameters.BorderWidth;
            cellParameters.Cell.Borders.Bottom.Width = cellParameters.BorderWidth;
            cellParameters.Cell.Format.Alignment = cellParameters.ParagraphAlignment;
            cellParameters.Cell.VerticalAlignment = VerticalAlignment.Center;
        }
    }
}
