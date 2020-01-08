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
    public partial class CreateAccount : Form
    {
        SpeechSynthesizer s = new SpeechSynthesizer();
        dbopr Q = new dbopr();

        public CreateAccount()
        {
            InitializeComponent();
        }

        SqlConnection con;
        DataTable dt;
        public void connection()
        {
            Connection cons = new Connection();
            con = cons.getconnection();
        }
        public void load()
        {
            dt = Q.display("select * from Userlogin");
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(usernametxt.Text) == true)
            {
                usernametxt.Focus();
                errorProvider1.SetError(this.usernametxt, "Please enter username!");


            }
            else if (string.IsNullOrEmpty(passwordtxt.Text) == true)
            {
                passwordtxt.Focus();
                errorProvider2.SetError(this.passwordtxt, "Please enter password!");
            }
            else if (passwordtxt.Text != conformtxt.Text)
            {
                conformtxt.Focus();
                errorProvider3.SetError(this.conformtxt, "Password is not match!");
            }

            else if (string.IsNullOrEmpty(usertypetxt.Text) == true)
            {
                usertypetxt.Focus();
                errorProvider4.SetError(this.usertypetxt, "fill this block");

            }
            else  if (string.IsNullOrEmpty(usertypetxt.Text) == true || usertypetxt.Text != "student" && usertypetxt.Text != "teacher")
            {
                usertypetxt.Focus();
                errorProvider4.SetError(this.usertypetxt, "Please enter only usertype teacher aur student");



            }
        

            else
            {
                s.SelectVoiceByHints(VoiceGender.Female);
                errorProvider1.Clear();
                errorProvider2.Clear();
                errorProvider4.Clear();
                errorProvider3.Clear();


                connection();
                // dt = Q.display("insert into vlogin(Username,Password,User_type)values('" + usernametxt.Text + "','" + passwordtxt.Text + "','" + usertypetxt.Text + "')");
                SqlCommand cmd = new SqlCommand("insert into Userlogin(Username,Password,Usertype)values('" + usernametxt.Text + "','" + passwordtxt.Text + "','" + usertypetxt.Text + "')", con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("your data Successfully inserted");
                s.Speak("your data Successfully inserted");
                load();
                Form1 login = new Form1();
                this.Hide();
                login.Show();
            }


        }

        private void usernametxt_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(usernametxt.Text) == true)
            {
                usernametxt.Focus();
               // s.Speak("Please enter username");
                errorProvider1.SetError(this.usernametxt, "Please enter username!");
            }
            else
            {
                errorProvider1.Clear();
            }

        }

       

        private void conformtxt_Leave(object sender, EventArgs e)
        {

            if (passwordtxt.Text != conformtxt.Text)
            {
                conformtxt.Focus();
                //s.Speak("password is not match");
                errorProvider3.SetError(this.conformtxt, "Password is not match!");
            }
            else
            {
                errorProvider3.Clear();
            }

        }

        private void usertypetxt_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(usertypetxt.Text) == true || usertypetxt.Text != "student" && usertypetxt.Text != "teacher")
            {
                usertypetxt.Focus();
                errorProvider4.SetError(this.usertypetxt, "Please enter only usertype teacher aur student");

            

            }
            else
            {
                errorProvider4.Clear();
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            this.Hide();
            login.Show();
        }

        private void passwordtxt_Leave(object sender, EventArgs e)
        {
            
        
            if (string.IsNullOrEmpty(passwordtxt.Text) == true)
            {
                passwordtxt.Focus();
                //s.Speak("Please enter password");
                errorProvider2.SetError(this.passwordtxt, "Please enter password!");
            }
            else
            {
                errorProvider2.Clear();
            }
        
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void usernametxt_Click(object sender, EventArgs e)
        {
            usernametxt.Clear();
            usernametxt.ForeColor = Color.WhiteSmoke;
            passwordtxt.ForeColor = Color.Yellow;
            conformtxt.ForeColor = Color.Yellow;
            usertypetxt.ForeColor = Color.Yellow;
        }

        private void passwordtxt_Click(object sender, EventArgs e)
        {
            passwordtxt.Clear();
            passwordtxt.ForeColor = Color.WhiteSmoke;
            conformtxt.ForeColor = Color.Yellow;
            usernametxt.ForeColor = Color.Yellow;
            usertypetxt.ForeColor = Color.Yellow;

        }

        private void conformtxt_Click(object sender, EventArgs e)
        {
            conformtxt.Clear();
            conformtxt.ForeColor = Color.WhiteSmoke;
            usernametxt.ForeColor = Color.Yellow;
            passwordtxt.ForeColor = Color.Yellow;
            usertypetxt.ForeColor = Color.Yellow;
        }

        private void usertypetxt_Click(object sender, EventArgs e)
        {
            usertypetxt.Clear();
            usertypetxt.ForeColor = Color.WhiteSmoke;
            usernametxt.ForeColor = Color.Yellow;
            passwordtxt.ForeColor = Color.Yellow;
            conformtxt.ForeColor = Color.Yellow;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Close();
          // Application.Exit();
        }

      

        



    }
}
