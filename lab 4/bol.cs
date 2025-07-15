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
    public partial class bol : Form
    {
        NpgsqlConnection con = new NpgsqlConnection();
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        private Form1 form1;

        public bol(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }


        private void bol_Load(object sender, EventArgs e)
        {
            con.ConnectionString = "Server=localhost; Port = 5432; User Id = " + form1.textBox1.Text + ";Database = postgres; Password=" + form1.textBox2.Text + ";";

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Прием_бол;";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, con);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
