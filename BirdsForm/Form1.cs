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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // this code runs before the first screen is drawn

            // populate the first of 3 listBox's  (NOT commboboxes, we want to se listBox
            // create a list of objects of type Region (which I had to define)
            // and then ask the SQL method GetRegions to popluate with this call
            List<Regions> RegionList = DBaccess.GetRegions();
           
            //// now set up the listBox to get its data from that List
            listBoxRegions.DataSource = RegionList;

            //// and set the hidden, corresponding value to be the DB key value for that Name
            listBoxRegions.ValueMember = "RegionID";

            //// tell it to show the Name property to the user
            listBoxRegions.DisplayMember = "RegionName";
            ////////////////////////////////////////////////////////

            List<Birds> BirdList = DBaccess.GetBird();
            listBoxBird.DataSource = BirdList;
            listBoxBird.ValueMember = "BirdID";
            listBoxBird.DisplayMember = "Name";
            ////////////////////////////////////////////////////////
            
            List<Birders> BirderList = DBaccess.GetBirder();
            listBoxBirder.DataSource = BirderList;
            listBoxBirder.ValueMember = "BirderID";
            listBoxBirder.DisplayMember = "LastName";

            updateScreen();
        }

        private void updateScreen()
        {
            dataGridView1.DataSource = DBaccess.GetCountData();
        }

        private void buttonAddEvent_Click(object sender, EventArgs e)
        {
            CountRow addCountRow = new CountRow();
            addCountRow.RegionID = listBoxRegions.SelectedValue.ToString();
            addCountRow.BirderID = 1;                               //  <<<<<<<<   need to change this to get value from a new listBoxBirders
            addCountRow.BirdID = "2";                                 //  <<<<<<<<   need to change this to get value from a new listBoxBirds
            addCountRow.Count = Convert.ToInt32(textBoxCount.Text);
            addCountRow.CountDate = Convert.ToDateTime(textBoxDate.Text);
            DBaccess.AddCount(addCountRow);

            updateScreen();  // refresh the display
        }

        private void buttonAddRegion_Click(object sender, EventArgs e)
        {
            new FormNewRegion().Show();  // opens and starts another form
        }

        private void buttonAddBirdType_Click(object sender, EventArgs e)
        {
            new FormNewBird().Show(); // opens and starts another form
        }

        private void buttonAddBirder_Click(object sender, EventArgs e)
        {
            new FormNewBirder().Show(); // opens and starts another form
        }

        private void listBoxRegions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBoxBird_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBoxBirder_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
