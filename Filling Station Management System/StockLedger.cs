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
            string sqlPetrolStock;

            MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
            connection.Open();

            sqlPetrolStock = $"SELECT * FROM `petrol_stock`";

            MySqlCommand cmd = new MySqlCommand(sqlPetrolStock, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            PetrolStockDataGrid.DataSource = dataTable;
        }



        void DieselStockLoad()
        {
            string sqlDieselStock;

            MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
            connection.Open();

            sqlDieselStock = $"SELECT * FROM `diesel_stock`";

            MySqlCommand cmd = new MySqlCommand(sqlDieselStock, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            DieselStockDataGrid.DataSource = dataTable;
        }

        private void StockLedger_Load(object sender, EventArgs e)
        {
            PetrolStockLoad();
            DieselStockLoad();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {

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
                SaveLedger.SaveDataGridToExcel(PetrolStockDataGrid);
            }
            else { SaveLedger.SaveDataGridToExcel(DieselStockDataGrid); }

        }
    }
}
