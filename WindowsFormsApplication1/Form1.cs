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
        OleDbDataAdapter da;
        DataTable dt;
        private void button1_Click(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=Database11.accdb");
            da = new OleDbDataAdapter("select * from öğrenci",con);
            dt = new DataTable();
            con.Open();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
    }
        }
    

