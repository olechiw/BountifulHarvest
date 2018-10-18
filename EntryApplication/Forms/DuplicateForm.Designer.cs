namespace EntryApplication.Forms
{
    partial class DuplicateForm
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
            this.duplicatesDataGridView = new System.Windows.Forms.DataGridView();
            this.columnDuplicateFamilyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDuplicatePatronFamily = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allowButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.duplicatesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // duplicatesDataGridView
            // 
            this.duplicatesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.duplicatesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnDuplicateFamilyName,
            this.columnDuplicatePatronFamily});
            this.duplicatesDataGridView.Location = new System.Drawing.Point(12, 62);
            this.duplicatesDataGridView.Name = "duplicatesDataGridView";
            this.duplicatesDataGridView.Size = new System.Drawing.Size(739, 175);
            this.duplicatesDataGridView.TabIndex = 0;
            // 
            // columnDuplicateFamilyName
            // 
            this.columnDuplicateFamilyName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnDuplicateFamilyName.HeaderText = "Patron Name";
            this.columnDuplicateFamilyName.Name = "columnDuplicateFamilyName";
            this.columnDuplicateFamilyName.ReadOnly = true;
            this.columnDuplicateFamilyName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnDuplicateFamilyName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // columnDuplicatePatronFamily
            // 
            this.columnDuplicatePatronFamily.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnDuplicatePatronFamily.HeaderText = "Patron Family";
            this.columnDuplicatePatronFamily.Name = "columnDuplicatePatronFamily";
            this.columnDuplicatePatronFamily.ReadOnly = true;
            this.columnDuplicatePatronFamily.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnDuplicatePatronFamily.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // allowButton
            // 
            this.allowButton.Location = new System.Drawing.Point(12, 252);
            this.allowButton.Name = "allowButton";
            this.allowButton.Size = new System.Drawing.Size(96, 41);
            this.allowButton.TabIndex = 1;
            this.allowButton.Text = "Allow";
            this.allowButton.UseVisualStyleBackColor = true;
            this.allowButton.Click += new System.EventHandler(this.allowButtonClick);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(655, 252);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(96, 41);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(114, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(495, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "The Following Duplicate Patrons Were Found!";
            // 
            // DuplicateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(763, 305);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.allowButton);
            this.Controls.Add(this.duplicatesDataGridView);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(779, 344);
            this.MinimizeBox = false;
            this.Name = "DuplicateForm";
            this.Text = "Duplicate Patron Warning";
            ((System.ComponentModel.ISupportInitialize)(this.duplicatesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView duplicatesDataGridView;
        private System.Windows.Forms.Button allowButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDuplicateFamilyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDuplicatePatronFamily;
    }
}