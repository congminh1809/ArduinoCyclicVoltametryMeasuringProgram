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

        //double[] dataToSmooth = new double[10000];
        ////double[] dataToSmooth = { -82.5807, -17.1429, -8.84793, -6.08296, -4.23964, -3.31799, -3.31799, -2.39633, -2.39633, -1.47467, -1.47467, -1.47467, -1.47467, -0.55299, -0.55299, -0.55299, -0.55299, -0.55299, 28.0184, 4.97695, 3.13362, 3.13362, 2.21196, 2.21196, 2.21196, 2.21196, 2.21196, 2.21196, 2.21196, 2.21196, 2.21196, 2.21196, 2.21196, 2.21196, 2.21196, 2.21196, 2.21196, 2.21196, 2.21196, 2.21196, 2.21196, 2.21196, 2.21196, 2.21196, 2.21196, 2.21196, 2.21196, 2.21196, 2.21196, 2.21196, 2.21196, 30.7834, 7.74191, 5.89861, 4.97695, 4.0553, 4.0553, 4.0553, 4.0553, 4.0553, 4.0553, 3.13362, 4.0553, 3.13362, 3.13362, 3.13362, 3.13362, 19.7235, 5.89861, 4.97695, 4.97695, 4.0553, 4.0553, 4.0553, 4.0553, 4.0553, 4.0553, 4.0553, 4.0553, 4.0553, 4.0553, 4.0553, 4.0553, 4.0553, 19.7235, 6.82027, 5.89861, 5.89861, 4.97695, 4.97695, 4.97695, 4.97695, 4.97695, 4.97695, 4.97695, 4.97695, 4.97695, 4.97695, 4.97695, 4.0553, 4.0553, 4.0553, 4.0553, 4.97695, 4.97695, 4.0553, 4.97695, 4.0553, 4.0553, 4.0553, 4.0553, 4.0553, 4.0553, 4.0553, 4.0553, 4.0553, 4.0553, 19.7235, 8.66359, 6.82027, 6.82027, 5.89861, 5.89861, 5.89861, 5.89861, 5.89861, 5.89861, 5.89861, 5.89861, 5.89861, 5.89861, 4.97695, 4.97695, 4.97695, 21.5668, 13.2719, 10.5069, 8.66359, 8.66359, 8.66359, 7.74191, 7.74191, 7.74191, 7.74191, 7.74191, 6.82027, 7.74191, 6.82027, 6.82027, 6.82027, 33.5484, 54.7465, 40.9216, 33.5484, 29.8617, 28.0184, 26.1751, 25.2535, 24.3318, 23.4101, 22.4885, 22.4885, 21.5668, 21.5668, 20.6451, 20.6451, 19.7235, 19.7235, 19.7235, 19.7235, 18.8018, 18.8018, 18.8018, 18.8018, 17.8802, 17.8802, 17.8802, 17.8802, 17.8802, 17.8802, 17.8802, 16.9585, 16.9585, 57.5115, 114.654, 97.1429, 87.0046, 78.7097, 73.1797, 69.4931, 65.8064, 63.0414, 61.1981, 59.3548, 58.4332, 56.5899, 55.6682, 54.7465, 53.8249, 52.9032, 51.9815, 51.0599, 51.0599, 50.1382, 49.2166, 49.2166, 48.2949, 48.2949, 47.3733, 47.3733, 47.3733, 46.4516, 45.5299, 45.5299, 45.5299, 44.6083, 81.4746, 133.088, 103.594, 88.8479, 80.553, 75.023, 70.4147, 67.6498, 64.8848, 62.1198, 60.2765, 59.3548, 57.5115, 56.5899, 54.7465, 53.8249, 52.9032, 51.9815, 51.0599, 51.0599, 50.1382, 49.2166, 48.2949, 48.2949, 47.3733, 47.3733, 47.3733, 45.5299, 45.5299, 44.6083, 44.6083, 44.6083, 43.6866, 64.8848, 43.6866, 42.765, 42.765, 42.765, 41.8433, 41.8433, 41.8433, 40.9216, 40.9216, 40.9216, 40.9216, 40, 40, 40, 40, 39.0783, 39.0783, 39.0783, 39.0783, 39.0783, 38.1567, 38.1567, 38.1567, 38.1567, 38.1567, 38.1567, 38.1567, 37.235, 37.235, 37.235, 37.235, 37.235, 54.7465, 36.3134, 36.3134, 36.3134, 36.3134, 36.3134, 36.3134, 36.3134, 36.3134, 35.3917, 35.3917, 35.3917, 35.3917, 35.3917, 35.3917, 35.3917, 35.3917, 35.3917, 34.47, 34.47, 34.47, 34.47, 34.47, 34.47, 34.47, 34.47, 34.47, 34.47, 33.5484, 33.5484, 33.5484, 33.5484, 33.5484, 51.9815, 33.5484, 33.5484, 33.5484, 33.5484, 33.5484, 33.5484, 33.5484, 32.6267, 32.6267, 32.6267, 32.6267, 32.6267, 32.6267, 32.6267, 32.6267, 32.6267, 32.6267, 32.6267, 32.6267, 32.6267, 32.6267, 32.6267, 31.7051, 31.7051, 31.7051, 31.7051, 31.7051, 31.7051, 31.7051, 31.7051, 31.7051, 31.7051, 43.6866, 31.7051, 31.7051, 31.7051, 31.7051, 31.7051, 31.7051, 31.7051, 31.7051, 31.7051, 30.7834, 31.7051, 30.7834, 30.7834, 30.7834, 30.7834, 30.7834, 30.7834, 30.7834, 30.7834, 30.7834, 30.7834, 30.7834, 30.7834, 30.7834, 30.7834, 30.7834, 30.7834, 30.7834, 29.8617, 30.7834, 29.8617, 29.8617, 38.1567, 29.8617, 29.8617, 29.8617, 29.8617, 29.8617, 29.8617, 29.8617, 29.8617, 29.8617, 29.8617, 29.8617, 29.8617, 29.8617, 29.8617, 29.8617, 29.8617, 29.8617, 29.8617, 29.8617, 29.8617, 29.8617, 29.8617, 29.8617, 29.8617, 28.9401, 29.8617, 28.9401, 28.9401, 29.8617, 28.9401, 28.9401, 28.9401, 28.9401, 28.9401, 28.9401, 28.9401, 28.9401, 28.9401, 28.9401, 17.8802, 28.9401, 28.9401, 28.9401, 28.9401, 28.9401, 28.9401, 28.9401, 28.9401, 28.9401, 28.9401, 28.9401, 28.9401, 28.9401, 28.9401, 28.9401, 28.9401, 28.9401, 28.9401, 28.9401, 28.9401, 28.9401, 28.0184, 28.0184, 28.0184, 28.0184, 28.0184, 28.0184, 28.0184, 28.0184, 28.0184, 28.0184, 28.0184, 14.1935, 28.0184, 28.0184, 28.0184, 28.0184, 28.0184, 28.0184, 28.0184, 28.0184, 28.0184, 28.0184, 28.0184, 28.0184, 28.0184, 28.0184, 28.0184, 28.0184, 28.0184, 28.0184, 28.0184, 28.0184, 28.0184, 28.0184, 28.0184, 28.0184, 28.0184, 28.0184, 28.0184, 27.0968, 28.0184, 28.0184, 27.0968, 28.0184, 3.13362, 28.0184, 27.0968, 27.0968, 27.0968, 27.0968, 27.0968, 27.0968, 27.0968, 27.0968, 27.0968, 27.0968, 27.0968, 27.0968, 27.0968, 27.0968, 27.0968, 27.0968, 27.0968, 27.0968, 27.0968, 27.0968, 27.0968, 27.0968, 27.0968, 27.0968, 27.0968, 27.0968, 27.0968, 27.0968, 27.0968, 27.0968, 27.0968, 5.89861, 27.0968, 27.0968, 27.0968, 27.0968, 27.0968, 27.0968, 27.0968, 27.0968, 27.0968, 27.0968, 27.0968, 26.1751, 27.0968, 26.1751, 26.1751, 27.0968, 27.0968, 27.0968, 27.0968, 27.0968, 26.1751, 26.1751, 26.1751, 26.1751, 26.1751, 26.1751, 26.1751, 27.0968, 26.1751, 26.1751, 26.1751, 26.1751, 1.2903, 26.1751, 26.1751, 26.1751, 26.1751, 26.1751, 26.1751, 26.1751, 26.1751, 26.1751, 26.1751, 26.1751, 26.1751, 26.1751, 26.1751, 26.1751, 26.1751, 26.1751, 26.1751, 26.1751, 26.1751, 26.1751, 26.1751, 26.1751, 26.1751, 26.1751, 26.1751, 26.1751, 26.1751, 26.1751, 26.1751, 26.1751, 26.1751, -2.39633, -2.39633, 3.13362, 6.82027, 8.66359, 10.5069, 11.4286, 12.3502, 13.2719, 13.2719, 14.1935, 14.1935, 15.1152, 15.1152, 15.1152, 15.1152, 15.1152, 16.0369, 16.0369, 16.0369, 16.0369, 16.0369, 16.0369, 16.0369, 16.9585, 16.9585, 16.9585, 16.9585, 16.9585, 16.9585, 16.9585, 16.9585, 16.9585, -10.6913, -89.0323, -70.5991, -59.5392, -50.3226, -43.871, -39.2627, -35.5761, -32.8111, -30.0461, -28.2028, -26.3595, -25.4378, -24.5161, -23.5945, -22.6728, -21.7512, -20.8295, -19.9078, -18.9862, -18.9862, -18.0645, -17.1429, -17.1429, -16.2212, -16.2212, -15.2996, -15.2996, -14.3779, -14.3779, -14.3779, -13.4562, -13.4562, -61.3825, -100.092, -72.4424, -58.6175, -51.2443, -46.636, -43.871, -42.0277, -40.1843, -38.341, -37.4194, -35.5761, -34.6544, -33.7327, -32.8111, -31.8894, -60.4608, -48.4793, -42.0277, -39.2627, -37.4194, -36.4977, -34.6544, -33.7327, -32.8111, -31.8894, -30.9677, -30.0461, -29.1244, -28.2028, -28.2028, -27.2811, -26.3595, -53.0876, -36.4977, -32.8111, -30.9677, -30.0461, -29.1244, -28.2028, -27.2811, -26.3595, -25.4378, -25.4378, -24.5161, -24.5161, -23.5945, -22.6728, -22.6728, -21.7512, -21.7512, -21.7512, -20.8295, -20.8295, -19.9078, -19.9078, -19.9078, -18.9862, -18.9862, -18.9862, -18.0645, -18.0645, -18.0645, -17.1429, -17.1429, -17.1429, -41.106, -22.6728, -20.8295, -19.9078, -18.9862, -18.9862, -18.0645, -17.1429, -17.1429, -17.1429, -16.2212, -16.2212, -16.2212, -15.2996, -15.2996, -15.2996, -15.2996, -37.4194, -19.9078, -18.0645, -17.1429, -16.2212, -16.2212, -15.2996, -15.2996, -14.3779, -14.3779, -14.3779, -14.3779, -13.4562, -13.4562, -13.4562, -13.4562, -53.0876, -21.7512, -18.0645, -17.1429, -16.2212, -15.2996, -15.2996, -14.3779, -14.3779, -13.4562, -13.4562, -13.4562, -12.5346, -12.5346, -12.5346, -12.5346, -11.6129, -11.6129, -11.6129, -11.6129, -11.6129, -10.6913, -10.6913, -10.6913, -10.6913, -10.6913, -10.6913, -9.76959, -9.76959, -9.76959, -9.76959, -9.76959, -9.76959, -47.5576, -16.2212, -13.4562, -12.5346, -11.6129, -11.6129, -10.6913, -10.6913, -10.6913, -9.76959, -9.76959, -9.76959, -9.76959, -9.76959, -9.76959, -8.84793, -8.84793, -8.84793 };
        //int dataToSmoothCount = 0;
        //double[] voltageToSmooth = new double[10000];
        ////double[] voltageToSmooth = { -200, -198, -196, -194, -192, -190, -188, -186, -184, -182, -180, -178, -176, -174, -172, -170, -168, -166, -164, -162, -160, -158, -156, -154, -152, -150, -148, -146, -144, -142, -140, -138, -136, -134, -132, -130, -128, -126, -124, -122, -120, -118, -116, -114, -112, -110, -108, -106, -104, -102, -100, -98, -96, -94, -92, -90, -88, -86, -84, -82, -80, -78, -76, -74, -72, -70, -68, -66, -64, -62, -60, -58, -56, -54, -52, -50, -48, -46, -44, -42, -40, -38, -36, -34, -32, -30, -28, -26, -24, -22, -20, -18, -16, -14, -12, -10, -8, -6, -4, -2, 0, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36, 38, 40, 42, 44, 46, 48, 50, 52, 54, 56, 58, 60, 62, 64, 66, 68, 70, 72, 74, 76, 78, 80, 82, 84, 86, 88, 90, 92, 94, 96, 98, 100, 102, 104, 106, 108, 110, 112, 114, 116, 118, 120, 122, 124, 126, 128, 130, 132, 134, 136, 138, 140, 142, 144, 146, 148, 150, 152, 154, 156, 158, 160, 162, 164, 166, 168, 170, 172, 174, 176, 178, 180, 182, 184, 186, 188, 190, 192, 194, 196, 198, 200, 202, 204, 206, 208, 210, 212, 214, 216, 218, 220, 222, 224, 226, 228, 230, 232, 234, 236, 238, 240, 242, 244, 246, 248, 250, 252, 254, 256, 258, 260, 262, 264, 266, 268, 270, 272, 274, 276, 278, 280, 282, 284, 286, 288, 290, 292, 294, 296, 298, 300, 302, 304, 306, 308, 310, 312, 314, 316, 318, 320, 322, 324, 326, 328, 330, 332, 334, 336, 338, 340, 342, 344, 346, 348, 350, 352, 354, 356, 358, 360, 362, 364, 366, 368, 370, 372, 374, 376, 378, 380, 382, 384, 386, 388, 390, 392, 394, 396, 398, 400, 402, 404, 406, 408, 410, 412, 414, 416, 418, 420, 422, 424, 426, 428, 430, 432, 434, 436, 438, 440, 442, 444, 446, 448, 450, 452, 454, 456, 458, 460, 462, 464, 466, 468, 470, 472, 474, 476, 478, 480, 482, 484, 486, 488, 490, 492, 494, 496, 498, 500, 502, 504, 506, 508, 510, 512, 514, 516, 518, 520, 522, 524, 526, 528, 530, 532, 534, 536, 538, 540, 542, 544, 546, 548, 550, 552, 554, 556, 558, 560, 562, 564, 566, 568, 570, 572, 574, 576, 578, 580, 582, 584, 586, 588, 590, 592, 594, 596, 598, 600, 600, 598, 596, 594, 592, 590, 588, 586, 584, 582, 580, 578, 576, 574, 572, 570, 568, 566, 564, 562, 560, 558, 556, 554, 552, 550, 548, 546, 544, 542, 540, 538, 536, 534, 532, 530, 528, 526, 524, 522, 520, 518, 516, 514, 512, 510, 508, 506, 504, 502, 500, 498, 496, 494, 492, 490, 488, 486, 484, 482, 480, 478, 476, 474, 472, 470, 468, 466, 464, 462, 460, 458, 456, 454, 452, 450, 448, 446, 444, 442, 440, 438, 436, 434, 432, 430, 428, 426, 424, 422, 420, 418, 416, 414, 412, 410, 408, 406, 404, 402, 400, 398, 396, 394, 392, 390, 388, 386, 384, 382, 380, 378, 376, 374, 372, 370, 368, 366, 364, 362, 360, 358, 356, 354, 352, 350, 348, 346, 344, 342, 340, 338, 336, 334, 332, 330, 328, 326, 324, 322, 320, 318, 316, 314, 312, 310, 308, 306, 304, 302, 300, 298, 296, 294, 292, 290, 288, 286, 284, 282, 280, 278, 276, 274, 272, 270, 268, 266, 264, 262, 260, 258, 256, 254, 252, 250, 248, 246, 244, 242, 240, 238, 236, 234, 232, 230, 228, 226, 224, 222, 220, 218, 216, 214, 212, 210, 208, 206, 204, 202, 200, 198, 196, 194, 192, 190, 188, 186, 184, 182, 180, 178, 176, 174, 172, 170, 168, 166, 164, 162, 160, 158, 156, 154, 152, 150, 148, 146, 144, 142, 140, 138, 136, 134, 132, 130, 128, 126, 124, 122, 120, 118, 116, 114, 112, 110, 108, 106, 104, 102, 100, 98, 96, 94, 92, 90, 88, 86, 84, 82, 80, 78, 76, 74, 72, 70, 68, 66, 64, 62, 60, 58, 56, 54, 52, 50, 48, 46, 44, 42, 40, 38, 36, 34, 32, 30, 28, 26, 24, 22, 20, 18, 16, 14, 12, 10, 8, 6, 4, 2, 0, -2, -4, -6, -8, -10, -12, -14, -16, -18, -20, -22, -24, -26, -28, -30, -32, -34, -36, -38, -40, -42, -44, -46, -48, -50, -52, -54, -56, -58, -60, -62, -64, -66, -68, -70, -72, -74, -76, -78, -80, -82, -84, -86, -88, -90, -92, -94, -96, -98, -100, -102, -104, -106, -108, -110, -112, -114, -116, -118, -120, -122, -124, -126, -128, -130, -132, -134, -136, -138, -140, -142, -144, -146, -148, -150, -152, -154, -156, -158, -160, -162, -164, -166, -168, -170, -172, -174, -176, -178, -180, -182, -184, -186, -188, -190, -192, -194, -196, -198, -200 };

        double[] bufferC = new double[16000];
        double[] tempC = new double[16000];
        double[] bufferV = new double[16000];
        string[] bufferCStr = new string[16000];
        string[] bufferVStr = new string[16000];
        int recieverCount = 0;
        int repeatCount = 1;
        int graphColor = 1;

        


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
            //LineItem curve = myPane.AddCurve("Data", list, Color.Red, SymbolType.None);
            LineItem curve = myPane.AddCurve("Data", list, Color.BlueViolet, SymbolType.None);

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

                progressBarMeasure.Value = (recieverCount + 1) / (numberSample / 100);
                if (progressBarMeasure.Value > 100)
                {
                    progressBarMeasure.Value = 100;
                }

                //if (recieverCount == numberSample / repeatCount)
                //{
                //    Data_Listview();
                //    SmoothingData(bufferC);
                //    graphColor = 1;
                //    ClearZedGraph();
                //    Draw();
                //}
                //if (recieverCount == (numberSample / repeatCount) * 2)
                //{
                //    Data_Listview();
                //    SmoothingData(bufferC);
                //    graphColor = 2;
                //    ClearZedGraph();
                //    Draw();
                //}
                //if (recieverCount == (numberSample / repeatCount) * 3)
                //{
                //    Data_Listview();
                //    SmoothingData(bufferC);
                //    graphColor = 3;
                //    ClearZedGraph();
                //    Draw();
                //}
                //if (recieverCount == (numberSample / repeatCount) * 4)
                //{
                //    Data_Listview();
                //    SmoothingData(bufferC);
                //    graphColor = 4;
                //    ClearZedGraph();
                //    Draw();
                //}

                if (recieverCount == numberSample)
                {
                    //recieverCount = 0;
                    //progressBarMeasure.Value = 0;

                    serialPort1.Close();
                    Data_Listview();
                    
                    SmoothingData(bufferC);
                    ClearZedGraph();
                    Draw();
                    btRun.Text = "Reset";
                    btConnect.Text = "Measure Again";

                    progressBarMeasure.Value = 0;
                }
                //Draw();
                //Data_Listview();
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
                    //SRealTime = arrList[0]; // Chuỗi đầu tiên lưu vào SRealTime
                    //SDatas = arrList[1]; // Chuỗi thứ hai lưu vào SDatas
                    //double.TryParse(SDatas, out datas); // Chuyển đổi sang   kiểu double
                    //double.TryParse(SRealTime, out realtime);

                    bufferVStr[recieverCount] = arrList[0];
                    bufferCStr[recieverCount] = arrList[1];
                    recieverCount++;

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
                for (int i = 0; i < recieverCount; i++)
                {
                    double.TryParse(bufferVStr[i], out bufferV[i]); // Chuyển đổi sang kiểu double
                    double.TryParse(bufferCStr[i], out bufferC[i]);
                    tempC[i]=bufferC[i];
                    ListViewItem item = new ListViewItem(bufferVStr[i]); // Gán biến realtime vào cột đầu tiên của ListView
                    item.SubItems.Add(bufferCStr[i]);
                    listView1.Items.Add(item); // Gán biến datas vào cột tiếp theo của ListView
                                               // Không nên gán string SDatas vì khi xuất dữ liệu sang Excel sẽ là dạng string, không thực hiện các phép toán được

                    listView1.Items[listView1.Items.Count - 1].EnsureVisible(); // Hiện thị dòng được gán gần nhất ở ListView, tức là mình cuộn ListView
                }
                //SmoothingData(bufferC);
                //Draw();

                
                
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

            //tempC = bufferC;
            //SmoothingData(bufferC);

            for (int i = numberSample / repeatCount * (repeatCount - 2); i < numberSample / repeatCount * (repeatCount - 1); i++)
            //for (int i = 0; i < numberSample; i++)
            {
                list.Add(bufferV[i], bufferC[i]);
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
            int graphHeightMax = 50;
            int graphHeightMin = -50;
            zedGraphControl1.GraphPane.CurveList.Clear(); // Xóa đường
            zedGraphControl1.GraphPane.GraphObjList.Clear(); // Xóa đối tượng

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();

            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.Title.Text = "Current-Voltage chart for Biomedical Testing";
            myPane.XAxis.Title.Text = "Potential (mV)";
            myPane.YAxis.Title.Text = "Current (µA)";

            RollingPointPairList list = new RollingPointPairList(60000);
            //LineItem curve = myPane.AddCurve("Dữ liệu", list, Color.Red, SymbolType.None);
            if (graphColor == 1) 
            {
                LineItem curve = myPane.AddCurve("Data", list, Color.BlueViolet, SymbolType.None);
            }
            if (graphColor == 2)
            {
                LineItem curve = myPane.AddCurve("Data", list, Color.YellowGreen, SymbolType.None);
            }
            if (graphColor == 3)
            {
                LineItem curve = myPane.AddCurve("Data", list, Color.OrangeRed, SymbolType.None);
            }
            if (graphColor == 4)
            {
                LineItem curve = myPane.AddCurve("Data", list, Color.Firebrick, SymbolType.None);
            }


            myPane.XAxis.Scale.Min = Convert.ToInt32(txt_SVol.Text) - 150;
            myPane.XAxis.Scale.Max = Convert.ToInt32(txt_EVol.Text) + 150;
            myPane.XAxis.Scale.MinorStep = 1;
            myPane.XAxis.Scale.MajorStep = 5;
            //myPane.YAxis.Scale.Min = -20;
            //myPane.YAxis.Scale.Max = 50;
            graphHeightMax = Convert.ToInt32(bufferC.Max());
            graphHeightMin = Convert.ToInt32(bufferC.Min());
            myPane.YAxis.Scale.Min = graphHeightMin - 5;
            myPane.YAxis.Scale.Max = graphHeightMax + 5;

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
            //double[] b = a;

            int frame;
            //int num = 1;
            double sum = 0;
            //int countFrame = 0;
            frame = Convert.ToInt32(txt_Frame.Text);
            //n = 802;
            //n = (Convert.ToInt32(txt_EVol) - Convert.ToInt32(txt_SVol)) / Convert.ToInt32(txt_Step) + 1;

            //while (countFrame < frame / 2)
            //{
            //    sum += a[countFrame - 1];
            //    a[countFrame - 1] = sum / countFrame;
            //    countFrame++;
            //    //num = num + 1;
            //}

            //for (int i = 602; i < 662; i++)
            //{
            //    tempC[i] = tempC[i] - ((i - 602) / 3);
            //    //temp1 = temp1 + (1 / 14);
            //}
            //for (int i = 662; i < 802; i++)
            //{
            //    tempC[i] = tempC[i] - ((801 - i) / 7);
            //    //temp2 = temp2 - (1/6);
            //}

            for (int i = 0 ; i < numberSample; i++) 
            {
                //a[i]=(a[i-Buffer/2] + … + a[i] + … + a[i+Buffer/2]) / Buffer
                sum = 0;
                if (i < frame / 2)  
                {
                    //sum = 0;
                    for (int j = 0; j <= i + frame/2; j++)
                    {
                        sum += tempC[j];
                    }
                    a[i] = sum / (i + frame / 2 + 1);
                    //sum = 0;
                    
                }

                if (i >= frame / 2 && i < numberSample - frame / 2)  
                {
                    //sum = 0;
                    //for (int j = i - frame / 2; j <= i + frame / 2; j++)
                    for (int j = (i - (frame / 2)); j < (i - (frame / 2) + frame); j++)
                    {
                        sum += tempC[j];
                    }
                    a[i] = sum / frame;
                    //sum = 0;
                }

                if (i >= numberSample - (frame / 2)) 
                {
                    //sum = 0;
                    for (int j = i - frame / 2; j < numberSample; j++) 
                    {
                        sum += tempC[j];
                    }
                    a[i] = sum / ((801-i) + frame / 2 + 1);
                    //sum = 0;
                    
                }

            }

            //for (int i = 400; i < 660; i++)
            //{
            //    a[i] = a[i] - ((i - 400) / 33);
            //    //temp1 = temp1 + (1 / 14);
            //}
            //for (int i = 660; i < 801; i++)
            //{
            //    a[i] = a[i] - ((800 - i) / 7);
            //    //temp2 = temp2 - (1/6);
            //}



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
                //ws.Cells[i, j] = comp.Text.ToString();
                ws.Cells[i, j] = Convert.ToDouble(comp.Text);
                foreach (ListViewItem.ListViewSubItem drv in comp.SubItems)
                {
                    //ws.Cells[i, j] = drv.Text.ToString();
                    ws.Cells[i, j] = Convert.ToDouble(drv.Text);
                    j++;
                }
                j = 1;
                i++;

                ws.Cells[smooth + 2, 3] = Convert.ToDouble(bufferC[smooth]);
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
                repeatCount = Convert.ToInt32(txt_Repeat.Text);
                numberSample = ((Convert.ToInt32(txt_EVol.Text) - Convert.ToInt32(txt_SVol.Text)) / Convert.ToInt32(txt_Step.Text) + 1) * 2 * repeatCount;
                if (repeatCount<1 || repeatCount>4)
                {
                    repeatCount = 4;
                }
                //serialPort1.Write("1"); //Gửi ký tự "2" qua Serial, tương ứng với state = 1
                //dataToSmooth = new double[5000];
                try
                {
                    
                    serialPort1.Open();
                    serialPort1.DiscardOutBuffer();
                    serialPort1.WriteLine(str);
                    btConnect.Text = "Disconnect";
                    btExit.Enabled = false;
                    recieverCount = 0;      //Biến đếm số giá trị nhận được chạy lại từ đầu
                    progressBarMeasure.Value = 0;   //Thanh trạng thái "Quá trình đo" chạy lại từ đầu

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
                btPause.Text = "Resume";
            }
            else
                //serialPort1.Open();
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

                    listView1.Items.Clear(); // Xóa listview

                    //dataToSmooth = new double[5000];
                    //Xóa đường trong đồ thị
                    ClearZedGraph();

                    //Xóa dữ liệu trong Form
                    ResetValue();
                    //MessageBox.Show("Bạn không thể dừng khi chưa kết nối với thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            listView1.Items.Clear(); // Xóa listview

            //dataToSmooth = new double[5000];
            //Xóa đường trong đồ thị
            ClearZedGraph();

            //Xóa dữ liệu trong Form
            ResetValue();
            //MessageBox.Show("Bạn không thể xóa khi chưa kết nối với thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            //else
            //{
            //    serialPort1.Open();
            //}
            listView1.Items.Clear(); // Xóa listview
            ClearZedGraph();        //Xóa đồ  thị
            recieverCount = 0;      //Biến đếm số giá trị nhận được chạy lại từ đầu
            progressBarMeasure.Value = 0;   //Thanh trạng thái "Quá trình đo" chạy lại từ đầu

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

        private void txt_Frame_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Repeat_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
/*
 - Đo repeat:
    + Tạo 1 biến RepeatCount=0, tạo textbox Repeat - Checked
    + NumberSample = NumberSample x RepeatCount - Checked
    + Mỗi lần repeat tương ứng 1 màu
    + Không clear listview - Checked
    + Tạo comboBox GraphChoice chọn đồ thị muốn hiển thị
- Giải quyết vấn đề reConnect không bắt đầu đo từ SVol
    + Xem kỹ hàm btConnect, btRun và btCheck
    + Tìm cách reset bên Arduino
 */