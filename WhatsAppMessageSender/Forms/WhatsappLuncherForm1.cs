using OfficeOpenXml;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using LicenseContext = System.ComponentModel.LicenseContext;

namespace WhatsAppMessageSender.Forms
{
    public partial class WhatsappLuncherForm1 : Form
    {
        IWebDriver m_driver;
        private delegate void SafeCallDelegate(string text);
        private delegate void SafeCallDelegateToEnable(bool status);
        private bool bStopSendingMessage = false;
        private readonly AppDbcontext dbContext;
        private bool pauseMessaging = false;
        private bool isPaused = false;
        public WhatsappLuncherForm1()
        {
            InitializeComponent();
          
            dbContext = new AppDbcontext();
           
        }
        public void openWhatsapp()
        {
            ChromeOptions options = new ChromeOptions();
            new DriverManager().SetUpDriver(new ChromeConfig());
            m_driver = new ChromeDriver(options);
        }
        public void UpdateTextBox(string numbers, string message)
        {
            txtChatName.Text = numbers;
            txtMessage.Text = message;
        }

        public void UpdateText(int c_Id, string message)
        {
            txtMessage.Text = message;
        }
        private void btnLaunchWhatsapp_Click(object sender, EventArgs e)
        {
            openWhatsapp();
            m_driver.Url = "https://web.whatsapp.com/";
            m_driver.Manage().Window.Maximize();
        }

        private void WriteTextSafe(string text)
        {
            if (txtLogs.InvokeRequired)
            {
                var d = new SafeCallDelegate(WriteTextSafe);
                txtLogs.Invoke(d, new object[] { text });
            }
            else
            {
                txtLogs.Text = text;
            }
        }

        private void EnableSendButton(bool status)
        {
            if (sndbtn.InvokeRequired)
            {
                var d = new SafeCallDelegateToEnable(EnableSendButton);
                sndbtn.Invoke(d, new object[] { status });
            }
            else
            {
                sndbtn.Enabled = status;
            }
        }

        StringBuilder strLogs = new StringBuilder();
        private void SetText(string logString)
        {
            strLogs.AppendLine(logString);
            WriteTextSafe(strLogs.ToString());
        }

        Thread threadMessages = null;
        private bool logininfo;

        public bool IsSend { get; private set; }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            threadMessages = new Thread(new ThreadStart(SendMessages));
            threadMessages.Start();
        }

        private async void SendMessages()
        {

            bStopSendingMessage = false;

            strLogs.Clear();
            SetText("============Starting=============");
            EnableSendButton(false);
            // Get to address to list and return if it is empty.
            List<string> toChatsList = txtChatName.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (toChatsList.Count < 1)
            {
                MessageBox.Show("Please Enter Any person/group names");
                sndbtn.Enabled = true;

                return;
            }

            // Check whether the user entered any message or not.
            string messageToSend = txtMessage.Text;
            if (string.IsNullOrEmpty(messageToSend))
            {
                MessageBox.Show("Please Enter a message to send");
                sndbtn.Enabled = true;
                return;
            }

            // send messages.
            int sleepTime = 1000;
            foreach (string toChat in toChatsList)
            {
                try
                {
                    if (pauseMessaging)
                    {
                        while (isPaused)
                        {
                            await Task.Delay(1000);
                        }
                        pauseMessaging = false;
                    }

                    string toChatTrimmed = toChat.Trim();
                  
                    SetText($"Searching for chat {toChatTrimmed}: ");
                    Thread.Sleep(sleepTime);
                    var searchLense = m_driver.FindElement(By.ClassName("opCKJ"));
                    Thread.Sleep(sleepTime);
                    searchLense.Click();
                    Thread.Sleep(sleepTime);
                    m_driver.SwitchTo().ActiveElement().SendKeys(toChatTrimmed);
                    Thread.Sleep(sleepTime);

                    // Get the chat list. List size should be grater than 0.
                    var chatSearchResultList = m_driver.FindElements(By.ClassName("_199zF"));
                    Thread.Sleep(sleepTime);
                    bool bMessageSent = false;
                    foreach (IWebElement chatResultItem in chatSearchResultList)
                    {
                        if (chatResultItem != null && !string.IsNullOrEmpty(chatResultItem.Text))
                        {
                            string nameMsg = chatResultItem.Text.Split(new[] { '\r', '\n' }).FirstOrDefault();
                            if (nameMsg.Equals(toChatTrimmed) || !nameMsg.Equals(toChatTrimmed))
                            {
                                chatResultItem.Click();
                                bMessageSent = true;
                                break;
                            }
                            else if (chatSearchResultList.Count == 0)
                            {
                                break;
                            }
                        }
                        //else 
                        //{ 

                        //} 

                    }
                    if (bMessageSent)
                    {
                        SetText($"Found.");
                    }
                    else
                    {
                        SetText($"This number is Not Exits in Chatlist SO we Check its Whasapp Exists Or Not on this Number");
                    }
                    Thread.Sleep(sleepTime);
                   
                    string messageEntryField = "_3Uu1_";
                    
                    bool isSend = dbContext.CompagainDetail
                                           .Any(detail => detail.Id.ToString() == toChatTrimmed && detail.isSend);

                    if (isSend)
                    {
                        SetText($"Skipping message for number: {toChatTrimmed} as it is already marked as sent.");
                        continue;
                    }
                    else
                    {
                        if (bMessageSent)
                        {

                            var messageTextBox = m_driver.FindElement(By.ClassName(messageEntryField));
                            Thread.Sleep(sleepTime);
                            if (messageTextBox != null)
                            {
                                CompainDetailForm form3 = Application.OpenForms.OfType<CompainDetailForm>().FirstOrDefault();
                                messageTextBox.Click();
                                Thread.Sleep(sleepTime);
                                messageTextBox.SendKeys(messageToSend);
                                form3.UpdateIsSendValue();
                                SetText($"Message Placed Successfully.");
                                var compagainDetail = dbContext.CompagainDetail.FirstOrDefault(detail => detail.Number.ToString() == toChatTrimmed);
                                if (compagainDetail != null)
                                {
                                    compagainDetail.isSend = true;
                                    dbContext.SaveChanges();
                                }
                            }
                        }

                        else
                        {
                            m_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                            var checked1 = m_driver.FindElements(By.XPath("//*[@id='app']/div/div/div[2]/div[1]/div/div[2]/div")).SingleOrDefault();
                            if (checked1 == null)
                            {
                                Console.WriteLine("ENTER THE MOBILE NUMBER ");
                                var mobile = Console.ReadLine();
                                mobile = toChatTrimmed;
                                Console.WriteLine("ENTER THE MESSAGE ");
                                var msg = messageToSend;
                                var sms = Console.ReadLine();

                                Task.Run(async () =>
                                {
                                    // Send message
                                    m_driver.Navigate().GoToUrl("https://web.whatsapp.com/send?phone=" + mobile + "&text=" + Uri.EscapeDataString(msg));
                                    //await Task.Delay(500);
                                    var errormsg = m_driver.FindElements(By.XPath("//*[@id='app']/div/span[2]/div/span/div/div/div/div/div/div[2]/div/div/div/div")).SingleOrDefault();
                                    if (errormsg != null)
                                    {
                                        //await Task.Delay(500);
                                        var messageshow = m_driver.FindElement(By.XPath("//*[@id='app']/div/span[2]/div/span/div/div/div/div/div/div[1]")).Text;
                                        Console.WriteLine("Message Failed Due To " + messageshow);
                                    }
                                    else
                                    {
                                        //var adas = m_driver.FindElement(By.XPath("//*[@id='main']/footer/div[1]/div/span[2]/div/div[2]/div[2]/button")); //Click SEND Arrow Button
                                        //if (adas != null)
                                        //{
                                        //    adas.Click();
                                        //    bMessageSent = false;
                                        //    SetText($"Message Send Successfully.");



                                        //}
                                    }
                                });
                            }
                            else
                            {
                                logininfo = false;
                            }
                        }
                    }

                    if (bStopSendingMessage)
                    {
                        EnableSendButton(true);
                        SetText("============Ending==============");
                        return;
                    }
                    Thread.Sleep(sleepTime);

                    string sendMessageButton = "_3XKXx";
                    IWebElement sendbtn = null;
                    try
                    {


                        int counter = 0;
                        while (sendbtn == null)
                        {
                            sendbtn = await SendButtonFinder(sendMessageButton);
                            counter++;
                            if (counter == 2) throw new Exception("Whatsapp not exist on this number or technical issue!");
                        }

                        if (sendMessageButton != null)
                        {
                            sendbtn.Click();
                            SetText($"Message Send Successfully.");
                        }




                    }
                    catch (Exception ee)
                    {
                        var okErrorMsg = m_driver.FindElements(By.ClassName("hjo1mxmu"));
                        if (okErrorMsg != null) okErrorMsg[0].Click();
                        throw new Exception(ee.Message);
                    }
                }
                catch (Exception ex1)
                {
                    MessageBox.Show($"Error :: {ex1.Message}");
                }
            }

            EnableSendButton(true);

            SetText("============Ending==============");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Excel File(*.xlsx)|*.xlsx|Word File(*.docx)|*.docx|Text File(*.txt)|*.txt";

            if (open.ShowDialog() == DialogResult.OK)
            {
                txtChatName.Text = ReadExcelFile(open.FileName);
            }
        }
        private string ReadExcelFile(string filePath)
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
                    textContent += "," + Environment.NewLine;
                }
            }

            return textContent;
        }

        private async Task<IWebElement> SendButtonFinder(string btn)
        {
            try
            {
                return m_driver.FindElement(By.ClassName(btn));
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void btnStop_Click_1(object sender, EventArgs e)
        {
            pauseMessaging = true;
            isPaused = true;
            stopbtn.Enabled = false;
            resumbtn.Enabled = true; 
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            pauseMessaging = false;
            isPaused = false;
            stopbtn.Enabled = true; 
            resumbtn.Enabled = false;
        }

       
    }
}
