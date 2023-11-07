using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using MySql.Data.MySqlClient;

namespace Filling_Station_Management_System
{
    public partial class StockLedger : KryptonForm
    {
        public StockLedger()
        {
            InitializeComponent();
        }

        void PetrolStockLoad()
        {
            try
            {

                string sqlPetrolStock;

                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();

                sqlPetrolStock = $"SELECT\r\n    Ref_No,\r\n    Date,\r\n    FORMAT(Total_Sale, 'C', 'en-PK') AS Total_Sale,\r\n    FORMAT(Total_Purchase, 'C', 'en-PK') AS Total_Purchase,\r\n    Available_Stock,\r\n    FORMAT(Available_Stock_Amount, 'C', 'en-PK') AS Available_Stock_Amount,\r\n    ROUND(Available_Stock_Unit_Price,4) AS Available_Stock_Unit_Price\r\nFROM petrol_stock;\r\n";

                MySqlCommand cmd = new MySqlCommand(sqlPetrolStock, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    PetrolStockDataGrid.DataSource = dataTable;
                }
                else { MessageBox.Show("No Entries in Database"); }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Diesel Stock Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        void DieselStockLoad()
        {
            try
            {
                string sqlDieselStock;

                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();

                sqlDieselStock = $"SELECT\r\n    Ref_No,\r\n    Date,\r\n    FORMAT(Total_Sale, 'C', 'en-PK') AS Total_Sale,\r\n    FORMAT(Total_Purchase, 'C', 'en-PK') AS Total_Purchase,\r\n    Available_Stock,\r\n    FORMAT(Available_Stock_Amount, 'C', 'en-PK') AS Available_Stock_Amount,\r\n    ROUND(Available_Stock_Unit_Price,4) AS Available_Stock_Unit_Price\r\nFROM diesel_stock;\r\n";

                MySqlCommand cmd = new MySqlCommand(sqlDieselStock, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                { DieselStockDataGrid.DataSource = dataTable; }
                else { MessageBox.Show("No Entries in Database"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Diesel Stock Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StockLedger_Load(object sender, EventArgs e)
        {
            PetrolStockLoad();
            DieselStockLoad();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {

            PasswordCheckPanel passCheck = new PasswordCheckPanel();
            passCheck.ShowDialog();
            if (passCheck.DialogResult != DialogResult.OK)
                return;

            string unit = (TabControl.SelectedTab.Text).ToLower();
            int ref_No = 0;
            if (unit == "petrol")
            {
                ref_No = int.Parse(PetrolStockDataGrid.SelectedRows[0].Cells[0].Value.ToString());
            }
            else if (unit == "diesel")
            {
                ref_No = int.Parse(DieselStockDataGrid.SelectedRows[0].Cells[0].Value.ToString());
            }
            else
            {
                MessageBox.Show("Select an Item To Remove");
                return;
            }

            try
            {
                if (ref_No > 0)
                {
                    MySqlConnection con = new MySqlConnection(AppSettings.ConString());
                    con.Open();
                    MySqlCommand cmd;

                    cmd = con.CreateCommand();

                    cmd.CommandText = $"DELETE FROM {unit}_stock WHERE Ref_No=@Ref_No;";
                    cmd.Parameters.AddWithValue("@Ref_No", ref_No);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    PetrolStockLoad();
                    DieselStockLoad();
                }
                else
                {
                    MessageBox.Show("Cannot Remove Last Entry");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            PetrolStockLoad();
            DieselStockLoad();
        }

        private void SaveExcelButton_Click(object sender, EventArgs e)
        {
            if (TabControl.SelectedIndex == 0)
            {
                SaveLedger.SaveDataGridToExcel(PetrolStockDataGrid, "Petrol Stock Data");
            }
            else { SaveLedger.SaveDataGridToExcel(DieselStockDataGrid, "Diesel Stock Data"); }

        }

        private void PetrolStockDataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == PetrolStockDataGrid.Rows.Count - 1)
            {
                e.CellStyle.BackColor = Color.Tomato;
            }
        }

        private void DieselStockDataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == PetrolStockDataGrid.Rows.Count - 1)
            {
                e.CellStyle.BackColor = Color.Tomato;
            }
        }
    }
}
