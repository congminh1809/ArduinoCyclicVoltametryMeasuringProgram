// MoveAvg.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
using namespace std;

int main()
{
    int n, frame;
	int num = 1;
	float sum = 0;
	int countFrame = 1;
	//float a[1000] = {19.1705, 19.1705, 19.1705, 19.1705, 19.1705, 19.1705, 17.3272, 17.3272, 17.3272, 19.1705, 17.3272, 17.3272, 19.1705, 19.1705, 17.3272, 19.1705, 19.1705, 17.3272, 19.1705, 19.1705, 17.3272, 17.3272, 19.1705, 17.3272, 19.1705, 17.3272, 17.3272, 48.6636, 44.977, 30.2304, 26.5438, 24.7004, 22.8571, 22.8571, 21.0138, 22.8571, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138, 48.6636, 50.5069, 35.7604, 30.2304, 28.3871, 26.5438, 26.5438, 24.7004, 24.7004, 26.5438, 24.7004, 24.7004, 24.7004, 24.7004, 24.7004, 24.7004, 24.7004, 24.7004, 24.7004, 24.7004, 24.7004, 24.7004, 22.8571, 22.8571, 22.8571, 22.8571, 22.8571, 22.8571, 22.8571, 94.7465, 100.276, 70.7834, 59.7235, 54.1935, 50.5069, 48.6636, 46.8203, 44.977, 43.1336, 43.1336, 41.2903, 41.2903, 41.2903, 39.447, 39.447, 39.447, 39.447, 39.447, 39.447, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 35.7604, 35.7604, 35.7604, 35.7604, 35.7604, 35.7604, 35.7604, 35.7604, 35.7604, 35.7604, 35.7604, 33.917, 33.917, 33.917, 33.917, 33.917, 33.917, 33.917, 33.917, 33.917, 33.917, 33.917, 33.917, 33.917, 33.917, 33.917, 33.917, 33.917, 33.917, 33.917, 33.917, 32.0737, 33.917, 32.0737, 32.0737, 32.0737, 32.0737, 32.0737, 107.65, 127.926, 96.5898, 83.6866, 76.3133, 70.7834, 68.9401, 65.2534, 63.4101, 61.5668, 61.5668, 59.7235, 57.8802, 57.8802, 56.0368, 56.0368, 56.0368, 56.0368, 54.1935, 54.1935, 54.1935, 52.3502, 52.3502, 52.3502, 52.3502, 50.5069, 50.5069, 50.5069, 50.5069, 50.5069, 50.5069, 50.5069, 48.6636, 48.6636, 48.6636, 48.6636, 48.6636, 48.6636, 48.6636, 46.8203, 46.8203, 46.8203, 46.8203, 46.8203, 46.8203, 46.8203, 46.8203, 46.8203, 46.8203, 46.8203, 44.977, 46.8203, 44.977, 44.977, 44.977, 44.977, 44.977, 44.977, 44.977, 44.977, 44.977, 44.977, 44.977, 44.977, 107.65, 107.65, 81.8433, 72.6267, 68.9401, 65.2534, 65.2534, 63.4101, 61.5668, 61.5668, 59.7235, 59.7235, 59.7235, 57.8802, 57.8802, 57.8802, 57.8802, 56.0368, 56.0368, 56.0368, 56.0368, 56.0368, 56.0368, 54.1935, 54.1935, 54.1935, 54.1935, 54.1935, 54.1935, 52.3502, 52.3502, 52.3502, 52.3502, 52.3502, 52.3502, 52.3502, 52.3502, -4.79266, -8.47928, 15.4838, 24.7004, 28.3871, 32.0737, 33.917, 33.917, 35.7604, 35.7604, 35.7604, 35.7604, 35.7604, 35.7604, 35.7604, 35.7604, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, 37.6037, -34.2857, -39.8157, -14.0092, -2.94934, 0.73732, 4.42392, 8.1106, 9.9539, 9.9539, 13.6405, 13.6405, 13.6405, 15.4838, 15.4838, 15.4838, 17.3272, 17.3272, 17.3272, 17.3272, 19.1705, 19.1705, 19.1705, 19.1705, 19.1705, 19.1705, 19.1705, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138, 22.8571, 21.0138, 22.8571, 22.8571, 22.8571, 22.8571, 22.8571, 22.8571, 22.8571, 22.8571, 22.8571, 22.8571, 22.8571, 22.8571, 22.8571, 22.8571, 22.8571, 24.7004, 22.8571, 22.8571, 22.8571, 24.7004, 24.7004, -50.8756, -72.9954, -37.9724, -23.2258, -14.0092, -10.3226, -6.63598, -4.79266, -1.10598, -1.10598, 0.73732, 0.73732, 2.5806, 2.5806, 4.42392, 4.42392, 4.42392, 6.26724, 6.26724, 6.26724, 6.26724, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 9.9539, -37.9724, -23.2258, -6.63598, -2.94934, -1.10598, 0.73732, 2.5806, 2.5806, 2.5806, 4.42392, 4.42392, 4.42392, 4.42392, 6.26724, 6.26724, 6.26724, 6.26724, 6.26724, 6.26724, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, -43.5023, -15.8526, 0.73732, 2.5806, 2.5806, 2.5806, 4.42392, 4.42392, 4.42392, 4.42392, 6.26724, 6.26724, 6.26724, 6.26724, 6.26724, 6.26724, 6.26724, 8.1106, 6.26724, 6.26724, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 11.7972, 11.7972, 9.9539, 11.7972, 11.7972, 11.7972, 11.7972, 11.7972, 11.7972, 11.7972, -32.4424, -6.63598, 6.26724, 6.26724, 6.26724, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 11.7972, 9.9539, -28.7558, -4.79266, 4.42392, 6.26724, 6.26724, 6.26724, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, -61.9355, -14.0092, -1.10598, 2.5806, 2.5806, 4.42392, 4.42392, 4.42392, 4.42392, 6.26724, 6.26724, 6.26724, 6.26724, 6.26724, 6.26724, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 9.9539, 8.1106, 9.9539, 8.1106, 9.9539, 8.1106, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, -60.0922, -10.3226, 2.5806, 4.42392, 4.42392, 6.26724, 6.26724, 6.26724, 6.26724, 6.26724, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 9.9539, 8.1106, 8.1106, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 11.7972, 11.7972, 11.7972, -58.2489, 2.5806, 4.42392, 6.26724, 6.26724, 6.26724, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 8.1106, 9.9539, 8.1106, 8.1106, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 9.9539, 57.8802, 32.0737, 17.3272, 15.4838, 15.4838, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 13.6405, 63.4101, 35.7604, 22.8571, 19.1705, 19.1705, 17.3272, 17.3272, 17.3272, 17.3272, 17.3272, 17.3272, 17.3272, 17.3272, 17.3272, 17.3272, 15.4838, 17.3272, 15.4838, 17.3272, 15.4838, 15.4838, 15.4838, 15.4838, 15.4838, 17.3272, 15.4838, 15.4838, 17.3272, 15.4838, 15.4838, 15.4838, 17.3272, 15.4838, 15.4838, 15.4838, 15.4838, 15.4838, 15.4838, 15.4838, 17.3272, 15.4838, 15.4838, 15.4838, 15.4838, 15.4838, 15.4838, 15.4838, 15.4838, 17.3272, 15.4838, 15.4838, 17.3272, 15.4838, 15.4838, 15.4838, 15.4838, 15.4838, 15.4838, 17.3272, 15.4838, 17.3272, 15.4838, 15.4838, 78.1566, 43.1336, 26.5438, 22.8571, 21.0138, 19.1705, 19.1705, 21.0138, 19.1705, 19.1705, 19.1705, 19.1705, 19.1705, 19.1705, 19.1705, 19.1705, 19.1705, 19.1705, 19.1705, 19.1705, 19.1705, 19.1705, 19.1705, 19.1705, 19.1705, 19.1705, 19.1705, 19.1705, 48.6636, 33.917, 24.7004, 22.8571, 22.8571, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138, 19.1705, 21.0138, 21.0138, 19.1705, 19.1705, 21.0138, 19.1705, 19.1705, 19.1705, 19.1705, 21.0138, 19.1705, 19.1705, 19.1705, 19.1705, 19.1705, 52.3502, 39.447, 26.5438, 24.7004, 22.8571, 22.8571, 22.8571, 22.8571, 22.8571, 21.0138, 21.0138, 21.0138, 21.0138, 22.8571, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138, 21.0138};
	float a[1000] = { -16.2212, -16.2212, -16.2212, -16.2212, -16.2212, -17.1429, -15.2996, -16.2212, -16.2212, -16.2212, -16.2212, -16.2212, -14.3779, -15.2996, -16.2212, -15.2996, -16.2212, -16.2212, 6.82027, -11.6129, -12.5346, -12.5346, -13.4562, -13.4562, -12.5346, -13.4562, -13.4562, -13.4562, -13.4562, -13.4562, -13.4562, -13.4562, -13.4562, -13.4562, -13.4562, -13.4562, -12.5346, -12.5346, -12.5346, -13.4562, -12.5346, -13.4562, -12.5346, -12.5346, -12.5346, -12.5346, -12.5346, -12.5346, -12.5346, -12.5346, -13.4562, 4.97695, -7.92628, -9.76959, -9.76959, -9.76959, -9.76959, -10.6913, -9.76959, -10.6913, -10.6913, -10.6913, -10.6913, -10.6913, -9.76959, -10.6913, -10.6913, 3.13362, -7.92628, -9.76959, -8.84793, -8.84793, -9.76959, -8.84793, -9.76959, -9.76959, -9.76959, -9.76959, -9.76959, -9.76959, -9.76959, -9.76959, -9.76959, -9.76959, 3.13362, -7.00462, -7.00462, -7.92628, -7.00462, -7.00462, -7.92628, -8.84793, -7.92628, -7.92628, -8.84793, -7.92628, -7.92628, -8.84793, -7.92628, -7.92628, -8.84793, -8.84793, -7.92628, -8.84793, -8.84793, -7.92628, -8.84793, -8.84793, -8.84793, -8.84793, -8.84793, -8.84793, -8.84793, -8.84793, -7.92628, -8.84793, -8.84793, 3.13362, -5.1613, -6.08296, -6.08296, -7.00462, -6.08296, -6.08296, -7.00462, -7.00462, -7.00462, -7.00462, -7.00462, -7.00462, -7.00462, -6.08296, -7.92628, -7.00462, 2.21196, -4.23964, -3.31799, -4.23964, -5.1613, -5.1613, -4.23964, -4.23964, -5.1613, -5.1613, -6.08296, -4.23964, -6.08296, -6.08296, -4.23964, -5.1613, 4.97695, 10.5069, 6.82027, 4.97695, 4.0553, 5.89861, 3.13362, 4.0553, 3.13362, 2.21196, 3.13362, 3.13362, 3.13362, 2.21196, 3.13362, 2.21196, 2.21196, 3.13362, 2.21196, 1.2903, 2.21196, 1.2903, 1.2903, 0.36866, 2.21196, 1.2903, 1.2903, 1.2903, 0.36866, 1.2903, 0.36866, 0.36866, 1.2903, 16.0369, 26.1751, 22.4885, 20.6451, 18.8018, 18.8018, 17.8802, 16.9585, 16.9585, 16.9585, 16.0369, 16.0369, 16.0369, 15.1152, 16.0369, 15.1152, 15.1152, 15.1152, 14.1935, 14.1935, 15.1152, 14.1935, 14.1935, 14.1935, 13.2719, 14.1935, 14.1935, 14.1935, 13.2719, 13.2719, 13.2719, 12.3502, 13.2719, 35.3917, 31.7051, 28.9401, 26.1751, 26.1751, 25.2535, 23.4101, 25.2535, 23.4101, 23.4101, 23.4101, 22.4885, 22.4885, 22.4885, 22.4885, 21.5668, 21.5668, 21.5668, 20.6451, 20.6451, 20.6451, 19.7235, 19.7235, 19.7235, 19.7235, 19.7235, 19.7235, 18.8018, 19.7235, 18.8018, 18.8018, 18.8018, 18.8018, 33.5484, 17.8802, 17.8802, 16.9585, 16.9585, 16.9585, 16.9585, 16.0369, 16.0369, 16.0369, 16.0369, 16.0369, 15.1152, 15.1152, 15.1152, 15.1152, 14.1935, 14.1935, 14.1935, 14.1935, 14.1935, 14.1935, 13.2719, 13.2719, 13.2719, 13.2719, 13.2719, 13.2719, 13.2719, 12.3502, 12.3502, 12.3502, 12.3502, 26.1751, 12.3502, 12.3502, 11.4286, 12.3502, 12.3502, 12.3502, 12.3502, 11.4286, 12.3502, 11.4286, 11.4286, 11.4286, 11.4286, 11.4286, 11.4286, 11.4286, 11.4286, 11.4286, 11.4286, 11.4286, 11.4286, 10.5069, 10.5069, 11.4286, 10.5069, 10.5069, 10.5069, 10.5069, 10.5069, 10.5069, 10.5069, 10.5069, 24.3318, 10.5069, 10.5069, 9.58524, 10.5069, 10.5069, 9.58524, 9.58524, 10.5069, 9.58524, 9.58524, 9.58524, 9.58524, 9.58524, 9.58524, 9.58524, 9.58524, 9.58524, 9.58524, 9.58524, 9.58524, 8.66359, 9.58524, 8.66359, 9.58524, 9.58524, 8.66359, 8.66359, 9.58524, 9.58524, 9.58524, 9.58524, 8.66359, 16.9585, 8.66359, 9.58524, 9.58524, 8.66359, 8.66359, 8.66359, 8.66359, 8.66359, 8.66359, 8.66359, 8.66359, 8.66359, 8.66359, 8.66359, 8.66359, 8.66359, 8.66359, 8.66359, 7.74191, 8.66359, 8.66359, 8.66359, 8.66359, 8.66359, 7.74191, 8.66359, 7.74191, 8.66359, 8.66359, 7.74191, 8.66359, 8.66359, 12.3502, 8.66359, 7.74191, 8.66359, 7.74191, 7.74191, 8.66359, 7.74191, 7.74191, 8.66359, 7.74191, 7.74191, 8.66359, 7.74191, 7.74191, 7.74191, 7.74191, 7.74191, 7.74191, 7.74191, 7.74191, 7.74191, 7.74191, 7.74191, 7.74191, 7.74191, 7.74191, 7.74191, 7.74191, 7.74191, 7.74191, 7.74191, 7.74191, 7.74191, 7.74191, 7.74191, 7.74191, 7.74191, 7.74191, 7.74191, 3.13362, 7.74191, 7.74191, 7.74191, 7.74191, 7.74191, 7.74191, 7.74191, 7.74191, 6.82027, 7.74191, 7.74191, 7.74191, 7.74191, 7.74191, 7.74191, 7.74191, 6.82027, 6.82027, 7.74191, 6.82027, 7.74191, 7.74191, 6.82027, 7.74191, 7.74191, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 2.21196, 6.82027, 6.82027, 7.74191, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, -5.1613, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 5.89861, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, -0.55299, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 6.82027, 5.89861, 6.82027, 5.89861, 6.82027, 5.89861, 6.82027, 6.82027, 6.82027, 5.89861, 5.89861, 6.82027, 6.82027, 5.89861, 6.82027, 6.82027, 6.82027, 6.82027, 5.89861, 6.82027, 5.89861, 6.82027, 5.89861, 6.82027, 6.82027, 5.89861, 6.82027, -3.31799, 5.89861, 6.82027, 5.89861, 5.89861, 5.89861, 6.82027, 6.82027, 6.82027, 6.82027, 5.89861, 5.89861, 5.89861, 5.89861, 6.82027, 5.89861, 6.82027, 5.89861, 5.89861, 6.82027, 5.89861, 5.89861, 6.82027, 5.89861, 5.89861, 5.89861, 5.89861, 5.89861, 5.89861, 5.89861, 5.89861, 6.82027, 5.89861, -7.92628, 1.2903, 3.13362, 3.13362, 3.13362, 2.21196, 3.13362, 3.13362, 3.13362, 3.13362, 3.13362, 3.13362, 4.0553, 3.13362, 3.13362, 4.0553, 4.0553, 3.13362, 4.0553, 3.13362, 4.0553, 4.0553, 2.21196, 4.0553, 4.0553, 3.13362, 4.0553, 4.0553, 3.13362, 4.0553, 3.13362, 3.13362, 4.0553, -15.2996, -18.9862, -16.2212, -13.4562, -12.5346, -11.6129, -11.6129, -12.5346, -11.6129, -10.6913, -10.6913, -10.6913, -10.6913, -10.6913, -9.76959, -9.76959, -9.76959, -8.84793, -9.76959, -9.76959, -8.84793, -8.84793, -9.76959, -8.84793, -8.84793, -8.84793, -7.92628, -8.84793, -8.84793, -7.92628, -8.84793, -8.84793, -8.84793, -43.871, -30.9677, -26.3595, -24.5161, -23.5945, -22.6728, -20.8295, -21.7512, -20.8295, -19.9078, -20.8295, -19.9078, -19.9078, -19.9078, -18.9862, -18.9862, -41.106, -25.4378, -23.5945, -23.5945, -23.5945, -22.6728, -21.7512, -21.7512, -21.7512, -21.7512, -21.7512, -20.8295, -20.8295, -20.8295, -19.9078, -19.9078, -19.9078, -44.7926, -25.4378, -23.5945, -23.5945, -22.6728, -22.6728, -21.7512, -21.7512, -22.6728, -20.8295, -21.7512, -20.8295, -20.8295, -19.9078, -20.8295, -19.9078, -19.9078, -18.9862, -19.9078, -18.9862, -18.9862, -19.9078, -18.9862, -18.9862, -18.9862, -18.0645, -18.9862, -18.9862, -18.0645, -18.0645, -18.0645, -17.1429, -17.1429, -41.106, -21.7512, -20.8295, -21.7512, -19.9078, -19.9078, -19.9078, -18.9862, -19.9078, -19.9078, -18.9862, -18.9862, -18.9862, -18.0645, -18.9862, -18.0645, -18.0645, -36.4977, -21.7512, -20.8295, -19.9078, -19.9078, -19.9078, -19.9078, -18.9862, -18.9862, -18.9862, -18.9862, -18.9862, -18.0645, -18.0645, -18.9862, -17.1429, -56.7742, -24.5161, -22.6728, -21.7512, -21.7512, -20.8295, -20.8295, -20.8295, -19.9078, -19.9078, -19.9078, -18.9862, -18.9862, -18.9862, -18.9862, -18.9862, -18.9862, -18.0645, -18.0645, -18.0645, -18.0645, -18.0645, -18.0645, -17.1429, -18.0645, -18.0645, -17.1429, -17.1429, -17.1429, -17.1429, -17.1429, -17.1429, -17.1429, -49.4009, -21.7512, -19.9078, -19.9078, -18.9862, -18.9862, -18.9862, -18.0645, -18.0645, -18.0645, -18.0645, -18.0645, -17.1429, -17.1429, -17.1429, -17.1429, -17.1429, -16.2212 };
	cin >> n;
	cin >> frame;

	while(countFrame < frame)
	{

		sum += a[countFrame - 1];
		cout << sum / countFrame << endl;
		countFrame++;
		num = num + 1;
	}

	for (int i = frame; i <= n ; i++)
	{
		sum = 0;
		for (int j = i- frame; j < i; j++)
		{
			sum += a[j];
		}
		cout << sum/frame << endl;
		num = num + 1;
	}
	
}
