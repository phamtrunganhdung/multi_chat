
namespace Server
{
    partial class ServerForm
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
            this.btnSend = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lsvMessage = new System.Windows.Forms.ListView();
            this.sttsStatus = new System.Windows.Forms.StatusStrip();
            this.tsslAllClientTitle = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslAllClient = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslClientOnlineTitle = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslClientOnline = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvClient = new System.Windows.Forms.DataGridView();
            this.cbbClient = new System.Windows.Forms.ComboBox();
            this.btnSendAll = new System.Windows.Forms.Button();
            this.sttsStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClient)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(236, 321);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(99, 34);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "Send Each Client";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(13, 322);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(217, 33);
            this.txtMessage.TabIndex = 4;
            // 
            // lsvMessage
            // 
            this.lsvMessage.HideSelection = false;
            this.lsvMessage.Location = new System.Drawing.Point(13, 65);
            this.lsvMessage.Name = "lsvMessage";
            this.lsvMessage.Size = new System.Drawing.Size(322, 251);
            this.lsvMessage.TabIndex = 3;
            this.lsvMessage.UseCompatibleStateImageBehavior = false;
            this.lsvMessage.View = System.Windows.Forms.View.List;
            // 
            // sttsStatus
            // 
            this.sttsStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslAllClientTitle,
            this.tsslAllClient,
            this.tsslClientOnlineTitle,
            this.tsslClientOnline});
            this.sttsStatus.Location = new System.Drawing.Point(0, 397);
            this.sttsStatus.Name = "sttsStatus";
            this.sttsStatus.Size = new System.Drawing.Size(561, 22);
            this.sttsStatus.TabIndex = 6;
            this.sttsStatus.Text = "statusStrip1";
            // 
            // tsslAllClientTitle
            // 
            this.tsslAllClientTitle.Name = "tsslAllClientTitle";
            this.tsslAllClientTitle.Size = new System.Drawing.Size(61, 17);
            this.tsslAllClientTitle.Text = "All Client: ";
            // 
            // tsslAllClient
            // 
            this.tsslAllClient.Name = "tsslAllClient";
            this.tsslAllClient.Size = new System.Drawing.Size(12, 17);
            this.tsslAllClient.Text = "?";
            // 
            // tsslClientOnlineTitle
            // 
            this.tsslClientOnlineTitle.Name = "tsslClientOnlineTitle";
            this.tsslClientOnlineTitle.Size = new System.Drawing.Size(82, 17);
            this.tsslClientOnlineTitle.Text = "Client Online: ";
            // 
            // tsslClientOnline
            // 
            this.tsslClientOnline.Name = "tsslClientOnline";
            this.tsslClientOnline.Size = new System.Drawing.Size(13, 17);
            this.tsslClientOnline.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(182, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Server Multi Chat";
            // 
            // dgvClient
            // 
            this.dgvClient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClient.Location = new System.Drawing.Point(341, 65);
            this.dgvClient.Name = "dgvClient";
            this.dgvClient.Size = new System.Drawing.Size(211, 251);
            this.dgvClient.TabIndex = 8;
            // 
            // cbbClient
            // 
            this.cbbClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbClient.FormattingEnabled = true;
            this.cbbClient.Location = new System.Drawing.Point(341, 322);
            this.cbbClient.Name = "cbbClient";
            this.cbbClient.Size = new System.Drawing.Size(212, 33);
            this.cbbClient.TabIndex = 9;
            // 
            // btnSendAll
            // 
            this.btnSendAll.Location = new System.Drawing.Point(12, 361);
            this.btnSendAll.Name = "btnSendAll";
            this.btnSendAll.Size = new System.Drawing.Size(99, 31);
            this.btnSendAll.TabIndex = 11;
            this.btnSendAll.Text = "Send All Client";
            this.btnSendAll.UseVisualStyleBackColor = true;
            this.btnSendAll.Click += new System.EventHandler(this.btnSendAll_Click);
            // 
            // ServerForm
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 419);
            this.Controls.Add(this.btnSendAll);
            this.Controls.Add(this.cbbClient);
            this.Controls.Add(this.dgvClient);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sttsStatus);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lsvMessage);
            this.Name = "ServerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ServerForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ServerForm_FormClosed);
            this.Load += new System.EventHandler(this.ServerForm_Load);
            this.sttsStatus.ResumeLayout(false);
            this.sttsStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.ListView lsvMessage;
        private System.Windows.Forms.StatusStrip sttsStatus;
        private System.Windows.Forms.ToolStripStatusLabel tsslAllClientTitle;
        private System.Windows.Forms.ToolStripStatusLabel tsslClientOnlineTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripStatusLabel tsslAllClient;
        private System.Windows.Forms.ToolStripStatusLabel tsslClientOnline;
        private System.Windows.Forms.DataGridView dgvClient;
        private System.Windows.Forms.ComboBox cbbClient;
        private System.Windows.Forms.Button btnSendAll;
    }
}

