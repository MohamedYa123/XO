namespace XO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            game gm=new game();
            if (comboBox1.SelectedIndex == 0)
            {
                gm.computer = piece.X;
            }
            gm.x=(int)X.Value; gm.y=(int)Y.Value;gm.winnum=(int)numericUpDown1.Value;
            gm.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex= 0;
        }
    }
}