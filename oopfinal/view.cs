using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Data.SqlClient;

namespace oopfinal
{
    public partial class view : Form
    {
        SpeechSynthesizer s = new SpeechSynthesizer();
        dbopr Q = new dbopr();
        public view()
        {
            InitializeComponent();
        }

        SqlConnection con;
        public void connection()
        {
            Connection cons = new Connection();
            con = cons.getconnection();
        }
        public void Attd()
        {
            connection();
            DataTable dt = Q.display("select * from Attd");
            dataGridView1.DataSource = dt;
        }
        public void userdata()
        {
            connection();
            DataTable dt = Q.display("select * from Userlogin");
            dataGridView1.DataSource = dt;
        }

        private void bttnlogout_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            //this.Hide();
            Close();
            form.Show();
        }

        private void view_Load(object sender, EventArgs e)
        {
            s.SelectVoiceByHints(VoiceGender.Female);
            s.Speak("Welcom admin");
            Attd();
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            connection();
            SqlCommand cmd = new SqlCommand("select * from Attd where id='"+searchtxt.Text+"'",con);
            cmd.ExecuteNonQuery();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            searchtxt.Clear();
        }

        private void btnuser_Click(object sender, EventArgs e)
        {
            userdata();
        }

        private void bttndisplay_Click(object sender, EventArgs e)
        {
            Attd();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //Close();
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

    }
}
