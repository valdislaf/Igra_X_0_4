using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace Igra_X_0_4
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        int rn = 0;
        List<Panel> panels;
        //  List<int> alphas;

        int counter_pl = 0;
        int[] sell = { -1, -1, -1, -1, -1, -1, -1, -1, -1 };
        List<int> alphas = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        int[][] win = {
            new int[]{ 0, 1, 2 },
            new int[]{ 3, 4, 5 },
            new int[]{ 6, 7, 8 },
            new int[]{ 0, 4, 8 },
            new int[]{ 2, 4, 6 },
            new int[]{ 0, 3, 6 },
            new int[]{ 1, 4, 7 },
            new int[]{ 2, 5, 8 }
        };
        //int x1 = 0;
        //int x2 = 0;
        //int x3 = 0;
        //int x4 = 0;
        //int x5 = 0;
        //int x6 = 0;
        //int x7 = 0;
        //int x8 = 0;
        //int x9 = 0;

        Color color1 = Color.Empty;
        Bitmap bmp;
        Panel panel;
        public Form1()
        {
            InitializeComponent();

            CenterToScreen();


            Redraw_all();
            this.Width = 180;
            this.Height = 200;

            //  panel11.SendToBack();
            panel11.Location = new Point(0, 0);
            panel11.Visible = true;
            panel11.Width = this.Width;
            panel11.Height = this.Height;
            panels = new List<Panel> { panel1, panel2, panel3, panel4, panel5, panel6, panel7, panel8, panel9 };


        }
        public void UpdateBitmap2(Panel panel, int alpha)
        {
            using (var g = Graphics.FromImage(bmp))
            {
                label2.Text = "" + counter_pl;
                int xLevo = 0;
                int yVerh = 0;
                int xZentr = panel1.Width / 2;
                int yZentr = panel1.Height / 2;
                int xPravo = panel1.Width;
                int yNiz = panel1.Height;
                Pen silverPen1 = new Pen(Color.Blue, 6);
                Pen silverPen2 = new Pen(Color.Red, 2);
                Pen silverPen3 = new Pen(Color.Black, 1);
                Pen silverPen4 = new Pen(Color.Silver, 1);
                g.DrawLine(silverPen3, 100, yNiz, 100, yVerh);
                g.DrawLine(silverPen3, xLevo, 100, xPravo, 100);
                SolidBrush brushB = new SolidBrush(color1);
                SolidBrush brushr = new SolidBrush(Color.Red);
                SolidBrush brushb = new SolidBrush(Color.Black);
                Font font = new Font("Consolas", 10.0f);
                Font font1 = new Font("Consolas", 28.0f);
                g.FillRectangle(brushB, 0, 0, panel.Width, panel.Height);

                if (panel == panel1) draw_X0(panel1, sell[0]);
                if (panel == panel2) draw_X0(panel2, sell[1]);
                if (panel == panel3) draw_X0(panel3, sell[2]);
                if (panel == panel4) draw_X0(panel4, sell[3]);
                if (panel == panel5) draw_X0(panel5, sell[4]);
                if (panel == panel6) draw_X0(panel6, sell[5]);
                if (panel == panel7) draw_X0(panel7, sell[6]);
                if (panel == panel8) draw_X0(panel8, sell[7]);
                if (panel == panel9) draw_X0(panel9, sell[8]);


                int a = 0;
            }
        }

        public void draw_X0(Panel panel, int x)
        {
            using (var g = Graphics.FromImage(bmp))
            {
                int n_elm = Convert.ToInt16(panel.Name.Substring(5)) - 1;
                if (x == 0)
                {
                    // if (sell[n_elm] == -1) { sell[n_elm] = 0; }
                    g.FillRectangle(new SolidBrush(Color.LightGray), 0, 0, panel.Width, panel.Height);
                    g.DrawString("0", new Font("Consolas", 28.0f), new SolidBrush(Color.Red), 3, -2);
                }

                if (x == 1)
                {
                    //  if (sell[n_elm] == -1) { sell[n_elm] = 1; }
                    g.FillRectangle(new SolidBrush(Color.LightGray), 0, 0, panel.Width, panel.Height);
                    g.DrawString("X", new Font("Consolas", 28.0f), new SolidBrush(Color.Black), 3, -2);
                }

            }
        }
        public void player_m()
        {

            if (counter_pl == 2)
            {
                if (sell[4] == -1)
                {
                    sell[4] = 0;
                    updt(panel5, alphas[4]);
                }
                if (sell[4] == 1)
                {
                    angle(new int[] { 0, 2, 6, 8 });
                }
                if (sell[4] == 0 && radioButton2.Checked == true)
                {
                    if (sell[0] != 1 && sell[8] != 1 && sell[2] != 1 && sell[6] != 1)
                    { angle(new int[] { 0, 2, 6, 8 }); }
                    else
                    {
                        if (sell[0] != 1 && sell[8] != 1)
                        { angle(new int[] { 0, 8 }); }
                        if (sell[2] != 1 && sell[6] != 1)
                        { angle(new int[] { 2, 6 }); }
                    }
                }
            }
            if (counter_pl == 3)
            {
                chek_game();
                if (radioButton1.Checked == true) //chek win on 1s
                {

                    if (!win_2_1(1, 0)) { win_1_1(0); }

                }
                if (radioButton2.Checked == true) //chek win on 0s
                {
                    if (!win_2_1(0, 0)) { win_1_1(0); }
                }
                chek_game();
            }
            if (counter_pl == 4)
            {
                chek_game();
                if (radioButton1.Checked == true) //chek win on 1s
                {

                    if (!win_2_1(1, 0)) { win_1_1(0); }

                }
                if (radioButton2.Checked == true) //chek win on 0s
                {
                    if (!win_2_1(0, 0)) { win_1_1(0); }
                }
                chek_game();
            }

            if (counter_pl == 5)
            {
                chek_game();
                if (radioButton1.Checked == true) //chek win on 1s
                {

                    if (!win_2_1(1, 0)) { win_1_1(0); }

                }
                if (radioButton2.Checked == true) //chek win on 0s
                {
                    if (!win_2_1(0, 0)) { win_1_1(0); }
                }
                chek_game();
            }
            if (counter_pl == 6)
            {
                chek_game();
                if (radioButton1.Checked == true) //chek win on 1s
                {

                    if (!win_2_1(1, 0)) { win_1_1(0); }

                }
                if (radioButton2.Checked == true) //chek win on 0s
                {
                    if (!win_2_1(0, 0)) { win_1_1(0); }
                }
                chek_game();
            }
            if (counter_pl == 7)
            {
                chek_game();
                if (radioButton1.Checked == true) //chek win on 1s
                {

                    if (!win_2_1(1, 0)) { win_1_1(0); }

                }
                if (radioButton2.Checked == true) //chek win on 0s
                {
                    if (!win_2_1(0, 0)) { win_1_1(0); }
                }
                chek_game();
            }
            if (counter_pl == 8)
            {
                chek_game();
                if (radioButton1.Checked == true) //chek win on 1s
                {

                    if (!win_2_1(1, 0)) { win_1_1(0); }

                }
                if (radioButton2.Checked == true) //chek win on 0s
                {
                    if (!win_2_1(0, 0)) { win_1_1(0); }
                }
                chek_game();
            }
            if (counter_pl == 9)
            {
                chek_game();
                if (radioButton1.Checked == true) //chek win on 1s
                {

                    if (!win_2_1(1, 0)) { win_1_1(0); }

                }
                if (radioButton2.Checked == true) //chek win on 0s
                {
                    if (!win_2_1(0, 0)) { win_1_1(0); }
                }
                chek_game();
            }

        }
        public void game_over(string s, Color color)
        {
            //panel12.Location = new Point(0, 0);
            //panel12.Visible = true;
            //panel12.Width = this.Width;
            //panel12.Height = this.Height;
            // label3.
            this.Width = 180;
            this.Height = 260;
            panel10.BackColor = color;
            label3.Text = s;
            label3.ForeColor = color;
            label3.BackColor = Color.FromArgb(0, 255, 255, 255);
            label3.Location = new Point(10, 150);
            button2.Location = new Point(30, 190);
            Redraw_all();
        }


        public void chek_game()
        {

            chek_Win();
            chek_Lost();
            chek_Drawn();
        }


        public bool chek_Drawn()
        {
            bool fl = true;
            int n_0 = 0; int n_1 = 0;
            for (int i = 0; i < win.Length; i++)
            {
                for (int k = 0; k < win[i].Length; k++)
                {
                    if ((sell[win[i][k]] == 0)) { ++n_0; }
                    if ((sell[win[i][k]] == 1)) { ++n_1; }
                }
                if ((n_0 > 0) && (n_1 > 0)) { fl = true; } else { fl = false; break; }
                n_0 = 0; n_1 = 0;
            }

            if (fl) { game_over("Drawn game", Color.Gray); Redraw_all(); }
            return fl;
        }

        public bool chek_Lost()
        {
            bool fl = false;
            int n3 = 0;
            for (int i = 0; i < win.Length; i++)
            {
                for (int k = 0; k < win[i].Length; k++)
                {
                    if ((sell[win[i][k]] == 0)) { ++n3; }
                }
                fl = (n3 == 3); n3 = 0; if (fl) { game_over("You Lost!", Color.Red); Redraw_all(); break; }
            }
            return fl;
        }
        public bool chek_Win()
        {
            bool fl = false;
            int n3 = 0;
            for (int i = 0; i < win.Length; i++)
            {
                for (int k = 0; k < win[i].Length; k++)
                {
                    if ((sell[win[i][k]] == 1)) { ++n3; }
                }
                fl = (n3 == 3); n3 = 0; if (fl) { game_over("You Win!", Color.Green); Redraw_all(); break; }
            }
            return fl;
        }


        public bool win_1_1(int out_value)
        {
            int n2_1 = 0; bool fl = false;


            for (int i = 0; i < win.Length; i++)
            {
                for (int k = 0; k < win[i].Length; k++)
                {
                    if (sell[win[i][k]] == -1) { n2_1++; }
                }
                if (n2_1 == 2)
                {
                    for (int k = 0; k < win[i].Length; k++)
                    {
                        if ((sell[win[i][k]] == -1) && (win[i][k] == 0 || win[i][k] == 2 || win[i][k] == 6 || win[i][k] == 8)) { sell[win[i][k]] = out_value; updt(panels[win[i][k]], alphas[win[i][k]]); fl = true; goto br1; }

                    }

                    angle(new int[] { win[i][0], win[i][1], win[i][2] }); fl = true; goto br1;

                }
            br1: n2_1 = 0; if (fl) { break; }
            }
        br2: return fl;
        }
        public bool win_2_1(int value, int out_value)
        {
            int v_0 = 0; bool fl = false;

            //1
            if (radioButton2.Checked == true)
            {
                for (int i = 0; i < win.Length; i++)
                {
                    for (int k = 0; k < win[i].Length; k++)
                    {
                        if (sell[win[i][k]] == 0) { v_0++; }
                    }
                    if (v_0 == 2)
                    {
                        for (int k = 0; k < win[i].Length; k++)
                        {
                            if (sell[win[i][k]] == -1) { sell[win[i][k]] = 0; updt(panels[win[i][k]], alphas[win[i][k]]); v_0 = 0; fl = true; goto br2; }
                        }

                    }
                    v_0 = 0;
                }
                for (int i = 0; i < win.Length; i++)
                {
                    for (int k = 0; k < win[i].Length; k++)
                    {
                        if (sell[win[i][k]] == 1) { v_0++; }
                    }
                    if (v_0 == 2)
                    {
                        for (int k = 0; k < win[i].Length; k++)
                        {
                            if (sell[win[i][k]] == -1) { sell[win[i][k]] = 0; updt(panels[win[i][k]], alphas[win[i][k]]); v_0 = 0; fl = true; goto br2; }
                        }

                    }
                    v_0 = 0;
                }
            }
            //0
            if (radioButton1.Checked == true)
            {
                for (int i = 0; i < win.Length; i++)
                {
                    for (int k = 0; k < win[i].Length; k++)
                    {
                        if (sell[win[i][k]] == 0) { v_0++; }
                    }
                    if (v_0 == 2)
                    {
                        for (int k = 0; k < win[i].Length; k++)
                        {
                            if (sell[win[i][k]] == -1) { sell[win[i][k]] = 0; updt(panels[win[i][k]], alphas[win[i][k]]); v_0 = 0; fl = true; goto br2; }
                        }

                    }
                    v_0 = 0;
                }
                for (int i = 0; i < win.Length; i++)
                {
                    for (int k = 0; k < win[i].Length; k++)
                    {
                        if (sell[win[i][k]] == 1) { v_0++; }
                    }
                    if (v_0 == 2)
                    {
                        for (int k = 0; k < win[i].Length; k++)
                        {
                            if (sell[win[i][k]] == -1) { sell[win[i][k]] = 0; updt(panels[win[i][k]], alphas[win[i][k]]); v_0 = 0; fl = true; goto br2; }
                        }

                    }
                    v_0 = 0;
                }
            }

            if (sell[0] != -1 && sell[2] != -1 && sell[6] != -1 && sell[8] != -1)
            {
                angle(new int[] { 1, 3, 5, 7 }); fl = true; goto br2;
            }


            int n2_1 = 0;
            for (int i = 0; i < win.Length; i++)
            {
                for (int k = 0; k < win[i].Length; k++)
                {
                    if (sell[win[i][k]] == value) { n2_1++; }
                }
                if (n2_1 == 2)
                {
                    for (int k = 0; k < win[i].Length; k++)
                    {
                        if (sell[win[i][k]] == -1) { sell[win[i][k]] = out_value; updt(panels[win[i][k]], alphas[win[i][k]]); fl = true; goto br1; }
                    }
                }
            br1: n2_1 = 0; if (fl) { break; }
            }

        br2: return fl;
        }
        public void angle(int[] free)
        {
            bool f1 = false;
            for (int i = 0; i < free.Length; i++) { if (sell[free[i]] == -1) { f1 = true; } }
            if (f1)
            {
            m02:
                rn = rnd.Next(0, 9);
                bool f2 = false;
                for (int i = 0; i < free.Length; i++) { if (rn == free[i]) { f2 = true; } }
                if (f2) { if (sell[rn] == -1) { sell[rn] = 0; } else { goto m02; } }
                else { goto m02; }
            }

            else
            {
                bool fc = false;
                for (int i = 0; i < sell.Length; i++) { if (sell[i] == -1) { fc = true; } }
                if (fc)
                {
                m03:
                    rn = rnd.Next(0, 9);
                    if (sell[rn] == -1) { sell[rn] = 0; }
                    else { goto m03; }
                }

            }
            updt(panels[rn], alphas[rn]);

        }

        void updt(Panel panel, int alpha)
        {

            typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(panel, true, null);
            if ((panel.Width != 0) && (panel.Height != 0))
            {
                bmp = new Bitmap(panel.Width, panel.Height);
                this.UpdateBitmap2(panel, alpha);
            }
            UpdateBitmap2(panel, alpha);
            panel.Refresh();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }
        private void ailphas_t_250(Panel panel, int alpha)
        {
            alpha = 0;
            while (alpha < 255)
            {
                color1 = Color.FromArgb(alpha = alpha + 1, 255, 255, 255);
                updt(panel, alpha);
            }
        }
        private void ailphas_t_10(Panel panel, int alpha)
        {
            alpha = 255;
            while (alpha > 0)
            {
                color1 = Color.FromArgb(alpha = alpha - 1, 255, 255, 255);
                updt(panel, alpha);
            }
        }
        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            ailphas_t_250(panel1, alphas[0]);
        }
        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            ailphas_t_10(panel1, alphas[0]);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            ailphas_t_250(panel2, alphas[1]);
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            ailphas_t_10(panel2, alphas[1]);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void panel3_MouseEnter(object sender, EventArgs e)
        {
            ailphas_t_250(panel3, alphas[2]);
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            ailphas_t_10(panel3, alphas[2]);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void panel4_MouseEnter(object sender, EventArgs e)
        {
            ailphas_t_250(panel4, alphas[3]);
        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            ailphas_t_10(panel4, alphas[3]);
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void panel5_MouseEnter(object sender, EventArgs e)
        {
            ailphas_t_250(panel5, alphas[4]);
        }

        private void panel5_MouseLeave(object sender, EventArgs e)
        {
            ailphas_t_10(panel5, alphas[4]);
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void panel6_MouseEnter(object sender, EventArgs e)
        {
            ailphas_t_250(panel6, alphas[5]);
        }

        private void panel6_MouseLeave(object sender, EventArgs e)
        {
            ailphas_t_10(panel6, alphas[5]);
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void panel7_MouseEnter(object sender, EventArgs e)
        {
            ailphas_t_250(panel7, alphas[6]);
        }

        private void panel7_MouseLeave(object sender, EventArgs e)
        {
            ailphas_t_10(panel7, alphas[6]);
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void panel8_MouseEnter(object sender, EventArgs e)
        {
            ailphas_t_250(panel8, alphas[7]);
        }

        private void panel8_MouseLeave(object sender, EventArgs e)
        {
            ailphas_t_10(panel8, alphas[7]);
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void panel9_MouseEnter(object sender, EventArgs e)
        {
            ailphas_t_250(panel9, alphas[8]);
        }

        private void panel9_MouseLeave(object sender, EventArgs e)
        {
            ailphas_t_10(panel9, alphas[8]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel11.SendToBack();
            panel11.Location = new Point(0, 0);
            panel11.Visible = false;
            panel11.Width = 0;
            panel11.Height = 0;
            if (radioButton2.Checked == true) { sell[4] = 0; }
            Redraw_all();
            ++counter_pl;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Redraw_all();
        }


        private void Redraw_all()
        {
            updt(panel1, alphas[0]);
            updt(panel2, alphas[1]);
            updt(panel3, alphas[2]);
            updt(panel4, alphas[3]);
            updt(panel5, alphas[4]);
            updt(panel6, alphas[5]);
            updt(panel7, alphas[6]);
            updt(panel8, alphas[7]);
            updt(panel9, alphas[8]);
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            Redraw_all();
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            if (sell[4] == -1) { sell[4] = 1; updt(panel5, alphas[4]); ++counter_pl; player_m(); }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            if (sell[0] == -1) { sell[0] = 1; updt(panel1, alphas[0]); ++counter_pl; player_m(); }
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            if (sell[1] == -1) { sell[1] = 1; updt(panel2, alphas[1]); ++counter_pl; player_m(); }
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            if (sell[2] == -1) { sell[2] = 1; updt(panel3, alphas[2]); ++counter_pl; player_m(); }
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            if (sell[3] == -1) { sell[3] = 1; updt(panel4, alphas[3]); ++counter_pl; player_m(); }
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            if (sell[5] == -1) { sell[5] = 1; updt(panel6, alphas[5]); ++counter_pl; player_m(); }
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            if (sell[6] == -1) { sell[6] = 1; updt(panel7, alphas[6]); ++counter_pl; player_m(); }
        }

        private void panel8_Click(object sender, EventArgs e)
        {
            if (sell[7] == -1) { sell[7] = 1; updt(panel8, alphas[7]); ++counter_pl; player_m(); }
        }

        private void panel9_Click(object sender, EventArgs e)
        {
            if (sell[8] == -1) { sell[8] = 1; updt(panel9, alphas[8]); ++counter_pl; player_m(); }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Restart();

        }
        private void Restart()
        {
            string[] arguments = Environment.GetCommandLineArgs();
            Debug.Assert(arguments != null && arguments.Length > 0);
            StringBuilder sb = new StringBuilder((arguments.Length - 1) * 16);
            for (int argumentIndex = 1; argumentIndex < arguments.Length - 1; argumentIndex++)
            {
                sb.Append('"');
                sb.Append(arguments[argumentIndex]);
                sb.Append("\" ");
            }
            if (arguments.Length > 1)
            {
                sb.Append('"');
                sb.Append(arguments[arguments.Length - 1]);
                sb.Append('"');
            }
            ProcessStartInfo currentStartInfo = new ProcessStartInfo();
            currentStartInfo.FileName = Path.ChangeExtension(Application.ExecutablePath, "exe");
            if (sb.Length > 0)
            {
                currentStartInfo.Arguments = sb.ToString();
            }
            Application.Exit();
            Process.Start(currentStartInfo);
        }
    }

}
