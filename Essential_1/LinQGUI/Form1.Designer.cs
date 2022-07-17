namespace LinQGUI
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.cbData = new System.Windows.Forms.ComboBox();
            this.txbKey = new System.Windows.Forms.TextBox();
            this.cbResult = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(262, 42);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 29);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Filter";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbData
            // 
            this.cbData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cbData.FormattingEnabled = true;
            this.cbData.Location = new System.Drawing.Point(57, 104);
            this.cbData.Name = "cbData";
            this.cbData.Size = new System.Drawing.Size(299, 315);
            this.cbData.TabIndex = 1;
            // 
            // txbKey
            // 
            this.txbKey.Location = new System.Drawing.Point(59, 43);
            this.txbKey.Name = "txbKey";
            this.txbKey.Size = new System.Drawing.Size(144, 27);
            this.txbKey.TabIndex = 2;
            // 
            // cbResult
            // 
            this.cbResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cbResult.FormattingEnabled = true;
            this.cbResult.Location = new System.Drawing.Point(405, 104);
            this.cbResult.Name = "cbResult";
            this.cbResult.Size = new System.Drawing.Size(326, 315);
            this.cbResult.TabIndex = 3;
            this.cbResult.SelectedIndexChanged += new System.EventHandler(this.cbResult_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbResult);
            this.Controls.Add(this.txbKey);
            this.Controls.Add(this.cbData);
            this.Controls.Add(this.btnSearch);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cbData;
        private System.Windows.Forms.TextBox txbKey;
        private System.Windows.Forms.ComboBox cbResult;
    }
}
