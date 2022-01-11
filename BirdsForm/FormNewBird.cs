using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BirdsForm
{
    public partial class FormNewBird : Form
    {
        public FormNewBird()
        {
            InitializeComponent();
        }

        private void buttonNewBird_Click(object sender, EventArgs e)
        {
            // grab the text the user entered and send it to the DBaccess method to add to database table Bird
            string status  = DBaccess.AddBird(textBoxBird.Text);
            // use the return value to show success
            labelStatus.Text = status;
        }
    }
}
