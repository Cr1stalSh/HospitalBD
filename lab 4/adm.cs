using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab_4
{
    public partial class adm : Form
    {
        NpgsqlConnection con = new NpgsqlConnection();
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        private Form1 form1;

        /* private FormRegistry formRegistry;
         private FormDoc formdoc;*/


        public adm(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }


        private void button2_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox1.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            break;
                        }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                   string query = "SELECT * FROM Инф_больной;";
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, con);
                    ds.Reset();
                    da.Fill(ds);
                    dt = ds.Tables[0];
                    dataGridView1.DataSource = dt;
                    con.Close();
                    break;
                case 1:
                    string query1 = "SELECT * FROM Врач;";
                    NpgsqlDataAdapter da1 = new NpgsqlDataAdapter(query1, con);
                    ds.Reset();
                    da1.Fill(ds);
                    dt = ds.Tables[0];
                    dataGridView1.DataSource = dt;
                    con.Close();
                    break;
                case 2:
                    string query2 = "SELECT * FROM Больной;";
                    NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(query2, con);
                    ds.Reset();
                    da2.Fill(ds);
                    dt = ds.Tables[0];
                    dataGridView1.DataSource = dt;
                    con.Close();
                    break;
                case 3:
                    string query3 = "SELECT * FROM Прием;";
                    NpgsqlDataAdapter da3 = new NpgsqlDataAdapter(query3, con);
                    ds.Reset();
                    da3.Fill(ds);
                    dt = ds.Tables[0];
                    dataGridView1.DataSource = dt;
                    con.Close();
                    break;
            }

        }

        private void adm_Load(object sender, EventArgs e)
        {
            con.ConnectionString = "Server=localhost; Port = 5432; User Id = " + form1.textBox1.Text + ";Database = postgres; Password=" + form1.textBox2.Text + ";";
            
        }
        


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

           
        }

        private void eventLog1_EntryWritten(object sender, System.Diagnostics.EntryWrittenEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            add Addform = new add(form1);
            Addform.Show();
            Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            del delform = new del(this.form1);
            delform.Show();
            Hide();
        }
    }
}
