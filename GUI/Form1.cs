using BLL;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ValunteerBLL valunteerBLL = new ValunteerBLL();
        private void button1_Click(object sender, EventArgs e)
        {
            label4.Visible = true;
            Volunteer.Visible = true;
            textBox1.Visible = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            HelpSeeker.Visible = true;
            textBox2.Visible = true;

        }
        private void Volunteer_Click(object sender, EventArgs e)
        {
            //בדיקה האם הוזן מספר והאם המתנדב קיים במערכת
            if (textBox1.Text != null)
            {
                try
                {
                    int id = Convert.ToInt32(textBox1.Text);
                    if (!valunteerBLL.IsVolunteerExists(id))
                    {
                        MessageBox.Show("This ID is not exist");
                        return;
                    }
                    ValunteerGUI valunteerGUI = new ValunteerGUI(id);
                    valunteerGUI.Show();
                    this.Hide();
                }
                catch
                {
                    MessageBox.Show("Invalid ID");
                }
            }
            else
            {
                MessageBox.Show("You didn't enter ID of volunteer");
            }
        }
        ServiceBLL ServiceBLL = new ServiceBLL();
        private void HelpSeeker_Click(object sender, EventArgs e)
        {
            //בדיקה האם הוזן מספר והאם השירות קיים במערכת
            if (textBox1.Text != null)
            {
                try
                {
                    int id = Convert.ToInt32(textBox2.Text);
                    if (!ServiceBLL.IsServiceExists(id))
                    {
                        MessageBox.Show("This ID is not exist");
                        return;
                    }
                    HelpSeekrsGUI helpSeekrsGUI = new HelpSeekrsGUI(id);
                    helpSeekrsGUI.Show();
                    this.Hide();
                }
                catch
                {
                    MessageBox.Show("Invalid ID");
                }
            }
            else
            {
                MessageBox.Show("You didn't enter ID of service");
            }
        }

       
    }
}
