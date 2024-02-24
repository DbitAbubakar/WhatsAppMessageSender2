using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace WhatsAppMessageSender.Forms
{
    public partial class CompainDetailForm : Form
    {
        private List<CompagainDetail> CompagainDetail;
        private AppDbcontext _context;
        private int _selectedCompagainId;
        private string msg;

        public CompainDetailForm(int selectedCompagainId , string message)
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            _context = new AppDbcontext();
            _selectedCompagainId = selectedCompagainId;
            msg = message;
            textBox1.Text= selectedCompagainId.ToString();
            dataGridView1.DataSource = _context.CompagainDetail.ToList();
            LoadCompagainDetails(selectedCompagainId );
        }

        private void LoadCompagains()
        {
            using (var dbContext = new AppDbcontext())
            {
                CompagainDetail = dbContext.CompagainDetail.ToList();
            }

            dataGridView1.DataSource = CompagainDetail;
        }
        private void Form3_Load(object sender, EventArgs e)
        {
           
            DisplayCompagainDetails();
           
        }
        private void DisplayCompagainDetails()
        {
           

        }

        private void btnImportNumbers_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Excel File(*.xlsx)|*.xlsx|Word File(*.docx)|*.docx|Text File(*.txt)|*.txt";

            if (open.ShowDialog() == DialogResult.OK)
            {
                textBoxNumbers.Text = ReadExcel(open.FileName);
            }
        }
        private string ReadExcel(string filePath)
        {
            string textContent = "";

            using (ExcelPackage package = new ExcelPackage(new System.IO.FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                int rowCount = worksheet.Dimension.Rows;
                int colCount = worksheet.Dimension.Columns;

                for (int row = 1; row <= rowCount; row++)
                {
                    for (int col = 1; col <= colCount; col++)
                    {
                        textContent += worksheet.Cells[row, col].Text;
                    }
                    if (row == rowCount)
                    {
                        break;
                    }
                    textContent += "," + Environment.NewLine;
                }
            }

            return textContent;



        }

           



        

        private void btnSave_Click(object sender, EventArgs e)
        {
            string[] numbersArray = textBoxNumbers.Text.Split(',');

            
            foreach (string numberStr in numbersArray)
            {
                
                if (long.TryParse(numberStr.Trim(), out long number))
                {
                    bool isSend = false;
                    int id = int.Parse( textBox1.Text);

                    
                    CreateCompagainDetail(number, isSend , id);
                }
                else
                {
                    
                    MessageBox.Show($"Invalid number format: {numberStr}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            textBoxNumbers.Clear();
            //textBox1.Clear(); 

            DisplayCompagainDetails();
            LoadCompagains();
        }
        private void CreateCompagainDetail(long number, bool isSend , int c_Id)
        {
            try
            {
                var compagainDetail = new CompagainDetail
                {
                    Number = number,
                    isSend = isSend,
                    C_Id = c_Id,
                    //Compagain = c_Id
                };

                _context.CompagainDetail.Add(compagainDetail);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show($"Error occurred while creating CompagainDetail: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void button4_Click(object sender, EventArgs e)
        //{

        //    string numbers = GetNumbersByC_ID(_selectedCompagainId);

        //    // Find the instance of Form1 and call the UpdateTextBox method
        //    //Form1 form1 = Application.OpenForms.OfType<Form1>().FirstOrDefault();
        //    WhatsappLuncherForm form1 = new WhatsappLuncherForm();
        //    if (numbers != null)
        //    {

        //        form1.UpdateTextBox(numbers, msg);

        //        form1.ShowDialog();
        //    }



        //}

        private void button4_Click(object sender, EventArgs e)
        {

            string numbers = GetNumbersByC_ID(_selectedCompagainId);


            if (!string.IsNullOrEmpty(numbers))
            {
                string[] individualNumbers = numbers.Split(',');

              

                List<string> unsentNumbers = individualNumbers
    .Where(number => _context.CompagainDetail
                        .Any(detail => detail.C_Id == _selectedCompagainId && detail.Number.ToString() == number && detail.isSend == false))
    .ToList();

                if (unsentNumbers.Any())
                {

                    string unsentNumbersString = string.Join(",", unsentNumbers);


                   
                    WhatsappLuncherForm1 form1 = new WhatsappLuncherForm1();
                    form1.UpdateTextBox(unsentNumbersString, msg);
                    form1.ShowDialog();
                }
                else
                {
                    MessageBox.Show("There are no numbers to send messages to for this Compagain.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("There are no numbers to send messages to for this Compagain.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private string GetNumbersByC_ID(int campaignId)
        {
            using (var context = new AppDbcontext())
            {
                
                var numbers = context.CompagainDetail
                                     .Where(detail => detail.C_Id == campaignId)
                                     .Select(detail => detail.Number)
                                     .ToList();

             
                return string.Join(",", numbers);
            }
        }
        public void UpdateIsSendValue()
        {

            dataGridView1.Rows[0].Cells["IsSend"].Value = true;
        }
        private void LoadCompagainDetails(int selectedCompagainId)
        {
           
            CompagainDetail = _context.CompagainDetail.Where(detail => detail.C_Id == selectedCompagainId).ToList();
            dataGridView1.DataSource = CompagainDetail;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Name != "Number")
                {
                    column.Visible = false;
                }
            }
        }
        

    }
}
