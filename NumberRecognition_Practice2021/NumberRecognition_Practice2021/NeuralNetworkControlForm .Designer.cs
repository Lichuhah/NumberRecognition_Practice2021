
namespace NumberRecognition_Practice2021
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnClearPictureBox = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLoadDataSet = new System.Windows.Forms.Button();
            this.btnDeleteData = new System.Windows.Forms.Button();
            this.numIdDeletePic = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAddData = new System.Windows.Forms.Button();
            this.txtAddData = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnNetworkSelection = new System.Windows.Forms.Button();
            this.cmbNetworkSelection = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnCreateNewNetwork = new System.Windows.Forms.Button();
            this.txtNewNetworkName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cmbNetworkDelete = new System.Windows.Forms.ComboBox();
            this.btnDeleteNetwork = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnTrainNetwork = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.numAlpha = new System.Windows.Forms.NumericUpDown();
            this.numError = new System.Windows.Forms.NumericUpDown();
            this.numIterations = new System.Windows.Forms.NumericUpDown();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnCheckNumber = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnStopTraining = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numIdDeletePic)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIterations)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Location = new System.Drawing.Point(35, 35);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(200, 300);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // btnClearPictureBox
            // 
            this.btnClearPictureBox.Location = new System.Drawing.Point(35, 379);
            this.btnClearPictureBox.Name = "btnClearPictureBox";
            this.btnClearPictureBox.Size = new System.Drawing.Size(200, 23);
            this.btnClearPictureBox.TabIndex = 3;
            this.btnClearPictureBox.Text = "Очистить";
            this.btnClearPictureBox.UseVisualStyleBackColor = true;
            this.btnClearPictureBox.Click += new System.EventHandler(this.btnClearPictureBox_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox);
            this.panel1.Controls.Add(this.btnClearPictureBox);
            this.panel1.Location = new System.Drawing.Point(13, 184);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(272, 428);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnLoadDataSet);
            this.panel2.Controls.Add(this.btnDeleteData);
            this.panel2.Controls.Add(this.numIdDeletePic);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.btnAddData);
            this.panel2.Controls.Add(this.txtAddData);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(294, 187);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(267, 163);
            this.panel2.TabIndex = 5;
            // 
            // btnLoadDataSet
            // 
            this.btnLoadDataSet.Enabled = false;
            this.btnLoadDataSet.Location = new System.Drawing.Point(3, 16);
            this.btnLoadDataSet.Name = "btnLoadDataSet";
            this.btnLoadDataSet.Size = new System.Drawing.Size(256, 23);
            this.btnLoadDataSet.TabIndex = 20;
            this.btnLoadDataSet.Text = "Выгрузить датасет";
            this.btnLoadDataSet.UseVisualStyleBackColor = true;
            this.btnLoadDataSet.Click += new System.EventHandler(this.btnLoadDataSet_Click);
            // 
            // btnDeleteData
            // 
            this.btnDeleteData.Enabled = false;
            this.btnDeleteData.Location = new System.Drawing.Point(7, 137);
            this.btnDeleteData.Name = "btnDeleteData";
            this.btnDeleteData.Size = new System.Drawing.Size(252, 23);
            this.btnDeleteData.TabIndex = 5;
            this.btnDeleteData.Text = "Удалить значение";
            this.btnDeleteData.UseVisualStyleBackColor = true;
            this.btnDeleteData.Click += new System.EventHandler(this.btnDeleteData_Click);
            // 
            // numIdDeletePic
            // 
            this.numIdDeletePic.Location = new System.Drawing.Point(68, 111);
            this.numIdDeletePic.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numIdDeletePic.Name = "numIdDeletePic";
            this.numIdDeletePic.Size = new System.Drawing.Size(190, 20);
            this.numIdDeletePic.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Id:";
            // 
            // btnAddData
            // 
            this.btnAddData.Enabled = false;
            this.btnAddData.Location = new System.Drawing.Point(2, 82);
            this.btnAddData.Name = "btnAddData";
            this.btnAddData.Size = new System.Drawing.Size(256, 23);
            this.btnAddData.TabIndex = 2;
            this.btnAddData.Text = "Добавить значение";
            this.btnAddData.UseVisualStyleBackColor = true;
            this.btnAddData.Click += new System.EventHandler(this.btnAddData_Click);
            // 
            // txtAddData
            // 
            this.txtAddData.Location = new System.Drawing.Point(67, 56);
            this.txtAddData.Name = "txtAddData";
            this.txtAddData.Size = new System.Drawing.Size(191, 20);
            this.txtAddData.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Значение:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnNetworkSelection);
            this.panel3.Controls.Add(this.cmbNetworkSelection);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(13, 15);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(178, 85);
            this.panel3.TabIndex = 6;
            // 
            // btnNetworkSelection
            // 
            this.btnNetworkSelection.Enabled = false;
            this.btnNetworkSelection.Location = new System.Drawing.Point(7, 40);
            this.btnNetworkSelection.Name = "btnNetworkSelection";
            this.btnNetworkSelection.Size = new System.Drawing.Size(159, 23);
            this.btnNetworkSelection.TabIndex = 2;
            this.btnNetworkSelection.Text = "Выбрать нейронную сеть";
            this.btnNetworkSelection.UseVisualStyleBackColor = true;
            this.btnNetworkSelection.Click += new System.EventHandler(this.btnNetworkSelection_Click);
            // 
            // cmbNetworkSelection
            // 
            this.cmbNetworkSelection.FormattingEnabled = true;
            this.cmbNetworkSelection.Location = new System.Drawing.Point(45, 10);
            this.cmbNetworkSelection.Name = "cmbNetworkSelection";
            this.cmbNetworkSelection.Size = new System.Drawing.Size(121, 21);
            this.cmbNetworkSelection.TabIndex = 1;
            this.cmbNetworkSelection.Click += new System.EventHandler(this.cmbNetworkSelection_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Выбор:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dataGridView);
            this.panel4.Location = new System.Drawing.Point(564, 15);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(468, 597);
            this.panel4.TabIndex = 7;
            // 
            // dataGridView
            // 
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(7, 4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(458, 590);
            this.dataGridView.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label11);
            this.panel5.Controls.Add(this.textBox1);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.btnCreateNewNetwork);
            this.panel5.Controls.Add(this.txtNewNetworkName);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Location = new System.Drawing.Point(198, 15);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(360, 163);
            this.panel5.TabIndex = 8;
            // 
            // btnCreateNewNetwork
            // 
            this.btnCreateNewNetwork.Location = new System.Drawing.Point(93, 130);
            this.btnCreateNewNetwork.Name = "btnCreateNewNetwork";
            this.btnCreateNewNetwork.Size = new System.Drawing.Size(167, 23);
            this.btnCreateNewNetwork.TabIndex = 2;
            this.btnCreateNewNetwork.Text = "Создать нейронную сеть";
            this.btnCreateNewNetwork.UseVisualStyleBackColor = true;
            this.btnCreateNewNetwork.Click += new System.EventHandler(this.btnCreateNewNetwork_Click);
            // 
            // txtNewNetworkName
            // 
            this.txtNewNetworkName.Location = new System.Drawing.Point(46, 10);
            this.txtNewNetworkName.Name = "txtNewNetworkName";
            this.txtNewNetworkName.Size = new System.Drawing.Size(125, 20);
            this.txtNewNetworkName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Имя:";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.cmbNetworkDelete);
            this.panel6.Controls.Add(this.btnDeleteNetwork);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Location = new System.Drawing.Point(13, 94);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(178, 84);
            this.panel6.TabIndex = 9;
            // 
            // cmbNetworkDelete
            // 
            this.cmbNetworkDelete.FormattingEnabled = true;
            this.cmbNetworkDelete.Location = new System.Drawing.Point(45, 25);
            this.cmbNetworkDelete.Name = "cmbNetworkDelete";
            this.cmbNetworkDelete.Size = new System.Drawing.Size(121, 21);
            this.cmbNetworkDelete.TabIndex = 3;
            this.cmbNetworkDelete.Click += new System.EventHandler(this.cmbNetworkSelection_Click);
            // 
            // btnDeleteNetwork
            // 
            this.btnDeleteNetwork.Enabled = false;
            this.btnDeleteNetwork.Location = new System.Drawing.Point(7, 52);
            this.btnDeleteNetwork.Name = "btnDeleteNetwork";
            this.btnDeleteNetwork.Size = new System.Drawing.Size(155, 23);
            this.btnDeleteNetwork.TabIndex = 2;
            this.btnDeleteNetwork.Text = "Удалить нейронную сеть";
            this.btnDeleteNetwork.UseVisualStyleBackColor = true;
            this.btnDeleteNetwork.Click += new System.EventHandler(this.btnDeleteNetwork_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Выбор:";
            // 
            // btnTrainNetwork
            // 
            this.btnTrainNetwork.Enabled = false;
            this.btnTrainNetwork.Location = new System.Drawing.Point(3, 106);
            this.btnTrainNetwork.Name = "btnTrainNetwork";
            this.btnTrainNetwork.Size = new System.Drawing.Size(256, 23);
            this.btnTrainNetwork.TabIndex = 6;
            this.btnTrainNetwork.Text = "Тренировать нейронную сеть";
            this.btnTrainNetwork.UseVisualStyleBackColor = true;
            this.btnTrainNetwork.Click += new System.EventHandler(this.btnTrainNetwork_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Alpha:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Ошибка:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Итерации:";
            // 
            // numAlpha
            // 
            this.numAlpha.DecimalPlaces = 2;
            this.numAlpha.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numAlpha.Location = new System.Drawing.Point(69, 10);
            this.numAlpha.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAlpha.Name = "numAlpha";
            this.numAlpha.Size = new System.Drawing.Size(190, 20);
            this.numAlpha.TabIndex = 15;
            this.numAlpha.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numError
            // 
            this.numError.DecimalPlaces = 5;
            this.numError.Location = new System.Drawing.Point(69, 44);
            this.numError.Name = "numError";
            this.numError.Size = new System.Drawing.Size(190, 20);
            this.numError.TabIndex = 16;
            // 
            // numIterations
            // 
            this.numIterations.Location = new System.Drawing.Point(69, 80);
            this.numIterations.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numIterations.Name = "numIterations";
            this.numIterations.Size = new System.Drawing.Size(190, 20);
            this.numIterations.TabIndex = 17;
            this.numIterations.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnStopTraining);
            this.panel7.Controls.Add(this.label7);
            this.panel7.Controls.Add(this.numIterations);
            this.panel7.Controls.Add(this.btnTrainNetwork);
            this.panel7.Controls.Add(this.numAlpha);
            this.panel7.Controls.Add(this.numError);
            this.panel7.Controls.Add(this.label8);
            this.panel7.Controls.Add(this.label9);
            this.panel7.Location = new System.Drawing.Point(291, 358);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(267, 161);
            this.panel7.TabIndex = 18;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.lblResult);
            this.panel8.Controls.Add(this.btnCheckNumber);
            this.panel8.Location = new System.Drawing.Point(291, 525);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(267, 87);
            this.panel8.TabIndex = 19;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblResult.Location = new System.Drawing.Point(105, 6);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(51, 55);
            this.lblResult.TabIndex = 2;
            this.lblResult.Text = "0";
            // 
            // btnCheckNumber
            // 
            this.btnCheckNumber.Enabled = false;
            this.btnCheckNumber.Location = new System.Drawing.Point(3, 64);
            this.btnCheckNumber.Name = "btnCheckNumber";
            this.btnCheckNumber.Size = new System.Drawing.Size(256, 23);
            this.btnCheckNumber.TabIndex = 1;
            this.btnCheckNumber.Text = "Распознать";
            this.btnCheckNumber.UseVisualStyleBackColor = true;
            this.btnCheckNumber.Click += new System.EventHandler(this.btnCheckNumber_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Конфигурация:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 56);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(345, 20);
            this.textBox1.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 79);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(335, 39);
            this.label11.TabIndex = 5;
            this.label11.Text = "*В виде \"кол-во нейронов на слое 1, кол-во нейронов на слое 2, \r\nкол-во выходов\"\r" +
    "\nКоличество слоев произвольно (пощадите пк)";
            // 
            // btnStopTraining
            // 
            this.btnStopTraining.Enabled = false;
            this.btnStopTraining.Location = new System.Drawing.Point(3, 135);
            this.btnStopTraining.Name = "btnStopTraining";
            this.btnStopTraining.Size = new System.Drawing.Size(255, 23);
            this.btnStopTraining.TabIndex = 20;
            this.btnStopTraining.Text = "Остановить тренировку";
            this.btnStopTraining.UseVisualStyleBackColor = true;
            this.btnStopTraining.Click += new System.EventHandler(this.btnStopTraining_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 669);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Персептрон ver 0.00001";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numIdDeletePic)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAlpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIterations)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btnClearPictureBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAddData;
        private System.Windows.Forms.TextBox txtAddData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnNetworkSelection;
        private System.Windows.Forms.ComboBox cmbNetworkSelection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnCreateNewNetwork;
        private System.Windows.Forms.TextBox txtNewNetworkName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDeleteData;
        private System.Windows.Forms.NumericUpDown numIdDeletePic;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnDeleteNetwork;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnTrainNetwork;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numAlpha;
        private System.Windows.Forms.NumericUpDown numError;
        private System.Windows.Forms.NumericUpDown numIterations;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnCheckNumber;
        private System.Windows.Forms.ComboBox cmbNetworkDelete;
        private System.Windows.Forms.Button btnLoadDataSet;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStopTraining;
    }
}

