using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project
{
    public partial class JournalistProcess : Form
    {

        AdminForm a;
        public JournalistProcess(AdminForm admin)
        {
            InitializeComponent();

            a = admin;
            a.Visible = false;


            if (Login.language == true)
            {
                chart1.ChartAreas["ChartArea1"].AxisY.Title = "Bài Viết";
                chart1.ChartAreas["ChartArea1"].AxisX.Title = "Nhà Báo";

            }
            else
            {
                chart1.ChartAreas["ChartArea1"].AxisY.Title = "News";
                chart1.ChartAreas["ChartArea1"].AxisX.Title = "Juarnalist";

            }
            DateTime date = dateTimePicker1.Value;

            DataTable dt = Data.NewDAO.getJournalistAccount();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataTable dtCount = Data.NewDAO.getJournalistCountNewsWithMonth(Convert.ToInt32((dt.Rows[i]["AccountID"].ToString())), new DateTime(date.Year, date.Month, 01));
                chart1.Series[0].Points.AddXY(dt.Rows[i]["UserName"], dtCount.Rows[0]["newsCount"]);
            }
            chart1.Series[0].Name = date.Month + "/" + date.Year;

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM-yyyy";
        }

        private void JournalistProcess_FormClosing(object sender, FormClosingEventArgs e)
        {
            a.Visible = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try {
                foreach (var series in chart1.Series)
                {
                    series.Points.Clear();
                }

                DateTime date = dateTimePicker1.Value;

                DataTable dt = Data.NewDAO.getJournalistAccount();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataTable dtCount = Data.NewDAO.getJournalistCountNewsWithMonth(Convert.ToInt32((dt.Rows[i]["AccountID"].ToString())), new DateTime(date.Year, date.Month, 01));
                    chart1.Series[0].Points.AddXY(dt.Rows[i]["UserName"], dtCount.Rows[0]["newsCount"]);
                }

                chart1.Series[0].Name = date.Month+"/"+date.Year;
            }
            catch (Exception) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var series in chart1.Series)
                {
                    series.Points.Clear();
                }

                DataTable dt = Data.NewDAO.getJournalistAccount();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataTable dtCount = Data.NewDAO.getJournalistCountNews(Convert.ToInt32((dt.Rows[i]["AccountID"].ToString())));
                    chart1.Series[0].Points.AddXY(dt.Rows[i]["UserName"], dtCount.Rows[0]["newsCount"]);
                }
                chart1.Series[0].Name = "Total";
            }
            catch (Exception) { }
        }
    }
}
