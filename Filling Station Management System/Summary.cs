using System;
using System.Data;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using MySql.Data.MySqlClient;

namespace Filling_Station_Management_System
{
    public partial class Summary : KryptonForm
    {
        public Summary()
        {
            InitializeComponent();
        }

        private void Summery_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            TotalSaleLabel.Text = "Total Sale Diesel: " + GetTotalSale().ToString();
        }


        void DieselSummaryPurchase()
        {
            string sqlDieselPurchase;

            MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
            connection.Open();

            sqlDieselPurchase = $"SELECT\r\n\tpurchase_date,\r\n\tROUND(SUM(Kanta_Wazan1), 2) AS Total_Wazan,\r\n\t" +
                $"ROUND(SUM(Miqdar1 ), 2) AS Total_Quantity,\r\n\t" +
                $"ROUND(SUM(Khoraki1), 2) AS Total_Khoraki,\r\n\t" +
                $"ROUND(SUM(Safi_Miqdar1), 2) AS Total_NetQuantity,\r\n\t" +
                $"ROUND(SUM(Kharcha_Mazdoori1 ), 2) AS Total_Mazdoori,\r\n    " +
                $"ROUND(SUM(Safi_Raqam1 ), 2) AS Net_Amount,\r\n    " +
                $"ROUND(SUM(Total_Amount1 ), 2) AS Total_Amount,\r\n    \r\n    " +
                $"ROUND(SUM(Raqam_Wasool_1+Raqam_Wasool_2+Raqam_Wasool_3+Raqam_Wasool_4+Raqam_Wasool_5 ), 2) AS Total_Raqam_Wasool,\r\n    " +
                $"ROUND(SUM(Baqaya1 ), 2) AS Baqaya\r\nFROM \r\n   " +
                $"(\r\n\tSELECT \r\n\t     DATE(date) AS purchase_date,\r\n\t     " +
                $"Kanta_Wazan AS Kanta_Wazan1,\r\n\t     Miqdar AS Miqdar1,\r\n\t     " +
                $"Khoraki AS Khoraki1,\r\n\t     Saafi_Miqdar AS Safi_Miqdar1,\r\n        " +
                $" Kharcha_Mazdoori AS Kharcha_Mazdoori1,\r\n         Saafi_Raqam AS Safi_Raqam1,\r\n         " +
                $"Total_Amount AS Total_Amount1,\r\n       \r\n         Amount_Paid_1 AS Raqam_Wasool_1,\r\n        " +
                $" Amount_Paid_2 AS Raqam_Wasool_2,\r\n         Amount_Paid_2 AS Raqam_Wasool_3,\r\n         " +
                $"Amount_Paid_4 AS Raqam_Wasool_4,\r\n         Amount_Paid_5 AS Raqam_Wasool_5,\r\n       \r\n        " +
                $" Baqaya AS Baqaya1\r\n\tFROM purchase_data_diesel\r\n   ) AS combined_data\r\nGROUP BY \r\n\tpurchase_date \r\n" +
                $"ORDER BY \r\n\tpurchase_date;";

            MySqlCommand cmd = new MySqlCommand(sqlDieselPurchase, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            DieselSummaryDataGrid.DataSource = dataTable;
        }
        void DieselSummarySale()
        {
            // Create a DataTable to store the retrieved data
            DataTable dataTable = new DataTable();

            // Create a SqlConnection and open it
            using (MySqlConnection connection = new MySqlConnection(AppSettings.ConString()))
            {
                connection.Open();

                // Create a SqlCommand with your SQL query
                string sqlQueryDieselSale = "SELECT\r\n    sales_date,\r\n    ROUND(SUM(NetQuantityUnit2), 2) AS NetQuantityUnit2,\r\n    " +
                    "ROUND(SUM(NetQuantityUnit3), 2) AS NetQuantityUnit3,\r\n    " +
                    "ROUND(SUM(NetQuantityUnit4), 2) AS NetQuantityUnit4,\r\n    " +
                    "ROUND(SUM(NetQuantityUnit2 + NetQuantityUnit3 + NetQuantityUnit4), 2) AS Total_Quantity,\r\n    " +
                    "ROUND(SUM(AmountUnit2 + AmountUnit3 + AmountUnit4), 2) AS Total_Amount,\r\n " +
                    "   ROUND(SUM(DiscountUnit2 + DiscountUnit3 + DiscountUnit4), 2) AS Total_Discount,\r\n    " +
                    "ROUND(SUM(BalanceUnit2 + BalanceUnit3 + BalanceUnit4), 2) AS Net_Amount\r\nFROM\r\n    " +
                    "(\r\n        SELECT\r\n            DATE(date) AS sales_date,\r\n            " +
                    "NetQuantity AS NetQuantityUnit2,\r\n            0 AS NetQuantityUnit3,\r\n           " +
                    " 0 AS NetQuantityUnit4,\r\n            Amount AS AmountUnit2,\r\n           " +
                    " 0 AS AmountUnit3,\r\n            0 AS AmountUnit4,\r\n            " +
                    "Discount AS DiscountUnit2,\r\n            0 AS DiscountUnit3,\r\n            " +
                    "0 AS DiscountUnit4,\r\n            Balance AS BalanceUnit2,\r\n           " +
                    " 0 AS BalanceUnit3,\r\n            0 AS BalanceUnit4\r\n        " +
                    "FROM unit2_sales_data\r\n\r\n        UNION ALL\r\n\r\n        S" +
                    "ELECT\r\n            DATE(date) AS sales_date,\r\n           " +
                    " 0 AS NetQuantityUnit2,\r\n            NetQuantity AS NetQuantityUnit3,\r\n           " +
                    " 0 AS NetQuantityUnit4,\r\n            0 AS AmountUnit2,\r\n          " +
                    "  Amount AS AmountUnit3,\r\n            0 AS AmountUnit4,\r\n            " +
                    "0 AS DiscountUnit2,\r\n            Discount AS DiscountUnit3,\r\n           " +
                    " 0 AS DiscountUnit4,\r\n            0 AS BalanceUnit2,\r\n            " +
                    "Balance AS BalanceUnit3,\r\n            0 AS BalanceUnit4\r\n        " +
                    "FROM unit3_sales_data\r\n\r\n        UNION ALL\r\n\r\n        SELECT\r\n            " +
                    "DATE(date) AS sales_date,\r\n            0 AS NetQuantityUnit2,\r\n            " +
                    "0 AS NetQuantityUnit3,\r\n            NetQuantity AS NetQuantityUnit4,\r\n           " +
                    " 0 AS AmountUnit2,\r\n            0 AS AmountUnit3,\r\n           " +
                    " Amount AS AmountUnit4,\r\n            0 AS DiscountUnit2,\r\n          " +
                    "  0 AS DiscountUnit3,\r\n            Discount AS DiscountUnit4,\r\n        " +
                    "    0 AS BalanceUnit2,\r\n            0 AS BalanceUnit3,\r\n           " +
                    " Balance AS BalanceUnit4\r\n        FROM unit4_sales_data\r\n    ) AS combined_data\r\nGROUP BY\r\n   " +
                    " sales_date\r\nORDER BY\r\n    sales_date;";
                MySqlCommand cmd = new MySqlCommand(sqlQueryDieselSale, connection);

                // Create a SqlDataAdapter and fill the DataTable
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dataTable);
            }

            // Bind the DataTable to the DataGridView
            DieselSummaryDataGrid.DataSource = dataTable;
            TotalSaleLabel.Text = "Total Sale Diesel: " + GetTotalSale().ToString();
        }

        void PetrolSummaryPurchase()
        {
            // Create a DataTable to store the retrieved data
            DataTable dataTable = new DataTable();

            // Create a SqlConnection and open it
            using (MySqlConnection connection = new MySqlConnection(AppSettings.ConString()))
            {
                connection.Open();

                // Create a SqlCommand with your SQL query
                string sqlQueryPetrolPurchase = "SELECT\r\n\tpurchase_date,\r\n\tROUND(SUM(Kanta_Wazan1), 2) AS Total_Wazan,\r\n\tROUND(SUM(Miqdar1 ), 2) AS Total_Quantity,\r\n\tROUND(SUM(Khoraki1), 2) AS Total_Khoraki,\r\n\tROUND(SUM(Safi_Miqdar1), 2) AS Total_NetQuantity,\r\n\tROUND(SUM(Kharcha_Mazdoori1 ), 2) AS Total_Mazdoori,\r\n    ROUND(SUM(Safi_Raqam1 ), 2) AS Net_Amount,\r\n    ROUND(SUM(Total_Amount1 ), 2) AS Total_Amount,\r\n    \r\n    ROUND(SUM(Raqam_Wasool_1+Raqam_Wasool_2+Raqam_Wasool_3+Raqam_Wasool_4+Raqam_Wasool_5 ), 2) AS Total_Raqam_Wasool,\r\n    ROUND(SUM(Baqaya1 ), 2) AS Baqaya\r\nFROM \r\n   (\r\n\tSELECT \r\n\t     DATE(date) AS purchase_date,\r\n\t     Kanta_Wazan AS Kanta_Wazan1,\r\n\t     Miqdar AS Miqdar1,\r\n\t     Khoraki AS Khoraki1,\r\n\t     Saafi_Miqdar AS Safi_Miqdar1,\r\n         Kharcha_Mazdoori AS Kharcha_Mazdoori1,\r\n         Saafi_Raqam AS Safi_Raqam1,\r\n         Total_Amount AS Total_Amount1,\r\n       \r\n         Amount_Paid_1 AS Raqam_Wasool_1,\r\n         Amount_Paid_2 AS Raqam_Wasool_2,\r\n         Amount_Paid_2 AS Raqam_Wasool_3,\r\n         Amount_Paid_4 AS Raqam_Wasool_4,\r\n         Amount_Paid_5 AS Raqam_Wasool_5,\r\n       \r\n         Baqaya AS Baqaya1\r\n\tFROM purchase_data_petrol\r\n   ) AS combined_data\r\nGROUP BY \r\n\tpurchase_date \r\nORDER BY \r\n\tpurchase_date;";
                MySqlCommand cmd = new MySqlCommand(sqlQueryPetrolPurchase, connection);

                // Create a SqlDataAdapter and fill the DataTable
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dataTable);
            }

            // Bind the DataTable to the DataGridView
            PetrolSummaryDataGrid.DataSource = dataTable;

        }


        private float GetTotalSale()
        {
            float lastClosingReading = 0;


            try
            {

                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();

                string sqlCom = $"SELECT \r\n    (SELECT Round(SUM(netQuantity),2) FROM unit2_sales_data) +\r\n    (SELECT Round(SUM(netQuantity),2) FROM unit3_sales_data) +\r\n    (SELECT Round(SUM(netQuantity),2) FROM unit4_sales_data) AS TotalSumQuantity;";





                MySqlCommand cmd = new MySqlCommand(sqlCom, connection);
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    lastClosingReading = float.Parse(result.ToString());
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }

            return lastClosingReading;
        }





        void PetrolSummarySale()
        {
            string sqlPetrolSale;

            try
            {
                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();


                sqlPetrolSale = $"SELECT\r\n    sales_date,\r\n    ROUND(SUM(NetQuantityUnit1), 2) AS Total_NetQuantity,\r\n    \r\n    ROUND(SUM(NetQuantityUnit1 ), 2) AS Total_Quantity,\r\n    ROUND(SUM(AmountUnit1), 2) AS Total_Amount,\r\n    ROUND(SUM(DiscountUnit1), 2) AS Total_Discount,\r\n    ROUND(SUM(BalanceUnit1 ), 2) AS Net_Amount\r\nFROM\r\n    (\r\n        SELECT\r\n            DATE(date) AS sales_date,\r\n            NetQuantity AS NetQuantityUnit1,\r\n            Amount AS AmountUnit1,\r\n            Discount AS DiscountUnit1,\r\n            Balance AS BalanceUnit1\r\n        FROM unit1_sales_data\r\n    ) AS combined_data\r\nGROUP BY\r\n    sales_date\r\nORDER BY\r\n    sales_date;";


                MySqlCommand cmd = new MySqlCommand(sqlPetrolSale, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                PetrolSummaryDataGrid.DataSource = dataTable;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Database Error: " + ex.Message);

            }
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                PetrolSummaryPurchase();
                DieselSummaryPurchase();
            }
            else
            {
                PetrolSummarySale();
                DieselSummarySale();
            }
        }

        private void SaveExcelButton_Click(object sender, EventArgs e)
        {
            if (TabControl.SelectedIndex == 0) { SaveLedger.SaveDataGridToExcel(PetrolSummaryDataGrid); }
            else if (TabControl.SelectedIndex == 1) { SaveLedger.SaveDataGridToExcel(DieselSummaryDataGrid); }
        }
    }
}
