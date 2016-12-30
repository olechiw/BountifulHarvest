namespace EntryApplication
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
            this.label1 = new System.Windows.Forms.Label();
            this.searchBox = new Common.LatinTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.addPatronButton = new System.Windows.Forms.Button();
            this.editPatronButton = new System.Windows.Forms.Button();
            this.visitPrintButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.outputDataView = new System.Windows.Forms.DataGridView();
            this.dateLabel = new System.Windows.Forms.Label();
            this.morePatronInfoButton = new System.Windows.Forms.Button();
            this.patronFirstNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.middleIColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patronLastNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patronGenderColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patronLastVisit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patronDateOfBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patronAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patronFamilyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patronIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.outputDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Output:";
            // 
            // searchBox
            // 
            this.searchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBox.Location = new System.Drawing.Point(255, 65);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(467, 28);
            this.searchBox.TabIndex = 2;
            this.searchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchBoxKeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(304, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(397, 38);
            this.label2.TabIndex = 4;
            this.label2.Text = "Search Patron Database";
            // 
            // addPatronButton
            // 
            this.addPatronButton.Location = new System.Drawing.Point(1400, 131);
            this.addPatronButton.Name = "addPatronButton";
            this.addPatronButton.Size = new System.Drawing.Size(150, 46);
            this.addPatronButton.TabIndex = 5;
            this.addPatronButton.Text = "Add Patron Entry";
            this.addPatronButton.UseVisualStyleBackColor = true;
            this.addPatronButton.Click += new System.EventHandler(this.addPatronButtonClick);
            // 
            // editPatronButton
            // 
            this.editPatronButton.Location = new System.Drawing.Point(1400, 314);
            this.editPatronButton.Name = "editPatronButton";
            this.editPatronButton.Size = new System.Drawing.Size(150, 46);
            this.editPatronButton.TabIndex = 6;
            this.editPatronButton.Text = "Edit Patron Entry";
            this.editPatronButton.UseVisualStyleBackColor = true;
            this.editPatronButton.Click += new System.EventHandler(this.editPatronButtonClick);
            // 
            // visitPrintButton
            // 
            this.visitPrintButton.Location = new System.Drawing.Point(1400, 579);
            this.visitPrintButton.Name = "visitPrintButton";
            this.visitPrintButton.Size = new System.Drawing.Size(150, 46);
            this.visitPrintButton.TabIndex = 7;
            this.visitPrintButton.Text = "Print A Visit";
            this.visitPrintButton.UseVisualStyleBackColor = true;
            this.visitPrintButton.Click += new System.EventHandler(this.printVisitButtonClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(400, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Enter a Name (First or Last)";
            // 
            // outputDataView
            // 
            this.outputDataView.AllowUserToAddRows = false;
            this.outputDataView.AllowUserToDeleteRows = false;
            this.outputDataView.AllowUserToResizeColumns = false;
            this.outputDataView.AllowUserToResizeRows = false;
            this.outputDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.outputDataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.patronFirstNameColumn,
            this.middleIColumn,
            this.patronLastNameColumn,
            this.patronGenderColumn,
            this.patronLastVisit,
            this.patronDateOfBirth,
            this.patronAge,
            this.patronFamilyColumn,
            this.patronIDColumn});
            this.outputDataView.Location = new System.Drawing.Point(31, 131);
            this.outputDataView.MultiSelect = false;
            this.outputDataView.Name = "outputDataView";
            this.outputDataView.ReadOnly = true;
            this.outputDataView.RowTemplate.Height = 24;
            this.outputDataView.Size = new System.Drawing.Size(1314, 708);
            this.outputDataView.TabIndex = 3;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(968, 47);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(92, 17);
            this.dateLabel.TabIndex = 9;
            this.dateLabel.Text = "Today\'s Date";
            // 
            // morePatronInfoButton
            // 
            this.morePatronInfoButton.Location = new System.Drawing.Point(1400, 443);
            this.morePatronInfoButton.Name = "morePatronInfoButton";
            this.morePatronInfoButton.Size = new System.Drawing.Size(150, 46);
            this.morePatronInfoButton.TabIndex = 10;
            this.morePatronInfoButton.Text = "More Info";
            this.morePatronInfoButton.UseVisualStyleBackColor = true;
            this.morePatronInfoButton.Click += new System.EventHandler(this.morePatronInfoButtonClick);
            // 
            // patronFirstNameColumn
            // 
            this.patronFirstNameColumn.HeaderText = "First Name";
            this.patronFirstNameColumn.Name = "patronFirstNameColumn";
            this.patronFirstNameColumn.ReadOnly = true;
            this.patronFirstNameColumn.Width = 150;
            // 
            // middleIColumn
            // 
            this.middleIColumn.HeaderText = "M.I.";
            this.middleIColumn.Name = "middleIColumn";
            this.middleIColumn.ReadOnly = true;
            this.middleIColumn.Width = 70;
            // 
            // patronLastNameColumn
            // 
            this.patronLastNameColumn.HeaderText = "Last Name";
            this.patronLastNameColumn.Name = "patronLastNameColumn";
            this.patronLastNameColumn.ReadOnly = true;
            this.patronLastNameColumn.Width = 150;
            // 
            // patronGenderColumn
            // 
            this.patronGenderColumn.HeaderText = "Gender";
            this.patronGenderColumn.Name = "patronGenderColumn";
            this.patronGenderColumn.ReadOnly = true;
            this.patronGenderColumn.Width = 70;
            // 
            // patronLastVisit
            // 
            this.patronLastVisit.HeaderText = "DateOfLastVisit";
            this.patronLastVisit.Name = "patronLastVisit";
            this.patronLastVisit.ReadOnly = true;
            this.patronLastVisit.Width = 150;
            // 
            // patronDateOfBirth
            // 
            this.patronDateOfBirth.HeaderText = "DateOfBirth";
            this.patronDateOfBirth.Name = "patronDateOfBirth";
            this.patronDateOfBirth.ReadOnly = true;
            this.patronDateOfBirth.Width = 150;
            // 
            // patronAge
            // 
            this.patronAge.HeaderText = "Age";
            this.patronAge.Name = "patronAge";
            this.patronAge.ReadOnly = true;
            // 
            // patronFamilyColumn
            // 
            this.patronFamilyColumn.HeaderText = "Family";
            this.patronFamilyColumn.Name = "patronFamilyColumn";
            this.patronFamilyColumn.ReadOnly = true;
            this.patronFamilyColumn.Width = 250;
            // 
            // patronIDColumn
            // 
            this.patronIDColumn.HeaderText = "Patron ID";
            this.patronIDColumn.Name = "patronIDColumn";
            this.patronIDColumn.ReadOnly = true;
            // 
            // BeginInterfaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1900, 851);
            this.Controls.Add(this.morePatronInfoButton);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.visitPrintButton);
            this.Controls.Add(this.editPatronButton);
            this.Controls.Add(this.addPatronButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.outputDataView);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(1918, 898);
            this.Name = "BeginInterfaceForm";
            this.Text = "Bountiful Harvest Patron Database";
            this.Load += new System.EventHandler(this.BeginInterfaceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.outputDataView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private Common.LatinTextBox searchBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addPatronButton;
        private System.Windows.Forms.Button editPatronButton;
        private System.Windows.Forms.Button visitPrintButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView outputDataView;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Button morePatronInfoButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn patronFirstNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn middleIColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patronLastNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patronGenderColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patronLastVisit;
        private System.Windows.Forms.DataGridViewTextBoxColumn patronDateOfBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn patronAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn patronFamilyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patronIDColumn;
    }
}

