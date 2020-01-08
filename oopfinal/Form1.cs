using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Speech.Synthesis;

namespace oopfinal
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer s = new SpeechSynthesizer();
        CreateAccount CA = new CreateAccount(); 
        dbopr Q = new dbopr();
        
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con;
        public void connection()
        {
            Connection cons = new Connection();
            con = cons.getconnection();
        }

        private void logbtn_Click(object sender, EventArgs e)
        {
            connection();
            DataTable dt = Q.display("select * from Userlogin where Username='" + usernametxt.Text + "' and  Password='" + passwordtxt.Text + "'");
            if (dt.Rows.Count>0)
            {
                if (dt.Rows[0]["Usertype"].ToString()=="admin")
                {
                    view Ve= new view(); 
                    this.Hide();
                    Ve.Show();
                    
                }
                else
                {
                    Attendance A = new Attendance();
                    Aid.Name = dt.Rows[0]["Username"].ToString().ToLower();
                    Aid.Id = dt.Rows[0]["Id"].ToString();
                    this.Hide();
                    A.Show();
                }
                
            }
            else
            {
                
                s.Speak("Invalid username and password");
                MessageBox.Show("Invalid username and password");
                
            
            }
        }

        private void btncreate_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            CA.Show();
        }

      

      

        private void label1_Click(object sender, EventArgs e)
        {
            Close();
        }

       

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void usernametxt_Click(object sender, EventArgs e)
        {
            usernametxt.Clear();
           usernametxt.ForeColor = Color.WhiteSmoke;
           panel1.ForeColor = Color.WhiteSmoke;
            //passwordtxt.ForeColor = Color.FromArgb(78, 184, 206);
            passwordtxt.ForeColor = Color.Yellow;
   
        }

        private void passwordtxt_Click(object sender, EventArgs e)
        {
            passwordtxt.Clear();
           // panel1.ForeColor = Color.FromArgb(78, 184, 206);
            //usernametxt.ForeColor = Color.FromArgb(78, 184, 206);
            usernametxt.ForeColor = Color.Yellow;
            //panel1.ForeColor = Color.Yellow;
            passwordtxt.ForeColor = Color.WhiteSmoke;

         }

        private void usernametxt_Leave(object sender, EventArgs e)
        {
            s.SelectVoiceByHints(VoiceGender.Female);

            if (string.IsNullOrEmpty(usernametxt.Text) == true)
            {
                s.Speak("Please enter username");
                usernametxt.Focus();
                errorProvider1.SetError(this.usernametxt, "Please enter username!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void passwordtxt_Leave(object sender, EventArgs e)
        {
            //s.SelectVoiceByHints(VoiceGender.Female);

            if (string.IsNullOrEmpty(passwordtxt.Text) == true)
            {
                s.Speak("Please enter username");
                passwordtxt.Focus();
                errorProvider2.SetError(this.passwordtxt, "Please enter username!");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

     

       

       
     

        

     

        

      




    }
}
