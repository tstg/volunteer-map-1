namespace VolunteerMap1
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_LogOut = new System.Windows.Forms.Button();
            this.menuStrip_Func = new System.Windows.Forms.MenuStrip();
            this.查找ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.热点分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.报名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.组织者ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.学生ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.支教活动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地理位置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.组织者ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.支教活动ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_Result = new System.Windows.Forms.Panel();
            this.textBox_Rewrite = new System.Windows.Forms.TextBox();
            this.comboBox_List = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.axMapControl_Main = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.panel1.SuspendLayout();
            this.menuStrip_Func.SuspendLayout();
            this.panel_Result.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl_Main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.button_LogOut);
            this.panel1.Controls.Add(this.menuStrip_Func);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1068, 46);
            this.panel1.TabIndex = 0;
            // 
            // button_LogOut
            // 
            this.button_LogOut.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_LogOut.Location = new System.Drawing.Point(963, 0);
            this.button_LogOut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_LogOut.Name = "button_LogOut";
            this.button_LogOut.Size = new System.Drawing.Size(105, 46);
            this.button_LogOut.TabIndex = 0;
            this.button_LogOut.Text = "退出";
            this.button_LogOut.UseVisualStyleBackColor = true;
            this.button_LogOut.Click += new System.EventHandler(this.button_LogOut_Click);
            // 
            // menuStrip_Func
            // 
            this.menuStrip_Func.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip_Func.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip_Func.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查找ToolStripMenuItem,
            this.分析ToolStripMenuItem,
            this.报名ToolStripMenuItem,
            this.添加ToolStripMenuItem,
            this.修改ToolStripMenuItem});
            this.menuStrip_Func.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_Func.Name = "menuStrip_Func";
            this.menuStrip_Func.Size = new System.Drawing.Size(1068, 46);
            this.menuStrip_Func.TabIndex = 2;
            this.menuStrip_Func.Text = "menuStrip1";
            // 
            // 查找ToolStripMenuItem
            // 
            this.查找ToolStripMenuItem.Name = "查找ToolStripMenuItem";
            this.查找ToolStripMenuItem.Size = new System.Drawing.Size(58, 42);
            this.查找ToolStripMenuItem.Text = "查找";
            this.查找ToolStripMenuItem.Click += new System.EventHandler(this.查找ToolStripMenuItem_Click);
            // 
            // 分析ToolStripMenuItem
            // 
            this.分析ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.热点分析ToolStripMenuItem});
            this.分析ToolStripMenuItem.Name = "分析ToolStripMenuItem";
            this.分析ToolStripMenuItem.Size = new System.Drawing.Size(58, 42);
            this.分析ToolStripMenuItem.Text = "分析";
            // 
            // 热点分析ToolStripMenuItem
            // 
            this.热点分析ToolStripMenuItem.Name = "热点分析ToolStripMenuItem";
            this.热点分析ToolStripMenuItem.Size = new System.Drawing.Size(146, 30);
            this.热点分析ToolStripMenuItem.Text = "热力图";
            this.热点分析ToolStripMenuItem.Click += new System.EventHandler(this.热力图ToolStripMenuItem_Click);
            // 
            // 报名ToolStripMenuItem
            // 
            this.报名ToolStripMenuItem.Name = "报名ToolStripMenuItem";
            this.报名ToolStripMenuItem.Size = new System.Drawing.Size(58, 42);
            this.报名ToolStripMenuItem.Text = "报名";
            this.报名ToolStripMenuItem.Click += new System.EventHandler(this.报名ToolStripMenuItem_Click);
            // 
            // 添加ToolStripMenuItem
            // 
            this.添加ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.组织者ToolStripMenuItem,
            this.学生ToolStripMenuItem,
            this.支教活动ToolStripMenuItem,
            this.地理位置ToolStripMenuItem});
            this.添加ToolStripMenuItem.Name = "添加ToolStripMenuItem";
            this.添加ToolStripMenuItem.Size = new System.Drawing.Size(58, 42);
            this.添加ToolStripMenuItem.Text = "添加";
            // 
            // 组织者ToolStripMenuItem
            // 
            this.组织者ToolStripMenuItem.Name = "组织者ToolStripMenuItem";
            this.组织者ToolStripMenuItem.Size = new System.Drawing.Size(164, 30);
            this.组织者ToolStripMenuItem.Text = "组织者";
            this.组织者ToolStripMenuItem.Click += new System.EventHandler(this.组织者ToolStripMenuItem_Click);
            // 
            // 学生ToolStripMenuItem
            // 
            this.学生ToolStripMenuItem.Name = "学生ToolStripMenuItem";
            this.学生ToolStripMenuItem.Size = new System.Drawing.Size(164, 30);
            this.学生ToolStripMenuItem.Text = "学生";
            this.学生ToolStripMenuItem.Click += new System.EventHandler(this.学生ToolStripMenuItem_Click);
            // 
            // 支教活动ToolStripMenuItem
            // 
            this.支教活动ToolStripMenuItem.Name = "支教活动ToolStripMenuItem";
            this.支教活动ToolStripMenuItem.Size = new System.Drawing.Size(164, 30);
            this.支教活动ToolStripMenuItem.Text = "支教活动";
            this.支教活动ToolStripMenuItem.Click += new System.EventHandler(this.支教活动ToolStripMenuItem_Click);
            // 
            // 地理位置ToolStripMenuItem
            // 
            this.地理位置ToolStripMenuItem.Name = "地理位置ToolStripMenuItem";
            this.地理位置ToolStripMenuItem.Size = new System.Drawing.Size(164, 30);
            this.地理位置ToolStripMenuItem.Text = "地理位置";
            this.地理位置ToolStripMenuItem.Click += new System.EventHandler(this.地理位置ToolStripMenuItem_Click);
            // 
            // 修改ToolStripMenuItem
            // 
            this.修改ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.组织者ToolStripMenuItem1,
            this.支教活动ToolStripMenuItem1});
            this.修改ToolStripMenuItem.Name = "修改ToolStripMenuItem";
            this.修改ToolStripMenuItem.Size = new System.Drawing.Size(58, 42);
            this.修改ToolStripMenuItem.Text = "修改";
            // 
            // 组织者ToolStripMenuItem1
            // 
            this.组织者ToolStripMenuItem1.Name = "组织者ToolStripMenuItem1";
            this.组织者ToolStripMenuItem1.Size = new System.Drawing.Size(164, 30);
            this.组织者ToolStripMenuItem1.Text = "组织者";
            this.组织者ToolStripMenuItem1.Click += new System.EventHandler(this.组织者ToolStripMenuItem1_Click);
            // 
            // 支教活动ToolStripMenuItem1
            // 
            this.支教活动ToolStripMenuItem1.Name = "支教活动ToolStripMenuItem1";
            this.支教活动ToolStripMenuItem1.Size = new System.Drawing.Size(164, 30);
            this.支教活动ToolStripMenuItem1.Text = "支教活动";
            this.支教活动ToolStripMenuItem1.Click += new System.EventHandler(this.支教活动ToolStripMenuItem1_Click);
            // 
            // panel_Result
            // 
            this.panel_Result.BackColor = System.Drawing.SystemColors.Window;
            this.panel_Result.Controls.Add(this.textBox_Rewrite);
            this.panel_Result.Controls.Add(this.comboBox_List);
            this.panel_Result.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_Result.Location = new System.Drawing.Point(596, 46);
            this.panel_Result.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_Result.Name = "panel_Result";
            this.panel_Result.Size = new System.Drawing.Size(472, 615);
            this.panel_Result.TabIndex = 1;
            // 
            // textBox_Rewrite
            // 
            this.textBox_Rewrite.Location = new System.Drawing.Point(128, 152);
            this.textBox_Rewrite.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_Rewrite.Name = "textBox_Rewrite";
            this.textBox_Rewrite.Size = new System.Drawing.Size(342, 28);
            this.textBox_Rewrite.TabIndex = 1;
            this.textBox_Rewrite.Visible = false;
            // 
            // comboBox_List
            // 
            this.comboBox_List.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_List.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_List.FormattingEnabled = true;
            this.comboBox_List.Items.AddRange(new object[] {
            "活动名称",
            "活动开始时间",
            "活动结束时间",
            "描述"});
            this.comboBox_List.Location = new System.Drawing.Point(0, 155);
            this.comboBox_List.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_List.Name = "comboBox_List";
            this.comboBox_List.Size = new System.Drawing.Size(121, 26);
            this.comboBox_List.TabIndex = 0;
            this.comboBox_List.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.axMapControl_Main);
            this.panel3.Controls.Add(this.axLicenseControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 46);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(596, 615);
            this.panel3.TabIndex = 2;
            // 
            // axMapControl_Main
            // 
            this.axMapControl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl_Main.Location = new System.Drawing.Point(0, 0);
            this.axMapControl_Main.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.axMapControl_Main.Name = "axMapControl_Main";
            this.axMapControl_Main.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl_Main.OcxState")));
            this.axMapControl_Main.Size = new System.Drawing.Size(596, 615);
            this.axMapControl_Main.TabIndex = 1;
            this.axMapControl_Main.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl_Main_OnMouseDown);
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(259, 408);
            this.axLicenseControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1068, 661);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel_Result);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip_Func;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip_Func.ResumeLayout(false);
            this.menuStrip_Func.PerformLayout();
            this.panel_Result.ResumeLayout(false);
            this.panel_Result.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl_Main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel_Result;
        private System.Windows.Forms.Panel panel3;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl_Main;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.Button button_LogOut;
        private System.Windows.Forms.MenuStrip menuStrip_Func;
        private System.Windows.Forms.ToolStripMenuItem 查找ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 报名ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 组织者ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 支教活动ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 学生ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 组织者ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 支教活动ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 热点分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 地理位置ToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox_Rewrite;
        private System.Windows.Forms.ComboBox comboBox_List;
    }
}