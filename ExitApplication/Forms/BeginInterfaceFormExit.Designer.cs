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
            this.patronNameLabel = new System.Windows.Forms.Label();
            this.patronVisitLabel = new System.Windows.Forms.Label();
            this.undoButton = new System.Windows.Forms.Button();
            this.outputDataView = new System.Windows.Forms.DataGridView();
            this.firstnameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.middleInitialColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPoundsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateOfVisitColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.visitIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.poundsLabel = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.dateLabel = new System.Windows.Forms.Label();
            this.patronLastNameTextBox = new Common.LatinTextBox();
            this.patronMiddleInitialTextBox = new Common.LatinTextBox();
            this.patronFirstNameTextBox = new Common.LatinTextBox();
            this.familySizeLabel = new System.Windows.Forms.Label();
            this.totalPoundsSpinner = new System.Windows.Forms.NumericUpDown();
            this.sizeOfFamilySpinner = new System.Windows.Forms.NumericUpDown();
            this.patronIDTextBox = new Common.NumericTextBox();
            this.patronIDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.outputDataView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalPoundsSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeOfFamilySpinner)).BeginInit();
            this.SuspendLayout();
            // 
            // patronNameLabel
            // 
            this.patronNameLabel.AutoSize = true;
            this.patronNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patronNameLabel.Location = new System.Drawing.Point(126, 125);
            this.patronNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.patronNameLabel.Name = "patronNameLabel";
            this.patronNameLabel.Size = new System.Drawing.Size(181, 32);
            this.patronNameLabel.TabIndex = 1;
            this.patronNameLabel.Text = "Patron Name";
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
            // undoButton
            // 
            this.undoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.undoButton.Location = new System.Drawing.Point(1150, 661);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(193, 72);
            this.undoButton.TabIndex = 5;
            this.undoButton.Text = "Undo";
            this.undoButton.UseVisualStyleBackColor = true;
            this.undoButton.Click += new System.EventHandler(this.undoButtonClick);
            // 
            // outputDataView
            // 
            this.outputDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.outputDataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.firstnameColumn,
            this.middleInitialColumn,
            this.lastNameColumn,
            this.totalPoundsColumn,
            this.dateOfVisitColumn,
            this.visitIDColumn});
            this.outputDataView.Location = new System.Drawing.Point(65, 271);
            this.outputDataView.Name = "outputDataView";
            this.outputDataView.Size = new System.Drawing.Size(1031, 462);
            this.outputDataView.TabIndex = 6;
            // 
            // firstnameColumn
            // 
            this.firstnameColumn.HeaderText = "First Name";
            this.firstnameColumn.Name = "firstnameColumn";
            // 
            // middleInitialColumn
            // 
            this.middleInitialColumn.HeaderText = "Middle Initial";
            this.middleInitialColumn.Name = "middleInitialColumn";
            // 
            // lastNameColumn
            // 
            this.lastNameColumn.HeaderText = "Last Name";
            this.lastNameColumn.Name = "lastNameColumn";
            // 
            // totalPoundsColumn
            // 
            this.totalPoundsColumn.HeaderText = "Total Lbs.";
            this.totalPoundsColumn.Name = "totalPoundsColumn";
            // 
            // dateOfVisitColumn
            // 
            this.dateOfVisitColumn.HeaderText = "Date Of Visit";
            this.dateOfVisitColumn.Name = "dateOfVisitColumn";
            // 
            // visitIDColumn
            // 
            this.visitIDColumn.HeaderText = "Visit ID";
            this.visitIDColumn.Name = "visitIDColumn";
            // 
            // poundsLabel
            // 
            this.poundsLabel.AutoSize = true;
            this.poundsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.poundsLabel.Location = new System.Drawing.Point(589, 125);
            this.poundsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.poundsLabel.Name = "poundsLabel";
            this.poundsLabel.Size = new System.Drawing.Size(140, 32);
            this.poundsLabel.TabIndex = 10;
            this.poundsLabel.Text = "Total Lbs.";
            // 
            // submitButton
            // 
            this.submitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitButton.Location = new System.Drawing.Point(1150, 369);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(193, 72);
            this.submitButton.TabIndex = 11;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButtonClick);
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLabel.Location = new System.Drawing.Point(1248, 51);
            this.dateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(90, 32);
            this.dateLabel.TabIndex = 12;
            this.dateLabel.Text = "Date: ";
            // 
            // patronLastNameTextBox
            // 
            this.patronLastNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patronLastNameTextBox.Location = new System.Drawing.Point(234, 178);
            this.patronLastNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.patronLastNameTextBox.Name = "patronLastNameTextBox";
            this.patronLastNameTextBox.Size = new System.Drawing.Size(128, 38);
            this.patronLastNameTextBox.TabIndex = 2;
            // 
            // patronMiddleInitialTextBox
            // 
            this.patronMiddleInitialTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patronMiddleInitialTextBox.Location = new System.Drawing.Point(191, 178);
            this.patronMiddleInitialTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.patronMiddleInitialTextBox.Name = "patronMiddleInitialTextBox";
            this.patronMiddleInitialTextBox.Size = new System.Drawing.Size(35, 38);
            this.patronMiddleInitialTextBox.TabIndex = 1;
            // 
            // patronFirstNameTextBox
            // 
            this.patronFirstNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patronFirstNameTextBox.Location = new System.Drawing.Point(55, 178);
            this.patronFirstNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.patronFirstNameTextBox.Name = "patronFirstNameTextBox";
            this.patronFirstNameTextBox.Size = new System.Drawing.Size(128, 38);
            this.patronFirstNameTextBox.TabIndex = 0;
            // 
            // familySizeLabel
            // 
            this.familySizeLabel.AutoSize = true;
            this.familySizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.familySizeLabel.Location = new System.Drawing.Point(829, 125);
            this.familySizeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.familySizeLabel.Name = "familySizeLabel";
            this.familySizeLabel.Size = new System.Drawing.Size(162, 32);
            this.familySizeLabel.TabIndex = 14;
            this.familySizeLabel.Text = "Family Size";
            // 
            // totalPoundsSpinner
            // 
            this.totalPoundsSpinner.Location = new System.Drawing.Point(595, 188);
            this.totalPoundsSpinner.Name = "totalPoundsSpinner";
            this.totalPoundsSpinner.Size = new System.Drawing.Size(134, 28);
            this.totalPoundsSpinner.TabIndex = 3;
            // 
            // sizeOfFamilySpinner
            // 
            this.sizeOfFamilySpinner.Location = new System.Drawing.Point(835, 187);
            this.sizeOfFamilySpinner.Name = "sizeOfFamilySpinner";
            this.sizeOfFamilySpinner.Size = new System.Drawing.Size(156, 28);
            this.sizeOfFamilySpinner.TabIndex = 4;
            // 
            // patronIDTextBox
            // 
            this.patronIDTextBox.Location = new System.Drawing.Point(1116, 188);
            this.patronIDTextBox.Name = "patronIDTextBox";
            this.patronIDTextBox.Size = new System.Drawing.Size(127, 28);
            this.patronIDTextBox.TabIndex = 5;
            // 
            // patronIDLabel
            // 
            this.patronIDLabel.AutoSize = true;
            this.patronIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patronIDLabel.Location = new System.Drawing.Point(1110, 125);
            this.patronIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.patronIDLabel.Name = "patronIDLabel";
            this.patronIDLabel.Size = new System.Drawing.Size(133, 32);
            this.patronIDLabel.TabIndex = 16;
            this.patronIDLabel.Text = "Patron ID";
            // 
            // BeginInterfaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1442, 851);
            this.Controls.Add(this.patronIDLabel);
            this.Controls.Add(this.patronIDTextBox);
            this.Controls.Add(this.sizeOfFamilySpinner);
            this.Controls.Add(this.totalPoundsSpinner);
            this.Controls.Add(this.familySizeLabel);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.poundsLabel);
            this.Controls.Add(this.patronLastNameTextBox);
            this.Controls.Add(this.patronMiddleInitialTextBox);
            this.Controls.Add(this.outputDataView);
            this.Controls.Add(this.undoButton);
            this.Controls.Add(this.patronVisitLabel);
            this.Controls.Add(this.patronNameLabel);
            this.Controls.Add(this.patronFirstNameTextBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1918, 898);
            this.Name = "BeginInterfaceForm";
            this.Text = "Bountiful Harvest Patron Database";
            this.Load += new System.EventHandler(this.BeginInterface_Load);
            ((System.ComponentModel.ISupportInitialize)(this.outputDataView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalPoundsSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeOfFamilySpinner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.LatinTextBox patronFirstNameTextBox;
        private System.Windows.Forms.Label patronNameLabel;
        private System.Windows.Forms.Label patronVisitLabel;
        private System.Windows.Forms.Button undoButton;
        private System.Windows.Forms.DataGridView outputDataView;
        private Common.LatinTextBox patronMiddleInitialTextBox;
        private Common.LatinTextBox patronLastNameTextBox;
        private System.Windows.Forms.Label poundsLabel;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstnameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn middleInitialColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPoundsColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateOfVisitColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn visitIDColumn;
        private System.Windows.Forms.Label familySizeLabel;
        private System.Windows.Forms.NumericUpDown totalPoundsSpinner;
        private System.Windows.Forms.NumericUpDown sizeOfFamilySpinner;
        private Common.NumericTextBox patronIDTextBox;
        private System.Windows.Forms.Label patronIDLabel;
    }
}

