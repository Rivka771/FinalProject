using BLL;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class HelpSeekrsGUI : Form
    {
        int HelpSeekerID;
        public HelpSeekrsGUI(int id)
        {
            InitializeComponent();
            HelpSeekerID = id;
        }
        ValunteerBLL valunteerBLL = new ValunteerBLL();
        RequestBLL RequestBLL = new RequestBLL();


        //part B ex2
        private void button2_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView1.DataSource = valunteerBLL.GetAvailableVolunteersByService(HelpSeekerID);
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Name";
            dataGridView1.Columns[2].HeaderText = "Phone";
        }

        //part B ex3

        private void button3_Click_1(object sender, EventArgs e)
        {
            //label5.Text = valunteerBLL.GetVolunteerAndRequestStatsForService(Convert.ToInt32(txt3.Text));

            //int id;
            //if (int.TryParse(txt3.Text, out id))
            //{
            var stats = valunteerBLL.GetVolunteerAndRequestStatsForService(HelpSeekerID);
            label6.Visible = true;
            label6.Text = $"Sum of volunteers: {stats.VolunteerCount}";
            label7.Visible = true;
            label7.Text = $"Sum of approved requests: {stats.ApprovedRequestCount}";
            //}
            //else
            //{
            //    MessageBox.Show("אנא הזן מספר תקין", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        //part B ex4
        private void button1_Click_1(object sender, EventArgs e)
        {
            //int idV = int.Parse(textBox1.Text);
            bool flag = RequestBLL.TheHoursGiven(HelpSeekerID);
            if (flag)
            {

                label4.Visible = true;
                label4.Text = "Definitely";
            }
            else
            {
                label4.Visible = true;
                label4.Text = "Unfortunately, not always";
            }
            
            //MessageBox.Show(flag.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }


    }




}


