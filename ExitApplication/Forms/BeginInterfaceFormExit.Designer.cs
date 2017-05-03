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
            this.patronIDTextBox = new Common.SafeTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.searchDataView = new System.Windows.Forms.DataGridView();
            this.patronSearchName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patronID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patronSearchTextBox = new System.Windows.Forms.TextBox();
            this.patronSearchLabel = new System.Windows.Forms.Label();
            this.thanksgiving = new System.Windows.Forms.CheckBox();
            this.winter = new System.Windows.Forms.CheckBox();
            this.easter = new System.Windows.Forms.CheckBox();
            this.school = new System.Windows.Forms.CheckBox();
            this.christmas = new System.Windows.Forms.CheckBox();
            this.halloween = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.outputDataView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalPoundsSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchDataView)).BeginInit();
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
            this.deleteButton.Location = new System.Drawing.Point(800, 647);
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
            this.outputDataView.Size = new System.Drawing.Size(754, 448);
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
            this.label1.Location = new System.Drawing.Point(23, 722);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1226, 24);
            this.label1.TabIndex = 18;
            this.label1.Text = "Edit the cell value and hit ENTER to change existing number of total pounds. If a" +
    "ny non-number characters are entered the value will not be saved";
            // 
            // searchDataView
            // 
            this.searchDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchDataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.patronSearchName,
            this.patronID});
            this.searchDataView.Location = new System.Drawing.Point(1058, 193);
            this.searchDataView.Name = "searchDataView";
            this.searchDataView.RowTemplate.Height = 24;
            this.searchDataView.Size = new System.Drawing.Size(328, 442);
            this.searchDataView.TabIndex = 19;
            // 
            // patronSearchName
            // 
            this.patronSearchName.HeaderText = "Name";
            this.patronSearchName.MinimumWidth = 200;
            this.patronSearchName.Name = "patronSearchName";
            this.patronSearchName.Width = 200;
            // 
            // patronID
            // 
            this.patronID.HeaderText = "ID";
            this.patronID.Name = "patronID";
            // 
            // patronSearchTextBox
            // 
            this.patronSearchTextBox.Location = new System.Drawing.Point(1058, 125);
            this.patronSearchTextBox.Name = "patronSearchTextBox";
            this.patronSearchTextBox.Size = new System.Drawing.Size(328, 28);
            this.patronSearchTextBox.TabIndex = 20;
            this.patronSearchTextBox.TextChanged += new System.EventHandler(this.patronSearchTextBoxChanged);
            // 
            // patronSearchLabel
            // 
            this.patronSearchLabel.AutoSize = true;
            this.patronSearchLabel.Location = new System.Drawing.Point(1162, 98);
            this.patronSearchLabel.Name = "patronSearchLabel";
            this.patronSearchLabel.Size = new System.Drawing.Size(121, 24);
            this.patronSearchLabel.TabIndex = 21;
            this.patronSearchLabel.Text = "Search Label";
            // 
            // thanksgiving
            // 
            this.thanksgiving.AutoSize = true;
            this.thanksgiving.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thanksgiving.Location = new System.Drawing.Point(800, 581);
            this.thanksgiving.Name = "thanksgiving";
            this.thanksgiving.Size = new System.Drawing.Size(151, 29);
            this.thanksgiving.TabIndex = 28;
            this.thanksgiving.Text = "Thanksgiving";
            this.thanksgiving.UseVisualStyleBackColor = true;
            // 
            // winter
            // 
            this.winter.AutoSize = true;
            this.winter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winter.Location = new System.Drawing.Point(800, 406);
            this.winter.Name = "winter";
            this.winter.Size = new System.Drawing.Size(138, 29);
            this.winter.TabIndex = 32;
            this.winter.Text = "Winter Coat";
            this.winter.UseVisualStyleBackColor = true;
            // 
            // easter
            // 
            this.easter.AutoSize = true;
            this.easter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.easter.Location = new System.Drawing.Point(800, 476);
            this.easter.Name = "easter";
            this.easter.Size = new System.Drawing.Size(90, 29);
            this.easter.TabIndex = 27;
            this.easter.Text = "Easter";
            this.easter.UseVisualStyleBackColor = true;
            // 
            // school
            // 
            this.school.AutoSize = true;
            this.school.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.school.Location = new System.Drawing.Point(800, 511);
            this.school.Name = "school";
            this.school.Size = new System.Drawing.Size(176, 29);
            this.school.TabIndex = 30;
            this.school.Text = "School Supplies";
            this.school.UseVisualStyleBackColor = true;
            // 
            // christmas
            // 
            this.christmas.AutoSize = true;
            this.christmas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.christmas.Location = new System.Drawing.Point(800, 441);
            this.christmas.Name = "christmas";
            this.christmas.Size = new System.Drawing.Size(122, 29);
            this.christmas.TabIndex = 29;
            this.christmas.Text = "Christmas";
            this.christmas.UseVisualStyleBackColor = true;
            // 
            // halloween
            // 
            this.halloween.AutoSize = true;
            this.halloween.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.halloween.Location = new System.Drawing.Point(800, 546);
            this.halloween.Name = "halloween";
            this.halloween.Size = new System.Drawing.Size(130, 29);
            this.halloween.TabIndex = 31;
            this.halloween.Text = "Halloween ";
            this.halloween.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 759);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(329, 24);
            this.label2.TabIndex = 33;
            this.label2.Text = "The same goes for the DATE of a Visit";
            // 
            // BeginInterfaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1442, 851);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.halloween);
            this.Controls.Add(this.winter);
            this.Controls.Add(this.christmas);
            this.Controls.Add(this.school);
            this.Controls.Add(this.patronSearchLabel);
            this.Controls.Add(this.patronSearchTextBox);
            this.Controls.Add(this.easter);
            this.Controls.Add(this.searchDataView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.thanksgiving);
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
            ((System.ComponentModel.ISupportInitialize)(this.searchDataView)).EndInit();
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
        private Common.SafeTextBox patronIDTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn patronIDColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView searchDataView;
        private System.Windows.Forms.TextBox patronSearchTextBox;
        private System.Windows.Forms.Label patronSearchLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn patronSearchName;
        private System.Windows.Forms.DataGridViewTextBoxColumn patronID;
        private System.Windows.Forms.CheckBox thanksgiving;
        private System.Windows.Forms.CheckBox winter;
        private System.Windows.Forms.CheckBox easter;
        private System.Windows.Forms.CheckBox school;
        private System.Windows.Forms.CheckBox christmas;
        private System.Windows.Forms.CheckBox halloween;
        private System.Windows.Forms.Label label2;
    }
}

