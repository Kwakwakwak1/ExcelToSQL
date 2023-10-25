namespace ExcelTestSheetToSQLInserts
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnUpload = new Button();
            btnSave = new Button();
            rtbSqlOutput = new RichTextBox();
            btnCopyToClipboard = new Button();
            cmbPageNames = new ComboBox();
            lblCount = new Label();
            SuspendLayout();
            // 
            // btnUpload
            // 
            btnUpload.Location = new Point(12, 12);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(187, 23);
            btnUpload.TabIndex = 0;
            btnUpload.Text = "Upload Excel To Convert";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += btnUpload_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(336, 12);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(146, 23);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save SQL Conversion";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // rtbSqlOutput
            // 
            rtbSqlOutput.Location = new Point(12, 56);
            rtbSqlOutput.Name = "rtbSqlOutput";
            rtbSqlOutput.Size = new Size(776, 382);
            rtbSqlOutput.TabIndex = 3;
            rtbSqlOutput.Text = "";
            // 
            // btnCopyToClipboard
            // 
            btnCopyToClipboard.Location = new Point(205, 12);
            btnCopyToClipboard.Name = "btnCopyToClipboard";
            btnCopyToClipboard.Size = new Size(125, 23);
            btnCopyToClipboard.TabIndex = 4;
            btnCopyToClipboard.Text = "Copy To Clipboard";
            btnCopyToClipboard.UseVisualStyleBackColor = true;
            btnCopyToClipboard.Click += btnCopyToClipboard_Click;
            // 
            // cmbPageNames
            // 
            cmbPageNames.FormattingEnabled = true;
            cmbPageNames.Items.AddRange(new object[] { "All Pages" });
            cmbPageNames.Location = new Point(667, 12);
            cmbPageNames.Name = "cmbPageNames";
            cmbPageNames.Size = new Size(121, 23);
            cmbPageNames.TabIndex = 5;
            cmbPageNames.SelectedIndexChanged += cmbPageNames_SelectedIndexChanged;
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.Location = new Point(773, 38);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(0, 15);
            lblCount.TabIndex = 6;
            lblCount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblCount);
            Controls.Add(cmbPageNames);
            Controls.Add(btnCopyToClipboard);
            Controls.Add(rtbSqlOutput);
            Controls.Add(btnSave);
            Controls.Add(btnUpload);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnUpload;
        private Button btnSave;
        private RichTextBox rtbSqlOutput;
        private Button btnCopyToClipboard;
        private ComboBox cmbPageNames;
        private Label lblCount;
    }
}