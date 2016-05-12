namespace kursova2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownM1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownM2 = new System.Windows.Forms.NumericUpDown();
            this.textBoxModF = new System.Windows.Forms.TextBox();
            this.textBoxArgF = new System.Windows.Forms.TextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownM1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownM2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(105, 113);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 0;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "M1 =";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "M2 =";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "|f| =";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(162, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "arg f =";
            // 
            // numericUpDownM1
            // 
            this.numericUpDownM1.Location = new System.Drawing.Point(54, 34);
            this.numericUpDownM1.Name = "numericUpDownM1";
            this.numericUpDownM1.Size = new System.Drawing.Size(46, 20);
            this.numericUpDownM1.TabIndex = 5;
            this.numericUpDownM1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numericUpDownM2
            // 
            this.numericUpDownM2.Location = new System.Drawing.Point(53, 64);
            this.numericUpDownM2.Name = "numericUpDownM2";
            this.numericUpDownM2.Size = new System.Drawing.Size(46, 20);
            this.numericUpDownM2.TabIndex = 6;
            this.numericUpDownM2.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // textBoxModF
            // 
            this.textBoxModF.Location = new System.Drawing.Point(206, 34);
            this.textBoxModF.Name = "textBoxModF";
            this.textBoxModF.Size = new System.Drawing.Size(74, 20);
            this.textBoxModF.TabIndex = 7;
            this.textBoxModF.Text = "1";
            // 
            // textBoxArgF
            // 
            this.textBoxArgF.Location = new System.Drawing.Point(206, 64);
            this.textBoxArgF.Name = "textBoxArgF";
            this.textBoxArgF.Size = new System.Drawing.Size(73, 20);
            this.textBoxArgF.TabIndex = 8;
            this.textBoxArgF.Text = "0";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(19, 150);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(761, 346);
            this.chart1.TabIndex = 9;
            this.chart1.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 508);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.textBoxArgF);
            this.Controls.Add(this.textBoxModF);
            this.Controls.Add(this.numericUpDownM2);
            this.Controls.Add(this.numericUpDownM1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCalculate);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownM1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownM2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownM1;
        private System.Windows.Forms.NumericUpDown numericUpDownM2;
        private System.Windows.Forms.TextBox textBoxModF;
        private System.Windows.Forms.TextBox textBoxArgF;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}

