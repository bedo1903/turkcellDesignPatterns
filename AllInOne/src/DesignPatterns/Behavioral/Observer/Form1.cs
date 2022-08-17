namespace Observer
{
    public partial class Form1 : Form
    {
        private ColorChangedSubscription _colorChangedSubscription = new ColorChangedSubscription();
        public Form1()
        {
            InitializeComponent();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form2 form2 = new Form2(_colorChangedSubscription);
            form2.Show();
        }

        private void buttonRenkDegistir_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                
                _colorChangedSubscription.Color = colorDialog.Color;
            }
        }
    }
}