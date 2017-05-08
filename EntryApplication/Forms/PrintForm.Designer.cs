namespace EntryApplication
{
    partial class PrintForm
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
            this.printPreviewControl = new System.Windows.Forms.PrintPreviewControl();
            this.halloween = new System.Windows.Forms.CheckBox();
            this.thanksgiving = new System.Windows.Forms.CheckBox();
            this.school = new System.Windows.Forms.CheckBox();
            this.winter = new System.Windows.Forms.CheckBox();
            this.christmas = new System.Windows.Forms.CheckBox();
            this.easter = new System.Windows.Forms.CheckBox();
            this.printButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // printPreviewControl
            // 
            this.printPreviewControl.Location = new System.Drawing.Point(12, 12);
            this.printPreviewControl.Name = "printPreviewControl";
            this.printPreviewControl.Size = new System.Drawing.Size(703, 895);
            this.printPreviewControl.TabIndex = 0;
            // 
            // halloween
            // 
            this.halloween.AutoSize = true;
            this.halloween.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.halloween.Location = new System.Drawing.Point(888, 141);
            this.halloween.Name = "halloween";
            this.halloween.Size = new System.Drawing.Size(171, 36);
            this.halloween.TabIndex = 1;
            this.halloween.Text = "Halloween";
            this.halloween.UseVisualStyleBackColor = true;
            this.halloween.CheckedChanged += new System.EventHandler(this.checkChanged);
            // 
            // thanksgiving
            // 
            this.thanksgiving.AutoSize = true;
            this.thanksgiving.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thanksgiving.Location = new System.Drawing.Point(888, 192);
            this.thanksgiving.Name = "thanksgiving";
            this.thanksgiving.Size = new System.Drawing.Size(206, 36);
            this.thanksgiving.TabIndex = 2;
            this.thanksgiving.Text = "Thanksgiving";
            this.thanksgiving.UseVisualStyleBackColor = true;
            this.thanksgiving.CheckedChanged += new System.EventHandler(this.checkChanged);
            // 
            // school
            // 
            this.school.AutoSize = true;
            this.school.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.school.Location = new System.Drawing.Point(888, 234);
            this.school.Name = "school";
            this.school.Size = new System.Drawing.Size(125, 36);
            this.school.TabIndex = 3;
            this.school.Text = "School";
            this.school.UseVisualStyleBackColor = true;
            this.school.CheckedChanged += new System.EventHandler(this.checkChanged);
            // 
            // winter
            // 
            this.winter.AutoSize = true;
            this.winter.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winter.Location = new System.Drawing.Point(888, 276);
            this.winter.Name = "winter";
            this.winter.Size = new System.Drawing.Size(119, 36);
            this.winter.TabIndex = 4;
            this.winter.Text = "Winter";
            this.winter.UseVisualStyleBackColor = true;
            this.winter.CheckedChanged += new System.EventHandler(this.checkChanged);
            // 
            // christmas
            // 
            this.christmas.AutoSize = true;
            this.christmas.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.christmas.Location = new System.Drawing.Point(888, 318);
            this.christmas.Name = "christmas";
            this.christmas.Size = new System.Drawing.Size(164, 36);
            this.christmas.TabIndex = 5;
            this.christmas.Text = "Christmas";
            this.christmas.UseVisualStyleBackColor = true;
            this.christmas.CheckedChanged += new System.EventHandler(this.checkChanged);
            // 
            // easter
            // 
            this.easter.AutoSize = true;
            this.easter.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.easter.Location = new System.Drawing.Point(888, 360);
            this.easter.Name = "easter";
            this.easter.Size = new System.Drawing.Size(119, 36);
            this.easter.TabIndex = 6;
            this.easter.Text = "Easter";
            this.easter.UseVisualStyleBackColor = true;
            this.easter.CheckedChanged += new System.EventHandler(this.checkChanged);
            // 
            // printButton
            // 
            this.printButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printButton.Location = new System.Drawing.Point(888, 693);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(220, 106);
            this.printButton.TabIndex = 7;
            this.printButton.Text = "Print";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButtonClick);
            // 
            // PrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1286, 904);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.easter);
            this.Controls.Add(this.christmas);
            this.Controls.Add(this.winter);
            this.Controls.Add(this.school);
            this.Controls.Add(this.thanksgiving);
            this.Controls.Add(this.halloween);
            this.Controls.Add(this.printPreviewControl);
            this.Name = "PrintForm";
            this.Text = "PrintForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PrintPreviewControl printPreviewControl;
        private System.Windows.Forms.CheckBox halloween;
        private System.Windows.Forms.CheckBox thanksgiving;
        private System.Windows.Forms.CheckBox school;
        private System.Windows.Forms.CheckBox winter;
        private System.Windows.Forms.CheckBox christmas;
        private System.Windows.Forms.CheckBox easter;
        private System.Windows.Forms.Button printButton;
    }
}