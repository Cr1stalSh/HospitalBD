using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_4
{
    public partial class reg : Form
    {
        NpgsqlConnection con = new NpgsqlConnection();
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        private Form1 form1;
        public reg(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    string query1 = "SELECT * FROM Врач;";
                    NpgsqlDataAdapter da1 = new NpgsqlDataAdapter(query1, con);
                    ds.Reset();
                    da1.Fill(ds);
                    dt = ds.Tables[0];
                    dataGridView1.DataSource = dt;
                    con.Close();
                    break;
                case 1:
                    string query2 = "SELECT * FROM Больной;";
                    NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(query2, con);
                    ds.Reset();
                    da2.Fill(ds);
                    dt = ds.Tables[0];
                    dataGridView1.DataSource = dt;
                    con.Close();
                    break;
                case 2:
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void reg_Load(object sender, EventArgs e)
        {
            con.ConnectionString = "Server=localhost; Port = 5432; User Id = " + form1.textBox1.Text + ";Database = postgres; Password=" + form1.textBox2.Text + ";";

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.ConnectionString = "Server=localhost; Port = 5432; User Id = " + form1.textBox1.Text + ";Database = postgres; Password=" + form1.textBox2.Text + ";";
                con.Open();
                string query = "insert into Прием values ('" + textBox6.Text + "','" 
                    + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text+ "','" + textBox7.Text + "');";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                cmd.ExecuteScalar();
                con.Close();
                MessageBox.Show("Данные были добавлены!");
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка! Введены не правильные данные");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            del delform = new del(this.form1);
            delform.Show();
            Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
