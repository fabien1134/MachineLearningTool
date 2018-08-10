namespace MachineLearningTool
{
    partial class frmMachineLearningTool
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
            this.btnStreamTweets = new System.Windows.Forms.Button();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.ssStatusSection = new System.Windows.Forms.StatusStrip();
            this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvTweetDownloads = new System.Windows.Forms.DataGridView();
            this.colProfilepic = new System.Windows.Forms.DataGridViewImageColumn();
            this.colTweet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFooter.SuspendLayout();
            this.ssStatusSection.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTweetDownloads)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStreamTweets
            // 
            this.btnStreamTweets.Location = new System.Drawing.Point(331, 6);
            this.btnStreamTweets.Name = "btnStreamTweets";
            this.btnStreamTweets.Size = new System.Drawing.Size(141, 42);
            this.btnStreamTweets.TabIndex = 0;
            this.btnStreamTweets.Text = "Stream Tweets";
            this.btnStreamTweets.UseVisualStyleBackColor = true;
            this.btnStreamTweets.Click += new System.EventHandler(this.btnStreamTweets_Click);
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.ssStatusSection);
            this.pnlFooter.Controls.Add(this.btnStreamTweets);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 662);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(946, 77);
            this.pnlFooter.TabIndex = 6;
            // 
            // ssStatusSection
            // 
            this.ssStatusSection.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatus});
            this.ssStatusSection.Location = new System.Drawing.Point(0, 55);
            this.ssStatusSection.Name = "ssStatusSection";
            this.ssStatusSection.Size = new System.Drawing.Size(946, 22);
            this.ssStatusSection.TabIndex = 0;
            // 
            // tsslStatus
            // 
            this.tsslStatus.Name = "tsslStatus";
            this.tsslStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(946, 10);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvTweetDownloads);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(946, 652);
            this.panel2.TabIndex = 8;
            // 
            // dgvTweetDownloads
            // 
            this.dgvTweetDownloads.AllowUserToAddRows = false;
            this.dgvTweetDownloads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTweetDownloads.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProfilepic,
            this.colTweet});
            this.dgvTweetDownloads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTweetDownloads.Location = new System.Drawing.Point(0, 0);
            this.dgvTweetDownloads.Name = "dgvTweetDownloads";
            this.dgvTweetDownloads.Size = new System.Drawing.Size(946, 652);
            this.dgvTweetDownloads.TabIndex = 5;
            // 
            // colProfilepic
            // 
            this.colProfilepic.HeaderText = "Profilepic";
            this.colProfilepic.Name = "colProfilepic";
            this.colProfilepic.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colProfilepic.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colTweet
            // 
            this.colTweet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTweet.HeaderText = "Tweet";
            this.colTweet.Name = "colTweet";
            this.colTweet.ReadOnly = true;
            this.colTweet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // frmMachineLearningTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 739);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlFooter);
            this.Name = "frmMachineLearningTool";
            this.Text = "Machine Learning Tool";
            this.Load += new System.EventHandler(this.frmMachineLearningTool_Load);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ssStatusSection.ResumeLayout(false);
            this.ssStatusSection.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTweetDownloads)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStreamTweets;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.StatusStrip ssStatusSection;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatus;
        private System.Windows.Forms.DataGridView dgvTweetDownloads;
        private System.Windows.Forms.DataGridViewImageColumn colProfilepic;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTweet;
    }
}

