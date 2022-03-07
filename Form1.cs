using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Giao tiếp qua Serial
using System.IO;
using System.IO.Ports;
using System.Xml;

// Thêm ZedGraph
using ZedGraph;

namespace CsharpInterface
{
    public
    partial class Form1 : Form
    {
        string SDatas = String.Empty; // Khai báo chuỗi để lưu dữ liệu cảm biến gửi qua Serial
        string SRealTime = String.Empty; // Khai báo chuỗi để lưu thời gian gửi qua Serial
        int status = 0; // Khai báo biến để xử lý sự kiện vẽ đồ thị
        double realtime = 0; //Khai báo biến thời gian để vẽ đồ thị
        double datas = 0; //Khai báo biến dữ liệu cảm biến để vẽ đồ thị

        //double[] dataToSmooth = { -253.835, -216.786, -189.208, -167.494, -150.395, -136.388, -125.136, -115.527, -107.698, -100.851, -95.151, -90.016, -85.654, -81.788, -78.425, -75.202, -72.552, -70.032, -67.712, -65.618, -63.854, -62.134, -60.526, -58.971, -57.338, -56.469, -54.844, -54.149, -52.741, -52.168, -50.943, -50.108, -49.274, -48.727, -47.745, -47.093, -46.303, -45.807, -44.965, -44.565, -43.8, -43.488, -42.792, -42.462, -41.732, -41.611, -40.837, -40.698, -40.09, -40.003, -39.36, -39.161, -38.77, -38.387, -37.849, -37.692, -37.249, -36.997, -36.563, -36.406, -36.163, -35.937, -35.494, -35.355, -34.929, -34.755, -34.477, -34.208, -33.947, -33.704, -33.591, -33.269, -33.13, -32.8, -32.557, -32.453, -32.296, -32.018, -31.923, -31.662, -31.506, -31.193, -29.481, -25.893, -23.243, -21.948, -20.705, -19.958, -18.168, -18.081, -16.587, -16.1, -14.927, -15.179, -13.233, -13.372, -11.852, -12.234, -10.218, -10.357, -9.219, -8.767, -7.889, -7.82, -6.195, -6.378, -5.5, -5.126, -3.797, -4.014, -3.119, -2.198, -1.99, -1.025, -0.339, 0.226, 0.261, 2.007, 1.885, 2.25, 2.737, 4.136, 4.205, 5.126, 5.682, 6.664, 6.395, 8.141, 7.716, 8.541, 9.158, 10.036, 10.053, 13.807, 12.269, 12.477, 12.521, 14.25, 14.015, 14.841, 15.275, 16.126, 15.901, 17.682, 17.256, 18.064, 17.734, 19.359, 18.638, 19.593, 19.68, 20.236, 19.724, 20.957, 20.193, 21.157, 21.157, 21.6, 21.183, 21.8, 22.156, 22.408, 22.269, 23.486, 23.217, 23.781, 24.537, 24.928, 25.241, 26.362, 26.796, 27.352, 27.9, 29.247, 29.907, 30.593, 31.714, 31.992, 33.009, 34.39, 34.799, 35.164, 36.667, 36.224, 37.014, 36.745, 38.379, 37.918, 38.63, 39.117, 39.769, 39.317, 40.985, 40.221, 40.95, 40.881, 42.141, 41.646, 42.254, 42.567, 42.931, 42.332, 43.74, 42.749, 43.453, 43.314, 43.687, 42.905, 43.592, 43.192, 43.644, 42.732, 43.887, 42.723, 43.236, 42.888, 42.905, 42.115, 42.862, 41.715, 41.897, 41.202, 41.741, 40.725, 40.655, 40.594, 40.047, 39.552, 39.812, 38.995, 38.665, 38.743, 38.326, 37.779, 37.423, 37.77, 36.962, 36.71, 36.693, 35.98, 35.459, 35.98, 34.938, 34.894, 34.938, 34.868, 33.921, 33.991, 34.043, 33.808, 33.13, 33.999, 32.905, 33.243, 33.035, 33.07, 32.305, 33.296, 31.966, 32.427, 31.462, 32.844, 31.54, 32.47, 31.497, 32.592, 31.002, 32.818, 31.141, 32.366, 31.419, 32.609, 31.384, 32.766, 32.018, 32.766, 31.818, 33.087, 32.131, 32.322, 32.757, 32.236, 32.079, 31.697, 32.661, 31.766, 32.183, 32.044, 32.253, 31.401, 32.766, 31.123, 32.322, 31.514, 32.079, 30.758, 31.766, 30.811, 32.149, 29.976, 32.574, 30.081, 31.94, 30.715, 31.94, 29.698, 32.383, 29.968, 31.732, 29.855, 32.383, 29.898, 31.862, 30.489, 31.792, 29.994, 32.192, 30.133, 31.862, 30.724, 32.157, 30.315, 32.157, 31.08, 32.409, 30.75, 33.261, 31.41, 32.592, 32.209, 33.409, 32.305, 34.46, 33.287, 34.338, 33.947, 35.198, 35.103, 35.259, 36.102, 36.024, 36.519, 37.171, 37.822, 37.501, 39.378, 39.021, 40.273, 40.151, 42.549, 41.924, 43.236, 37.857, 35.416, 34.416, 33.174, 32.566, 31.679, 31.236, 30.35, 30.089, 29.255, 28.916, 28.386, 27.987, 27.431, 27.509, 26.735, 26.605, 25.893, 26.093, 25.328, 25.467, 24.85, 24.824, 24.355, 24.398, 23.755, 23.929, 23.225, 23.416, 22.678, 23.147, 22.339, 22.747, 21.983, 22.226, 21.696, 21.852, 21.253, 21.418, 20.758, 21.018, 20.384, 21.149, 20.462, 20.367, 19.923, 20.036, 19.619, 19.75, 19.411, 19.498, 19.176, 19.237, 19.089, 19.037, 18.542, 18.698, 18.611, 18.481, 18.455, 18.247, 18.446, 18.125, 18.081, 17.786, 17.995, 17.76, 17.856, 17.577, 17.647, 17.291, 17.612, 16.943, 17.36, 16.882, 17.16, 16.683, 17.03, 16.517, 16.778, 16.483, 15.092, 12.894, 9.01, 8.28, 5.535, 6.221, 2.902, 4.883, 2.024, 2.476, 0.66, 2.398, 0.608, 1.077, -0.2, 1.008, -0.799, 0.304, -0.365, -0.886, -0.956, -0.721, -1.712, -1.086, -1.103, -1.408, -1.764, -2.12, -1.295, -2.589, -1.573, -2.337, -1.92, -2.32, -1.833, -4.735, -1.746, -3.232, -2.051, -4.014, -1.816, -3.823, -2.641, -3.979, -2.216, -4.119, -2.233, -3.597, -2.555, -4.179, -1.964, -3.832, -2.459, -4.336, -1.894, -4.64, -2.224, -3.693, -2.476, -4.162, -1.851, -4.145, -2.137, -3.875, -2.059, -4.457, -1.799, -3.615, -2.224, -3.762, -1.599, -3.728, -2.216 };
        double[] dataToSmooth = new double[10000];
        int dataToSmoothCount = 0;
        //double[] voltageToSmooth = { -1260, -1250, -1240, -1230, -1220, -1210, -1200, -1190, -1180, -1170, -1160, -1150, -1140, -1130, -1120, -1110, -1100, -1090, -1080, -1070, -1060, -1050, -1040, -1030, -1020, -1010, -1000, -990, -980, -970, -960, -950, -940, -930, -920, -910, -900, -890, -880, -870, -860, -850, -840, -830, -820, -810, -800, -790, -780, -770, -760, -750, -740, -730, -720, -710, -700, -690, -680, -670, -660, -650, -640, -630, -620, -610, -600, -590, -580, -570, -560, -550, -540, -530, -520, -510, -500, -490, -480, -470, -460, -450, -440, -430, -420, -410, -400, -390, -380, -370, -360, -350, -340, -330, -320, -310, -300, -290, -280, -270, -260, -250, -240, -230, -220, -210, -200, -190, -180, -170, -160, -150, -140, -130, -120, -110, -100, -90, -80, -70, -60, -50, -40, -30, -20, -10, 0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160, 170, 180, 190, 200, 210, 220, 230, 240, 250, 260, 270, 280, 290, 300, 310, 320, 330, 340, 350, 360, 370, 380, 390, 400, 410, 420, 430, 440, 450, 460, 470, 480, 490, 500, 510, 520, 530, 540, 550, 560, 570, 580, 590, 600, 610, 620, 630, 640, 650, 660, 670, 680, 690, 700, 710, 720, 730, 740, 750, 760, 770, 780, 790, 800, 810, 820, 830, 840, 850, 860, 870, 880, 890, 900, 910, 920, 930, 940, 950, 960, 970, 980, 990, 1000, 1010, 1020, 1030, 1040, 1050, 1060, 1070, 1080, 1090, 1100, 1110, 1120, 1130, 1140, 1150, 1160, 1170, 1180, 1190, 1200, 1210, 1220, 1230, 1240, 1250, 1260, 1250, 1240, 1230, 1220, 1210, 1200, 1190, 1180, 1170, 1160, 1150, 1140, 1130, 1120, 1110, 1100, 1090, 1080, 1070, 1060, 1050, 1040, 1030, 1020, 1010, 1000, 990, 980, 970, 960, 950, 940, 930, 920, 910, 900, 890, 880, 870, 860, 850, 840, 830, 820, 810, 800, 790, 780, 770, 760, 750, 740, 730, 720, 710, 700, 690, 680, 670, 660, 650, 640, 630, 620, 610, 600, 590, 580, 570, 560, 550, 540, 530, 520, 510, 500, 490, 480, 470, 460, 450, 440, 430, 420, 410, 400, 390, 380, 370, 360, 350, 340, 330, 320, 310, 300, 290, 280, 270, 260, 250, 240, 230, 220, 210, 200, 190, 180, 170, 160, 150, 140, 130, 120, 110, 100, 90, 80, 70, 60, 50, 40, 30, 20, 10, 0, -10, -20, -30, -40, -50, -60, -70, -80, -90, -100, -110, -120, -130, -140, -150, -160, -170, -180, -190, -200, -210, -220, -230, -240, -250, -260, -270, -280, -290, -300, -310, -320, -330, -340, -350, -360, -370, -380, -390, -400, -410, -420, -430, -440, -450, -460, -470, -480, -490, -500, -510, -520, -530, -540, -550, -560, -570, -580, -590, -600, -610, -620, -630, -640, -650, -660, -670, -680, -690, -700, -710, -720, -730, -740, -750, -760, -770, -780, -790, -800, -810, -820, -830, -840, -850, -860, -870, -880, -890, -900, -910, -920, -930, -940, -950, -960, -970, -980, -990, -1000, -1010, -1020, -1030, -1040, -1050, -1060, -1070, -1080, -1090, -1100, -1110, -1120, -1130, -1140, -1150, -1160, -1170, -1180, -1190, -1200, -1210, -1220, -1230, -1240, -1250, -1260};
        double[] voltageToSmooth = new double[10000];
        //int voltageToSmoothCount = 0;

        int numberSample;


        public
            Form1()
        {
            InitializeComponent();

            //string[] BR = { "4800", "9600", "230400" };
            //comboBR.Items.addRange(BR);
        }

        private
            void Form1_Load(object sender, EventArgs e)
        {
            comboBoxName.DataSource = SerialPort.GetPortNames(); // Lấy nguồn cho comboBox là tên của cổng COM
            comboBoxName.Text = Properties.Settings.Default.ComName; // Lấy ComName đã làm ở bước 5 cho comboBox
            

            // Khởi tạo ZedGraph
            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.Title.Text = "Cyclic - Voltammetry Graph";
            myPane.XAxis.Title.Text = "Potential (mV)";
            myPane.YAxis.Title.Text = "Current (µA)";

            RollingPointPairList list = new RollingPointPairList(60000);
            LineItem curve = myPane.AddCurve("Dữ liệu", list, Color.Red, SymbolType.None);

            myPane.XAxis.Scale.Min = -500;
            myPane.XAxis.Scale.Max = 500;
            myPane.XAxis.Scale.MinorStep = 1;
            myPane.XAxis.Scale.MajorStep = 5;
            myPane.YAxis.Scale.Min = -30;
            myPane.YAxis.Scale.Max = 30;

            myPane.AxisChange();
        }

        // Hàm Tick này sẽ bắt sự kiện cổng Serial mở hay không
        private
            void timer1_Tick(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                progressBar1.Value = 0;
                //ClearZedGraph();
            }
            else if (serialPort1.IsOpen)
            {
                progressBar1.Value = 100;
                //Draw();
                Data_Listview();
                status = 0;

            }
        }
        // Hàm này lưu lại cổng COM đã chọn cho lần kết nối
        private
            void SaveSetting()
        {
            Properties.Settings.Default.ComName = comboBoxName.Text;
            Properties.Settings.Default.Save();
        }


        //Array.Clear(dataToSmooth, 0, dataToSmooth.length);
        // Nhận và xử lý string gửi từ Serial
        private
            void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            if (serialPort1.IsOpen)
            {
                try
                {
                    string[] arrList = serialPort1.ReadLine().Split('|'); // Đọc một dòng của Serial, cắt chuỗi khi gặp ký tự gạch đứng
                    SRealTime = arrList[0]; // Chuỗi đầu tiên lưu vào SRealTime
                    SDatas = arrList[1]; // Chuỗi thứ hai lưu vào SDatas
                    double.TryParse(SDatas, out datas); // Chuyển đổi sang   kiểu double
                    double.TryParse(SRealTime, out realtime);

                    //realtime = realtime / 100; // Đối ms sang s
                    //datas = datas * 3 / 2.3;
                    status = 1; // Bắt sự kiện xử lý xong chuỗi, đổi starus về 1 để hiển thị dữ liệu trong ListView và vẽ đồ thị
                }
                catch
                {
                    return;
                }
            }
            
        }


        // Hiển thị dữ liệu trong ListView
        private
            void Data_Listview()
        {
            if (status == 0)
                return;
            else
            {
                ListViewItem item = new ListViewItem(realtime.ToString()); // Gán biến realtime vào cột đầu tiên của ListView
                item.SubItems.Add(datas.ToString());

                dataToSmooth[dataToSmoothCount] = datas;
                voltageToSmooth[dataToSmoothCount] = realtime;
                dataToSmoothCount++;

                if (dataToSmoothCount == numberSample)
                {
                    serialPort1.Close();
                    SmoothingData(dataToSmooth);
                    Draw();
                }

                listView1.Items.Add(item); // Gán biến datas vào cột tiếp theo của ListView
                                           // Không nên gán string SDatas vì khi xuất dữ liệu sang Excel sẽ là dạng string, không thực hiện các phép toán được

                listView1.Items[listView1.Items.Count - 1].EnsureVisible(); // Hiện thị dòng được gán gần nhất ở ListView, tức là mình cuộn ListView theo dữ liệu gần nhất đó
            }
        }


        //int graphDrawCount = 0;
        //int n;

        // Vẽ đồ thị
        private
            void Draw()
        {

            if (zedGraphControl1.GraphPane.CurveList.Count <= 0)
                return;

            LineItem curve = zedGraphControl1.GraphPane.CurveList[0] as LineItem;

            if (curve == null)
                return;

            IPointListEdit list = curve.Points as IPointListEdit;

            if (list == null)
                return;

            //list.Add(realtime, datas); // Thêm điểm trên đồ thị
            //n = (Convert.ToInt32(txt_EVol) - Convert.ToInt32(txt_SVol)) / Convert.ToInt32(txt_Step) + 1;
            //n = 401;
            //if (graphDrawCount%n==0)
            //{
            //    list.Add(realtime, dataToSmooth[graphDrawCount]); // Thêm điểm trên đồ thị
            //}
            for (int i = 0; i < dataToSmoothCount; i++)
            {
                list.Add(voltageToSmooth[i], dataToSmooth[i]);
            }
            

            Scale xScale = zedGraphControl1.GraphPane.XAxis.Scale;
            Scale yScale = zedGraphControl1.GraphPane.YAxis.Scale;

            // Tự động Scale theo trục x
            if (realtime > xScale.Max - xScale.MajorStep)
            {
                xScale.Max = (realtime + xScale.MajorStep);
                xScale.Min = (xScale.Max - 30);
            }

            // Tự động Scale theo trục y
            if (datas > yScale.Max - yScale.MajorStep)
            {
                yScale.Max = datas + yScale.MajorStep;
            }
            else if (datas < yScale.Min + yScale.MajorStep)
            {
                yScale.Min = datas - yScale.MajorStep;
            }

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            zedGraphControl1.Refresh();

            //ZedGraph.GraphPane myPane = zedGraphControl1.GraphPane;
            //myPane.XAxis.Scale.Min = 0.0;
            //zedGraphControl1.AxisChange();
            //zedGraphControl1.RestoreScale(myPane);
            //zedGraphControl1.ZoomOut(pane);
        }

        // Xóa đồ thị, với ZedGraph thì phải khai báo lại như ở hàm Form1_Load, nếu không sẽ không hiển thị
        private
            void ClearZedGraph()
        {
            zedGraphControl1.GraphPane.CurveList.Clear(); // Xóa đường
            zedGraphControl1.GraphPane.GraphObjList.Clear(); // Xóa đối tượng

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();

            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.Title.Text = "Current-Voltage chart for Biomedical Testing";
            myPane.XAxis.Title.Text = "Potential (mV)";
            myPane.YAxis.Title.Text = "Current (µA)";

            RollingPointPairList list = new RollingPointPairList(60000);
            LineItem curve = myPane.AddCurve("Dữ liệu", list, Color.Red, SymbolType.None);

            myPane.XAxis.Scale.Min = Convert.ToInt32(txt_SVol.Text)-30;
            myPane.XAxis.Scale.Max = Convert.ToInt32(txt_EVol.Text)+30;
            myPane.XAxis.Scale.MinorStep = 1;
            myPane.XAxis.Scale.MajorStep = 5;
            myPane.YAxis.Scale.Min = -30;
            myPane.YAxis.Scale.Max = 30;

            zedGraphControl1.AxisChange();
        }

        // Hàm xóa dữ liệu
        private
            void ResetValue()
        {
            realtime = 0;
            datas = 0;
            SDatas = String.Empty;
            SRealTime = String.Empty;
            status = 0; // Chuyển status về 0
        }

        // Hàm làm mịn dữ liệu
        private
            void SmoothingData(double[] a)
        {
            double[] b = a;

            int frame;
            //int num = 1;
            double sum = 0;
            int countFrame = 1;
            frame = 65;
            //n = 802;
            //n = (Convert.ToInt32(txt_EVol) - Convert.ToInt32(txt_SVol)) / Convert.ToInt32(txt_Step) + 1;

            while (countFrame < frame / 2)
            {
                sum += a[countFrame - 1];
                a[countFrame - 1] = sum / countFrame ;
                countFrame++;
                //num = num + 1;
            }

            for (int i = frame / 2 + 1; i <= numberSample; i++) 
            {
                sum = 0;
                for (int j = i + (frame / 2 + 1) - frame; j <= i - (frame / 2 + 1) + frame; j++)
                {
                    sum += b[j];
                }
                a[i] = sum / frame;
                sum = 0;

                //if (i <= numberSample) 
                //{
                //    sum = 0;
                //    for (int j = i + (frame / 2 + 1) - frame; j <= i - (frame / 2 + 1) + frame; j++)
                //    {
                //        sum += b[j];
                //    }
                //    a[i] = sum / frame;
                //    sum = 0;
                //}

                //if (i > numberSample)
                //{
                //    sum = 0;
                //    for (int j = i - frame; j <= i ; j++)
                //    {
                //        sum += b[j];
                //    }
                //    a[i] = sum / frame;
                //    sum = 0;
                //}

            }
            
            
        }

        // Hàm lưu ListView sang Excel
        private
            void SaveToExcel()
        {
            Microsoft.Office.Interop.Excel.Application xla = new Microsoft.Office.Interop.Excel.Application();
            xla.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook wb = xla.Workbooks.Add(Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)xla.ActiveSheet;

            // Đặt tên cho hai ô A1. B1 lần lượt là "Thời gian (s)" và "Dữ liệu", sau đó tự động dãn độ rộng
            Microsoft.Office.Interop.Excel.Range rg = (Microsoft.Office.Interop.Excel.Range)ws.get_Range("A1", "B1");
            ws.Cells[1, 1] = "Potential";
            ws.Cells[1, 2] = "Current";
            ws.Cells[1, 3] = "Smooth";
            rg.Columns.AutoFit();
            
            // Lưu từ ô đầu tiên của dòng thứ 2, tức ô A2
            int i = 2;
            int j = 1;
            int smooth = 0;

            ////Làm mịn dữ liệu
            //SmoothingData(dataToSmooth);

            foreach (ListViewItem comp in listView1.Items)
            {
                ws.Cells[i, j] = comp.Text.ToString();
                foreach (ListViewItem.ListViewSubItem drv in comp.SubItems)
                {
                    ws.Cells[i, j] = drv.Text.ToString();
                    j++;
                }
                j = 1;
                i++;

                ws.Cells[smooth + 2, 3] = Convert.ToDouble(dataToSmooth[smooth]);
                smooth++;
                ws.Cells[1, 3] = "Smooth";
            }
            

        }

        // Sự kiện nhấn nút btConnect
        private
            void btConnect_Click(object sender, EventArgs e)
        {
            string str = txt_SVol.Text + '|' + txt_EVol.Text + '_' + txt_Step.Text + '?' + txt_Freq.Text;


            if (serialPort1.IsOpen)
            {
                //serialPort1.Write("0"); //Gửi ký tự "0" qua Serial, tương ứng với state = 0
                //serialPort1.DiscardOutBuffer();
                serialPort1.WriteLine(str);
                serialPort1.Close();
                btConnect.Text = "Kết nối";
                btExit.Enabled = true;
                SaveSetting(); // Lưu cổng COM vào ComName
            }
            else
            {
                serialPort1.PortName = comboBoxName.Text; // Lấy cổng COM
                serialPort1.BaudRate = Convert.ToInt32(comboBR.Text); // Baudrate là 9600, trùng với baudrate của Arduino
                numberSample = ((Convert.ToInt32(txt_EVol.Text) - Convert.ToInt32(txt_SVol.Text)) / Convert.ToInt32(txt_Step.Text) + 1)*2;
                //serialPort1.Write("1"); //Gửi ký tự "2" qua Serial, tương ứng với state = 1
                //dataToSmooth = new double[5000];
                try
                {
                    
                    serialPort1.Open();
                    serialPort1.DiscardOutBuffer();
                    serialPort1.WriteLine(str);
                    btConnect.Text = "Disconnect";
                    btExit.Enabled = false;
                }
                catch
                {
                    MessageBox.Show("Không thể mở cổng" + serialPort1.PortName, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Sự kiện nhấn nút btExxit
        private
            void btExit_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc muốn thoát?", "Thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (traloi == DialogResult.OK)
            {
                Application.Exit(); // Đóng ứng dụng
            }
        }

        // Sự kiện nhấn nút btSave
        private
            void btSave_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có muốn lưu số liệu?", "Lưu", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (traloi == DialogResult.OK)
            {
                SaveToExcel(); // Thực thi hàm lưu ListView sang Excel
            }
        }

        // Sự kiện nhấn nút btCheck
        private
            void btCheck_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Write("1"); //Gửi ký tự "1" qua Serial, chạy hàm tạo Random ở Arduino
            }
            else
                MessageBox.Show("Bạn không thể chạy khi chưa kết nối với thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        // Sự kiện nhấn nút btPause
        private
            void btPause_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                //serialPort1.Write("0"); //Gửi ký tự "0" qua Serial, Dừng Arduino
                serialPort1.Close();
                //Làm mịn dữ liệu
                //SmoothingData(dataToSmooth);
                //Draw();
            }
            else
                MessageBox.Show("Bạn không thể dừng khi chưa kết nối với thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Sự kiện nhấn nút Clear
        private
            void btClear_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn có chắc muốn xóa?", "Xóa dữ liệu", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (traloi == DialogResult.OK)
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Write("2"); //Gửi ký tự "2" qua Serial
                        listView1.Items.Clear(); // Xóa listview
                        
                        //dataToSmooth = new double[5000];
                        //Xóa đường trong đồ thị
                        ClearZedGraph();

                        //Xóa dữ liệu trong Form
                        ResetValue();
                    }
                    else
                        MessageBox.Show("Bạn không thể dừng khi chưa kết nối với thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không thể xóa khi chưa kết nối với thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Sự kiện nhấn nút Run
        private
            void btRun_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                //dataToSmooth = new double[5000];
                serialPort1.Write("1"); //Gửi ký tự "1" qua Serial, chạy hàm tạo Random ở Arduino
            }
            listView1.Items.Clear(); // Xóa listview
            ClearZedGraph();
            //ResetValue();
            //Draw();
            dataToSmoothCount = 0;

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_SVol_TextChanged(object sender, EventArgs e)
        {
            //if (serialPort1.IsOpen)
            //{
            //    serialPort1.Write(txt_SVol.Text);
            //}
        }

        private void txt_EVol_TextChanged(object sender, EventArgs e)
        {
            //if (serialPort1.IsOpen)
            //{
            //    serialPort1.Write("|");
            //    serialPort1.WriteLine(txt_EVol.Text);
                
            //}
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void txt_Step_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Freq_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}