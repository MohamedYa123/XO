using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XO
{
    public partial class game : Form
    {
        public game()
        {
            InitializeComponent();
        }
        public int x;
        public int y;
        public int winnum;
        public GameManager manager;
        piece pc = piece.O;
        private void game_Load(object sender, EventArgs e)
        {
            manager=new GameManager(x, y, winnum);
            var heightA=GameSpace.Height; var widthA=GameSpace.Width;
            var h = heightA / y;
            var w = widthA / x;
           
            for(int i=0;i<x;i++)
            {
                for(int j=0;j<y;j++)
                {
                    Button btn= new Button();
                    btn.BackColor= Color.White;
                    btn.Name = $"{i},{j}";
                    btn.Font = new Font("tahoma", 16, FontStyle.Bold);
                    if ((i +j) % 2 == 1)
                    {
                        btn.BackColor= Color.Black;
                        btn.ForeColor= Color.White;
                    }
                    btn.Location= new Point(i*w,j*h);
                    btn.Size = new Size(w, h);
                    int tx = i;
                    int ty = j;
                    btn.Click += delegate
                    {
                        try
                        {
                            manager.put(tx, ty, pc);
                            btn.Text = pc.ToString();
                            if(pc==piece.O)
                            {
                                pc = piece.X;
                            }
                            else
                            {
                                pc = piece.O;
                            }
                        }
                        catch { }
                    };
                    GameSpace.Controls.Add(btn);

                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = manager.checkstate().ToString().Replace("_"," ") ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thinker th= new Thinker();
            Stopwatch sp=new Stopwatch();
            sp.Start();
            var f=th.FindBest(manager, pc,pc,6);
            sp.Stop();
            foreach(Control p in GameSpace.Controls)
            {
                if (p.Name == $"{f[0]},{f[1]}")
                {
                    ((Button)p).PerformClick();
                }
            }
            label2.Text = $"{f[0]} : {f[1]}  eval : {f[2]} Branches : {th.totalBranches} time{sp.ElapsedMilliseconds/1000.0} speed {th.totalBranches/(sp.ElapsedMilliseconds+1)} branch/ms";
        }
         public piece computer = piece.O;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (computer == pc)
            {
                button1.PerformClick();
            }
        }
    }
}
