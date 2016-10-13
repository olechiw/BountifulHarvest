namespace ExitApplication
{
    partial class BeginInterfaceForm
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
            this.patronNameTextBox = new System.Windows.Forms.TextBox();
            this.patronNameLabel = new System.Windows.Forms.Label();
            this.visitDateLabel = new System.Windows.Forms.Label();
            this.visitDateTextBox = new System.Windows.Forms.TextBox();
            this.patronVisitLabel = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // patronNameTextBox
            // 
            this.patronNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patronNameTextBox.Location = new System.Drawing.Point(55, 178);
            this.patronNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.patronNameTextBox.Name = "patronNameTextBox";
            this.patronNameTextBox.Size = new System.Drawing.Size(343, 38);
            this.patronNameTextBox.TabIndex = 0;
            // 
            // patronNameLabel
            // 
            this.patronNameLabel.AutoSize = true;
            this.patronNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patronNameLabel.Location = new System.Drawing.Point(133, 125);
            this.patronNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.patronNameLabel.Name = "patronNameLabel";
            this.patronNameLabel.Size = new System.Drawing.Size(181, 32);
            this.patronNameLabel.TabIndex = 1;
            this.patronNameLabel.Text = "Patron Name";
            // 
            // visitDateLabel
            // 
            this.visitDateLabel.AutoSize = true;
            this.visitDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.visitDateLabel.Location = new System.Drawing.Point(133, 263);
            this.visitDateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.visitDateLabel.Name = "visitDateLabel";
            this.visitDateLabel.Size = new System.Drawing.Size(137, 32);
            this.visitDateLabel.TabIndex = 2;
            this.visitDateLabel.Text = "Visit Date";
            // 
            // visitDateTextBox
            // 
            this.visitDateTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.visitDateTextBox.Location = new System.Drawing.Point(55, 318);
            this.visitDateTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.visitDateTextBox.Name = "visitDateTextBox";
            this.visitDateTextBox.Size = new System.Drawing.Size(343, 38);
            this.visitDateTextBox.TabIndex = 3;
            // 
            // patronVisitLabel
            // 
            this.patronVisitLabel.AutoSize = true;
            this.patronVisitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patronVisitLabel.Location = new System.Drawing.Point(496, 28);
            this.patronVisitLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.patronVisitLabel.Name = "patronVisitLabel";
            this.patronVisitLabel.Size = new System.Drawing.Size(354, 46);
            this.patronVisitLabel.TabIndex = 4;
            this.patronVisitLabel.Text = "Log a Patron Visit";
            // 
            // submitButton
            // 
            this.submitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitButton.Location = new System.Drawing.Point(1169, 644);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(193, 72);
            this.submitButton.TabIndex = 5;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            // 
            // BeginInterfaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1442, 851);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.patronVisitLabel);
            this.Controls.Add(this.visitDateTextBox);
            this.Controls.Add(this.visitDateLabel);
            this.Controls.Add(this.patronNameLabel);
            this.Controls.Add(this.patronNameTextBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1918, 898);
            this.Name = "BeginInterfaceForm";
            this.Text = "Bountiful Harvest Patron Database";
            this.Load += new System.EventHandler(this.BeginInterface_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox patronNameTextBox;
        private System.Windows.Forms.Label patronNameLabel;
        private System.Windows.Forms.Label visitDateLabel;
        private System.Windows.Forms.TextBox visitDateTextBox;
        private System.Windows.Forms.Label patronVisitLabel;
        private System.Windows.Forms.Button submitButton;
    }
}

