using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Observer
{
    public partial class Form2 : Form, IObserver
    {
        private ColorChangedSubscription changedSubscription;
        public Form2(ColorChangedSubscription colorChangedSubscription)
        {

            InitializeComponent();
            this.changedSubscription = colorChangedSubscription;
        }

        public void ColorChange(Color color)
        {
            this.BackColor = color;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            changedSubscription.Subscribe(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            changedSubscription.UnSubscribe(this);
        }
    }
}
