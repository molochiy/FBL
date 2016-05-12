using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace kursova2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int N;
        private int M;
        private double modF;
        private double argF;
        double limitWidth = 1;
        double limitHeight = 1;
        double P = 1;
        Complex f0;
        double leftc = 0.1;
        double rightc = 5;

        private Complex SubIntegralFunction(double ksi1, double ksi2, double ksii1, double ksii2, double c1, double c2)
        {
            Complex result = new Complex();
            for (int n = -N; n <= N; n++)
            {
                for (int m = -M; m <= M; m++)
                {
                    double a = c1 * n * (ksi1 - ksii1) + c2 * m * (ksi2 - ksii2);
                    result += new Complex(Math.Cos(a), Math.Sin(a));
                }
            }
            return result * P * f0;
        }

        private Complex SubIntegralFunction2(double ksi1, double ksi2, double ksii1, double ksii2, double c1, double c2)
        {
            Complex result = new Complex();
            for (int n = -N; n <= N; n++)
            {
                for (int m = -M; m <= M; m++)
                {
                    double a = c1 * n * (ksi1 - ksii1) + c2 * m * (ksi2 - ksii2);
                    result += new Complex(Math.Cos(a), Math.Sin(a));
                }
            }
            return result * f0;
        }

        private Complex CalculateIntegral(Func<double, double, double, double, double, double, Complex> subFunc, double ksi1, double ksi2, double c1, double c2)
        {
            double amountStepsForKsi1 = 10;
            double amountStepsForKsi2 = 10;
            double hksi1 = (2 * limitHeight) / (2 * amountStepsForKsi1); // (b-a)/2N
            double hksi2 = (2 * limitWidth) / (2 * amountStepsForKsi2); // (d-c)/2M
            Complex result = new Complex();

            for (int i = 0; i < amountStepsForKsi1; i++)
            {
                for (int j = 0; j < amountStepsForKsi2; j++)
                {
                    result +=
                        subFunc(ksi1, ksi2, 2 * i * hksi1, 2 * j * hksi2, c1, c2) +
                        subFunc(ksi1, ksi2, 2 * (i + 1) * hksi1, 2 * j * hksi2, c1, c2) +
                        subFunc(ksi1, ksi2, 2 * i * hksi1, 2 * (j + 1) * hksi2, c1, c2) +
                        subFunc(ksi1, ksi2, 2 * (i + 1) * hksi1, 2 * (j + 1) * hksi2, c1, c2) +
                        4 * (
                            subFunc(ksi1, ksi2, (2 * j + 1) * hksi1, 2 * j * hksi2, c1, c2) +
                            subFunc(ksi1, ksi2, 2 * i * hksi1, (2 * j + 1) * hksi2, c1, c2) +
                            subFunc(ksi1, ksi2, (2 * i + 2) * hksi1, (2 * j + 1) * hksi2, c1, c2) +
                            subFunc(ksi1, ksi2, (2 * i + 1) * hksi1, (2 * j + 2) * hksi2, c1, c2)
                            ) +
                        16 * subFunc(ksi1, ksi2, (2 * i + 1) * hksi1, (2 * j + 1) * hksi2, c1, c2);
                }
            }

            return result * hksi1 * hksi2 / 9.0;
        }

        private void calculateMatrices(out double[,] D, out double[,] B, double c1, double c2)
        {
            double leftksi1 = -1;
            double rightsi1 = 1;
            double leftksi2 = -1;
            double rightsi2 = 1;
            double step = 0.1;

            int amountStepsKsi1 = Convert.ToInt32((rightsi1 - leftksi1) / step);
            int amountStepsKsi2 = Convert.ToInt32((rightsi2 - leftksi2) / step);

            D = new double[amountStepsKsi1 + 1, amountStepsKsi2 + 1];
            B = new double[amountStepsKsi1 + 1, amountStepsKsi2 + 1];

            for (int i = 0; i <= amountStepsKsi1; i++)
            {
                for (int j = 0; j <= amountStepsKsi2; j++)
                {
                    double ksi1 = i * step + leftksi1;
                    double ksi2 = j * step + leftksi2;
                    double alpha = Math.Pow(2 * Math.PI, 2) / (c1 * c2);
                    // TODO
                    D[i, j] = 2 / alpha * CalculateIntegral(SubIntegralFunction, ksi1, ksi2, c1, c2).Real;
                    double dc2 = 0.001;
                    B[i, j] = (2 / alpha * CalculateIntegral(SubIntegralFunction, ksi1, ksi2, c1, c2 + dc2).Real - D[i, j]) / dc2;
                }
            }
        }

        private void decomposeMatrices(ref double[,] D, ref double[,] B, out double detD, out double detB)
        {
            // D = LU
            // B = MU + LV
            int n = D.GetLength(0);

            double[,] L = new double[n, n];

            for (int i = 0; i < n; i++)
            {
                L[i, i] = 1;
            }

            double[,] U = new double[n, n];
            double[,] V = new double[n, n];
            double[,] M = new double[n, n];

            for (int r = 0; r < n; r++)
            {
                for (int k = r; k < n; k++)
                {
                    double sumU = 0.0;
                    double sumV = 0.0;
                    for (int j = 0; j < r; j++)
                    {
                        sumU += L[r, j] * U[j, k];
                        sumV += M[r, j] * U[j, k] + L[r, j] * V[j, k];
                    }
                    U[r, k] = D[r, k] - sumU;
                    V[r, k] = B[r, k] - sumV;
                }

                for (int i = r + 1; i < n; i++)
                {
                    double sumL = 0.0;
                    double sumM = 0.0;
                    for (int j = 0; j < r; j++)
                    {
                        sumL += L[i, j] * U[j, r];
                        sumM += M[i, j] * U[j, r] + L[i, j] * V[j, r];
                    }
                    L[i, r] = (D[i, r] - sumL) / U[r, r];
                    M[i, r] = (B[i, r] - sumM - L[i, r] * V[r, r]) / U[r, r];
                }
            }

            detD = 1;
            detB = 0;

            for(int i = 0; i < n; i++)
            {
                double sum = V[i, i];

                for(int k = 0; k < n; k++)
                {
                    if(k != i)
                    {
                        sum *= U[k, k];
                    }
                }

                detD *= U[i, i];
                detB += sum;
            }
        }

        private double Newton(double c1, double c2)
        {            
            double eps = 0.0001;
            int amountSteps = 1000;
            

            double[,] D;
            double[,] B;
            calculateMatrices(out D, out B, c1, c2);

            double detD;
            double detB;
            decomposeMatrices(ref D, ref B, out detD, out detB);

            double c2Next = c2 - detD / detB;

            while ((amountSteps != 0) && (Math.Abs(c2Next - c2) > eps))
            {
                c2 = c2Next;
                calculateMatrices(out D, out B, c1, c2);
                decomposeMatrices(ref D, ref B, out detD, out detB);

                c2Next = c2 - detD / detB;

                amountSteps--;
            }            

            return c2;
        }

        List<Tuple<double, double>> listC1C2 = null;

        private void CalculateC1C2()
        {
            listC1C2 = new List<Tuple<double, double>>();

            double hC = 0.1;
            int amountSteps = Convert.ToInt32((rightc - leftc) / hC);

            for(int i = 1; i <= amountSteps; i++)
            {
                double c1 = i * hC;
                double c2 = Newton(c1, leftc);
                listC1C2.Add(new Tuple<double, double>(c1, c2));
                Console.WriteLine("c1 = {0:0.0000}, c2 = {1:0.0000}", c1, c2);
            }
        }

        private void PrintChart()
        {
            chart1.Series.Clear();
            chart1.Legends.Clear();
            chart1.ChartAreas.Clear();
            chart1.ChartAreas.Add("");
            Series series = new Series();
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 1;
            for (int i = 0; i < listC1C2.Count; i++)
            {
                DataPoint point = new DataPoint(listC1C2[i].Item1, listC1C2[i].Item2);
                //point.ToolTip = String.Format("x{0}: [{1:0.000}; {2:0.000}]", i, hN * i, c[index][i]);
                series.Points.Add(point);
            }
            chart1.Series.Add(series);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            N = Convert.ToInt32(numericUpDownM1.Value);
            M = Convert.ToInt32(numericUpDownM2.Value);
            modF = Convert.ToDouble(textBoxModF.Text.Replace(".", ","));
            argF = Convert.ToDouble(textBoxArgF.Text.Replace(".", ","));
            f0 = new Complex(modF * Math.Cos(argF), modF * Math.Sin(argF));
            CalculateC1C2();
            PrintChart();            
        }
    }
}
