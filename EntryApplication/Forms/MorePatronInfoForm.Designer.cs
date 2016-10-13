namespace EntryApplication
{
    partial class MoreInfoForm
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.dateOfBirthLabel = new System.Windows.Forms.Label();
            this.addressLabel = new System.Windows.Forms.Label();
            this.phoneNumberLabel = new System.Windows.Forms.Label();
            this.lastVisitLabel = new System.Windows.Forms.Label();
            this.firstVisitLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.familyLabel = new System.Windows.Forms.Label();
            this.commentsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(12, 46);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(98, 32);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name:";
            // 
            // dateOfBirthLabel
            // 
            this.dateOfBirthLabel.AutoSize = true;
            this.dateOfBirthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateOfBirthLabel.Location = new System.Drawing.Point(12, 183);
            this.dateOfBirthLabel.Name = "dateOfBirthLabel";
            this.dateOfBirthLabel.Size = new System.Drawing.Size(180, 32);
            this.dateOfBirthLabel.TabIndex = 1;
            this.dateOfBirthLabel.Text = "Date of Birth:";
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.addressLabel.Location = new System.Drawing.Point(12, 325);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(122, 31);
            this.addressLabel.TabIndex = 2;
            this.addressLabel.Text = "Address:";
            // 
            // phoneNumberLabel
            // 
            this.phoneNumberLabel.AutoSize = true;
            this.phoneNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.phoneNumberLabel.Location = new System.Drawing.Point(12, 467);
            this.phoneNumberLabel.Name = "phoneNumberLabel";
            this.phoneNumberLabel.Size = new System.Drawing.Size(203, 31);
            this.phoneNumberLabel.TabIndex = 3;
            this.phoneNumberLabel.Text = "Phone Number:";
            // 
            // lastVisitLabel
            // 
            this.lastVisitLabel.AutoSize = true;
            this.lastVisitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lastVisitLabel.Location = new System.Drawing.Point(793, 47);
            this.lastVisitLabel.Name = "lastVisitLabel";
            this.lastVisitLabel.Size = new System.Drawing.Size(133, 31);
            this.lastVisitLabel.TabIndex = 4;
            this.lastVisitLabel.Text = "Last Visit:";
            // 
            // firstVisitLabel
            // 
            this.firstVisitLabel.AutoSize = true;
            this.firstVisitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.firstVisitLabel.Location = new System.Drawing.Point(801, 226);
            this.firstVisitLabel.Name = "firstVisitLabel";
            this.firstVisitLabel.Size = new System.Drawing.Size(135, 31);
            this.firstVisitLabel.TabIndex = 5;
            this.firstVisitLabel.Text = "First Visit:";
            // 
            // closeButton
            // 
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.closeButton.Location = new System.Drawing.Point(1195, 558);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(185, 81);
            this.closeButton.TabIndex = 6;
            this.closeButton.Text = "Done";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButtonClick);
            // 
            // familyLabel
            // 
            this.familyLabel.AutoSize = true;
            this.familyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.familyLabel.Location = new System.Drawing.Point(801, 349);
            this.familyLabel.Name = "familyLabel";
            this.familyLabel.Size = new System.Drawing.Size(102, 31);
            this.familyLabel.TabIndex = 7;
            this.familyLabel.Text = "Family:";
            // 
            // commentsLabel
            // 
            this.commentsLabel.AutoSize = true;
            this.commentsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.commentsLabel.Location = new System.Drawing.Point(793, 487);
            this.commentsLabel.Name = "commentsLabel";
            this.commentsLabel.Size = new System.Drawing.Size(153, 31);
            this.commentsLabel.TabIndex = 8;
            this.commentsLabel.Text = "Comments:";
            // 
            // MoreInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1593, 691);
            this.Controls.Add(this.commentsLabel);
            this.Controls.Add(this.familyLabel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.firstVisitLabel);
            this.Controls.Add(this.lastVisitLabel);
            this.Controls.Add(this.phoneNumberLabel);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.dateOfBirthLabel);
            this.Controls.Add(this.nameLabel);
            this.MaximumSize = new System.Drawing.Size(1611, 738);
            this.MinimumSize = new System.Drawing.Size(1611, 738);
            this.Name = "MoreInfoForm";
            this.Text = "More Info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label dateOfBirthLabel;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.Label phoneNumberLabel;
        private System.Windows.Forms.Label lastVisitLabel;
        private System.Windows.Forms.Label firstVisitLabel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label familyLabel;
        private System.Windows.Forms.Label commentsLabel;
    }
}