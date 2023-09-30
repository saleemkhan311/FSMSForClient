using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Filling_Station_Management_System
{
    internal class SaveLedger
    {
        public static void SaveDataGridToExcel(DataGridView dataGridView)
        {


            if (dataGridView.Rows.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                save.FileName = "DataExport.xlsx";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    Excel.Application excelApp = new Excel.Application();
                    excelApp.Visible = false;
                    excelApp.DisplayAlerts = false;

                    try
                    {
                        Excel.Workbook workbook = excelApp.Workbooks.Add();
                        Excel.Worksheet worksheet = workbook.Sheets[1];

                        // Write DataGridView column headers to Excel
                        for (int col = 0; col < dataGridView.Columns.Count; col++)
                        {
                            worksheet.Cells[1, col + 1] = dataGridView.Columns[col].HeaderText;
                        }

                        // Write DataGridView data to Excel
                        for (int row = 0; row < dataGridView.Rows.Count; row++)
                        {
                            for (int col = 0; col < dataGridView.Columns.Count; col++)
                            {
                                worksheet.Cells[row + 2, col + 1] = dataGridView.Rows[row].Cells[col].Value;
                            }
                        }

                        // Save the Excel file
                        workbook.SaveAs(save.FileName);
                        workbook.Close();
                        excelApp.Quit();

                        MessageBox.Show("Data saved successfully as Excel!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while exporting data!" + ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        Marshal.ReleaseComObject(excelApp);
                    }
                }
            }
        }
    }


}
