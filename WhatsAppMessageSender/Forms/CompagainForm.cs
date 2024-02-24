using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WhatsAppMessageSender.Forms
{
    public partial class CompagainForm : Form
    {
        private List<Compagain> compagains;
        public int selectedCompagainId = -1;
        DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
        DataGridViewButtonColumn detailButtonColumn = new DataGridViewButtonColumn();


        public CompagainForm()
        {
            InitializeComponent();
          
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadCompagains();
            AddButtonsToDataGridView();
        }

        private void LoadCompagains()
        {
            using (var dbContext = new AppDbcontext())
            {
                compagains = dbContext.Compagains.ToList();
            }

            dataGridViewMessages.DataSource = compagains;
           
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (selectedCompagainId > 0)
            {
                try
                {
                    using (var dbContext = new AppDbcontext())
                    {

                        var compagainToUpdate = dbContext.Compagains.Find(selectedCompagainId);
                        if (compagainToUpdate != null)
                        {
                            compagainToUpdate.Name = textBoxName.Text;
                            compagainToUpdate.CampaignStatus = Status.Start; // You can change the status accordingly
                            compagainToUpdate.No_Of_Participants = int.Parse(textBoxParticipants.Text);
                            compagainToUpdate.Message = textBoxMessage.Text;

                            dbContext.SaveChanges();
                        }
                        buttonSave.Text = "Save";
                    }

                    LoadCompagains();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    using (var dbContext = new AppDbcontext())
                    {
                        var newCompagain = new Compagain
                        {
                            Name = textBoxName.Text,
                            CampaignStatus = Status.Start,
                            No_Of_Participants = int.Parse(textBoxParticipants.Text),
                            Message = textBoxMessage.Text
                        };
                        selectedCompagainId = 0;
                        dbContext.Compagains.Add(newCompagain);
                        dbContext.SaveChanges();
                    }

                    LoadCompagains();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please fill the all Feild");
                }
                //LoadCompagains();
            }
        }

      

    
        private void ClearFields()
        {
            textBoxName.Text = string.Empty;
            textBoxParticipants.Text = string.Empty;
            textBoxMessage.Text = string.Empty;
            selectedCompagainId = -1;
        }

       

        private void dataGridViewMessages_CellClick(object sender, DataGridViewCellEventArgs e)
               {
            DataGridViewRow row = dataGridViewMessages.Rows[e.RowIndex];
            selectedCompagainId = 0;
            //string delete = Convert.ToString(row.Cells["Delete"].Value);
            if (e.ColumnIndex == dataGridViewMessages.Columns["DetailButton"].Index)
            {

                DataGridViewRow selectedRow = dataGridViewMessages.Rows[e.RowIndex];
                selectedCompagainId = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                string message =Convert.ToString( selectedRow.Cells["Message"].Value);

                
                CompainDetailForm form = new CompainDetailForm(selectedCompagainId, message)  ;
                form.ShowDialog();
              

            }
            else if (e.ColumnIndex == dataGridViewMessages.Columns["DeleteButton"].Index)
            {
                if (row !=null && !row.IsNewRow)
                {
                    Compagain compagain = (Compagain)row.DataBoundItem;

                 
                    using (var dbContext = new AppDbcontext())
                    {
                        dbContext.Compagains.Attach(compagain);
                        dbContext.Compagains.Remove(compagain);
                        dbContext.SaveChanges();
                    }

                    LoadCompagains();
                    //dataGridViewMessages.Rows.Remove(row);

                }
            }

            else 
            {
                buttonSave.Text = "Edit";
                DataGridViewRow selectedRow = dataGridViewMessages.Rows[e.RowIndex];
                selectedCompagainId = Convert.ToInt32(selectedRow.Cells["Id"].Value);
                textBoxName.Text = Convert.ToString(selectedRow.Cells["Name"].Value);
                textBoxParticipants.Text = Convert.ToString(selectedRow.Cells["No_Of_Participants"].Value);
                textBoxMessage.Text = Convert.ToString(selectedRow.Cells["Message"].Value);

              
            }

        }
        private void AddButtonsToDataGridView()
        {
            int lastColumnIndex = dataGridViewMessages.Columns.Count - 1;

          
            deleteButtonColumn.HeaderText = "Delete";
            deleteButtonColumn.Text = "Delete";
            deleteButtonColumn.Name = "DeleteButton";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            dataGridViewMessages.Columns.Insert(lastColumnIndex + 1, deleteButtonColumn);

           
            
            detailButtonColumn.HeaderText = "Detail";
            detailButtonColumn.Text = "Detail";
            detailButtonColumn.Name = "DetailButton";
            detailButtonColumn.UseColumnTextForButtonValue = true;
            dataGridViewMessages.Columns.Insert(lastColumnIndex + 2, detailButtonColumn);
        }

        private void textBoxParticipants_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
