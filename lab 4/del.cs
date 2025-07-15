using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab_4
{
    public partial class del : Form
    {
        NpgsqlConnection con = new NpgsqlConnection();
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        private Form1 form1;

        public del(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
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
            catch(Exception)
            {
                MessageBox.Show("У вас нет прав для чтения этой таблицы");
            }
            
             
        }

        private void del_Load(object sender, EventArgs e)
        {
            con.ConnectionString = "Server=localhost; Port = 5432; User Id = " + form1.textBox1.Text + ";Database = postgres; Password=" + form1.textBox2.Text + ";";
        }

        private void del_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (form1.textBox1.Text == "postgres")
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
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    try
                    {
                        con.ConnectionString = "Server=localhost; Port = 5432; User Id = " + form1.textBox1.Text + ";Database = postgres; Password=" + form1.textBox2.Text + ";";
                        con.Open();
                        string query = "update Инф_больной set " + textBox2.Text + " = '" + textBox3.Text + "' where n_карты =" + textBox1.Text+";";
                      NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                        cmd.ExecuteScalar();
                        con.Close();
                        MessageBox.Show("Данные были изменены!");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка! Введены не правильные данные");
                    }
                    break;
                case 1:
                    try
                    {
                        con.ConnectionString = "Server=localhost; Port = 5432; User Id = " + form1.textBox1.Text + ";Database = postgres; Password=" + form1.textBox2.Text + ";";
                        con.Open();
                        string query = "update Врач set " + textBox2.Text + " = '" + textBox3.Text + "' where id =" + textBox1.Text + ";";
                        NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                        cmd.ExecuteScalar();
                        con.Close();
                        MessageBox.Show("Данные были изменены!");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка! Введены не правильные данные");
                    }
                    break;
                case 2:
                    try
                    {
                        con.ConnectionString = "Server=localhost; Port = 5432; User Id = " + form1.textBox1.Text + ";Database = postgres; Password=" + form1.textBox2.Text + ";";
                        con.Open();
                        string query = "update Больной set " + textBox2.Text + " = '" + textBox3.Text + "' where n_карты =" + textBox1.Text + ";";
                        NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                        cmd.ExecuteScalar();
                        con.Close();
                        MessageBox.Show("Данные были изменены!");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка! Введены не правильные данные");
                    }
                    break;
                case 3:
                    try
                    {
                        con.ConnectionString = "Server=localhost; Port = 5432; User Id = " + form1.textBox1.Text + ";Database = postgres; Password=" + form1.textBox2.Text + ";";
                        con.Open();
                        string query = "update Прием set " + textBox2.Text + " = '" + textBox3.Text + "' where n_зап =" + textBox1.Text + ";";
                        NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                        cmd.ExecuteScalar();
                        con.Close();
                        MessageBox.Show("Данные были изменены!");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка! Введены не правильные данные");
                    }
                    break;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    try
                    {
                        con.ConnectionString = "Server=localhost; Port = 5432; User Id = " + form1.textBox1.Text + ";Database = postgres; Password=" + form1.textBox2.Text + ";";
                        con.Open();
                        string query = "delete from Инф_больной where n_карты =" + textBox4.Text + ";";
                        NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                        cmd.ExecuteScalar();
                        con.Close();
                        MessageBox.Show("Данные были изменены!");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка! Введены не правильные данные");
                    }
                    break;
                case 1:
                    try
                    {
                        con.ConnectionString = "Server=localhost; Port = 5432; User Id = " + form1.textBox1.Text + ";Database = postgres; Password=" + form1.textBox2.Text + ";";
                        con.Open();
                        string query = "delete from Врач where id =" + textBox4.Text + ";";
                        NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                        cmd.ExecuteScalar();
                        con.Close();
                        MessageBox.Show("Данные были изменены!");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка! Введены не правильные данные");
                    }
                    break;
                case 2:
                    try
                    {
                        con.ConnectionString = "Server=localhost; Port = 5432; User Id = " + form1.textBox1.Text + ";Database = postgres; Password=" + form1.textBox2.Text + ";";
                        con.Open();
                        string query = "delete from Больной where n_карты =" + textBox4.Text + ";";
                        NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                        cmd.ExecuteScalar();
                        con.Close();
                        MessageBox.Show("Данные были изменены!");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка! Введены не правильные данные");
                    }
                    break;
                case 3:
                    try
                    {
                        con.ConnectionString = "Server=localhost; Port = 5432; User Id = " + form1.textBox1.Text + ";Database = postgres; Password=" + form1.textBox2.Text + ";";
                        con.Open();
                        string query = "delete from Прием where n_зап =" + textBox4.Text + ";";
                        NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                        cmd.ExecuteScalar();
                        con.Close();
                        MessageBox.Show("Данные были изменены!");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка! Введены не правильные данные");
                    }
                    break;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
