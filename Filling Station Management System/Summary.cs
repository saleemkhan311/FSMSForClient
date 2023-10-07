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

        }


        void DieselSummaryPurchase()
        {
            string sqlDieselPurchase;

            MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
            connection.Open();

            sqlDieselPurchase = @"SELECT
                                    purchase_date,
                                    ROUND(SUM(Kanta_Wazan1), 2) AS Total_Wazan,
                                    ROUND(SUM(Miqdar1), 2) AS Total_Quantity,
                                    ROUND(SUM(Khoraki1), 2) AS Total_Khoraki,
                                    ROUND(SUM(Safi_Miqdar1), 2) AS Total_NetQuantity,
                                    ROUND(SUM(Kharcha_Mazdoori1), 2) AS Total_Mazdoori,
                                    ROUND(SUM(Safi_Raqam1), 2) AS Net_Amount,
                                    ROUND(SUM(Total_Amount1), 2) AS Total_Amount,
                                    ROUND(SUM(Raqam_Wasool_1 + Raqam_Wasool_2 + Raqam_Wasool_3 + Raqam_Wasool_4 + Raqam_Wasool_5), 2) AS Total_Raqam_Wasool,
                                    ROUND(SUM(Baqaya1), 2) AS Baqaya
                                FROM
                                    (
                                        SELECT
                                            DATE(date) AS purchase_date,
                                            Kanta_Wazan AS Kanta_Wazan1,
                                            Miqdar AS Miqdar1,
                                            Khoraki AS Khoraki1,
                                            Saafi_Miqdar AS Safi_Miqdar1,
                                            Kharcha_Mazdoori AS Kharcha_Mazdoori1,
                                            Saafi_Raqam AS Safi_Raqam1,
                                            Total_Amount AS Total_Amount1,
                                            Amount_Paid_1 AS Raqam_Wasool_1,
                                            Amount_Paid_2 AS Raqam_Wasool_2,
                                            Amount_Paid_2 AS Raqam_Wasool_3,
                                            Amount_Paid_4 AS Raqam_Wasool_4,
                                            Amount_Paid_5 AS Raqam_Wasool_5,
                                            Baqaya AS Baqaya1
                                        FROM
                                            purchase_data_diesel
                                    ) AS combined_data
                                GROUP BY
                                    purchase_date
                                ORDER BY
                                    purchase_date;";

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
                string sqlQueryDieselSale = @"SELECT
                                                sales_date,
                                                ROUND(SUM(NetQuantityUnit2), 2) AS NetQuantityUnit2,
                                                ROUND(SUM(NetQuantityUnit3), 2) AS NetQuantityUnit3,
                                                ROUND(SUM(NetQuantityUnit4), 2) AS NetQuantityUnit4,
                                                ROUND(SUM(NetQuantityUnit2 + NetQuantityUnit3 + NetQuantityUnit4), 2) AS Total_Quantity,
                                                ROUND(SUM(AmountUnit2 + AmountUnit3 + AmountUnit4), 2) AS Total_Amount,
                                                ROUND(SUM(DiscountUnit2 + DiscountUnit3 + DiscountUnit4), 2) AS Total_Discount,
                                                ROUND(SUM(BalanceUnit2 + BalanceUnit3 + BalanceUnit4), 2) AS Net_Amount
                                            FROM
                                                (
                                                    SELECT
                                                        DATE(date) AS sales_date,
                                                        NetQuantity AS NetQuantityUnit2,
                                                        0 AS NetQuantityUnit3,
                                                        0 AS NetQuantityUnit4,
                                                        Amount AS AmountUnit2,
                                                        0 AS AmountUnit3,
                                                        0 AS AmountUnit4,
                                                        Discount AS DiscountUnit2,
                                                        0 AS DiscountUnit3,
                                                        0 AS DiscountUnit4,
                                                        Balance AS BalanceUnit2,
                                                        0 AS BalanceUnit3,
                                                        0 AS BalanceUnit4
                                                    FROM
                                                        unit2_sales_data

                                                    UNION ALL

                                                    SELECT
                                                        DATE(date) AS sales_date,
                                                        0 AS NetQuantityUnit2,
                                                        NetQuantity AS NetQuantityUnit3,
                                                        0 AS NetQuantityUnit4,
                                                        0 AS AmountUnit2,
                                                        Amount AS AmountUnit3,
                                                        0 AS AmountUnit4,
                                                        0 AS DiscountUnit2,
                                                        Discount AS DiscountUnit3,
                                                        0 AS DiscountUnit4,
                                                        0 AS BalanceUnit2,
                                                        Balance AS BalanceUnit3,
                                                        0 AS BalanceUnit4
                                                    FROM
                                                        unit3_sales_data

                                                    UNION ALL

                                                    SELECT
                                                        DATE(date) AS sales_date,
                                                        0 AS NetQuantityUnit2,
                                                        0 AS NetQuantityUnit3,
                                                        NetQuantity AS NetQuantityUnit4,
                                                        0 AS AmountUnit2,
                                                        0 AS AmountUnit3,
                                                        Amount AS AmountUnit4,
                                                        0 AS DiscountUnit2,
                                                        0 AS DiscountUnit3,
                                                        Discount AS DiscountUnit4,
                                                        0 AS BalanceUnit2,
                                                        0 AS BalanceUnit3,
                                                        Balance AS BalanceUnit4
                                                    FROM
                                                        unit4_sales_data
                                                ) AS combined_data
                                            GROUP BY
                                                sales_date
                                            ORDER BY
                                                sales_date;
                                            ";
                MySqlCommand cmd = new MySqlCommand(sqlQueryDieselSale, connection);

                // Create a SqlDataAdapter and fill the DataTable
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dataTable);
            }

            // Bind the DataTable to the DataGridView
            DieselSummaryDataGrid.DataSource = dataTable;

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
                string sqlQueryPetrolPurchase = @"SELECT
                                                    purchase_date,
                                                    ROUND(SUM(Kanta_Wazan1), 2) AS Total_Wazan,
                                                    ROUND(SUM(Miqdar1), 2) AS Total_Quantity,
                                                    ROUND(SUM(Khoraki1), 2) AS Total_Khoraki,
                                                    ROUND(SUM(Safi_Miqdar1), 2) AS Total_NetQuantity,
                                                    ROUND(SUM(Kharcha_Mazdoori1), 2) AS Total_Mazdoori,
                                                    ROUND(SUM(Safi_Raqam1), 2) AS Net_Amount,
                                                    ROUND(SUM(Total_Amount1), 2) AS Total_Amount,
                                                    ROUND(SUM(Raqam_Wasool_1 + Raqam_Wasool_2 + Raqam_Wasool_3 + Raqam_Wasool_4 + Raqam_Wasool_5), 2) AS Total_Raqam_Wasool,
                                                    ROUND(SUM(Baqaya1), 2) AS Baqaya
                                                FROM
                                                    (
                                                        SELECT
                                                            DATE(date) AS purchase_date,
                                                            Kanta_Wazan AS Kanta_Wazan1,
                                                            Miqdar AS Miqdar1,
                                                            Khoraki AS Khoraki1,
                                                            Saafi_Miqdar AS Safi_Miqdar1,
                                                            Kharcha_Mazdoori AS Kharcha_Mazdoori1,
                                                            Saafi_Raqam AS Safi_Raqam1,
                                                            Total_Amount AS Total_Amount1,
                                                            Amount_Paid_1 AS Raqam_Wasool_1,
                                                            Amount_Paid_2 AS Raqam_Wasool_2,
                                                            Amount_Paid_2 AS Raqam_Wasool_3,
                                                            Amount_Paid_4 AS Raqam_Wasool_4,
                                                            Amount_Paid_5 AS Raqam_Wasool_5,
                                                            Baqaya AS Baqaya1
                                                        FROM
                                                            purchase_data_petrol
                                                    ) AS combined_data
                                                GROUP BY
                                                    purchase_date
                                                ORDER BY
                                                    purchase_date;
                                                ";
                MySqlCommand cmd = new MySqlCommand(sqlQueryPetrolPurchase, connection);

                // Create a SqlDataAdapter and fill the DataTable
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dataTable);
            }

            // Bind the DataTable to the DataGridView
            PetrolSummaryDataGrid.DataSource = dataTable;

        }

        void PetrolSummarySale()
        {
            string sqlPetrolSale;

            try
            {
                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();


                sqlPetrolSale = @"SELECT
                                    sales_date,
                                    ROUND(SUM(NetQuantityUnit1), 2) AS Total_NetQuantity,
                                    ROUND(SUM(NetQuantityUnit1), 2) AS Total_Quantity,
                                    ROUND(SUM(AmountUnit1), 2) AS Total_Amount,
                                    ROUND(SUM(DiscountUnit1), 2) AS Total_Discount,
                                    ROUND(SUM(BalanceUnit1), 2) AS Net_Amount
                                FROM
                                    (
                                        SELECT
                                            DATE(date) AS sales_date,
                                            NetQuantity AS NetQuantityUnit1,
                                            Amount AS AmountUnit1,
                                            Discount AS DiscountUnit1,
                                            Balance AS BalanceUnit1
                                        FROM
                                            unit1_sales_data
                                    ) AS combined_data
                                GROUP BY
                                    sales_date
                                ORDER BY
                                    sales_date;
                                ";

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
