﻿namespace ExitApplication
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
            this.patronFirstNameTextBox = new StringTextBox();
            this.patronNameLabel = new System.Windows.Forms.Label();
            this.visitDateLabel = new System.Windows.Forms.Label();
            this.visitDateTextBox = new StringTextBox();
            this.patronVisitLabel = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.firstnameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.middleInitialColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPoundsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patronMiddleInitialTextBox = new StringTextBox();
            this.lastNameTextBox = new StringTextBox();
            this.totalPoundsTextBox = new StringTextBox();
            this.poundsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            this.visitDateTextBox.Size = new System.Drawing.Size(307, 38);
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
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.firstnameColumn,
            this.middleInitialColumn,
            this.lastNameColumn,
            this.totalPoundsColumn});
            this.dataGridView1.Location = new System.Drawing.Point(55, 452);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(733, 264);
            this.dataGridView1.TabIndex = 6;
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
            // patronMiddleInitialTextBox
            // 
            this.patronMiddleInitialTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patronMiddleInitialTextBox.Location = new System.Drawing.Point(191, 178);
            this.patronMiddleInitialTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.patronMiddleInitialTextBox.Name = "patronMiddleInitialTextBox";
            this.patronMiddleInitialTextBox.Size = new System.Drawing.Size(35, 38);
            this.patronMiddleInitialTextBox.TabIndex = 7;
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameTextBox.Location = new System.Drawing.Point(234, 178);
            this.lastNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(128, 38);
            this.lastNameTextBox.TabIndex = 8;
            // 
            // totalPoundsTextBox
            // 
            this.totalPoundsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPoundsTextBox.Location = new System.Drawing.Point(624, 318);
            this.totalPoundsTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.totalPoundsTextBox.Name = "totalPoundsTextBox";
            this.totalPoundsTextBox.Size = new System.Drawing.Size(307, 38);
            this.totalPoundsTextBox.TabIndex = 9;
            // 
            // poundsLabel
            // 
            this.poundsLabel.AutoSize = true;
            this.poundsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.poundsLabel.Location = new System.Drawing.Point(713, 282);
            this.poundsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.poundsLabel.Name = "poundsLabel";
            this.poundsLabel.Size = new System.Drawing.Size(119, 32);
            this.poundsLabel.TabIndex = 10;
            this.poundsLabel.Text = "Pounds ";
            // 
            // BeginInterfaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1442, 851);
            this.Controls.Add(this.poundsLabel);
            this.Controls.Add(this.totalPoundsTextBox);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.patronMiddleInitialTextBox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.patronVisitLabel);
            this.Controls.Add(this.visitDateTextBox);
            this.Controls.Add(this.visitDateLabel);
            this.Controls.Add(this.patronNameLabel);
            this.Controls.Add(this.patronFirstNameTextBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1918, 898);
            this.Name = "BeginInterfaceForm";
            this.Text = "Bountiful Harvest Patron Database";
            this.Load += new System.EventHandler(this.BeginInterface_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private StringTextBox patronFirstNameTextBox;
        private System.Windows.Forms.Label patronNameLabel;
        private System.Windows.Forms.Label visitDateLabel;
        private StringTextBox visitDateTextBox;
        private System.Windows.Forms.Label patronVisitLabel;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private StringTextBox patronMiddleInitialTextBox;
        private StringTextBox lastNameTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstnameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn middleInitialColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPoundsColumn;
        private StringTextBox totalPoundsTextBox;
        private System.Windows.Forms.Label poundsLabel;
    }
}

