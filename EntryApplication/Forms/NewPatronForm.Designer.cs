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
            this.monthTextBox = new Common.NumericTextBox();
            this.dayTextBox = new Common.NumericTextBox();
            this.yearTextBox = new Common.NumericTextBox();
            this.firstNameTextBox = new Common.LatinTextBox();
            this.lastNameTextBox = new Common.LatinTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.middleInitialTextBox = new Common.LatinTextBox();
            this.relativesDataView = new System.Windows.Forms.DataGridView();
            this.addRowButton = new System.Windows.Forms.Button();
            this.relationsLabel = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.commentsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.genderLabel = new System.Windows.Forms.Label();
            this.genderTextBox = new Common.LatinTextBox();
            this.phoneNumberTextBox = new Common.NumericTextBox();
            this.phoneNumberLabel = new System.Windows.Forms.Label();
            this.addressLabel = new System.Windows.Forms.Label();
            this.addressTextBox1 = new Common.LatinTextBox();
            this.addressTextBox2 = new Common.LatinTextBox();
            this.personName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patronGender = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.patronMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patronDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patronYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.relativesDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(357, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add a Patron";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(111, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Date of Birth";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "YYYY";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(166, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "DD";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(114, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "MM";
            // 
            // monthTextBox
            // 
            this.monthTextBox.Location = new System.Drawing.Point(117, 188);
            this.monthTextBox.Name = "monthTextBox";
            this.monthTextBox.Size = new System.Drawing.Size(27, 22);
            this.monthTextBox.TabIndex = 7;
            // 
            // dayTextBox
            // 
            this.dayTextBox.Location = new System.Drawing.Point(169, 187);
            this.dayTextBox.Name = "dayTextBox";
            this.dayTextBox.Size = new System.Drawing.Size(25, 22);
            this.dayTextBox.TabIndex = 8;
            // 
            // yearTextBox
            // 
            this.yearTextBox.Location = new System.Drawing.Point(221, 187);
            this.yearTextBox.Name = "yearTextBox";
            this.yearTextBox.Size = new System.Drawing.Size(41, 22);
            this.yearTextBox.TabIndex = 9;
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(137, 90);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(146, 22);
            this.firstNameTextBox.TabIndex = 0;
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(573, 90);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(145, 22);
            this.lastNameTextBox.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(131, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 32);
            this.label6.TabIndex = 10;
            this.label6.Text = "First Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(567, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 32);
            this.label7.TabIndex = 11;
            this.label7.Text = "Last Name";
            // 
            // middleInitialTextBox
            // 
            this.middleInitialTextBox.Location = new System.Drawing.Point(425, 90);
            this.middleInitialTextBox.Name = "middleInitialTextBox";
            this.middleInitialTextBox.Size = new System.Drawing.Size(24, 22);
            this.middleInitialTextBox.TabIndex = 1;
            // 
            // relativesDataView
            // 
            this.relativesDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.relativesDataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.personName,
            this.patronGender,
            this.patronMonth,
            this.patronDay,
            this.patronYear});
            this.relativesDataView.Location = new System.Drawing.Point(493, 206);
            this.relativesDataView.Name = "relativesDataView";
            this.relativesDataView.RowTemplate.Height = 24;
            this.relativesDataView.Size = new System.Drawing.Size(538, 295);
            this.relativesDataView.TabIndex = 14;
            this.relativesDataView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.relativesDataViewEditing);
            this.relativesDataView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.familyTextBoxKeyDown);
            // 
            // addRowButton
            // 
            this.addRowButton.Location = new System.Drawing.Point(459, 469);
            this.addRowButton.Name = "addRowButton";
            this.addRowButton.Size = new System.Drawing.Size(28, 32);
            this.addRowButton.TabIndex = 15;
            this.addRowButton.Text = "+";
            this.addRowButton.UseVisualStyleBackColor = true;
            this.addRowButton.Click += new System.EventHandler(this.addRowButtonClick);
            // 
            // relationsLabel
            // 
            this.relationsLabel.AutoSize = true;
            this.relationsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.relationsLabel.Location = new System.Drawing.Point(539, 171);
            this.relationsLabel.Name = "relationsLabel";
            this.relationsLabel.Size = new System.Drawing.Size(135, 32);
            this.relationsLabel.TabIndex = 16;
            this.relationsLabel.Text = "Relations";
            // 
            // submitButton
            // 
            this.submitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitButton.Location = new System.Drawing.Point(13, 508);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(181, 41);
            this.submitButton.TabIndex = 17;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButtonClick);
            // 
            // commentsRichTextBox
            // 
            this.commentsRichTextBox.Location = new System.Drawing.Point(48, 313);
            this.commentsRichTextBox.Name = "commentsRichTextBox";
            this.commentsRichTextBox.Size = new System.Drawing.Size(266, 138);
            this.commentsRichTextBox.TabIndex = 10;
            this.commentsRichTextBox.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F);
            this.label8.Location = new System.Drawing.Point(358, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(175, 32);
            this.label8.TabIndex = 13;
            this.label8.Text = "Middle Initial";
            // 
            // genderLabel
            // 
            this.genderLabel.AutoSize = true;
            this.genderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F);
            this.genderLabel.Location = new System.Drawing.Point(772, 55);
            this.genderLabel.Name = "genderLabel";
            this.genderLabel.Size = new System.Drawing.Size(110, 32);
            this.genderLabel.TabIndex = 20;
            this.genderLabel.Text = "Gender";
            // 
            // genderTextBox
            // 
            this.genderTextBox.Location = new System.Drawing.Point(778, 90);
            this.genderTextBox.Name = "genderTextBox";
            this.genderTextBox.Size = new System.Drawing.Size(98, 22);
            this.genderTextBox.TabIndex = 3;
            // 
            // phoneNumberTextBox
            // 
            this.phoneNumberTextBox.Location = new System.Drawing.Point(1058, 114);
            this.phoneNumberTextBox.Name = "phoneNumberTextBox";
            this.phoneNumberTextBox.Size = new System.Drawing.Size(268, 22);
            this.phoneNumberTextBox.TabIndex = 4;
            // 
            // phoneNumberLabel
            // 
            this.phoneNumberLabel.AutoSize = true;
            this.phoneNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F);
            this.phoneNumberLabel.Location = new System.Drawing.Point(1092, 55);
            this.phoneNumberLabel.Name = "phoneNumberLabel";
            this.phoneNumberLabel.Size = new System.Drawing.Size(205, 32);
            this.phoneNumberLabel.TabIndex = 22;
            this.phoneNumberLabel.Text = "Phone Number";
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F);
            this.addressLabel.Location = new System.Drawing.Point(1130, 206);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(119, 32);
            this.addressLabel.TabIndex = 23;
            this.addressLabel.Text = "Address";
            // 
            // addressTextBox1
            // 
            this.addressTextBox1.Location = new System.Drawing.Point(1058, 262);
            this.addressTextBox1.Name = "addressTextBox1";
            this.addressTextBox1.Size = new System.Drawing.Size(268, 22);
            this.addressTextBox1.TabIndex = 5;
            // 
            // addressTextBox2
            // 
            this.addressTextBox2.Location = new System.Drawing.Point(1058, 302);
            this.addressTextBox2.Name = "addressTextBox2";
            this.addressTextBox2.Size = new System.Drawing.Size(268, 22);
            this.addressTextBox2.TabIndex = 6;
            // 
            // personName
            // 
            this.personName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.personName.HeaderText = "Name";
            this.personName.MinimumWidth = 95;
            this.personName.Name = "personName";
            // 
            // patronGender
            // 
            this.patronGender.HeaderText = "Gender";
            this.patronGender.Name = "patronGender";
            // 
            // patronMonth
            // 
            this.patronMonth.HeaderText = "MM";
            this.patronMonth.MinimumWidth = 30;
            this.patronMonth.Name = "patronMonth";
            this.patronMonth.Width = 30;
            // 
            // patronDay
            // 
            this.patronDay.HeaderText = "DD";
            this.patronDay.MinimumWidth = 30;
            this.patronDay.Name = "patronDay";
            this.patronDay.Width = 30;
            // 
            // patronYear
            // 
            this.patronYear.HeaderText = "YY";
            this.patronYear.MinimumWidth = 60;
            this.patronYear.Name = "patronYear";
            this.patronYear.Width = 60;
            // 
            // NewPatronForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1338, 593);
            this.Controls.Add(this.addressTextBox2);
            this.Controls.Add(this.addressTextBox1);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.phoneNumberLabel);
            this.Controls.Add(this.phoneNumberTextBox);
            this.Controls.Add(this.genderTextBox);
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
            this.Name = "NewPatronForm";
            this.Text = "Add a Patron";
            ((System.ComponentModel.ISupportInitialize)(this.relativesDataView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Common.NumericTextBox monthTextBox;
        private Common.NumericTextBox dayTextBox;
        private Common.NumericTextBox yearTextBox;
        private Common.LatinTextBox firstNameTextBox;
        private Common.LatinTextBox lastNameTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private Common.LatinTextBox middleInitialTextBox;
        private System.Windows.Forms.DataGridView relativesDataView;
        private System.Windows.Forms.Button addRowButton;
        private System.Windows.Forms.Label relationsLabel;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.RichTextBox commentsRichTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label genderLabel;
        private Common.LatinTextBox genderTextBox;
        private Common.NumericTextBox phoneNumberTextBox;
        private System.Windows.Forms.Label phoneNumberLabel;
        private System.Windows.Forms.Label addressLabel;
        private Common.LatinTextBox addressTextBox1;
        private Common.LatinTextBox addressTextBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn personName;
        private System.Windows.Forms.DataGridViewComboBoxColumn patronGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn patronMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn patronDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn patronYear;
    }
}