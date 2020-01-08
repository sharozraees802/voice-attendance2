using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;

namespace oopfinal
{
    public partial class Attendance : Form
    {
        //dbopr Q = new dbopr();
        SpeechSynthesizer s = new SpeechSynthesizer();
        Boolean wake = false;
        Choices list = new Choices();

        SqlConnection con;

        dbopr Q = new dbopr();
        public void connection()
        {
            Connection cons = new Connection();
            con = cons.getconnection();
        }

        public Attendance()
        {
            SpeechRecognitionEngine rec = new SpeechRecognitionEngine();
            //list.Add(new string[] {"one","two","three","four","five","six","seven","eight","nine","ten" });
            list.Add(File.ReadAllLines(@"C:\Users\Shehroz\Desktop\OOP\oopfinal\AttendanceId.txt"));
             //string[] english =File.ReadAllLines(@"C:\Users\Shehroz\Desktop\OOP\oopfinal\AttendanceId.txt");
           


            Grammar gr = new Grammar(new GrammarBuilder(list));
            try
            {
                rec.RequestRecognizerUpdate();
                rec.LoadGrammar(gr);
                rec.SpeechRecognized += rec_SpeechRecognized;
                //rec.SpeechRecognized += Attendance_Loadl;
                rec.SetInputToDefaultAudioDevice();
                rec.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch { return; }

            s.SelectVoiceByHints(VoiceGender.Female);
            s.Speak("Assalamalikum ");
            s.Speak("my name is amy");
            s.Speak("if you want to mark your attendance first say hey amy");
            
           

      
            
            InitializeComponent();
        }

        public void attendance()
        {
            DataTable dt = Q.display("select * from Attd where date='" + DateTime.Now.ToShortDateString() + "'and id='" + Aid.Id + "'");
            label2.Text = Aid.Name;
            label9.Text = Aid.Id;


            if (dt.Rows.Count == 0)
            {
                Q.id("insert into Attd(id,Username,date,day,Timein)values('" + Aid.Id + "','" + Aid.Name + "','" + System.DateTime.Now.ToShortDateString() + "','" + System.DateTime.Now.DayOfWeek.ToString() + "','" + System.DateTime.Now.ToShortTimeString() + "')");

            }
            if (dt.Rows.Count > 0)
            {
                Q.id("update Attd set Timeout='" + System.DateTime.Now.ToShortTimeString() + "'where date='" + DateTime.Now.ToString() + "' and id='" + Aid.Id + "'");
            }

            //s.Speak("your atteance mark");
            say("your attendance mark");

            MessageBox.Show("your attendance mark");
        }

        public void say(string h)
        {
            s.Speak(h);
            wake = false;
            textBox2.AppendText(h + "\n");

        }


       



        public void rec_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            String r = e.Result.Text;
           
            

            string converted = "";

            if (Aid.Id == "11")
            {

                converted = "eleven";
            }
            else if (Aid.Id=="3")
            {
                converted = "three";
            }
        
                else if (Aid.Id=="4")
                {
                    converted = "four";
                }

            else if (Aid.Id == "5")
            {
                converted = "five";
            }

            else if (Aid.Id == "6")
            {
                converted = "six";
            }

            else if (Aid.Id == "7")
            {
                converted = "seven";
            }

            else if (Aid.Id == "8")
            {
                converted = "eight";
            }

            else if (Aid.Id == "9")
            {
                converted = "nine";
            }

            else if (Aid.Id == "10")
            {
                converted = "ten";
            }

            else if (Aid.Id == "12")
            {
                converted = "twelve";
            }


            else if (Aid.Id == "13")
            {
                converted = "thirteen";
            }


            else if (Aid.Id == "14")
            {
                converted = "forteen";
            }


            else if (Aid.Id == "15")
            {
                converted = "fifteen";
            }


            else if (Aid.Id == "16")
            {
                converted = "sixteen";
            }


            else if (Aid.Id == "17")
            {
                converted = "seventeen";
            }

            else if (Aid.Id == "18")
            {
                converted = "eighteen";
            }

            else if (Aid.Id == "19")
            {
                converted = "ninteen";
            }

            else if (Aid.Id == "20")
            {
                converted = "twenty";
            }


            
           
            if (r == "hey amy")
            {
                
                say("Hey " + Aid.Name+" please tell me your id number");
                wake = true;
            }
            if (wake == true)
            {
               

                if (converted == "eleven" && converted == r)
                {
                    attendance();
                }
                else if (converted == "three" && converted == r)
                {
                    attendance();
                }
                else if (converted == "four" && converted == r)
                {
                    attendance();
                }

                else if (converted == "five" && converted == r)
                {
                    attendance();
                }
                else if (converted == "six" && converted == r)
                {
                    attendance();
                }
                else if (converted == "seven" && converted == r)
                {
                    attendance();
                }
                else if (converted == "eight" && converted == r)
                {
                    attendance();
                }
                else if (converted == "nine" && converted == r)
                {
                    attendance();
                }
                else if (converted == "ten" && converted == r)
                {
                    attendance();
                }
                else if (converted == "twelve" && converted == r)
                {
                    attendance();
                }
                else if (converted == "thirteen" && converted == r)
                {
                    attendance();
                }
                else if (converted == "forteen" && converted == r)
                {
                    attendance();
                }
                else if (converted == "fifteen" && converted == r)
                {
                    attendance();
                }
                else if (converted == "sixteen" && converted == r)
                {
                    attendance();
                }
                else if (converted == "seventeen" && converted == r)
                {
                    attendance();
                }
                else if (converted == "eighteen" && converted == r)
                {
                    attendance();
                }
                else if (converted == "ninteen" && converted == r)
                {
                    attendance();
                }
                else if (converted == "twenty" && converted == r)
                {
                    attendance();
                }
                
               
             
             
             
             
             
             
         }
            textBox1.AppendText(r + "\n");

            
        }

       private void Attendance_Load(object sender, EventArgs e) 
       {
       
           //s.SelectVoiceByHints(VoiceGender.Female);
           //s.Speak("Welcome " + Aid.Name);
           //label2.Text = Aid.Name;
           //label3.Text = Aid.Id;
       }
       
           

        private void btnlogout_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            Close();
            //Application.Exit();
            form.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            //Close();
            Application.Exit();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

       

      

        

    }
}
