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

namespace lab_4
{
    public partial class add : Form
    {
        private Form1 form1;
        private adm BD;
        NpgsqlConnection con = new NpgsqlConnection();
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        /* private FormRegistry formRegistry;
         private FormDoc formdoc;*/

        public add(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
           
        }


        private void add_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.ConnectionString = "Server=localhost; Port = 5432; User Id = " + form1.textBox1.Text + ";Database = postgres; Password=" + form1.textBox2.Text + ";";
                con.Open();
                string query = "insert into Врач(ФИО, Специальность) values ('" + textBox1.Text + "','" + textBox2.Text +"');";
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void add_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (form1.textBox1.Text == "postgres" )
            {
                adm BD = new adm(form1);
                BD.Show();
                Hide();
            }
            else
            {
                if (form1.textBox1.Text == "doc1")
                {
                   reg formDoc = new reg(form1);
                    formDoc.Show();
                    Hide();
                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.ConnectionString = "Server=localhost; Port = 5432; User Id = " + form1.textBox1.Text + ";Database = postgres; Password=" + form1.textBox2.Text + ";";
                con.Open();
                string query = "insert into Больной values (" + textBox4.Text + ",'" + textBox5.Text + "');";
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
    }
}
