using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection con;
        OleDbCommand cm;
        OleDbDataAdapter da;
        DataTable dt;
        private void button1_Click(object sender, EventArgs e)
        {
            doldur();
        }

        private void doldur()
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=Database1.accdb");
            da = new OleDbDataAdapter("select * from öğrenci", con);
            dt = new DataTable();
            con.Open();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            
         }

        private void button2_Click(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=Database1.accdb");
            cm = new OleDbCommand();
            con.Open();
            cm.Connection = con;
            cm.CommandText = "insert into öğrenci (ogr_no,ogr_ad,ogr_soyad,ogr_sınıf) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
            cm.ExecuteNonQuery();
            con.Close();
            doldur();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            cm = new OleDbCommand();
            con.Open();
            cm.Connection = con;
            cm.CommandText = "delete from öğrenci where ogr_no=" + textBox1.Text + "";
            cm.ExecuteNonQuery();
            con.Close();
            doldur();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cm = new OleDbCommand();
            con.Open();
            cm.Connection = con;
            cm.CommandText = "update öğrenci set ogr_ad='" + textBox2.Text + "',ogr_soyad='" + textBox3.Text + "',ogr_sınıf='" + textBox4.Text + "' where ogr_no=" + textBox1.Text + "";
            cm.ExecuteNonQuery();
            con.Close();
            doldur();
        }
       }
     }
    

