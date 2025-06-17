using BLL;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class ValunteerGUI : Form
    {
        int VolunteerId;
        public ValunteerGUI(int id)
        {
            InitializeComponent();
            VolunteerId = id;
        }
        ValunteerBLL valunteerBLL = new ValunteerBLL();


        //part B ex1
        private void button1_Click(object sender, EventArgs e)
        {
            //    //label1.Text= valunteerBLL.GetAllHoursHasLeft(txt1.Text);
            //    if (txt1.Text == null)
            //    {
            //        label1.Text = "ערך לא תקין";
            //    }
            //    else
            //    {
            //       int result = int.Parse(valunteerBLL.GetAllHoursHasLeft(txt1.Text));
            //    }
            //if (string.IsNullOrWhiteSpace(txt1.Text))
            //{
            //    label1.Text = "ערך לא תקין";
            //    return;
            //}

            //if (int.TryParse(txt1.Text, out int id))
            //{

            int result = valunteerBLL.GetAllHoursHasLeft(VolunteerId);
            label1.Visible = true;
            label1.Text = "You have left " + result.ToString() + " hours";
            
            //}
            //else
            //{
            //label1.Text = "יש להכניס מספר מזהה תקין";

            //}
        }





        //part B ex5

        private void button4_Click_1(object sender, EventArgs e)
        {
            //label8.Visible = true;
            //label8.Text = valunteerBLL.CountExclusiveServices(txt5.Text);

            label4.Visible = true;

            //int id;
            //if (int.TryParse(txt5.Text, out id))
            //{
            int count = valunteerBLL.CountExclusiveServices(VolunteerId);
            label4.Text = $"Special services: {count}";
            //}
            //else
            //{
            //    label8.Text = "אנא הזן מזהה מספרי תקין";
            //}
        }
        //part B ex6

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = true;
            dataGridView2.DataSource = valunteerBLL.GetAllDetails(VolunteerId);
            dataGridView2.Columns[0].HeaderText = "Name";
            dataGridView2.Columns[1].HeaderText = "Phone";
            dataGridView2.Columns[2].HeaderText = "Address";
            dataGridView2.Columns[3].HeaderText = "Context";
            dataGridView2.Columns[4].HeaderText = "Date";
            dataGridView2.Columns[5].HeaderText = "Service";
        }
        //part B ex7

        private void button6_Click(object sender, EventArgs e)
        {
            //int idV = int.Parse(textBox1.Text);
            var result = valunteerBLL.GetVolunteerHours(VolunteerId);
            MessageBox.Show(result.ToString());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }


    }
}
