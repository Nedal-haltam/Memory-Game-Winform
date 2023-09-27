using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Similar_Picture_game.Properties;

namespace Similar_Picture_game
{
    public partial class Form1 : Form
    {

        readonly Random rnd = new Random();
        readonly List<Image> Images_database;
        int[] index;
        bool played;
        PictureBox pic1, pic2;
        readonly System.Timers.Timer timer;

        readonly byte diff;
        readonly int gtime;
        byte score;

        struct Game
        {
            public Label lblGame_score;
            public Label lblGame_time;
            public Panel Game_panel;
            public int intGame_time;
            public List<Image> images;
            public List<PictureBox> pictureBoxes;
            public byte precision;
        }
        Game mem_game;

        public Form1(byte diff, int time)
        {
            InitializeComponent();
            this.diff = diff;
            this.gtime = time;
            timer = new System.Timers.Timer(599)
            {
                Enabled = false
            };
            
            timer.Elapsed += Timer_Elapsed;

            Images_database = new List<Image>
            {
                Resources._1,
                Resources._2,
                Resources._3,
                Resources._4,
                Resources._5,
                Resources._6,
                Resources.a__1_,
                Resources.a__2_,
                Resources.a__3_,
                Resources.a__4_,
                Resources.a__5_,
                Resources.a__6_,
                Resources.a__7_,
                Resources.a__8_,
                Resources.a__9_,
                Resources.a__10_,
                Resources.a__11_,
                Resources.a__12_,
                Resources.a__13_,
                Resources.a__14_,
                Resources.a__15_,
                Resources.a__16_,
                Resources.a__17_,
                Resources.a__18_,
                Resources.a__19_,
                Resources.a__20_,
                Resources.a__21_,
                Resources.a__22_,
                Resources.a__23_,
                Resources.a__24_,
                Resources.a__25_,
                Resources.a__26_,
                Resources.a__27_,
                Resources.a__28_,

            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Load_game();

            Setting_game();

            Reset_game();
        }

        private void Set_Diff(Panel p , Label s , Label t , List<PictureBox> pb)
        {
            mem_game = new Game
            {
                lblGame_score = s,
                lblGame_time = t,
                Game_panel = p,
                pictureBoxes = pb,
                images = new List<Image>()
            };



            mem_game.Game_panel.Parent = this;
            mem_game.Game_panel.Visible = true;
            mem_game.Game_panel.Dock = DockStyle.Fill;
        }

        private void Load_game()
        {

            switch (diff)
            {
                case 0:
                    Set_Diff(epanel , elblscore , elbltime, new List<PictureBox> {
                        epictureBox1, epictureBox2, epictureBox3, epictureBox4, epictureBox5, epictureBox6,
                        epictureBox7, epictureBox8, epictureBox9, epictureBox10, epictureBox11, epictureBox12
                    });
                    index = new int[mem_game.pictureBoxes.Count];
                    break;

                case 1:
                    Set_Diff(mpanel , mlblscore , mlbltime , new List<PictureBox>
                    {
                        mpictureBox1,mpictureBox2,mpictureBox3,mpictureBox4,mpictureBox5,mpictureBox6,mpictureBox7,mpictureBox8,mpictureBox9,mpictureBox10,
                        mpictureBox11,mpictureBox12,mpictureBox13,mpictureBox14,mpictureBox15,mpictureBox16,mpictureBox17,mpictureBox18,mpictureBox19,mpictureBox20,
                        mpictureBox21,mpictureBox22,mpictureBox23,mpictureBox24,mpictureBox25,mpictureBox26,mpictureBox27,mpictureBox28,mpictureBox29,mpictureBox30,
                    });
                    index = new int[mem_game.pictureBoxes.Count];

                    break;

                case 2:
                    Set_Diff(hpanel , hlblscore , hlbltime , new List<PictureBox>
                {
                    hpictureBox1,
                    hpictureBox2,
                    hpictureBox3,
                    hpictureBox4,
                    hpictureBox5,
                    hpictureBox6,
                    hpictureBox7,
                    hpictureBox8,
                    hpictureBox9,
                    hpictureBox10,
                    hpictureBox11,
                    hpictureBox12,
                    hpictureBox13,
                    hpictureBox14,
                    hpictureBox15,
                    hpictureBox16,
                    hpictureBox17,
                    hpictureBox18,
                    hpictureBox19,
                    hpictureBox20,
                    hpictureBox21,
                    hpictureBox22,
                    hpictureBox23,
                    hpictureBox24,
                    hpictureBox25,
                    hpictureBox26,
                    hpictureBox27,
                    hpictureBox28,
                    hpictureBox29,
                    hpictureBox30,
                    hpictureBox31,
                    hpictureBox32,
                    hpictureBox33,
                    hpictureBox34,
                    hpictureBox35,
                    hpictureBox36,
                    hpictureBox37,
                    hpictureBox38,
                    hpictureBox39,
                    hpictureBox40,
                    hpictureBox41,
                    hpictureBox42,
                    hpictureBox43,
                    hpictureBox44,
                    hpictureBox45,
                    hpictureBox46,
                    hpictureBox47,
                    hpictureBox48,
                    hpictureBox49,
                    hpictureBox50,
                    hpictureBox51,
                    hpictureBox52,
                    hpictureBox53,
                    hpictureBox54,
                    hpictureBox55,
                    hpictureBox56,
                    hpictureBox57,
                    hpictureBox58,
                    hpictureBox59,
                    hpictureBox60,
                    hpictureBox61,
                    hpictureBox62,
                    hpictureBox63,
                    hpictureBox64,
                    hpictureBox65,
                    hpictureBox66,
                    hpictureBox67,
                    hpictureBox68,
                });
                    index = new int[mem_game.pictureBoxes.Count];
                    break;

            }
        }

        private void Setting_game()
        {
            for (int i = 0; i < index.Length / 2; i++)
                mem_game.images.Add(Images_database[i]);

            for (int i = 0; i < index.Length; i++)
                mem_game.pictureBoxes[i].Tag = index[i] = i;
        }

        private void Reset_game()
        {
            Shuffling();

            foreach(PictureBox pb in mem_game.pictureBoxes)
            {
                pb.Enabled = true;
                pb.Image = Resources.question_mark;
            }
            
            mem_game.intGame_time = gtime;
            mem_game.precision = 0;
            mem_game.lblGame_time.Text = mem_game.intGame_time.ToString();
            score = 0;
            mem_game.lblGame_score.Text = "score " + score;
            played = false;
            pic1 = pic2 = null;
            timer1.Enabled = true;
        }

        private void Shuffling()
        {
            mem_game.images = mem_game.images.OrderBy(x => rnd.Next()).ToList();
            index = index.OrderBy(x => rnd.Next()).ToArray();
        }

        private int Get_image_index(PictureBox pb)
        {
            return index[Convert.ToInt32(pb.Tag)] % mem_game.images.Count;
        }

        private void Change_image(PictureBox pb)
        {
            pb.Image = mem_game.images[Get_image_index(pb)];
        }

        private void PictureBox9_Click(object sender, EventArgs e)
        {
            Change_image(((PictureBox)sender));

            Picture_clicked(((PictureBox)sender));


            if (score == mem_game.images.Count)
            {
                timer1.Stop();

                if (MessageBox.Show("You win.\ndo you want to reset the game?", "the game is over", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    Button1_Click(ebtn, e);
                else
                    Reset_game();
            }
        }

        private bool Matching()
        {
            return mem_game.images[Get_image_index(pic1)] == mem_game.images[Get_image_index(pic2)];
        }

        private void Enabled_game(bool enable)
        {
            foreach (PictureBox p in mem_game.pictureBoxes)
            {
                p.Enabled = enable;
            }
        }

        private void Update_game(bool matched)
        {
            if(matched)
            {
                score++;
                mem_game.lblGame_score.Text = "score " + score;
                pic1.Enabled = pic2.Enabled = false;
                pic1 = pic2 = null;
            }
            else
            {
                Enabled_game(false);
                timer.Enabled = true;
            }
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Enabled_game(true);

            pic1.Image = pic2.Image = Resources.question_mark;
            pic1 = pic2 = null;

            timer.Enabled = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            Form2 form2 = new Form2();
            this.Hide();
            form2.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Change_time_label()
        {
            if (mem_game.precision == 0)
            {
                mem_game.intGame_time--;
                mem_game.precision = 9;
            }

            mem_game.lblGame_time.Text = mem_game.intGame_time.ToString() + "." + (mem_game.precision--).ToString();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (mem_game.intGame_time == 0 && mem_game.precision == 0)
            {
                mem_game.lblGame_time.Text = mem_game.intGame_time.ToString() + "." + (mem_game.precision).ToString();
                timer1.Stop();

                if (MessageBox.Show("Time Is Up.\ndo you want to reset the game?", "Game Over", MessageBoxButtons.YesNo) == DialogResult.No)
                    Button1_Click(null, e);
                else
                    Reset_game();
            }
            Change_time_label();
        }

        private void Picture_clicked(PictureBox pb)
        {
            if (!played)
            {
                pic1 = pb;
                pic1.Enabled = false;
            }
            else
            {
                pic2 = pb;
                pic2.Enabled = false;
            }

            if (played)
            {
                if (Matching())
                    Update_game(Matching());

                else
                    Update_game(Matching());

                played = false;
            }
            else
                played = true;
        }
    }
}
