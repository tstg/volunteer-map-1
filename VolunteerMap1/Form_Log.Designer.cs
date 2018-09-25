namespace VolunteerMap1
{
    partial class Form_Log
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Log));
            this.pictureBox_Back = new System.Windows.Forms.PictureBox();
            this.label_User = new System.Windows.Forms.Label();
            this.label_Password = new System.Windows.Forms.Label();
            this.textBox_User = new System.Windows.Forms.TextBox();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.label_LogTitle = new System.Windows.Forms.Label();
            this.label_UserType = new System.Windows.Forms.Label();
            this.comboBox_UserType = new System.Windows.Forms.ComboBox();
            this.button_Log = new System.Windows.Forms.Button();
            this.label_Title = new System.Windows.Forms.Label();
            this.button_Visitor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Back)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Back
            // 
            this.pictureBox_Back.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox_Back.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Back.Location = new System.Drawing.Point(295, 226);
            this.pictureBox_Back.Name = "pictureBox_Back";
            this.pictureBox_Back.Size = new System.Drawing.Size(400, 300);
            this.pictureBox_Back.TabIndex = 0;
            this.pictureBox_Back.TabStop = false;
            // 
            // label_User
            // 
            this.label_User.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_User.AutoSize = true;
            this.label_User.BackColor = System.Drawing.Color.Transparent;
            this.label_User.Font = new System.Drawing.Font("方正姚体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_User.Location = new System.Drawing.Point(338, 353);
            this.label_User.Name = "label_User";
            this.label_User.Size = new System.Drawing.Size(114, 27);
            this.label_User.TabIndex = 1;
            this.label_User.Text = "用户名 ：";
            // 
            // label_Password
            // 
            this.label_Password.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_Password.AutoSize = true;
            this.label_Password.BackColor = System.Drawing.Color.Transparent;
            this.label_Password.Font = new System.Drawing.Font("方正姚体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Password.Location = new System.Drawing.Point(338, 398);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(114, 27);
            this.label_Password.TabIndex = 2;
            this.label_Password.Text = "密    码 ：";
            // 
            // textBox_User
            // 
            this.textBox_User.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_User.Location = new System.Drawing.Point(467, 344);
            this.textBox_User.Name = "textBox_User";
            this.textBox_User.Size = new System.Drawing.Size(152, 25);
            this.textBox_User.TabIndex = 3;
            // 
            // textBox_Password
            // 
            this.textBox_Password.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_Password.Location = new System.Drawing.Point(467, 398);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.Size = new System.Drawing.Size(152, 25);
            this.textBox_Password.TabIndex = 4;
            // 
            // label_LogTitle
            // 
            this.label_LogTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_LogTitle.AutoSize = true;
            this.label_LogTitle.BackColor = System.Drawing.Color.Transparent;
            this.label_LogTitle.Font = new System.Drawing.Font("华文仿宋", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_LogTitle.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label_LogTitle.Location = new System.Drawing.Point(421, 226);
            this.label_LogTitle.Name = "label_LogTitle";
            this.label_LogTitle.Size = new System.Drawing.Size(166, 42);
            this.label_LogTitle.TabIndex = 5;
            this.label_LogTitle.Text = "用户登录";
            // 
            // label_UserType
            // 
            this.label_UserType.AutoSize = true;
            this.label_UserType.BackColor = System.Drawing.Color.Transparent;
            this.label_UserType.Font = new System.Drawing.Font("方正姚体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_UserType.Location = new System.Drawing.Point(338, 451);
            this.label_UserType.Name = "label_UserType";
            this.label_UserType.Size = new System.Drawing.Size(132, 27);
            this.label_UserType.TabIndex = 6;
            this.label_UserType.Text = "用户类型：";
            // 
            // comboBox_UserType
            // 
            this.comboBox_UserType.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_UserType.FormattingEnabled = true;
            this.comboBox_UserType.Items.AddRange(new object[] {
            "报名者",
            "组织者",
            "管理员"});
            this.comboBox_UserType.Location = new System.Drawing.Point(467, 451);
            this.comboBox_UserType.Name = "comboBox_UserType";
            this.comboBox_UserType.Size = new System.Drawing.Size(121, 23);
            this.comboBox_UserType.TabIndex = 7;
            this.comboBox_UserType.Text = "报名者";
            // 
            // button_Log
            // 
            this.button_Log.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Log.BackColor = System.Drawing.Color.Transparent;
            this.button_Log.FlatAppearance.BorderSize = 0;
            this.button_Log.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button_Log.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Log.Font = new System.Drawing.Font("方正姚体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Log.Location = new System.Drawing.Point(452, 479);
            this.button_Log.Name = "button_Log";
            this.button_Log.Size = new System.Drawing.Size(79, 47);
            this.button_Log.TabIndex = 8;
            this.button_Log.Text = "登录";
            this.button_Log.UseVisualStyleBackColor = false;
            this.button_Log.Click += new System.EventHandler(this.button_Log_Click);
            // 
            // label_Title
            // 
            this.label_Title.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_Title.AutoSize = true;
            this.label_Title.BackColor = System.Drawing.Color.Transparent;
            this.label_Title.Font = new System.Drawing.Font("微软雅黑", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Title.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label_Title.Location = new System.Drawing.Point(191, 99);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(509, 57);
            this.label_Title.TabIndex = 9;
            this.label_Title.Text = "北师大支教活动管理系统";
            // 
            // button_Visitor
            // 
            this.button_Visitor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Visitor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button_Visitor.FlatAppearance.BorderSize = 0;
            this.button_Visitor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Visitor.Font = new System.Drawing.Font("仿宋", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Visitor.Location = new System.Drawing.Point(629, 492);
            this.button_Visitor.Name = "button_Visitor";
            this.button_Visitor.Size = new System.Drawing.Size(95, 34);
            this.button_Visitor.TabIndex = 10;
            this.button_Visitor.Text = "游客访问";
            this.button_Visitor.UseVisualStyleBackColor = true;
            this.button_Visitor.Click += new System.EventHandler(this.button_Visitor_Click);
            // 
            // Form_Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            //this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(981, 777);
            this.Controls.Add(this.button_Visitor);
            this.Controls.Add(this.label_Title);
            this.Controls.Add(this.button_Log);
            this.Controls.Add(this.comboBox_UserType);
            this.Controls.Add(this.label_UserType);
            this.Controls.Add(this.label_LogTitle);
            this.Controls.Add(this.textBox_Password);
            this.Controls.Add(this.textBox_User);
            this.Controls.Add(this.label_Password);
            this.Controls.Add(this.label_User);
            this.Controls.Add(this.pictureBox_Back);
            this.Font = new System.Drawing.Font("方正姚体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "Form_Log";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Back)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Back;
        private System.Windows.Forms.Label label_User;
        private System.Windows.Forms.Label label_Password;
        public System.Windows.Forms.TextBox textBox_User;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.Label label_LogTitle;
        private System.Windows.Forms.Label label_UserType;
        private System.Windows.Forms.ComboBox comboBox_UserType;
        private System.Windows.Forms.Button button_Log;
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.Button button_Visitor;
    }
}

