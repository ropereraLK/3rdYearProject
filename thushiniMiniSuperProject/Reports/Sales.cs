using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Media;
using System.Globalization;
using System.Windows.Forms.DataVisualization.Charting;

namespace thushiniMiniSuperProject.Reports
{
    public partial class Sales : Form
    {


        public Sales()
        {
            InitializeComponent();
        }



        private void Sales_Load(object sender, EventArgs e)
        {
            //TextBox Values
            cmbSelect.Text = "Yearly";
            //  cmbType.Text = "By Qty";
            cmbYear.Text = "2019";
            cmbMonth.Text = "January";
            //  cmbCategory.Text = "Select";
            //  cmbSubC.Text = "Select";
            // cmbProduct.Text = "Select";

        }

        private void updateDataGridView(String queryString, String duration)
        {
            //Removing previous content
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = duration;
            dataGridView1.Columns[1].Name = "Sales Amount";

            dbString dbc = new dbString();
            string conString = dbc.connectionSring;
            MySqlConnection con = new MySqlConnection(conString);

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(queryString, con);
                MySqlDataReader rdr = cmd.ExecuteReader();
                int i = 1;

                while (rdr.Read() && i<33)
                {
                    if (cmbSelect.Text == "Daily")
                    {
                       
                        {
                            for (int x = 0; x < 32; x++) {
                                if (rdr[0].ToString() == ("0" + i.ToString() + "-08-2019"))
                                {
                                    string[] row1 = new string[] { (rdr[0]).ToString(), (rdr[1]).ToString() };
                                    dataGridView1.Rows.Add(row1);
                                    break;
                                }
                                else if (rdr[0].ToString() == i.ToString() + "-08-2019")
                                {
                                    string[] row1 = new string[] { (rdr[0]).ToString(), (rdr[1]).ToString() };
                                    dataGridView1.Rows.Add(row1);
                                    break;
                                }
                                else
                                {
                                    string[] row1 = new string[] { i + ("-08-2019").ToString(), "0" };
                                    dataGridView1.Rows.Add(row1);
                                    i++;
                                }
                            }
                        }
                      
                    }

                    
                    else

                    {

                        string[] row = new string[] { (rdr[0]).ToString(), (rdr[1]).ToString() };
                        dataGridView1.Rows.Add(row);
                    }
                    i++;
                }
            }
            catch (Exception exec)
            {
                MessageBox.Show("Erro r" + exec);
            }
            finally
            {
                con.Close();
            }
        }

        private void cmbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSelect.Text == "Yearly")
            {
                cmbYear.Hide();
                cmbMonth.Hide();
                lblMonth.Hide();
                lblYear.Hide();


            }
            else if (cmbSelect.Text == "Monthly")
            {
                cmbMonth.Hide();
                cmbYear.Show();
                lblMonth.Hide();
                lblYear.Show();


            }
            else if (cmbSelect.Text == "Daily")
            {
                cmbMonth.Show();
                cmbYear.Show();
                lblMonth.Show();
                lblYear.Show();



            }
            String queryString = "";
            String duration = "";
            if (cmbSelect.Text == "Monthly")
            {
                cmbSelect.Text = "Monthly";
                queryString = "SELECT DATE_FORMAT(salesDate,  '%m-%Y'), SUM(salesTotal)FROM salestable GROUP BY DATE_FORMAT(salesDate, '%m-%Y')";
                duration = "Month-Year";
            }
            else if (cmbSelect.Text == "Daily")
            {
                int MonthNumber;
                if (cmbMonth.Text == "January")
                {
                    MonthNumber = 1;
                }
                else if (cmbMonth.Text == "February")
                {
                    MonthNumber = 2;
                }
                else if (cmbMonth.Text == "March")
                {
                    MonthNumber = 3;
                }
                else if (cmbMonth.Text == "April")
                {
                    MonthNumber = 4;
                }
                else if (cmbMonth.Text == "May")
                {
                    MonthNumber = 5;
                }
                else if (cmbMonth.Text == "June")
                {
                    MonthNumber = 6;
                }
                else if (cmbMonth.Text == "July")
                {
                    MonthNumber = 7;
                }
                else if (cmbMonth.Text == "August")
                {
                    MonthNumber = 8;
                }
                else if (cmbMonth.Text == "September")
                {
                    MonthNumber = 9;
                }
                else if (cmbMonth.Text == "October")
                {
                    MonthNumber = 10;
                }
                else if (cmbMonth.Text == "November")
                {
                    MonthNumber = 11;
                }
                else if (cmbMonth.Text == "December")
                {
                    MonthNumber = 12;
                }
                else
                {
                    MonthNumber = 0;
                }
                cmbSelect.Text = "Daily";
                queryString = @"SELECT DATE_FORMAT(salesDate, '%d-%m-%Y'), SUM(salesTotal)FROM salestable WHERE month(`salesDate`) = '" + MonthNumber + "' and YEAR(`salesDate`)= '2019' GROUP BY DATE_FORMAT(salesDate, '%d-%m-%Y') order by  DATE_FORMAT(salesDate, '%d-%m-%Y') ";
                duration = "Date";
            }
            else
            {
                cmbSelect.Text = "Yearly";
                queryString = "SELECT DATE_FORMAT(salesDate, '%Y'), SUM(salesTotal)FROM salestable GROUP BY DATE_FORMAT(salesDate, '%Y')";
                duration = "Year";

            }


            updateDataGridView(queryString, duration);
            fillChart();
            queryString = "";
            duration = "";
            //chart1.Series(0).Points(result.PointIndex).AxisLabel.ToString();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void fillChart()
        {
            
            chart1.Series.Clear();
            Series s = new Series("Value");
            chart1.Series.Add(s);

           
            for (int counter = 0; counter < (dataGridView1.Rows.Count); counter++)
            {
                //string x = (dataGridView1.Rows[counter].Cells[0].Value).ToString();
                chart1.Series["Value"].Points.AddXY(counter + 1, dataGridView1.Rows[counter].Cells[1].Value);

            }
            //chart1.Series(0).Points(result.PointIndex).AxisLabel.ToString();
            var chartArea = new ChartArea("MyChart");
             

           

            

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            String queryString = "";
            String duration = "";
            if (cmbSelect.Text == "Monthly")
            {
                cmbSelect.Text = "Monthly";
                queryString = "SELECT DATE_FORMAT(salesDate,  '%m-%Y'), SUM(salesTotal)FROM salestable GROUP BY DATE_FORMAT(salesDate, '%m-%Y')";
                duration = "Month-Year";
            }
            else if (cmbSelect.Text == "Daily")
            {
                int MonthNumber;
                if (cmbMonth.Text == "January")
                {
                    MonthNumber = 1;
                }
                else if (cmbMonth.Text == "February")
                {
                    MonthNumber = 2;
                }
                else if (cmbMonth.Text == "March")
                {
                    MonthNumber = 3;
                }
                else if (cmbMonth.Text == "April")
                {
                    MonthNumber = 4;
                }
                else if (cmbMonth.Text == "May")
                {
                    MonthNumber = 5;
                }
                else if (cmbMonth.Text == "June")
                {
                    MonthNumber = 6;
                }
                else if (cmbMonth.Text == "July")
                {
                    MonthNumber = 7;
                }
                else if (cmbMonth.Text == "August")
                {
                    MonthNumber = 8;
                }
                else if (cmbMonth.Text == "September")
                {
                    MonthNumber = 9;
                }
                else if (cmbMonth.Text == "October")
                {
                    MonthNumber = 10;
                }
                else if (cmbMonth.Text == "November")
                {
                    MonthNumber = 11;
                }
                else if (cmbMonth.Text == "December")
                {
                    MonthNumber = 12;
                }
                else
                {
                    MonthNumber = 0;
                }
                cmbSelect.Text = "Daily";
                queryString = @"SELECT DATE_FORMAT(salesDate, '%d-%m-%Y'), SUM(salesTotal)FROM salestable WHERE month(`salesDate`) = '" + MonthNumber + "' and YEAR(`salesDate`)= '2019' GROUP BY DATE_FORMAT(salesDate, '%d-%m-%Y')";
                duration = "Date";

                updateDataGridView(queryString, duration);
                fillChart();
            }
        }
    }
}
