namespace EntryApplication
{
    partial class MorePatronInfoForm
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
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(68, 56);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(117, 39);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name:";
            // 
            // dateOfBirthLabel
            // 
            this.dateOfBirthLabel.AutoSize = true;
            this.dateOfBirthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateOfBirthLabel.Location = new System.Drawing.Point(61, 183);
            this.dateOfBirthLabel.Name = "dateOfBirthLabel";
            this.dateOfBirthLabel.Size = new System.Drawing.Size(214, 39);
            this.dateOfBirthLabel.TabIndex = 1;
            this.dateOfBirthLabel.Text = "Date of Birth:";
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addressLabel.Location = new System.Drawing.Point(68, 316);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(151, 39);
            this.addressLabel.TabIndex = 2;
            this.addressLabel.Text = "Address:";
            // 
            // phoneNumberLabel
            // 
            this.phoneNumberLabel.AutoSize = true;
            this.phoneNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.phoneNumberLabel.Location = new System.Drawing.Point(61, 466);
            this.phoneNumberLabel.Name = "phoneNumberLabel";
            this.phoneNumberLabel.Size = new System.Drawing.Size(255, 39);
            this.phoneNumberLabel.TabIndex = 3;
            this.phoneNumberLabel.Text = "Phone Number:";
            // 
            // lastVisitLabel
            // 
            this.lastVisitLabel.AutoSize = true;
            this.lastVisitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lastVisitLabel.Location = new System.Drawing.Point(761, 77);
            this.lastVisitLabel.Name = "lastVisitLabel";
            this.lastVisitLabel.Size = new System.Drawing.Size(164, 39);
            this.lastVisitLabel.TabIndex = 4;
            this.lastVisitLabel.Text = "Last Visit:";
            // 
            // firstVisitLabel
            // 
            this.firstVisitLabel.AutoSize = true;
            this.firstVisitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.firstVisitLabel.Location = new System.Drawing.Point(768, 225);
            this.firstVisitLabel.Name = "firstVisitLabel";
            this.firstVisitLabel.Size = new System.Drawing.Size(166, 39);
            this.firstVisitLabel.TabIndex = 5;
            this.firstVisitLabel.Text = "First Visit:";
            // 
            // closeButton
            // 
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.closeButton.Location = new System.Drawing.Point(1043, 508);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(185, 81);
            this.closeButton.TabIndex = 6;
            this.closeButton.Text = "Done";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButtonClick);
            // 
            // MorePatronInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1412, 691);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.firstVisitLabel);
            this.Controls.Add(this.lastVisitLabel);
            this.Controls.Add(this.phoneNumberLabel);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.dateOfBirthLabel);
            this.Controls.Add(this.nameLabel);
            this.Name = "MorePatronInfoForm";
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
    }
}