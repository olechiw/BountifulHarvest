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
            this.patronVisitLabel = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.outputDataView = new System.Windows.Forms.DataGridView();
            this.firstnameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.middleInitialColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPoundsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateOfVisitColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.visitIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patronIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.poundsLabel = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.dateLabel = new System.Windows.Forms.Label();
            this.totalPoundsSpinner = new System.Windows.Forms.NumericUpDown();
            this.patronIDLabel = new System.Windows.Forms.Label();
            this.patronIDTextBox = new Common.NumericTextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.outputDataView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalPoundsSpinner)).BeginInit();
            this.SuspendLayout();
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
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.Location = new System.Drawing.Point(809, 661);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(193, 72);
            this.deleteButton.TabIndex = 5;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButtonClick);
            // 
            // outputDataView
            // 
            this.outputDataView.AllowUserToAddRows = false;
            this.outputDataView.AllowUserToDeleteRows = false;
            this.outputDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.outputDataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.firstnameColumn,
            this.middleInitialColumn,
            this.lastNameColumn,
            this.totalPoundsColumn,
            this.dateOfVisitColumn,
            this.visitIDColumn,
            this.patronIDColumn});
            this.outputDataView.GridColor = System.Drawing.SystemColors.MenuHighlight;
            this.outputDataView.Location = new System.Drawing.Point(27, 271);
            this.outputDataView.MultiSelect = false;
            this.outputDataView.Name = "outputDataView";
            this.outputDataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.outputDataView.Size = new System.Drawing.Size(754, 462);
            this.outputDataView.TabIndex = 6;
            this.outputDataView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.outputDataView_CellEndEdit);
            this.outputDataView.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.outputDataView_CellEndEdit);
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
            // patronIDColumn
            // 
            this.patronIDColumn.HeaderText = "PatronID";
            this.patronIDColumn.Name = "patronIDColumn";
            // 
            // poundsLabel
            // 
            this.poundsLabel.AutoSize = true;
            this.poundsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.poundsLabel.Location = new System.Drawing.Point(252, 125);
            this.poundsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.poundsLabel.Name = "poundsLabel";
            this.poundsLabel.Size = new System.Drawing.Size(140, 32);
            this.poundsLabel.TabIndex = 10;
            this.poundsLabel.Text = "Total Lbs.";
            // 
            // submitButton
            // 
            this.submitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitButton.Location = new System.Drawing.Point(800, 271);
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
            this.dateLabel.Location = new System.Drawing.Point(467, 125);
            this.dateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(90, 32);
            this.dateLabel.TabIndex = 12;
            this.dateLabel.Text = "Date: ";
            // 
            // totalPoundsSpinner
            // 
            this.totalPoundsSpinner.Location = new System.Drawing.Point(258, 188);
            this.totalPoundsSpinner.Name = "totalPoundsSpinner";
            this.totalPoundsSpinner.Size = new System.Drawing.Size(134, 28);
            this.totalPoundsSpinner.TabIndex = 3;
            // 
            // patronIDLabel
            // 
            this.patronIDLabel.AutoSize = true;
            this.patronIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patronIDLabel.Location = new System.Drawing.Point(59, 125);
            this.patronIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.patronIDLabel.Name = "patronIDLabel";
            this.patronIDLabel.Size = new System.Drawing.Size(133, 32);
            this.patronIDLabel.TabIndex = 16;
            this.patronIDLabel.Text = "Patron ID";
            // 
            // patronIDTextBox
            // 
            this.patronIDTextBox.Location = new System.Drawing.Point(65, 188);
            this.patronIDTextBox.Name = "patronIDTextBox";
            this.patronIDTextBox.Size = new System.Drawing.Size(127, 28);
            this.patronIDTextBox.TabIndex = 17;
            this.patronIDTextBox.TextChanged += new System.EventHandler(this.patronIDChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 746);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1226, 24);
            this.label1.TabIndex = 18;
            this.label1.Text = "Edit the cell value and hit ENTER to change existing number of total pounds. If a" +
    "ny non-number characters are entered the value will not be saved";
            // 
            // BeginInterfaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1442, 851);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.patronIDTextBox);
            this.Controls.Add(this.patronIDLabel);
            this.Controls.Add(this.totalPoundsSpinner);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.poundsLabel);
            this.Controls.Add(this.outputDataView);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.patronVisitLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1918, 898);
            this.Name = "BeginInterfaceForm";
            this.Text = "Bountiful Harvest Patron Database";
            this.Load += new System.EventHandler(this.BeginInterface_Load);
            ((System.ComponentModel.ISupportInitialize)(this.outputDataView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalPoundsSpinner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label patronVisitLabel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.DataGridView outputDataView;
        private System.Windows.Forms.Label poundsLabel;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstnameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn middleInitialColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPoundsColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateOfVisitColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn visitIDColumn;
        private System.Windows.Forms.NumericUpDown totalPoundsSpinner;
        private System.Windows.Forms.Label patronIDLabel;
        private Common.NumericTextBox patronIDTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn patronIDColumn;
        private System.Windows.Forms.Label label1;
    }
}

