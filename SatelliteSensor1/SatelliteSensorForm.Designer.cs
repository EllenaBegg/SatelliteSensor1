namespace SatelliteSensor1
{
    partial class SatelliteSensorForm
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
            this.numericUpDownSigma = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMu = new System.Windows.Forms.NumericUpDown();
            this.buttonLoadSensorData = new System.Windows.Forms.Button();
            this.listViewSensorData = new System.Windows.Forms.ListView();
            this.columnHeaderA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonIterativeSearchA = new System.Windows.Forms.Button();
            this.textBoxIterativeSearchTimeA = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonRecursiveSearchA = new System.Windows.Forms.Button();
            this.textBoxRecursiveSearchTimeA = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSearchTargetA = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonSelectionSortA = new System.Windows.Forms.Button();
            this.textBoxSelectionSortTimeA = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonInsertionSortA = new System.Windows.Forms.Button();
            this.textBoxInsertionSortTimeA = new System.Windows.Forms.TextBox();
            this.listBoxSensorA = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonIterativeSearchB = new System.Windows.Forms.Button();
            this.textBoxIterativeSearchTimeB = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonRecursiveSearchB = new System.Windows.Forms.Button();
            this.textBoxRecursiveSearchTimeB = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxSearchTargetB = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonSelectionSortB = new System.Windows.Forms.Button();
            this.textBoxSelectionSortTimeB = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonInsertionSortB = new System.Windows.Forms.Button();
            this.textBoxInsertionSortTimeB = new System.Windows.Forms.TextBox();
            this.listBoxSensorB = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSigma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMu)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownSigma
            // 
            this.numericUpDownSigma.Location = new System.Drawing.Point(12, 58);
            this.numericUpDownSigma.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownSigma.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownSigma.Name = "numericUpDownSigma";
            this.numericUpDownSigma.Size = new System.Drawing.Size(40, 20);
            this.numericUpDownSigma.TabIndex = 0;
            this.numericUpDownSigma.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numericUpDownMu
            // 
            this.numericUpDownMu.Location = new System.Drawing.Point(161, 58);
            this.numericUpDownMu.Maximum = new decimal(new int[] {
            75,
            0,
            0,
            0});
            this.numericUpDownMu.Minimum = new decimal(new int[] {
            35,
            0,
            0,
            0});
            this.numericUpDownMu.Name = "numericUpDownMu";
            this.numericUpDownMu.Size = new System.Drawing.Size(40, 20);
            this.numericUpDownMu.TabIndex = 1;
            this.numericUpDownMu.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // buttonLoadSensorData
            // 
            this.buttonLoadSensorData.Location = new System.Drawing.Point(52, 92);
            this.buttonLoadSensorData.Name = "buttonLoadSensorData";
            this.buttonLoadSensorData.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadSensorData.TabIndex = 2;
            this.buttonLoadSensorData.Text = "Load Sensor Data";
            this.buttonLoadSensorData.UseVisualStyleBackColor = true;
            // 
            // listViewSensorData
            // 
            this.listViewSensorData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderA,
            this.columnHeaderB});
            this.listViewSensorData.HideSelection = false;
            this.listViewSensorData.Location = new System.Drawing.Point(12, 132);
            this.listViewSensorData.Name = "listViewSensorData";
            this.listViewSensorData.Size = new System.Drawing.Size(189, 414);
            this.listViewSensorData.TabIndex = 3;
            this.listViewSensorData.UseCompatibleStateImageBehavior = false;
            this.listViewSensorData.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderA
            // 
            this.columnHeaderA.Text = "Sensor A";
            this.columnHeaderA.Width = 90;
            // 
            // columnHeaderB
            // 
            this.columnHeaderB.Text = "Sensor B";
            this.columnHeaderB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderB.Width = 90;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(246, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sensor A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(251, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Iterative Binary Search";
            // 
            // buttonIterativeSearchA
            // 
            this.buttonIterativeSearchA.Location = new System.Drawing.Point(251, 92);
            this.buttonIterativeSearchA.Name = "buttonIterativeSearchA";
            this.buttonIterativeSearchA.Size = new System.Drawing.Size(75, 23);
            this.buttonIterativeSearchA.TabIndex = 6;
            this.buttonIterativeSearchA.Text = "Search";
            this.buttonIterativeSearchA.UseVisualStyleBackColor = true;
            // 
            // textBoxIterativeSearchTimeA
            // 
            this.textBoxIterativeSearchTimeA.Enabled = false;
            this.textBoxIterativeSearchTimeA.Location = new System.Drawing.Point(251, 132);
            this.textBoxIterativeSearchTimeA.Name = "textBoxIterativeSearchTimeA";
            this.textBoxIterativeSearchTimeA.Size = new System.Drawing.Size(100, 20);
            this.textBoxIterativeSearchTimeA.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(254, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Recursive Binary Search";
            // 
            // buttonRecursiveSearchA
            // 
            this.buttonRecursiveSearchA.Location = new System.Drawing.Point(251, 202);
            this.buttonRecursiveSearchA.Name = "buttonRecursiveSearchA";
            this.buttonRecursiveSearchA.Size = new System.Drawing.Size(75, 23);
            this.buttonRecursiveSearchA.TabIndex = 9;
            this.buttonRecursiveSearchA.Text = "Search";
            this.buttonRecursiveSearchA.UseVisualStyleBackColor = true;
            // 
            // textBoxRecursiveSearchTimeA
            // 
            this.textBoxRecursiveSearchTimeA.Enabled = false;
            this.textBoxRecursiveSearchTimeA.Location = new System.Drawing.Point(251, 232);
            this.textBoxRecursiveSearchTimeA.Name = "textBoxRecursiveSearchTimeA";
            this.textBoxRecursiveSearchTimeA.Size = new System.Drawing.Size(100, 20);
            this.textBoxRecursiveSearchTimeA.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(251, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Search Target:";
            // 
            // textBoxSearchTargetA
            // 
            this.textBoxSearchTargetA.Location = new System.Drawing.Point(251, 287);
            this.textBoxSearchTargetA.Name = "textBoxSearchTargetA";
            this.textBoxSearchTargetA.Size = new System.Drawing.Size(100, 20);
            this.textBoxSearchTargetA.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(251, 329);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Selection Sort";
            // 
            // buttonSelectionSortA
            // 
            this.buttonSelectionSortA.Location = new System.Drawing.Point(251, 360);
            this.buttonSelectionSortA.Name = "buttonSelectionSortA";
            this.buttonSelectionSortA.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectionSortA.TabIndex = 14;
            this.buttonSelectionSortA.Text = "Sort";
            this.buttonSelectionSortA.UseVisualStyleBackColor = true;
            // 
            // textBoxSelectionSortTimeA
            // 
            this.textBoxSelectionSortTimeA.Enabled = false;
            this.textBoxSelectionSortTimeA.Location = new System.Drawing.Point(251, 390);
            this.textBoxSelectionSortTimeA.Name = "textBoxSelectionSortTimeA";
            this.textBoxSelectionSortTimeA.Size = new System.Drawing.Size(100, 20);
            this.textBoxSelectionSortTimeA.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(251, 430);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Insertion Sort";
            // 
            // buttonInsertionSortA
            // 
            this.buttonInsertionSortA.Location = new System.Drawing.Point(251, 456);
            this.buttonInsertionSortA.Name = "buttonInsertionSortA";
            this.buttonInsertionSortA.Size = new System.Drawing.Size(75, 23);
            this.buttonInsertionSortA.TabIndex = 17;
            this.buttonInsertionSortA.Text = "Sort";
            this.buttonInsertionSortA.UseVisualStyleBackColor = true;
            // 
            // textBoxInsertionSortTimeA
            // 
            this.textBoxInsertionSortTimeA.Enabled = false;
            this.textBoxInsertionSortTimeA.Location = new System.Drawing.Point(251, 502);
            this.textBoxInsertionSortTimeA.Name = "textBoxInsertionSortTimeA";
            this.textBoxInsertionSortTimeA.Size = new System.Drawing.Size(100, 20);
            this.textBoxInsertionSortTimeA.TabIndex = 18;
            // 
            // listBoxSensorA
            // 
            this.listBoxSensorA.FormattingEnabled = true;
            this.listBoxSensorA.Location = new System.Drawing.Point(382, 60);
            this.listBoxSensorA.Name = "listBoxSensorA";
            this.listBoxSensorA.Size = new System.Drawing.Size(110, 446);
            this.listBoxSensorA.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(550, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 25);
            this.label7.TabIndex = 20;
            this.label7.Text = "Sensor B";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(555, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Iterative Binary Search";
            // 
            // buttonIterativeSearchB
            // 
            this.buttonIterativeSearchB.Location = new System.Drawing.Point(558, 92);
            this.buttonIterativeSearchB.Name = "buttonIterativeSearchB";
            this.buttonIterativeSearchB.Size = new System.Drawing.Size(75, 23);
            this.buttonIterativeSearchB.TabIndex = 22;
            this.buttonIterativeSearchB.Text = "Search";
            this.buttonIterativeSearchB.UseVisualStyleBackColor = true;
            // 
            // textBoxIterativeSearchTimeB
            // 
            this.textBoxIterativeSearchTimeB.Enabled = false;
            this.textBoxIterativeSearchTimeB.Location = new System.Drawing.Point(555, 132);
            this.textBoxIterativeSearchTimeB.Name = "textBoxIterativeSearchTimeB";
            this.textBoxIterativeSearchTimeB.Size = new System.Drawing.Size(100, 20);
            this.textBoxIterativeSearchTimeB.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(558, 174);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Recursive Binary Search";
            // 
            // buttonRecursiveSearchB
            // 
            this.buttonRecursiveSearchB.Location = new System.Drawing.Point(555, 202);
            this.buttonRecursiveSearchB.Name = "buttonRecursiveSearchB";
            this.buttonRecursiveSearchB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonRecursiveSearchB.Size = new System.Drawing.Size(75, 23);
            this.buttonRecursiveSearchB.TabIndex = 25;
            this.buttonRecursiveSearchB.Text = "Search";
            this.buttonRecursiveSearchB.UseVisualStyleBackColor = true;
            // 
            // textBoxRecursiveSearchTimeB
            // 
            this.textBoxRecursiveSearchTimeB.Enabled = false;
            this.textBoxRecursiveSearchTimeB.Location = new System.Drawing.Point(558, 231);
            this.textBoxRecursiveSearchTimeB.Name = "textBoxRecursiveSearchTimeB";
            this.textBoxRecursiveSearchTimeB.Size = new System.Drawing.Size(100, 20);
            this.textBoxRecursiveSearchTimeB.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(555, 270);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Search Target:";
            // 
            // textBoxSearchTargetB
            // 
            this.textBoxSearchTargetB.Location = new System.Drawing.Point(558, 287);
            this.textBoxSearchTargetB.Name = "textBoxSearchTargetB";
            this.textBoxSearchTargetB.Size = new System.Drawing.Size(100, 20);
            this.textBoxSearchTargetB.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(561, 328);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Selection Sort";
            // 
            // buttonSelectionSortB
            // 
            this.buttonSelectionSortB.Location = new System.Drawing.Point(555, 360);
            this.buttonSelectionSortB.Name = "buttonSelectionSortB";
            this.buttonSelectionSortB.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectionSortB.TabIndex = 30;
            this.buttonSelectionSortB.Text = "Sort";
            this.buttonSelectionSortB.UseVisualStyleBackColor = true;
            // 
            // textBoxSelectionSortTimeB
            // 
            this.textBoxSelectionSortTimeB.Enabled = false;
            this.textBoxSelectionSortTimeB.Location = new System.Drawing.Point(558, 402);
            this.textBoxSelectionSortTimeB.Name = "textBoxSelectionSortTimeB";
            this.textBoxSelectionSortTimeB.Size = new System.Drawing.Size(100, 20);
            this.textBoxSelectionSortTimeB.TabIndex = 31;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(558, 440);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 13);
            this.label12.TabIndex = 32;
            this.label12.Text = "Insertion Sort";
            // 
            // buttonInsertionSortB
            // 
            this.buttonInsertionSortB.Location = new System.Drawing.Point(555, 455);
            this.buttonInsertionSortB.Name = "buttonInsertionSortB";
            this.buttonInsertionSortB.Size = new System.Drawing.Size(75, 23);
            this.buttonInsertionSortB.TabIndex = 33;
            this.buttonInsertionSortB.Text = "Sort";
            this.buttonInsertionSortB.UseVisualStyleBackColor = true;
            // 
            // textBoxInsertionSortTimeB
            // 
            this.textBoxInsertionSortTimeB.Enabled = false;
            this.textBoxInsertionSortTimeB.Location = new System.Drawing.Point(561, 502);
            this.textBoxInsertionSortTimeB.Name = "textBoxInsertionSortTimeB";
            this.textBoxInsertionSortTimeB.Size = new System.Drawing.Size(100, 20);
            this.textBoxInsertionSortTimeB.TabIndex = 34;
            // 
            // listBoxSensorB
            // 
            this.listBoxSensorB.FormattingEnabled = true;
            this.listBoxSensorB.Location = new System.Drawing.Point(685, 60);
            this.listBoxSensorB.Name = "listBoxSensorB";
            this.listBoxSensorB.Size = new System.Drawing.Size(110, 446);
            this.listBoxSensorB.TabIndex = 35;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 13);
            this.label13.TabIndex = 36;
            this.label13.Text = "Sigma";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(161, 30);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(22, 13);
            this.label14.TabIndex = 37;
            this.label14.Text = "Mu";
            // 
            // SatelliteSensorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 586);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.listBoxSensorB);
            this.Controls.Add(this.textBoxInsertionSortTimeB);
            this.Controls.Add(this.buttonInsertionSortB);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBoxSelectionSortTimeB);
            this.Controls.Add(this.buttonSelectionSortB);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBoxSearchTargetB);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxRecursiveSearchTimeB);
            this.Controls.Add(this.buttonRecursiveSearchB);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxIterativeSearchTimeB);
            this.Controls.Add(this.buttonIterativeSearchB);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listBoxSensorA);
            this.Controls.Add(this.textBoxInsertionSortTimeA);
            this.Controls.Add(this.buttonInsertionSortA);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxSelectionSortTimeA);
            this.Controls.Add(this.buttonSelectionSortA);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxSearchTargetA);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxRecursiveSearchTimeA);
            this.Controls.Add(this.buttonRecursiveSearchA);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxIterativeSearchTimeA);
            this.Controls.Add(this.buttonIterativeSearchA);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewSensorData);
            this.Controls.Add(this.buttonLoadSensorData);
            this.Controls.Add(this.numericUpDownMu);
            this.Controls.Add(this.numericUpDownSigma);
            this.Name = "SatelliteSensorForm";
            this.Text = "Satellite Sensor";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSigma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownSigma;
        private System.Windows.Forms.NumericUpDown numericUpDownMu;
        private System.Windows.Forms.Button buttonLoadSensorData;
        private System.Windows.Forms.ListView listViewSensorData;
        private System.Windows.Forms.ColumnHeader columnHeaderA;
        private System.Windows.Forms.ColumnHeader columnHeaderB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonIterativeSearchA;
        private System.Windows.Forms.TextBox textBoxIterativeSearchTimeA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonRecursiveSearchA;
        private System.Windows.Forms.TextBox textBoxRecursiveSearchTimeA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSearchTargetA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonSelectionSortA;
        private System.Windows.Forms.TextBox textBoxSelectionSortTimeA;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonInsertionSortA;
        private System.Windows.Forms.TextBox textBoxInsertionSortTimeA;
        private System.Windows.Forms.ListBox listBoxSensorA;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonIterativeSearchB;
        private System.Windows.Forms.TextBox textBoxIterativeSearchTimeB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonRecursiveSearchB;
        private System.Windows.Forms.TextBox textBoxRecursiveSearchTimeB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxSearchTargetB;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonSelectionSortB;
        private System.Windows.Forms.TextBox textBoxSelectionSortTimeB;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button buttonInsertionSortB;
        private System.Windows.Forms.TextBox textBoxInsertionSortTimeB;
        private System.Windows.Forms.ListBox listBoxSensorB;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
    }
}

