namespace WindowsGame1.Forms
{
    partial class NewMapForm
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
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.lable1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mapNameText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.mapHeightBox = new System.Windows.Forms.NumericUpDown();
            this.tileHeightBox = new System.Windows.Forms.NumericUpDown();
            this.tileWidthtBox = new System.Windows.Forms.NumericUpDown();
            this.mapWidthtBox = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.mapHeightBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileHeightBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileWidthtBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapWidthtBox)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(50, 149);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(115, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(204, 149);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(120, 22);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // lable1
            // 
            this.lable1.AutoSize = true;
            this.lable1.Location = new System.Drawing.Point(12, 69);
            this.lable1.Name = "lable1";
            this.lable1.Size = new System.Drawing.Size(62, 13);
            this.lable1.TabIndex = 6;
            this.lable1.Text = "Map Height";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Map Width";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tile Height";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(197, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tile Width";
            // 
            // mapNameText
            // 
            this.mapNameText.Location = new System.Drawing.Point(89, 22);
            this.mapNameText.Name = "mapNameText";
            this.mapNameText.Size = new System.Drawing.Size(268, 20);
            this.mapNameText.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Map Name";
            // 
            // mapHeightBox
            // 
            this.mapHeightBox.Location = new System.Drawing.Point(89, 69);
            this.mapHeightBox.Name = "mapHeightBox";
            this.mapHeightBox.Size = new System.Drawing.Size(76, 20);
            this.mapHeightBox.TabIndex = 12;
            this.mapHeightBox.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // tileHeightBox
            // 
            this.tileHeightBox.Location = new System.Drawing.Point(89, 107);
            this.tileHeightBox.Name = "tileHeightBox";
            this.tileHeightBox.Size = new System.Drawing.Size(76, 20);
            this.tileHeightBox.TabIndex = 13;
            this.tileHeightBox.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // tileWidthtBox
            // 
            this.tileWidthtBox.Location = new System.Drawing.Point(281, 107);
            this.tileWidthtBox.Name = "tileWidthtBox";
            this.tileWidthtBox.Size = new System.Drawing.Size(76, 20);
            this.tileWidthtBox.TabIndex = 14;
            this.tileWidthtBox.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // mapWidthtBox
            // 
            this.mapWidthtBox.Location = new System.Drawing.Point(281, 67);
            this.mapWidthtBox.Name = "mapWidthtBox";
            this.mapWidthtBox.Size = new System.Drawing.Size(76, 20);
            this.mapWidthtBox.TabIndex = 15;
            this.mapWidthtBox.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // NewMapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 217);
            this.Controls.Add(this.mapWidthtBox);
            this.Controls.Add(this.tileWidthtBox);
            this.Controls.Add(this.tileHeightBox);
            this.Controls.Add(this.mapHeightBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mapNameText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lable1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "NewMapForm";
            this.Text = "NewMapForm";
            this.Load += new System.EventHandler(this.NewMapForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mapHeightBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileHeightBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileWidthtBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapWidthtBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label lable1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox mapNameText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown mapHeightBox;
        private System.Windows.Forms.NumericUpDown tileHeightBox;
        private System.Windows.Forms.NumericUpDown tileWidthtBox;
        private System.Windows.Forms.NumericUpDown mapWidthtBox;
    }
}