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
            this.outputDataView = new System.Windows.Forms.DataGridView();
            this.firstnameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.middleInitialColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPoundsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateOfVisitColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.visitIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patronIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.initialVisitDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.outputDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(9, 37);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(77, 26);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name:";
            // 
            // dateOfBirthLabel
            // 
            this.dateOfBirthLabel.AutoSize = true;
            this.dateOfBirthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateOfBirthLabel.Location = new System.Drawing.Point(9, 149);
            this.dateOfBirthLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dateOfBirthLabel.Name = "dateOfBirthLabel";
            this.dateOfBirthLabel.Size = new System.Drawing.Size(139, 26);
            this.dateOfBirthLabel.TabIndex = 1;
            this.dateOfBirthLabel.Text = "Date of Birth:";
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.addressLabel.Location = new System.Drawing.Point(9, 264);
            this.addressLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(98, 26);
            this.addressLabel.TabIndex = 2;
            this.addressLabel.Text = "Address:";
            // 
            // phoneNumberLabel
            // 
            this.phoneNumberLabel.AutoSize = true;
            this.phoneNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.phoneNumberLabel.Location = new System.Drawing.Point(9, 379);
            this.phoneNumberLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.phoneNumberLabel.Name = "phoneNumberLabel";
            this.phoneNumberLabel.Size = new System.Drawing.Size(165, 26);
            this.phoneNumberLabel.TabIndex = 3;
            this.phoneNumberLabel.Text = "Phone Number:";
            // 
            // lastVisitLabel
            // 
            this.lastVisitLabel.AutoSize = true;
            this.lastVisitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lastVisitLabel.Location = new System.Drawing.Point(363, 37);
            this.lastVisitLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lastVisitLabel.Name = "lastVisitLabel";
            this.lastVisitLabel.Size = new System.Drawing.Size(107, 26);
            this.lastVisitLabel.TabIndex = 4;
            this.lastVisitLabel.Text = "Last Visit:";
            // 
            // firstVisitLabel
            // 
            this.firstVisitLabel.AutoSize = true;
            this.firstVisitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.firstVisitLabel.Location = new System.Drawing.Point(363, 185);
            this.firstVisitLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.firstVisitLabel.Name = "firstVisitLabel";
            this.firstVisitLabel.Size = new System.Drawing.Size(108, 26);
            this.firstVisitLabel.TabIndex = 5;
            this.firstVisitLabel.Text = "First Visit:";
            // 
            // closeButton
            // 
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.closeButton.Location = new System.Drawing.Point(491, 465);
            this.closeButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(139, 66);
            this.closeButton.TabIndex = 6;
            this.closeButton.Text = "Done";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButtonClick);
            // 
            // familyLabel
            // 
            this.familyLabel.AutoSize = true;
            this.familyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.familyLabel.Location = new System.Drawing.Point(363, 264);
            this.familyLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.familyLabel.Name = "familyLabel";
            this.familyLabel.Size = new System.Drawing.Size(83, 26);
            this.familyLabel.TabIndex = 7;
            this.familyLabel.Text = "Family:";
            // 
            // commentsLabel
            // 
            this.commentsLabel.AutoSize = true;
            this.commentsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.commentsLabel.Location = new System.Drawing.Point(363, 379);
            this.commentsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.commentsLabel.Name = "commentsLabel";
            this.commentsLabel.Size = new System.Drawing.Size(125, 26);
            this.commentsLabel.TabIndex = 8;
            this.commentsLabel.Text = "Comments:";
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
            this.outputDataView.Location = new System.Drawing.Point(740, 50);
            this.outputDataView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.outputDataView.MultiSelect = false;
            this.outputDataView.Name = "outputDataView";
            this.outputDataView.ReadOnly = true;
            this.outputDataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.outputDataView.Size = new System.Drawing.Size(548, 311);
            this.outputDataView.TabIndex = 9;
            // 
            // firstnameColumn
            // 
            this.firstnameColumn.HeaderText = "First Name";
            this.firstnameColumn.Name = "firstnameColumn";
            this.firstnameColumn.ReadOnly = true;
            // 
            // middleInitialColumn
            // 
            this.middleInitialColumn.HeaderText = "Middle Initial";
            this.middleInitialColumn.Name = "middleInitialColumn";
            this.middleInitialColumn.ReadOnly = true;
            // 
            // lastNameColumn
            // 
            this.lastNameColumn.HeaderText = "Last Name";
            this.lastNameColumn.Name = "lastNameColumn";
            this.lastNameColumn.ReadOnly = true;
            // 
            // totalPoundsColumn
            // 
            this.totalPoundsColumn.HeaderText = "Total Lbs.";
            this.totalPoundsColumn.Name = "totalPoundsColumn";
            this.totalPoundsColumn.ReadOnly = true;
            // 
            // dateOfVisitColumn
            // 
            this.dateOfVisitColumn.HeaderText = "Date Of Visit";
            this.dateOfVisitColumn.Name = "dateOfVisitColumn";
            this.dateOfVisitColumn.ReadOnly = true;
            // 
            // visitIDColumn
            // 
            this.visitIDColumn.HeaderText = "Visit ID";
            this.visitIDColumn.Name = "visitIDColumn";
            this.visitIDColumn.ReadOnly = true;
            // 
            // patronIDColumn
            // 
            this.patronIDColumn.HeaderText = "PatronId";
            this.patronIDColumn.Name = "patronIDColumn";
            this.patronIDColumn.ReadOnly = true;
            // 
            // initialVisitDate
            // 
            this.initialVisitDate.AutoSize = true;
            this.initialVisitDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.initialVisitDate.Location = new System.Drawing.Point(9, 465);
            this.initialVisitDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.initialVisitDate.Name = "initialVisitDate";
            this.initialVisitDate.Size = new System.Drawing.Size(175, 26);
            this.initialVisitDate.TabIndex = 10;
            this.initialVisitDate.Text = "Initial Visit Date: ";
            // 
            // MoreInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1318, 568);
            this.Controls.Add(this.initialVisitDate);
            this.Controls.Add(this.outputDataView);
            this.Controls.Add(this.commentsLabel);
            this.Controls.Add(this.familyLabel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.firstVisitLabel);
            this.Controls.Add(this.lastVisitLabel);
            this.Controls.Add(this.phoneNumberLabel);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.dateOfBirthLabel);
            this.Controls.Add(this.nameLabel);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximumSize = new System.Drawing.Size(1444, 885);
            this.MinimumSize = new System.Drawing.Size(1212, 607);
            this.Name = "MoreInfoForm";
            this.Text = "More Info";
            ((System.ComponentModel.ISupportInitialize)(this.outputDataView)).EndInit();
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
        private System.Windows.Forms.DataGridView outputDataView;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstnameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn middleInitialColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPoundsColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateOfVisitColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn visitIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patronIDColumn;
        private System.Windows.Forms.Label initialVisitDate;
    }
}