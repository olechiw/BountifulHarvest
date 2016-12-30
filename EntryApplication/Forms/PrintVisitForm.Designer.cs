namespace EntryApplication
{
    partial class PrintVisitForm
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
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.datelabel = new System.Windows.Forms.Label();
            this.printButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.middleInitialLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.limitsAllowedLabel = new System.Windows.Forms.Label();
            this.printPreviewButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameLabel.Location = new System.Drawing.Point(71, 60);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(167, 32);
            this.firstNameLabel.TabIndex = 0;
            this.firstNameLabel.Text = "First Name: ";
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameLabel.Location = new System.Drawing.Point(72, 230);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(166, 32);
            this.lastNameLabel.TabIndex = 1;
            this.lastNameLabel.Text = "Last Name: ";
            // 
            // datelabel
            // 
            this.datelabel.AutoSize = true;
            this.datelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datelabel.Location = new System.Drawing.Point(574, 60);
            this.datelabel.Name = "datelabel";
            this.datelabel.Size = new System.Drawing.Size(195, 32);
            this.datelabel.TabIndex = 2;
            this.datelabel.Text = "Today\'s Date: ";
            // 
            // printButton
            // 
            this.printButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printButton.Location = new System.Drawing.Point(791, 460);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(229, 66);
            this.printButton.TabIndex = 3;
            this.printButton.Text = "Print";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(451, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 36);
            this.label1.TabIndex = 4;
            this.label1.Text = "PRINT";
            // 
            // middleInitialLabel
            // 
            this.middleInitialLabel.AutoSize = true;
            this.middleInitialLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.middleInitialLabel.Location = new System.Drawing.Point(72, 150);
            this.middleInitialLabel.Name = "middleInitialLabel";
            this.middleInitialLabel.Size = new System.Drawing.Size(46, 32);
            this.middleInitialLabel.TabIndex = 5;
            this.middleInitialLabel.Text = "M:";
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(37, 460);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(229, 66);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButtonClick);
            // 
            // limitsAllowedLabel
            // 
            this.limitsAllowedLabel.AutoSize = true;
            this.limitsAllowedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.limitsAllowedLabel.Location = new System.Drawing.Point(574, 251);
            this.limitsAllowedLabel.Name = "limitsAllowedLabel";
            this.limitsAllowedLabel.Size = new System.Drawing.Size(206, 32);
            this.limitsAllowedLabel.TabIndex = 8;
            this.limitsAllowedLabel.Text = "Limits Allowed:";
            // 
            // printPreviewButton
            // 
            this.printPreviewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printPreviewButton.Location = new System.Drawing.Point(424, 460);
            this.printPreviewButton.Name = "printPreviewButton";
            this.printPreviewButton.Size = new System.Drawing.Size(229, 66);
            this.printPreviewButton.TabIndex = 9;
            this.printPreviewButton.Text = "Preview";
            this.printPreviewButton.UseVisualStyleBackColor = true;
            this.printPreviewButton.Click += new System.EventHandler(this.previewButtonClick);
            // 
            // PrintVisitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 593);
            this.Controls.Add(this.printPreviewButton);
            this.Controls.Add(this.limitsAllowedLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.middleInitialLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.datelabel);
            this.Controls.Add(this.lastNameLabel);
            this.Controls.Add(this.firstNameLabel);
            this.Name = "PrintVisitForm";
            this.Text = "Print a Patron Visit";
            this.Load += new System.EventHandler(this.PrintVisitForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.Label datelabel;
        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label middleInitialLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label limitsAllowedLabel;
        private System.Windows.Forms.Button printPreviewButton;
    }
}