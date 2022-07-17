
namespace PRN211_M1_ADO.GUI
{
    partial class BidAddGUI
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
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnBid = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.txtSellerID = new System.Windows.Forms.TextBox();
            this.txtCurrentPrice = new System.Windows.Forms.TextBox();
            this.txtEndDateTime = new System.Windows.Forms.TextBox();
            this.txtBidDateTime = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtItemTypeID = new System.Windows.Forms.TextBox();
            this.txtMinimumBidIncrement = new System.Windows.Forms.TextBox();
            this.txtTimeRemaining = new System.Windows.Forms.TextBox();
            this.txtBidPrice = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(460, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Item description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Seller:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(513, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Item type:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Current price:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(399, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(206, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Minimum bid increment:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 280);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = "End date time:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(460, 274);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 25);
            this.label8.TabIndex = 7;
            this.label8.Text = "Time remaining:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 363);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 25);
            this.label9.TabIndex = 8;
            this.label9.Text = "Bid date time:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(506, 357);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 25);
            this.label10.TabIndex = 9;
            this.label10.Text = "Bid price:";
            // 
            // btnBid
            // 
            this.btnBid.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnBid.Location = new System.Drawing.Point(220, 447);
            this.btnBid.Name = "btnBid";
            this.btnBid.Size = new System.Drawing.Size(112, 34);
            this.btnBid.TabIndex = 10;
            this.btnBid.Text = "Bid";
            this.btnBid.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(493, 447);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 34);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(152, 65);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.ReadOnly = true;
            this.txtItemName.Size = new System.Drawing.Size(239, 31);
            this.txtItemName.TabIndex = 12;
            // 
            // txtSellerID
            // 
            this.txtSellerID.Location = new System.Drawing.Point(152, 129);
            this.txtSellerID.Name = "txtSellerID";
            this.txtSellerID.ReadOnly = true;
            this.txtSellerID.Size = new System.Drawing.Size(239, 31);
            this.txtSellerID.TabIndex = 13;
            // 
            // txtCurrentPrice
            // 
            this.txtCurrentPrice.Location = new System.Drawing.Point(152, 199);
            this.txtCurrentPrice.Name = "txtCurrentPrice";
            this.txtCurrentPrice.ReadOnly = true;
            this.txtCurrentPrice.Size = new System.Drawing.Size(239, 31);
            this.txtCurrentPrice.TabIndex = 14;
            // 
            // txtEndDateTime
            // 
            this.txtEndDateTime.Location = new System.Drawing.Point(152, 274);
            this.txtEndDateTime.Name = "txtEndDateTime";
            this.txtEndDateTime.ReadOnly = true;
            this.txtEndDateTime.Size = new System.Drawing.Size(239, 31);
            this.txtEndDateTime.TabIndex = 15;
            // 
            // txtBidDateTime
            // 
            this.txtBidDateTime.Location = new System.Drawing.Point(152, 357);
            this.txtBidDateTime.Name = "txtBidDateTime";
            this.txtBidDateTime.ReadOnly = true;
            this.txtBidDateTime.Size = new System.Drawing.Size(239, 31);
            this.txtBidDateTime.TabIndex = 16;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(614, 65);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(278, 31);
            this.txtDescription.TabIndex = 17;
            // 
            // txtItemTypeID
            // 
            this.txtItemTypeID.Location = new System.Drawing.Point(614, 129);
            this.txtItemTypeID.Name = "txtItemTypeID";
            this.txtItemTypeID.ReadOnly = true;
            this.txtItemTypeID.Size = new System.Drawing.Size(278, 31);
            this.txtItemTypeID.TabIndex = 18;
            // 
            // txtMinimumBidIncrement
            // 
            this.txtMinimumBidIncrement.Location = new System.Drawing.Point(614, 196);
            this.txtMinimumBidIncrement.Name = "txtMinimumBidIncrement";
            this.txtMinimumBidIncrement.ReadOnly = true;
            this.txtMinimumBidIncrement.Size = new System.Drawing.Size(278, 31);
            this.txtMinimumBidIncrement.TabIndex = 19;
            // 
            // txtTimeRemaining
            // 
            this.txtTimeRemaining.Location = new System.Drawing.Point(614, 268);
            this.txtTimeRemaining.Name = "txtTimeRemaining";
            this.txtTimeRemaining.ReadOnly = true;
            this.txtTimeRemaining.Size = new System.Drawing.Size(278, 31);
            this.txtTimeRemaining.TabIndex = 20;
            // 
            // txtBidPrice
            // 
            this.txtBidPrice.Location = new System.Drawing.Point(614, 357);
            this.txtBidPrice.Name = "txtBidPrice";
            this.txtBidPrice.Size = new System.Drawing.Size(278, 31);
            this.txtBidPrice.TabIndex = 21;
            // 
            // BidAddGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 551);
            this.Controls.Add(this.txtBidPrice);
            this.Controls.Add(this.txtTimeRemaining);
            this.Controls.Add(this.txtMinimumBidIncrement);
            this.Controls.Add(this.txtItemTypeID);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtBidDateTime);
            this.Controls.Add(this.txtEndDateTime);
            this.Controls.Add(this.txtCurrentPrice);
            this.Controls.Add(this.txtSellerID);
            this.Controls.Add(this.txtItemName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBid);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "BidAddGUI";
            this.Text = "BidAddGUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnBid;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.TextBox txtSellerID;
        private System.Windows.Forms.TextBox txtCurrentPrice;
        private System.Windows.Forms.TextBox txtEndDateTime;
        private System.Windows.Forms.TextBox txtBidDateTime;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtItemTypeID;
        private System.Windows.Forms.TextBox txtMinimumBidIncrement;
        private System.Windows.Forms.TextBox txtTimeRemaining;
        private System.Windows.Forms.TextBox txtBidPrice;
    }
}