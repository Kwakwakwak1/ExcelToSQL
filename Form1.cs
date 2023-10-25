using OfficeOpenXml;
using System.Linq;
using System;
using System.IO;
using System.Windows.Forms;

namespace ExcelTestSheetToSQLInserts
{

    public partial class Form1 : Form
    {
        private string outputPath;
        FileInfo existingFile;
        string[] allSqlStatements;
        string sqlStatements;
        public Form1()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            InitializeComponent();
            this.Text = "Excel TestSheet To SQL Insert App";
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xls;*.xlsx;*.xlsm",
                Title = "Select an Excel File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                GenerateSqlFromFile(openFileDialog.FileName);
                MessageBox.Show("SQL statements generated successfully!");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Files|*.txt",
                Title = "Save SQL Statements"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, rtbSqlOutput.Text);
                outputPath = saveFileDialog.FileName;
                MessageBox.Show("File saved successfully!");
            }
        }

        private void GenerateSqlFromFile(string excelPath)
        {
            existingFile = new FileInfo(excelPath);
            sqlStatements = "";

            using (var package = new ExcelPackage(existingFile))
            {
                // List of sheets you want to convert to SQL. Leave it empty to convert all sheets.
                string[] sheetsToConvert = package.Workbook.Worksheets.Select(ws => ws.Name).ToArray();//{ };  // Adjust accordingly

                // If sheetsToConvert is empty, set it to all sheet names in the workbook.
                if (sheetsToConvert.Length == 0)
                {
                    sheetsToConvert = package.Workbook.Worksheets.Select(ws => ws.Name).ToArray();
                }

                cmbPageNames.Items.Clear();
                cmbPageNames.Items.Add("All Pages");
                cmbPageNames.Items.AddRange(sheetsToConvert);
                cmbPageNames.SelectedIndex = 0;


                foreach (var sheetName in sheetsToConvert)
                {
                    var worksheet = package.Workbook.Worksheets[sheetName];
                    int totalRows = worksheet.Dimension.End.Row;

                    for (int i = 2; i <= totalRows; i++)
                    {
                        var orderSequence = worksheet.Cells[i, 1].Text;
                        var functionName = worksheet.Cells[i, 2].Text.Replace("'", "''");
                        var executionSteps = worksheet.Cells[i, 3].Text.Replace("'", "''");

                        if (!string.IsNullOrEmpty(orderSequence)
                            && !string.IsNullOrEmpty(functionName)
                            && !string.IsNullOrEmpty(executionSteps)
                            && !(orderSequence == "#"
                                && functionName == "Function"
                                && executionSteps == "How To Execute"))
                        {
                            string sql = $@"USE [ADIS_GREEN_WEB]
GO

INSERT INTO [dbo].[WebsiteCapabilities]
           ([OrderSequence]
           ,[FunctionName]
           ,[PageName]
           ,[ExecutionSteps]
           ,[WorkingStatus])
     VALUES
           ('{orderSequence}'
           ,'{functionName}'
           ,'{sheetName}'
           ,'{executionSteps}'
           ,'')
GO
";
                            sqlStatements += sql;
                        }
                    }
                }
            }
            rtbSqlOutput.Text = sqlStatements;
        }
        private void cmbPageNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterSqlOutputByPageName(cmbPageNames.SelectedItem.ToString());
        }

        private void FilterSqlOutputByPageName(string pageName)
        {


            var allStatements = sqlStatements.Split(new[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);
            if (pageName == "All Pages")
            {
                rtbSqlOutput.Text = string.Join("GO\n\n", allStatements);
                lblCount.Text = allStatements.Length.ToString();
                //lblCount.Text = ((allStatements.Length - 2) / 2).ToString();

            }
            else
            {
                var filteredStatements = allStatements.Where(stmt => stmt.Contains($"'{pageName}'")).ToList();
                rtbSqlOutput.Text = string.Join("GO\n\n", filteredStatements);
                lblCount.Text = filteredStatements.Count.ToString();
            }
        }
        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(rtbSqlOutput.Text);
            MessageBox.Show("Text copied to clipboard successfully!");
        }

        private string ExtractPageNameFromSql(string sqlStatement)
        {
            var match = System.Text.RegularExpressions.Regex.Match(sqlStatement, @"VALUES\s*\('.*?','.*?',\s*'(?<PageName>.*?)',");
            return match.Groups["PageName"].Value;
        }
    }
}
