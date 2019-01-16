namespace appStore
{
    partial class FormAddTransaction
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.availableProduct = new System.Windows.Forms.ComboBox();
            this.availableCode = new System.Windows.Forms.ComboBox();
            this.discountLabel = new System.Windows.Forms.Label();
            this.totalLabel = new System.Windows.Forms.Label();
            this.amountBox = new System.Windows.Forms.NumericUpDown();
            this.priceBox = new System.Windows.Forms.Label();
            this.image = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.amountBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Product";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Amount";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(110, 251);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Code";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(120, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(109, 313);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Total";
            // 
            // availableProduct
            // 
            this.availableProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.availableProduct.FormattingEnabled = true;
            this.availableProduct.Location = new System.Drawing.Point(213, 54);
            this.availableProduct.Name = "availableProduct";
            this.availableProduct.Size = new System.Drawing.Size(121, 21);
            this.availableProduct.TabIndex = 10;
            this.availableProduct.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // availableCode
            // 
            this.availableCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.availableCode.FormattingEnabled = true;
            this.availableCode.Location = new System.Drawing.Point(202, 251);
            this.availableCode.Name = "availableCode";
            this.availableCode.Size = new System.Drawing.Size(121, 21);
            this.availableCode.TabIndex = 11;
            this.availableCode.SelectedIndexChanged += new System.EventHandler(this.codeBox_SelectedIndexChanged);
            // 
            // discountLabel
            // 
            this.discountLabel.AutoSize = true;
            this.discountLabel.ForeColor = System.Drawing.Color.Green;
            this.discountLabel.Location = new System.Drawing.Point(350, 258);
            this.discountLabel.Name = "discountLabel";
            this.discountLabel.Size = new System.Drawing.Size(0, 13);
            this.discountLabel.TabIndex = 12;
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Location = new System.Drawing.Point(235, 312);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(0, 13);
            this.totalLabel.TabIndex = 13;
            // 
            // amountBox
            // 
            this.amountBox.Location = new System.Drawing.Point(213, 192);
            this.amountBox.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.amountBox.Name = "amountBox";
            this.amountBox.Size = new System.Drawing.Size(120, 20);
            this.amountBox.TabIndex = 15;
            this.amountBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.amountBox.ValueChanged += new System.EventHandler(this.amountBox_ValueChanged);
            // 
            // priceBox
            // 
            this.priceBox.AutoSize = true;
            this.priceBox.Location = new System.Drawing.Point(210, 117);
            this.priceBox.Name = "priceBox";
            this.priceBox.Size = new System.Drawing.Size(0, 13);
            this.priceBox.TabIndex = 16;
            // 
            // image
            // 
            this.image.Location = new System.Drawing.Point(400, 80);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(174, 220);
            this.image.TabIndex = 17;
            this.image.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(160, 380);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 32);
            this.button1.TabIndex = 18;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormAddTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.image);
            this.Controls.Add(this.priceBox);
            this.Controls.Add(this.amountBox);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.discountLabel);
            this.Controls.Add(this.availableCode);
            this.Controls.Add(this.availableProduct);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormAddTransaction";
            this.Text = "Add a bill";
            this.Load += new System.EventHandler(this.FormAddTransaction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.amountBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox availableProduct;
        private System.Windows.Forms.ComboBox availableCode;
        private System.Windows.Forms.Label discountLabel;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.NumericUpDown amountBox;
        private System.Windows.Forms.Label priceBox;
        private System.Windows.Forms.PictureBox image;
        private System.Windows.Forms.Button button1;
    }
}