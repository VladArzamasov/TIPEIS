using AmortizationOSBusinessLogic.HelperModels;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Office2013.Excel;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Linq;

namespace AmortizationOSBusinessLogic.BusinessLogics
{
    static class SaveToExcel
    {
        public static void CreateDoc(ExcelInfo info)
        {
            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(info.FileName, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
                workbookpart.Workbook = new Workbook();
                CreateStyles(workbookpart);
                SharedStringTablePart shareStringPart =
               spreadsheetDocument.WorkbookPart.GetPartsOfType<SharedStringTablePart>().Count() > 0
                ?
               spreadsheetDocument.WorkbookPart.GetPartsOfType<SharedStringTablePart>().First()
                :
               spreadsheetDocument.WorkbookPart.AddNewPart<SharedStringTablePart>();
                if (shareStringPart.SharedStringTable == null)
                {
                    shareStringPart.SharedStringTable = new SharedStringTable();
                }
                WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());
                Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());
                Sheet sheet = new Sheet()
                {
                    Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart),
                    SheetId = 1,
                    Name = "Лист"
                };
                sheets.Append(sheet);
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    Worksheet = worksheetPart.Worksheet,
                    ShareStringPart = shareStringPart,
                    ColumnName = "A",
                    RowIndex = 1,
                    Text = info.Title,
                    StyleIndex = 2U
                });
                MergeCells(new ExcelMergeParameters
                {
                    Worksheet = worksheetPart.Worksheet,
                    CellFromName = "A1",
                    CellToName = "F1"
                });
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    Worksheet = worksheetPart.Worksheet,
                    ShareStringPart = shareStringPart,
                    ColumnName = "A",
                    RowIndex = 2,
                    Text = "Инв. ном.",
                    StyleIndex = 1U
                });
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    Worksheet = worksheetPart.Worksheet,
                    ShareStringPart = shareStringPart,
                    ColumnName = "B",
                    RowIndex = 2,
                    Text = "Наименование ОС",
                    StyleIndex = 1U
                });
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    Worksheet = worksheetPart.Worksheet,
                    ShareStringPart = shareStringPart,
                    ColumnName = "C",
                    RowIndex = 2,
                    Text = "Сумма износа",
                    StyleIndex = 1U
                });
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    Worksheet = worksheetPart.Worksheet,
                    ShareStringPart = shareStringPart,
                    ColumnName = "D",
                    RowIndex = 2,
                    Text = "Остаточная стоим. на нач. мес.",
                    StyleIndex = 1U
                });
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    Worksheet = worksheetPart.Worksheet,
                    ShareStringPart = shareStringPart,
                    ColumnName = "E",
                    RowIndex = 2,
                    Text = "Остаточная стоим. на кон. мес.",
                    StyleIndex = 1U
                });
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    Worksheet = worksheetPart.Worksheet,
                    ShareStringPart = shareStringPart,
                    ColumnName = "F",
                    RowIndex = 2,
                    Text = "Сумма износа с нач. года",
                    StyleIndex = 1U
                });
                uint rowIndex = 3;
                decimal sum = 0;
                foreach (var sc in info.ReportCalculation)
                {
                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        Worksheet = worksheetPart.Worksheet,
                        ShareStringPart = shareStringPart,
                        ColumnName = "A",
                        RowIndex = rowIndex,
                        Text = sc.Id.ToString(),
                        StyleIndex = 1U
                    });
                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        Worksheet = worksheetPart.Worksheet,
                        ShareStringPart = shareStringPart,
                        ColumnName = "B",
                        RowIndex = rowIndex,
                        Text = sc.OsName,
                        StyleIndex = 1U
                    });
                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        Worksheet = worksheetPart.Worksheet,
                        ShareStringPart = shareStringPart,
                        ColumnName = "C",
                        RowIndex = rowIndex,
                        Text = sc.Sum.ToString(),
                        StyleIndex = 1U
                    });
                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        Worksheet = worksheetPart.Worksheet,
                        ShareStringPart = shareStringPart,
                        ColumnName = "D",
                        RowIndex = rowIndex,
                        Text = sc.OstSumStart.ToString(),
                        StyleIndex = 1U
                    });
                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        Worksheet = worksheetPart.Worksheet,
                        ShareStringPart = shareStringPart,
                        ColumnName = "E",
                        RowIndex = rowIndex,
                        Text = sc.OstSumEnd.ToString(),
                        StyleIndex = 1U
                    });
                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        Worksheet = worksheetPart.Worksheet,
                        ShareStringPart = shareStringPart,
                        ColumnName = "F",
                        RowIndex = rowIndex,
                        Text = sc.SumIznosa.ToString(),
                        StyleIndex = 1U
                    });
                    sum += sc.Sum;
                    rowIndex++;
                }
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    Worksheet = worksheetPart.Worksheet,
                    ShareStringPart = shareStringPart,
                    ColumnName = "B",
                    RowIndex = rowIndex,
                    Text = "Итого:",
                    StyleIndex = 0U
                });
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    Worksheet = worksheetPart.Worksheet,
                    ShareStringPart = shareStringPart,
                    ColumnName = "C",
                    RowIndex = rowIndex,
                    Text = sum.ToString(),
                    StyleIndex = 0U
                });
                workbookpart.Workbook.Save();
            }
        }
        public static void CreateDocument(ExcelInfoes info)
        {
            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(info.FileName, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
                workbookpart.Workbook = new Workbook();
                CreateStyles(workbookpart);
                SharedStringTablePart shareStringPart =
               spreadsheetDocument.WorkbookPart.GetPartsOfType<SharedStringTablePart>().Count() > 0
                ?
               spreadsheetDocument.WorkbookPart.GetPartsOfType<SharedStringTablePart>().First()
                :
               spreadsheetDocument.WorkbookPart.AddNewPart<SharedStringTablePart>();
                if (shareStringPart.SharedStringTable == null)
                {
                    shareStringPart.SharedStringTable = new SharedStringTable();
                }
                WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());
                Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());
                Sheet sheet = new Sheet()
                {
                    Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart),
                    SheetId = 1,
                    Name = "Лист"
                };
                sheets.Append(sheet);
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    Worksheet = worksheetPart.Worksheet,
                    ShareStringPart = shareStringPart,
                    ColumnName = "A",
                    RowIndex = 1,
                    Text = info.Title,
                    StyleIndex = 2U
                });
                MergeCells(new ExcelMergeParameters
                {
                    Worksheet = worksheetPart.Worksheet,
                    CellFromName = "A1",
                    CellToName = "G1"
                });
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    Worksheet = worksheetPart.Worksheet,
                    ShareStringPart = shareStringPart,
                    ColumnName = "A",
                    RowIndex = 2,
                    Text = "Месяц",
                    StyleIndex = 1U
                });
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    Worksheet = worksheetPart.Worksheet,
                    ShareStringPart = shareStringPart,
                    ColumnName = "B",
                    RowIndex = 2,
                    Text = "Счет затрат (20)",
                    StyleIndex = 1U
                });
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    Worksheet = worksheetPart.Worksheet,
                    ShareStringPart = shareStringPart,
                    ColumnName = "C",
                    RowIndex = 2,
                    Text = "Счет затрат (23)",
                    StyleIndex = 1U
                });
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    Worksheet = worksheetPart.Worksheet,
                    ShareStringPart = shareStringPart,
                    ColumnName = "D",
                    RowIndex = 2,
                    Text = "Счет затрат (25)",
                    StyleIndex = 1U
                });
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    Worksheet = worksheetPart.Worksheet,
                    ShareStringPart = shareStringPart,
                    ColumnName = "E",
                    RowIndex = 2,
                    Text = "Счет затрат (26)",
                    StyleIndex = 1U
                });
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    Worksheet = worksheetPart.Worksheet,
                    ShareStringPart = shareStringPart,
                    ColumnName = "F",
                    RowIndex = 2,
                    Text = "Итого за месяц",
                    StyleIndex = 1U
                });
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    Worksheet = worksheetPart.Worksheet,
                    ShareStringPart = shareStringPart,
                    ColumnName = "G",
                    RowIndex = 2,
                    Text = "Сумма износа с начала года",
                    StyleIndex = 1U
                });
                uint rowIndex = 3;
                decimal sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0;
                foreach (var sc in info.ReportDistribution)
                {
                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        Worksheet = worksheetPart.Worksheet,
                        ShareStringPart = shareStringPart,
                        ColumnName = "A",
                        RowIndex = rowIndex,
                        Text = sc.Month,
                        StyleIndex = 1U
                    });
                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        Worksheet = worksheetPart.Worksheet,
                        ShareStringPart = shareStringPart,
                        ColumnName = "B",
                        RowIndex = rowIndex,
                        Text = sc.SumAccount1.ToString(),
                        StyleIndex = 1U
                    });
                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        Worksheet = worksheetPart.Worksheet,
                        ShareStringPart = shareStringPart,
                        ColumnName = "C",
                        RowIndex = rowIndex,
                        Text = sc.SumAccount2.ToString(),
                        StyleIndex = 1U
                    });
                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        Worksheet = worksheetPart.Worksheet,
                        ShareStringPart = shareStringPart,
                        ColumnName = "D",
                        RowIndex = rowIndex,
                        Text = sc.SumAccount3.ToString(),
                        StyleIndex = 1U
                    });
                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        Worksheet = worksheetPart.Worksheet,
                        ShareStringPart = shareStringPart,
                        ColumnName = "E",
                        RowIndex = rowIndex,
                        Text = sc.SumAccount4.ToString(),
                        StyleIndex = 1U
                    });
                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        Worksheet = worksheetPart.Worksheet,
                        ShareStringPart = shareStringPart,
                        ColumnName = "F",
                        RowIndex = rowIndex,
                        Text = sc.SumItog.ToString(),
                        StyleIndex = 1U
                    });
                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        Worksheet = worksheetPart.Worksheet,
                        ShareStringPart = shareStringPart,
                        ColumnName = "G",
                        RowIndex = rowIndex,
                        Text = sc.SumStartYear.ToString(),
                        StyleIndex = 1U
                    });
                    sum1 += sc.SumAccount1;
                    sum2 += sc.SumAccount2;
                    sum3 += sc.SumAccount3;
                    sum4 += sc.SumAccount4;
                    rowIndex++;
                }
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    Worksheet = worksheetPart.Worksheet,
                    ShareStringPart = shareStringPart,
                    ColumnName = "A",
                    RowIndex = rowIndex,
                    Text = "Итого:",
                    StyleIndex = 0U
                });
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    Worksheet = worksheetPart.Worksheet,
                    ShareStringPart = shareStringPart,
                    ColumnName = "B",
                    RowIndex = rowIndex,
                    Text = sum1.ToString(),
                    StyleIndex = 0U
                });
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    Worksheet = worksheetPart.Worksheet,
                    ShareStringPart = shareStringPart,
                    ColumnName = "C",
                    RowIndex = rowIndex,
                    Text = sum2.ToString(),
                    StyleIndex = 0U
                });
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    Worksheet = worksheetPart.Worksheet,
                    ShareStringPart = shareStringPart,
                    ColumnName = "D",
                    RowIndex = rowIndex,
                    Text = sum3.ToString(),
                    StyleIndex = 0U
                });
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    Worksheet = worksheetPart.Worksheet,
                    ShareStringPart = shareStringPart,
                    ColumnName = "E",
                    RowIndex = rowIndex,
                    Text = sum4.ToString(),
                    StyleIndex = 0U
                });
                workbookpart.Workbook.Save();
            }
        }
        public static void CreateDocumention(ExcelInformation info)
        {
            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(info.FileName, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
                workbookpart.Workbook = new Workbook();
                CreateStyles(workbookpart);
                SharedStringTablePart shareStringPart =
               spreadsheetDocument.WorkbookPart.GetPartsOfType<SharedStringTablePart>().Count() > 0
                ?
               spreadsheetDocument.WorkbookPart.GetPartsOfType<SharedStringTablePart>().First()
                :
               spreadsheetDocument.WorkbookPart.AddNewPart<SharedStringTablePart>();
                if (shareStringPart.SharedStringTable == null)
                {
                    shareStringPart.SharedStringTable = new SharedStringTable();
                }
                WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());
                Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());
                Sheet sheet = new Sheet()
                {
                    Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart),
                    SheetId = 1,
                    Name = "Лист"
                };
                sheets.Append(sheet);
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    Worksheet = worksheetPart.Worksheet,
                    ShareStringPart = shareStringPart,
                    ColumnName = "A",
                    RowIndex = 1,
                    Text = info.Title,
                    StyleIndex = 2U
                });
                MergeCells(new ExcelMergeParameters
                {
                    Worksheet = worksheetPart.Worksheet,
                    CellFromName = "A1",
                    CellToName = "G1"
                });
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    Worksheet = worksheetPart.Worksheet,
                    ShareStringPart = shareStringPart,
                    ColumnName = "A",
                    RowIndex = 2,
                    Text = "Счет",
                    StyleIndex = 1U
                });
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    Worksheet = worksheetPart.Worksheet,
                    ShareStringPart = shareStringPart,
                    ColumnName = "B",
                    RowIndex = 2,
                    Text = "Начальный дебет",
                    StyleIndex = 1U
                });
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    Worksheet = worksheetPart.Worksheet,
                    ShareStringPart = shareStringPart,
                    ColumnName = "C",
                    RowIndex = 2,
                    Text = "Начальный кредит",
                    StyleIndex = 1U
                });
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    Worksheet = worksheetPart.Worksheet,
                    ShareStringPart = shareStringPart,
                    ColumnName = "D",
                    RowIndex = 2,
                    Text = "Дебетовый оборот",
                    StyleIndex = 1U
                });
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    Worksheet = worksheetPart.Worksheet,
                    ShareStringPart = shareStringPart,
                    ColumnName = "E",
                    RowIndex = 2,
                    Text = "Кредитовый оборот",
                    StyleIndex = 1U
                });
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    Worksheet = worksheetPart.Worksheet,
                    ShareStringPart = shareStringPart,
                    ColumnName = "F",
                    RowIndex = 2,
                    Text = "Остаток дебет",
                    StyleIndex = 1U
                });
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    Worksheet = worksheetPart.Worksheet,
                    ShareStringPart = shareStringPart,
                    ColumnName = "G",
                    RowIndex = 2,
                    Text = "Остаток кредит",
                    StyleIndex = 1U
                });
                uint rowIndex = 3;
                foreach (var sc in info.TurnoverBalance)
                {
                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        Worksheet = worksheetPart.Worksheet,
                        ShareStringPart = shareStringPart,
                        ColumnName = "A",
                        RowIndex = rowIndex,
                        Text = sc.Account,
                        StyleIndex = 1U
                    });
                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        Worksheet = worksheetPart.Worksheet,
                        ShareStringPart = shareStringPart,
                        ColumnName = "B",
                        RowIndex = rowIndex,
                        Text = sc.DebetStart.ToString(),
                        StyleIndex = 1U
                    });
                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        Worksheet = worksheetPart.Worksheet,
                        ShareStringPart = shareStringPart,
                        ColumnName = "C",
                        RowIndex = rowIndex,
                        Text = sc.KreditStart.ToString(),
                        StyleIndex = 1U
                    });
                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        Worksheet = worksheetPart.Worksheet,
                        ShareStringPart = shareStringPart,
                        ColumnName = "D",
                        RowIndex = rowIndex,
                        Text = sc.DebetObr.ToString(),
                        StyleIndex = 1U
                    });
                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        Worksheet = worksheetPart.Worksheet,
                        ShareStringPart = shareStringPart,
                        ColumnName = "E",
                        RowIndex = rowIndex,
                        Text = sc.KreditObr.ToString(),
                        StyleIndex = 1U
                    });
                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        Worksheet = worksheetPart.Worksheet,
                        ShareStringPart = shareStringPart,
                        ColumnName = "F",
                        RowIndex = rowIndex,
                        Text = sc.DebetOst.ToString(),
                        StyleIndex = 1U
                    });
                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        Worksheet = worksheetPart.Worksheet,
                        ShareStringPart = shareStringPart,
                        ColumnName = "G",
                        RowIndex = rowIndex,
                        Text = sc.KreditOst.ToString(),
                        StyleIndex = 1U
                    });
                    rowIndex++;
                }
                workbookpart.Workbook.Save();
            }
        }
        private static void CreateStyles(WorkbookPart workbookpart)
        {
            WorkbookStylesPart sp = workbookpart.AddNewPart<WorkbookStylesPart>();
            sp.Stylesheet = new Stylesheet();
            Fonts fonts = new Fonts() { Count = (UInt32Value)2U, KnownFonts = true };
            Font fontUsual = new Font();
            fontUsual.Append(new FontSize() { Val = 12D });
            fontUsual.Append(new DocumentFormat.OpenXml.Office2010.Excel.Color()
            {
                Theme
           = (UInt32Value)1U
            });
            fontUsual.Append(new FontName() { Val = "Times New Roman" });
            fontUsual.Append(new FontFamilyNumbering() { Val = 2 });
            fontUsual.Append(new FontScheme() { Val = FontSchemeValues.Minor });
            Font fontTitle = new Font();
            fontTitle.Append(new Bold());
            fontTitle.Append(new FontSize() { Val = 14D });
            fontTitle.Append(new DocumentFormat.OpenXml.Office2010.Excel.Color()
            {
                Theme
           = (UInt32Value)1U
            });
            fontTitle.Append(new FontName() { Val = "Times New Roman" });
            fontTitle.Append(new FontFamilyNumbering() { Val = 2 });
            fontTitle.Append(new FontScheme() { Val = FontSchemeValues.Minor });
            fonts.Append(fontUsual);
            fonts.Append(fontTitle);
            Fills fills = new Fills() { Count = (UInt32Value)2U };
            Fill fill1 = new Fill();
            fill1.Append(new PatternFill() { PatternType = PatternValues.None });
            Fill fill2 = new Fill();
            fill2.Append(new PatternFill() { PatternType = PatternValues.Gray125 });
            fills.Append(fill1);
            fills.Append(fill2);
            Borders borders = new Borders() { Count = (UInt32Value)2U };
            Border borderNoBorder = new Border();
            borderNoBorder.Append(new LeftBorder());
            borderNoBorder.Append(new RightBorder());
            borderNoBorder.Append(new TopBorder());
            borderNoBorder.Append(new BottomBorder());
            borderNoBorder.Append(new DiagonalBorder());
            Border borderThin = new Border();
            LeftBorder leftBorder = new LeftBorder() { Style = BorderStyleValues.Thin };
            leftBorder.Append(new DocumentFormat.OpenXml.Office2010.Excel.Color()
            {
                Indexed = (UInt32Value)64U
            });
            RightBorder rightBorder = new RightBorder()
            {
                Style = BorderStyleValues.Thin
            };
            rightBorder.Append(new DocumentFormat.OpenXml.Office2010.Excel.Color()
            {
                Indexed = (UInt32Value)64U
            });
            TopBorder topBorder = new TopBorder() { Style = BorderStyleValues.Thin };
            topBorder.Append(new DocumentFormat.OpenXml.Office2010.Excel.Color()
            {
                Indexed = (UInt32Value)64U
            });
            BottomBorder bottomBorder = new BottomBorder()
            {
                Style = BorderStyleValues.Thin
            };
            bottomBorder.Append(new DocumentFormat.OpenXml.Office2010.Excel.Color()
            {
                Indexed = (UInt32Value)64U
            });
            borderThin.Append(leftBorder);
            borderThin.Append(rightBorder);
            borderThin.Append(topBorder);
            borderThin.Append(bottomBorder);
            borderThin.Append(new DiagonalBorder());
            borders.Append(borderNoBorder);
            borders.Append(borderThin);
            CellStyleFormats cellStyleFormats = new CellStyleFormats()
            {
                Count =
           (UInt32Value)1U
            };
            CellFormat cellFormatStyle = new CellFormat()
            {
                NumberFormatId =
           (UInt32Value)0U,
                FontId = (UInt32Value)0U,
                FillId = (UInt32Value)0U,
                BorderId =
           (UInt32Value)0U
            };
            cellStyleFormats.Append(cellFormatStyle);
            CellFormats cellFormats = new CellFormats() { Count = (UInt32Value)3U };
            CellFormat cellFormatFont = new CellFormat()
            {
                NumberFormatId =
           (UInt32Value)0U,
                FontId = (UInt32Value)0U,
                FillId = (UInt32Value)0U,
                BorderId =
           (UInt32Value)0U,
                FormatId = (UInt32Value)0U,
                ApplyFont = true
            };
            CellFormat cellFormatFontAndBorder = new CellFormat()
            {
                NumberFormatId =
           (UInt32Value)0U,
                FontId = (UInt32Value)0U,
                FillId = (UInt32Value)0U,
                BorderId =
           (UInt32Value)1U,
                FormatId = (UInt32Value)0U,
                ApplyFont = true,
                ApplyBorder = true
            };
            CellFormat cellFormatTitle = new CellFormat()
            {
                NumberFormatId =
           (UInt32Value)0U,
                FontId = (UInt32Value)1U,
                FillId = (UInt32Value)0U,
                BorderId =
           (UInt32Value)0U,
                FormatId = (UInt32Value)0U,
                Alignment = new Alignment()
                {
                    Vertical =
           VerticalAlignmentValues.Center,
                    WrapText = true,
                    Horizontal =
           HorizontalAlignmentValues.Center
                },
                ApplyFont = true
            };
            cellFormats.Append(cellFormatFont);
            cellFormats.Append(cellFormatFontAndBorder);
            cellFormats.Append(cellFormatTitle);
            CellStyles cellStyles = new CellStyles() { Count = (UInt32Value)1U };
            cellStyles.Append(new CellStyle()
            {
                Name = "Normal",
                FormatId =
                (UInt32Value)0U,
                BuiltinId = (UInt32Value)0U
            });
            DocumentFormat.OpenXml.Office2013.Excel.DifferentialFormats
           differentialFormats = new DocumentFormat.OpenXml.Office2013.Excel.DifferentialFormats()
           {
               Count = (UInt32Value)0U
           };

            TableStyles tableStyles = new TableStyles()
            {
                Count = (UInt32Value)0U,
                DefaultTableStyle = "TableStyleMedium2",
                DefaultPivotStyle = "PivotStyleLight16"
            };
            StylesheetExtensionList stylesheetExtensionList = new
           StylesheetExtensionList();
            StylesheetExtension stylesheetExtension1 = new StylesheetExtension()
            {
                Uri =
           "{EB79DEF2-80B8-43e5-95BD-54CBDDF9020C}"
            };
            stylesheetExtension1.AddNamespaceDeclaration("x14",
           "http://schemas.microsoft.com/office/spreadsheetml/2009/9/main");
            stylesheetExtension1.Append(new SlicerStyles()
            {
                DefaultSlicerStyle =
           "SlicerStyleLight1"
            });
            StylesheetExtension stylesheetExtension2 = new StylesheetExtension()
            {
                Uri =
           "{9260A510-F301-46a8-8635-F512D64BE5F5}"
            };
            stylesheetExtension2.AddNamespaceDeclaration("x15",
           "http://schemas.microsoft.com/office/spreadsheetml/2010/11/main");
            stylesheetExtension2.Append(new TimelineStyles()
            {
                DefaultTimelineStyle =
           "TimeSlicerStyleLight1"
            });
            stylesheetExtensionList.Append(stylesheetExtension1);
            stylesheetExtensionList.Append(stylesheetExtension2);
            sp.Stylesheet.Append(fonts);
            sp.Stylesheet.Append(fills);
            sp.Stylesheet.Append(borders);
            sp.Stylesheet.Append(cellStyleFormats);
            sp.Stylesheet.Append(cellFormats);
            sp.Stylesheet.Append(cellStyles);
            sp.Stylesheet.Append(differentialFormats);
            sp.Stylesheet.Append(tableStyles);
            sp.Stylesheet.Append(stylesheetExtensionList);
        }
        private static void InsertCellInWorksheet(ExcelCellParameters cellParameters)
        {
            SheetData sheetData = cellParameters.Worksheet.GetFirstChild<SheetData>();
            Row row;
            if (sheetData.Elements<Row>().Where(r => r.RowIndex == cellParameters.RowIndex).Count() != 0)
            {
                row = sheetData.Elements<Row>().Where(r => r.RowIndex == cellParameters.RowIndex).First();
            }
            else
            {
                row = new Row() { RowIndex = cellParameters.RowIndex };
                sheetData.Append(row);
            }
            Cell cell;
            if (row.Elements<Cell>().Where(c => c.CellReference.Value == cellParameters.CellReference).Count() > 0)
            {
                cell = row.Elements<Cell>().Where(c => c.CellReference.Value == cellParameters.CellReference).First();
            }
            else
            {
                Cell refCell = null;
                foreach (Cell rowCell in row.Elements<Cell>())
                {
                    if (string.Compare(rowCell.CellReference.Value, cellParameters.CellReference, true) > 0)
                    {
                        refCell = rowCell;
                        break;
                    }
                }
                Cell newCell = new Cell()
                {
                    CellReference = cellParameters.CellReference
                };
                row.InsertBefore(newCell, refCell);
                cell = newCell;
            }
            cellParameters.ShareStringPart.SharedStringTable.AppendChild(new SharedStringItem(new Text(cellParameters.Text)));
            cellParameters.ShareStringPart.SharedStringTable.Save();
            cell.CellValue = new
           CellValue((cellParameters.ShareStringPart.SharedStringTable.Elements<SharedStringItem>().
           Count() - 1).ToString());
            cell.DataType = new EnumValue<CellValues>(CellValues.SharedString);
            cell.StyleIndex = cellParameters.StyleIndex;
        }
        private static void MergeCells(ExcelMergeParameters mergeParameters)
        {
            MergeCells mergeCells;
            if (mergeParameters.Worksheet.Elements<MergeCells>().Count() > 0)
            {
                mergeCells = mergeParameters.Worksheet.Elements<MergeCells>().First();
            }
            else
            {
                mergeCells = new MergeCells();
                if (mergeParameters.Worksheet.Elements<CustomSheetView>().Count() > 0)
                {
                    mergeParameters.Worksheet.InsertAfter(mergeCells, mergeParameters.Worksheet.Elements<CustomSheetView>().First());
                }
                else
                {
                    mergeParameters.Worksheet.InsertAfter(mergeCells, mergeParameters.Worksheet.Elements<SheetData>().First());
                }
            }
            MergeCell mergeCell = new MergeCell()
            {
                Reference = new StringValue(mergeParameters.Merge)
            };
            mergeCells.Append(mergeCell);
        }
    }
}
