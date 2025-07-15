using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace lab_4
{
    public partial class Form1 : Form
    {
        NpgsqlConnection con = new NpgsqlConnection();
        public Form1()
        {
            InitializeComponent();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            try
            {
                con.ConnectionString = "Server=localhost; Port = 5432; User Id = " + textBox1.Text + ";Database = postgres; Password=" + textBox2.Text + ";";
                con.Open();
                string Login = textBox1.Text;


                if (Login == "postgres")
                {
                    adm BD_main = new adm(this);
                    BD_main.Show();
                    Hide();
                }
                else if (Login == "doc1")
                {
                    reg formSick = new reg(this);
                    formSick.Show();
                    Hide();
                }
                else if (Login == "bol1")
                {
                    bol formDoc = new bol(this);
                    formDoc.Show();
                    Hide();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не правильный логин или пароль");

            }
            con.Close();

        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
