namespace CG_6
{
    partial class For_Lab6
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
            this.modelsCB = new System.Windows.Forms.ComboBox();
            this.dNumeric = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cNumeric = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.bNumeric = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.aNumeric = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.standardViewRB = new System.Windows.Forms.RadioButton();
            this.firstHalfViewRB = new System.Windows.Forms.RadioButton();
            this.secondHalfViewRB = new System.Windows.Forms.RadioButton();
            this.sectionViewRB = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // modelsCB
            // 
            this.modelsCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modelsCB.FormattingEnabled = true;
            this.modelsCB.Location = new System.Drawing.Point(12, 490);
            this.modelsCB.Name = "modelsCB";
            this.modelsCB.Size = new System.Drawing.Size(134, 21);
            this.modelsCB.TabIndex = 16;
            this.modelsCB.SelectedIndexChanged += new System.EventHandler(this.modelsCB_SelectedIndexChanged);
            // 
            // dNumeric
            // 
            this.dNumeric.DecimalPlaces = 1;
            this.dNumeric.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.dNumeric.Location = new System.Drawing.Point(214, 26);
            this.dNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.dNumeric.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.dNumeric.Name = "dNumeric";
            this.dNumeric.Size = new System.Drawing.Size(36, 20);
            this.dNumeric.TabIndex = 24;
            this.dNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dNumeric.ValueChanged += new System.EventHandler(this.dNumeric_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(185, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Z +";
            // 
            // cNumeric
            // 
            this.cNumeric.DecimalPlaces = 1;
            this.cNumeric.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.cNumeric.Location = new System.Drawing.Point(144, 26);
            this.cNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.cNumeric.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.cNumeric.Name = "cNumeric";
            this.cNumeric.Size = new System.Drawing.Size(39, 20);
            this.cNumeric.TabIndex = 22;
            this.cNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cNumeric.ValueChanged += new System.EventHandler(this.cNumeric_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(124, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Y +";
            // 
            // bNumeric
            // 
            this.bNumeric.DecimalPlaces = 1;
            this.bNumeric.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.bNumeric.Location = new System.Drawing.Point(79, 26);
            this.bNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.bNumeric.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.bNumeric.Name = "bNumeric";
            this.bNumeric.Size = new System.Drawing.Size(39, 20);
            this.bNumeric.TabIndex = 20;
            this.bNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bNumeric.ValueChanged += new System.EventHandler(this.bNumeric_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "X +";
            // 
            // aNumeric
            // 
            this.aNumeric.DecimalPlaces = 1;
            this.aNumeric.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.aNumeric.Location = new System.Drawing.Point(13, 26);
            this.aNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.aNumeric.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.aNumeric.Name = "aNumeric";
            this.aNumeric.Size = new System.Drawing.Size(39, 20);
            this.aNumeric.TabIndex = 18;
            this.aNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.aNumeric.ValueChanged += new System.EventHandler(this.aNumeric_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Плоскость:";
            // 
            // standardViewRB
            // 
            this.standardViewRB.AutoSize = true;
            this.standardViewRB.Checked = true;
            this.standardViewRB.Location = new System.Drawing.Point(12, 52);
            this.standardViewRB.Name = "standardViewRB";
            this.standardViewRB.Size = new System.Drawing.Size(113, 17);
            this.standardViewRB.TabIndex = 25;
            this.standardViewRB.TabStop = true;
            this.standardViewRB.Text = "Стандартный вид";
            this.standardViewRB.UseVisualStyleBackColor = true;
            this.standardViewRB.CheckedChanged += new System.EventHandler(this.standardViewRB_CheckedChanged);
            // 
            // firstHalfViewRB
            // 
            this.firstHalfViewRB.AutoSize = true;
            this.firstHalfViewRB.Location = new System.Drawing.Point(12, 72);
            this.firstHalfViewRB.Name = "firstHalfViewRB";
            this.firstHalfViewRB.Size = new System.Drawing.Size(103, 17);
            this.firstHalfViewRB.TabIndex = 26;
            this.firstHalfViewRB.TabStop = true;
            this.firstHalfViewRB.Text = "1-ая половинка";
            this.firstHalfViewRB.UseVisualStyleBackColor = true;
            this.firstHalfViewRB.CheckedChanged += new System.EventHandler(this.firstHalfViewRB_CheckedChanged);
            // 
            // secondHalfViewRB
            // 
            this.secondHalfViewRB.AutoSize = true;
            this.secondHalfViewRB.Location = new System.Drawing.Point(12, 95);
            this.secondHalfViewRB.Name = "secondHalfViewRB";
            this.secondHalfViewRB.Size = new System.Drawing.Size(103, 17);
            this.secondHalfViewRB.TabIndex = 27;
            this.secondHalfViewRB.TabStop = true;
            this.secondHalfViewRB.Text = "2-ая половинка";
            this.secondHalfViewRB.UseVisualStyleBackColor = true;
            this.secondHalfViewRB.CheckedChanged += new System.EventHandler(this.secondHalfViewRB_CheckedChanged);
            // 
            // sectionViewRB
            // 
            this.sectionViewRB.AutoSize = true;
            this.sectionViewRB.Location = new System.Drawing.Point(12, 118);
            this.sectionViewRB.Name = "sectionViewRB";
            this.sectionViewRB.Size = new System.Drawing.Size(67, 17);
            this.sectionViewRB.TabIndex = 28;
            this.sectionViewRB.TabStop = true;
            this.sectionViewRB.Text = "Сечение";
            this.sectionViewRB.UseVisualStyleBackColor = true;
            this.sectionViewRB.CheckedChanged += new System.EventHandler(this.sectionViewRB_CheckedChanged);
            // 
            // For_Lab6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 523);
            this.Controls.Add(this.sectionViewRB);
            this.Controls.Add(this.secondHalfViewRB);
            this.Controls.Add(this.firstHalfViewRB);
            this.Controls.Add(this.standardViewRB);
            this.Controls.Add(this.dNumeric);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cNumeric);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bNumeric);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.aNumeric);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.modelsCB);
            this.DoubleBuffered = true;
            this.Name = "For_Lab6";
            this.Text = "CG6";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.For_Lab6_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.For_Lab6_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.For_Lab6_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.For_Lab6_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.dNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox modelsCB;
        private System.Windows.Forms.NumericUpDown dNumeric;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown cNumeric;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown bNumeric;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown aNumeric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton standardViewRB;
        private System.Windows.Forms.RadioButton firstHalfViewRB;
        private System.Windows.Forms.RadioButton secondHalfViewRB;
        private System.Windows.Forms.RadioButton sectionViewRB;
    }
}

