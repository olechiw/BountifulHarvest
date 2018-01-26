namespace EntryApplication
{
    partial class NewPatronForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.monthTextBox = new Common.SafeTextBox();
            this.dayTextBox = new Common.SafeTextBox();
            this.yearTextBox = new Common.SafeTextBox();
            this.firstNameTextBox = new Common.SafeTextBox();
            this.lastNameTextBox = new Common.SafeTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.middleInitialTextBox = new Common.SafeTextBox();
            this.relativesDataView = new System.Windows.Forms.DataGridView();
            this.patronFamilyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patronFamilyGender = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.patronFamilyMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patronFamilyDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patronFamilyYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addRowButton = new System.Windows.Forms.Button();
            this.relationsLabel = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.commentsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.genderLabel = new System.Windows.Forms.Label();
            this.phoneNumberTextBox = new Common.SafeTextBox();
            this.phoneNumberLabel = new System.Windows.Forms.Label();
            this.addressLabel = new System.Windows.Forms.Label();
            this.addressTextBox1 = new Common.SafeTextBox();
            this.addressTextBox2 = new Common.SafeTextBox();
            this.genderComboBox = new System.Windows.Forms.ComboBox();
            this.everyWeekCheckBox = new System.Windows.Forms.CheckBox();
            this.printVisitCheckBox = new System.Windows.Forms.CheckBox();
            this.veteranCheckBox = new System.Windows.Forms.CheckBox();
            this.seniorCheckBox = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.zipCodeUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.relativesDataView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zipCodeUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(268, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add a Patron";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(83, 110);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Date of Birth";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(164, 136);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "YYYY";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(124, 136);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "DD";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(86, 136);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "MM";
            // 
            // monthTextBox
            // 
            this.monthTextBox.Location = new System.Drawing.Point(88, 153);
            this.monthTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.monthTextBox.Name = "monthTextBox";
            this.monthTextBox.Size = new System.Drawing.Size(21, 20);
            this.monthTextBox.TabIndex = 7;
            // 
            // dayTextBox
            // 
            this.dayTextBox.Location = new System.Drawing.Point(127, 152);
            this.dayTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.dayTextBox.Name = "dayTextBox";
            this.dayTextBox.Size = new System.Drawing.Size(20, 20);
            this.dayTextBox.TabIndex = 8;
            // 
            // yearTextBox
            // 
            this.yearTextBox.Location = new System.Drawing.Point(166, 152);
            this.yearTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.yearTextBox.Name = "yearTextBox";
            this.yearTextBox.Size = new System.Drawing.Size(32, 20);
            this.yearTextBox.TabIndex = 9;
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(103, 73);
            this.firstNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(110, 20);
            this.firstNameTextBox.TabIndex = 0;
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(430, 73);
            this.lastNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(110, 20);
            this.lastNameTextBox.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(98, 45);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 26);
            this.label6.TabIndex = 10;
            this.label6.Text = "First Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(425, 45);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 26);
            this.label7.TabIndex = 11;
            this.label7.Text = "Last Name";
            // 
            // middleInitialTextBox
            // 
            this.middleInitialTextBox.Location = new System.Drawing.Point(319, 73);
            this.middleInitialTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.middleInitialTextBox.Name = "middleInitialTextBox";
            this.middleInitialTextBox.Size = new System.Drawing.Size(19, 20);
            this.middleInitialTextBox.TabIndex = 1;
            // 
            // relativesDataView
            // 
            this.relativesDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.relativesDataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.patronFamilyName,
            this.patronFamilyGender,
            this.patronFamilyMonth,
            this.patronFamilyDay,
            this.patronFamilyYear});
            this.relativesDataView.Location = new System.Drawing.Point(370, 167);
            this.relativesDataView.Margin = new System.Windows.Forms.Padding(2);
            this.relativesDataView.Name = "relativesDataView";
            this.relativesDataView.RowTemplate.Height = 24;
            this.relativesDataView.Size = new System.Drawing.Size(404, 240);
            this.relativesDataView.TabIndex = 17;
            this.relativesDataView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.RelativesDataViewEditing);
            this.relativesDataView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FamilyTextBoxKeyDown);
            // 
            // patronFamilyName
            // 
            this.patronFamilyName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.patronFamilyName.HeaderText = "Name";
            this.patronFamilyName.MinimumWidth = 95;
            this.patronFamilyName.Name = "patronFamilyName";
            // 
            // patronFamilyGender
            // 
            this.patronFamilyGender.HeaderText = "Gender";
            this.patronFamilyGender.Name = "patronFamilyGender";
            // 
            // patronFamilyMonth
            // 
            this.patronFamilyMonth.HeaderText = "MM";
            this.patronFamilyMonth.MinimumWidth = 30;
            this.patronFamilyMonth.Name = "patronFamilyMonth";
            this.patronFamilyMonth.Width = 30;
            // 
            // patronFamilyDay
            // 
            this.patronFamilyDay.HeaderText = "DD";
            this.patronFamilyDay.MinimumWidth = 30;
            this.patronFamilyDay.Name = "patronFamilyDay";
            this.patronFamilyDay.Width = 30;
            // 
            // patronFamilyYear
            // 
            this.patronFamilyYear.HeaderText = "YYYY";
            this.patronFamilyYear.MinimumWidth = 60;
            this.patronFamilyYear.Name = "patronFamilyYear";
            this.patronFamilyYear.Width = 60;
            // 
            // addRowButton
            // 
            this.addRowButton.Location = new System.Drawing.Point(344, 381);
            this.addRowButton.Margin = new System.Windows.Forms.Padding(2);
            this.addRowButton.Name = "addRowButton";
            this.addRowButton.Size = new System.Drawing.Size(21, 26);
            this.addRowButton.TabIndex = 16;
            this.addRowButton.Text = "+";
            this.addRowButton.UseVisualStyleBackColor = true;
            this.addRowButton.Click += new System.EventHandler(this.AddRowButtonClick);
            // 
            // relationsLabel
            // 
            this.relationsLabel.AutoSize = true;
            this.relationsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.relationsLabel.Location = new System.Drawing.Point(404, 139);
            this.relationsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.relationsLabel.Name = "relationsLabel";
            this.relationsLabel.Size = new System.Drawing.Size(103, 26);
            this.relationsLabel.TabIndex = 16;
            this.relationsLabel.Text = "Relations";
            // 
            // submitButton
            // 
            this.submitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitButton.Location = new System.Drawing.Point(10, 413);
            this.submitButton.Margin = new System.Windows.Forms.Padding(2);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(136, 33);
            this.submitButton.TabIndex = 17;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.SubmitButtonClick);
            // 
            // commentsRichTextBox
            // 
            this.commentsRichTextBox.Location = new System.Drawing.Point(36, 254);
            this.commentsRichTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.commentsRichTextBox.Name = "commentsRichTextBox";
            this.commentsRichTextBox.Size = new System.Drawing.Size(200, 113);
            this.commentsRichTextBox.TabIndex = 12;
            this.commentsRichTextBox.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F);
            this.label8.Location = new System.Drawing.Point(268, 45);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 26);
            this.label8.TabIndex = 13;
            this.label8.Text = "Middle Initial";
            // 
            // genderLabel
            // 
            this.genderLabel.AutoSize = true;
            this.genderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F);
            this.genderLabel.Location = new System.Drawing.Point(579, 45);
            this.genderLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.genderLabel.Name = "genderLabel";
            this.genderLabel.Size = new System.Drawing.Size(84, 26);
            this.genderLabel.TabIndex = 20;
            this.genderLabel.Text = "Gender";
            // 
            // phoneNumberTextBox
            // 
            this.phoneNumberTextBox.Location = new System.Drawing.Point(794, 93);
            this.phoneNumberTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.phoneNumberTextBox.Name = "phoneNumberTextBox";
            this.phoneNumberTextBox.Size = new System.Drawing.Size(202, 20);
            this.phoneNumberTextBox.TabIndex = 4;
            // 
            // phoneNumberLabel
            // 
            this.phoneNumberLabel.AutoSize = true;
            this.phoneNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F);
            this.phoneNumberLabel.Location = new System.Drawing.Point(819, 45);
            this.phoneNumberLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.phoneNumberLabel.Name = "phoneNumberLabel";
            this.phoneNumberLabel.Size = new System.Drawing.Size(159, 26);
            this.phoneNumberLabel.TabIndex = 22;
            this.phoneNumberLabel.Text = "Phone Number";
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F);
            this.addressLabel.Location = new System.Drawing.Point(848, 167);
            this.addressLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(92, 26);
            this.addressLabel.TabIndex = 23;
            this.addressLabel.Text = "Address";
            // 
            // addressTextBox1
            // 
            this.addressTextBox1.Location = new System.Drawing.Point(794, 213);
            this.addressTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.addressTextBox1.Name = "addressTextBox1";
            this.addressTextBox1.Size = new System.Drawing.Size(202, 20);
            this.addressTextBox1.TabIndex = 13;
            // 
            // addressTextBox2
            // 
            this.addressTextBox2.Location = new System.Drawing.Point(794, 245);
            this.addressTextBox2.Margin = new System.Windows.Forms.Padding(2);
            this.addressTextBox2.Name = "addressTextBox2";
            this.addressTextBox2.Size = new System.Drawing.Size(202, 20);
            this.addressTextBox2.TabIndex = 14;
            // 
            // genderComboBox
            // 
            this.genderComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.genderComboBox.FormattingEnabled = true;
            this.genderComboBox.Location = new System.Drawing.Point(584, 70);
            this.genderComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.genderComboBox.Name = "genderComboBox";
            this.genderComboBox.Size = new System.Drawing.Size(92, 21);
            this.genderComboBox.TabIndex = 3;
            // 
            // everyWeekCheckBox
            // 
            this.everyWeekCheckBox.AutoSize = true;
            this.everyWeekCheckBox.Location = new System.Drawing.Point(584, 110);
            this.everyWeekCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.everyWeekCheckBox.Name = "everyWeekCheckBox";
            this.everyWeekCheckBox.Size = new System.Drawing.Size(112, 17);
            this.everyWeekCheckBox.TabIndex = 5;
            this.everyWeekCheckBox.Text = "Visits Every Week";
            this.everyWeekCheckBox.UseVisualStyleBackColor = true;
            // 
            // printVisitCheckBox
            // 
            this.printVisitCheckBox.AutoSize = true;
            this.printVisitCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printVisitCheckBox.Location = new System.Drawing.Point(166, 413);
            this.printVisitCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.printVisitCheckBox.Name = "printVisitCheckBox";
            this.printVisitCheckBox.Size = new System.Drawing.Size(124, 30);
            this.printVisitCheckBox.TabIndex = 15;
            this.printVisitCheckBox.Text = "Print Visit";
            this.printVisitCheckBox.UseVisualStyleBackColor = true;
            // 
            // veteranCheckBox
            // 
            this.veteranCheckBox.AutoSize = true;
            this.veteranCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.veteranCheckBox.Location = new System.Drawing.Point(88, 191);
            this.veteranCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.veteranCheckBox.Name = "veteranCheckBox";
            this.veteranCheckBox.Size = new System.Drawing.Size(95, 28);
            this.veteranCheckBox.TabIndex = 10;
            this.veteranCheckBox.Text = "Veteran";
            this.veteranCheckBox.UseVisualStyleBackColor = true;
            // 
            // seniorCheckBox
            // 
            this.seniorCheckBox.AutoSize = true;
            this.seniorCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seniorCheckBox.Location = new System.Drawing.Point(88, 223);
            this.seniorCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.seniorCheckBox.Name = "seniorCheckBox";
            this.seniorCheckBox.Size = new System.Drawing.Size(164, 28);
            this.seniorCheckBox.TabIndex = 11;
            this.seniorCheckBox.Text = "CFSP Filled Out";
            this.seniorCheckBox.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(841, 267);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 25);
            this.label9.TabIndex = 24;
            this.label9.Text = "Zip Code";
            // 
            // zipCodeUpDown
            // 
            this.zipCodeUpDown.Location = new System.Drawing.Point(835, 295);
            this.zipCodeUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.zipCodeUpDown.Name = "zipCodeUpDown";
            this.zipCodeUpDown.Size = new System.Drawing.Size(120, 20);
            this.zipCodeUpDown.TabIndex = 25;
            // 
            // NewPatronForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 482);
            this.Controls.Add(this.zipCodeUpDown);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.seniorCheckBox);
            this.Controls.Add(this.veteranCheckBox);
            this.Controls.Add(this.printVisitCheckBox);
            this.Controls.Add(this.everyWeekCheckBox);
            this.Controls.Add(this.genderComboBox);
            this.Controls.Add(this.addressTextBox2);
            this.Controls.Add(this.addressTextBox1);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.phoneNumberLabel);
            this.Controls.Add(this.phoneNumberTextBox);
            this.Controls.Add(this.genderLabel);
            this.Controls.Add(this.commentsRichTextBox);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.relationsLabel);
            this.Controls.Add(this.addRowButton);
            this.Controls.Add(this.relativesDataView);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.middleInitialTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(this.yearTextBox);
            this.Controls.Add(this.dayTextBox);
            this.Controls.Add(this.monthTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "NewPatronForm";
            this.Text = "Winter Coat";
            ((System.ComponentModel.ISupportInitialize)(this.relativesDataView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zipCodeUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Common.SafeTextBox monthTextBox;
        private Common.SafeTextBox dayTextBox;
        private Common.SafeTextBox yearTextBox;
        private Common.SafeTextBox firstNameTextBox;
        private Common.SafeTextBox lastNameTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private Common.SafeTextBox middleInitialTextBox;
        private System.Windows.Forms.DataGridView relativesDataView;
        private System.Windows.Forms.Button addRowButton;
        private System.Windows.Forms.Label relationsLabel;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.RichTextBox commentsRichTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label genderLabel;
        private Common.SafeTextBox phoneNumberTextBox;
        private System.Windows.Forms.Label phoneNumberLabel;
        private System.Windows.Forms.Label addressLabel;
        private Common.SafeTextBox addressTextBox1;
        private Common.SafeTextBox addressTextBox2;
        private System.Windows.Forms.ComboBox genderComboBox;
        private System.Windows.Forms.CheckBox everyWeekCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn patronFamilyName;
        private System.Windows.Forms.DataGridViewComboBoxColumn patronFamilyGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn patronFamilyMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn patronFamilyDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn patronFamilyYear;
        private System.Windows.Forms.CheckBox printVisitCheckBox;
        private System.Windows.Forms.CheckBox veteranCheckBox;
        private System.Windows.Forms.CheckBox seniorCheckBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown zipCodeUpDown;
    }
}