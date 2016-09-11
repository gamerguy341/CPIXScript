namespace WindowsFormsApplication1
{
    partial class FixVuln
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Telnet / FTP");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Service packs");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Automatic updates");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Firewall");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Default accounts");
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.cancelButton = new System.Windows.Forms.Button();
            this.installButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            treeNode1.Checked = true;
            treeNode1.Name = "TlFTP";
            treeNode1.Text = "Telnet / FTP";
            treeNode1.ToolTipText = "Disables Telnet and FTP services";
            treeNode2.Checked = true;
            treeNode2.Name = "Serv";
            treeNode2.Text = "Service packs";
            treeNode2.ToolTipText = "Downloads service packs";
            treeNode3.Checked = true;
            treeNode3.Name = "AutoUp";
            treeNode3.Text = "Automatic updates";
            treeNode3.ToolTipText = "Enables automatic updates";
            treeNode4.Checked = true;
            treeNode4.Name = "Firew";
            treeNode4.Text = "Firewall";
            treeNode4.ToolTipText = "Enables Bult-in Windows Firewall";
            treeNode5.Checked = true;
            treeNode5.Name = "GuestAcc";
            treeNode5.Text = "Default accounts";
            treeNode5.ToolTipText = "Disables built-in guest and Admin accounts";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            this.treeView1.Size = new System.Drawing.Size(260, 215);
            this.treeView1.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(197, 233);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // installButton
            // 
            this.installButton.Location = new System.Drawing.Point(116, 233);
            this.installButton.Name = "installButton";
            this.installButton.Size = new System.Drawing.Size(75, 23);
            this.installButton.TabIndex = 2;
            this.installButton.Text = "Install";
            this.installButton.UseVisualStyleBackColor = true;
            this.installButton.Click += new System.EventHandler(this.installButton_Click);
            // 
            // FixVuln
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.installButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.treeView1);
            this.Name = "FixVuln";
            this.Text = "FixVuln";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button installButton;
    }
}