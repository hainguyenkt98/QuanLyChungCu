using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Net;
using System.Net.NetworkInformation;

namespace QuanLyChungCu
{
    public partial class fKetNoiDataBase : DevExpress.XtraEditors.XtraForm
    {
        public delegate void HandleEventConnetion();
        public event HandleEventConnetion eventConnection;
        public fKetNoiDataBase()
        {
            InitializeComponent();
            Task taskScanIP = new Task(ScanIP);
            taskScanIP.Start();
            taskScanIP.Wait();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=" + cboIP.Text.Trim() + ";Initial Catalog=" + txtTenDB.Text.Trim() + ";User ID=" + txtTaiKhoanDB.Text.Trim() + ";Password=" + txtMatKhauDB.Text.Trim() + "";
            DataLinqDataContext context = new DataLinqDataContext(connectionString);

            try
            {
                CanHo ch = context.CanHos.FirstOrDefault();
                PropertieConst.connectionString = connectionString;
                PropertieConst.accountDB = txtTaiKhoanDB.Text.Trim();
                PropertieConst.passDB = txtMatKhauDB.Text.Trim();
                OnEventConnection();
            }
            catch
            {
                MessageBox.Show("Thông tin kết nối tới cơ sở dữ liệu không chính xác !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void OnEventConnection()
        {
            if (eventConnection != null)
            {
                eventConnection();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async void ScanIP()
        {

            string pingIP = "";
            string baseIP = "";
            string hostName = Dns.GetHostName(); // Retrive the Name of HOST  
            for (int w = 0; w < Dns.GetHostByName(hostName).AddressList.Count(); w++)
            {
                string myIP = Dns.GetHostByName(hostName).AddressList[w].ToString();
                string submetMarsk = Dns.GetHostByName(hostName).AddressList[w].ToString();
                int coutDot = 0;

                string firstOctet = "";
                for (int i = 0; i < myIP.Length; i++)
                {
                    if (myIP[i].Equals('.'))
                    {
                        coutDot++;
                    }
                    if (coutDot == 1)
                    {
                        firstOctet = myIP.Substring(0, i + 1);
                        break;
                    }
                }

                firstOctet = firstOctet.Substring(0, firstOctet.Length - 1);



                if (classIP(firstOctet) == "A")
                {
                    coutDot = 0;
                    for (int i = 0; i < myIP.Length; i++)
                    {
                        if (myIP[i].Equals('.'))
                        {
                            coutDot++;
                        }
                        if (coutDot == 1)
                        {
                            baseIP = myIP.Substring(0, i + 1);
                            break;
                        }
                    }


                    for (int e = 0; e <= 255; e++)
                    {
                        string secondOctet = e.ToString();

                        for (int i = 0; i <= 255; i++)
                        {
                            string thirdOctet = i.ToString();
                            pingIP = "";


                            for (int j = 1; j < 255; j++)
                            {
                                pingIP = baseIP + secondOctet + "." + thirdOctet + "." + j.ToString();
                                Ping ping = new Ping();
                                PingReply pingresult = await ping.SendPingAsync(pingIP, 100);
                                if (pingresult.Status.ToString() == "Success")
                                {
                                    if (cboIP.InvokeRequired)
                                    {
                                        cboIP.Invoke((MethodInvoker)delegate ()
                                        {
                                            cboIP.Items.Add(pingIP);
                                        });
                                    }
                                    else
                                    {
                                        cboIP.Items.Add(pingIP);
                                    }
                                }
                            }
                        }
                    }

                }
                if (classIP(firstOctet) == "B")
                {
                    coutDot = 0;
                    for (int i = 0; i < myIP.Length; i++)
                    {
                        if (myIP[i].Equals('.'))
                        {
                            coutDot++;
                        }
                        if (coutDot == 2)
                        {
                            baseIP = myIP.Substring(0, i + 1);
                            break;
                        }
                    }
                    for (int i = 0; i <= 255; i++)
                    {
                        string thirdOctet = i.ToString();
                        pingIP = "";


                        for (int j = 1; j < 255; j++)
                        {
                            pingIP = baseIP + thirdOctet + "." + j.ToString();
                            Ping ping = new Ping();
                            PingReply pingresult = await ping.SendPingAsync(pingIP, 100);
                            if (pingresult.Status.ToString() == "Success")
                            {
                                if (cboIP.InvokeRequired)
                                {
                                    cboIP.Invoke((MethodInvoker)delegate ()
                                    {
                                        cboIP.Items.Add(pingIP);
                                    });
                                }
                                else
                                {
                                    cboIP.Items.Add(pingIP);
                                }
                            }
                        }
                    }
                }
                if (classIP(firstOctet) == "C")
                {
                    coutDot = 0;
                    for (int i = 0; i < myIP.Length; i++)
                    {
                        if (myIP[i].Equals('.'))
                        {
                            coutDot++;
                        }
                        if (coutDot == 3)
                        {
                            baseIP = myIP.Substring(0, i + 1);
                            break;
                        }
                    }
                    for (int i = 1; i < 255; i++)
                    {
                        pingIP = "";
                        pingIP = pingIP + baseIP + i;
                        Ping ping = new Ping();
                        PingReply pingresult = await ping.SendPingAsync(pingIP, 100);
                        if (pingresult.Status.ToString() == "Success")
                        {
                            if (cboIP.InvokeRequired)
                            {
                                cboIP.Invoke((MethodInvoker)delegate ()
                                {
                                    cboIP.Items.Add(pingIP);
                                });
                            }
                            else
                            {
                                cboIP.Items.Add(pingIP);
                            }
                        }
                    }
                }

            }

        }
        private string classIP(string firstOctet)
        {
            int num = Convert.ToInt32(firstOctet);
            if (num >= 0 && num <= 127)
            {
                return "A";
            }
            if (num >= 128 && num <= 191)
            {
                return "B";
            }
            return "C";
        }
    }
}