using System;
using System.Data;

namespace NJCourts.Models
{
    internal static class DataTableExtensions
    {
        public static void ExportToExcel(this DataTable tableToExport, string outputPath = null)
        {
            try
            {
                int columnsCount = tableToExport.Columns.Count;
                int rowsCount = tableToExport.Rows.Count;
                if (tableToExport == null || columnsCount * rowsCount == 0)
                {
                    throw new Exception("ExportToExcel: Null or empty input table!\n");
                }

                // Load Excel, and create a new workbook
                var excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Workbooks.Add();

                // Single worksheet
                Microsoft.Office.Interop.Excel._Worksheet Worksheet = excel.ActiveSheet;
                object[] Header = new object[columnsCount];

                // Column headings               
                for (int i = 0; i < columnsCount; i++)
                    Header[i] = tableToExport.Columns[i].ColumnName;

                Microsoft.Office.Interop.Excel.Range HeaderRange = Worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[1, 1]), (Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[1, columnsCount]));
                HeaderRange.Value = Header;
                HeaderRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                HeaderRange.Font.Bold = true;

                // DataCells
                int RowsCount = tableToExport.Rows.Count;
                object[,] Cells = new object[rowsCount, columnsCount];

                for (int j = 0; j < rowsCount; j++)
                    for (int i = 0; i < columnsCount; i++)
                        Cells[j, i] = tableToExport.Rows[j][i];

                Worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[2, 1]), (Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[rowsCount + 1, columnsCount])).Value = Cells;

                // Check filepath
                if (outputPath != null && outputPath != "")
                {
                    try
                    {
                        Worksheet.SaveAs(outputPath);
                        excel.Quit();
                        //System.Windows.MessageBox.Show("Excel file saved!");
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("ExportToExcel: Excel file could not be saved! Check filepath.\n"
                            + ex.Message);
                    }
                }
                else    // no filepath is given
                {
                    excel.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ExportToExcel: \n" + ex.Message);
            }
        }
    }
}
