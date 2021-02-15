using OfficeOpenXml;
using System;
using System.IO;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;
using System.Drawing;
using System.Diagnostics;

namespace Reliability
{
    /// <summary>
    /// Формирование отчета в excel
    /// </summary>
    class ExcelReport
    {
        public readonly string PATH = $"{Environment.CurrentDirectory}\\Отчет.xlsx";
        public ReliabilityResults results { get;}
        public ExcelReport(ReliabilityResults results)
        {
            this.results = results;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }
        /// <summary>
        /// Сохраняет отчет в папку с exe файлом
        /// </summary>
        public void SaveReport()
        {
            try
            {
                if (File.Exists(PATH)) File.Delete(PATH);
                var file = new FileInfo(PATH);
                using (var package = new ExcelPackage(file))
                {
                    var sheet = package.Workbook.Worksheets.Add("My Sheet");
                    using (ExcelRange rng = sheet.Cells[2, 2, 4, 7])
                    {
                        rng.Value = "Результаты расчета надежности представлены ниже";
                        rng.Merge = true;
                        rng.Style.Font.Size = 16;
                        rng.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        rng.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                        rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                        rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                        rng.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                        rng.Style.Font.Bold = true;
                        rng.Style.Font.Name = "Arial";
                        rng.Style.Font.Italic = true;
                        rng.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.DarkGrid;
                        rng.Style.Fill.BackgroundColor.SetColor(Color.Yellow);
                    }
                    using (ExcelRange Rng = sheet.Cells["D6:E10"])
                    {
                        ExcelTable table = sheet.Tables.Add(Rng, "Reliability");
                        Rng.Style.Font.Bold = true;
                        Rng.Style.Font.Name = "Arial";
                        Rng.Style.Font.Italic = true;
                        Rng.Style.Font.Size = 12;
                        Rng.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Rng.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                        Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                        Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                        Rng.Style.Border.Left.Style = ExcelBorderStyle.Medium;

                        table.TableStyle = TableStyles.Light10;
                        table.Columns[0].Name = "Наименование параметра";
                        table.Columns[1].Name = "Значение параметра";
                        table.ShowFilter = false;
                    }

                    using (ExcelRange rng = sheet.Cells["D7"])
                    {
                        rng.Style.Font.Bold = false;
                        rng.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Fill;
                        rng.Value = "Вероятность безотказной работы";
                    }
                    using (ExcelRange rng = sheet.Cells["D8"])
                    {
                        rng.Style.Font.Bold = false;
                        rng.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Fill;
                        rng.Value = "Интенсивность отказов [1/ч]";
                    }
                    using (ExcelRange rng = sheet.Cells["D9"])
                    {
                        rng.Style.Font.Bold = false;
                        rng.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Fill;
                        rng.Value = "Средняя наработка до отказа [ч]";
                    }
                    using (ExcelRange rng = sheet.Cells["D10"])
                    {
                        rng.Style.Font.Bold = false;
                        rng.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Fill;
                        rng.Value = "Гамма-процентная наработка до отказа [ч]";
                    }

                    using (ExcelRange rng = sheet.Cells["E7"])
                    {
                        rng.Style.Font.Bold = false;
                        rng.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        rng.Value = $"{results.P:0.000000}";
                    }
                    using (ExcelRange rng = sheet.Cells["E8"])
                    {
                        rng.Style.Font.Bold = false;
                        rng.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        rng.Value = $"{results.Lymbda:0.000000000}";
                    }
                    using (ExcelRange rng = sheet.Cells["E9"])
                    {
                        rng.Style.Font.Bold = false;
                        rng.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        rng.Value = $"{results.Tsr:0.}";
                    }
                    using (ExcelRange rng = sheet.Cells["E10"])
                    {
                        rng.Style.Font.Bold = false;
                        rng.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        rng.Value = $"{results.Ty:0.}";
                    }

                    sheet.Cells[sheet.Dimension.Address].AutoFitColumns();
                    package.Save();
                    Process.Start(PATH);
                }
            }
            catch { }
        }
    }
}
