using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VolunteerMap1
{
    public partial class Form_Log : Form
    {
        public int flag = 0;

        public Form_Log()
        {
            InitializeComponent();

            // 初始化界面
            pictureBox_Back.SendToBack();
            pictureBox_Back.Size = new Size(400, 300);
            pictureBox_Back.Location = new Point(ClientSize.Width / 3, ClientSize.Height / 3);
            pictureBox_Back.BackColor = Color.FromArgb(30, Color.White);

            label_User.Parent = pictureBox_Back;
            label_User.BackColor = Color.Transparent;
            label_User.Location = new Point(70, 120);

            label_Password.Parent = pictureBox_Back;
            label_Password.BackColor = Color.Transparent;
            label_Password.Location = new Point(70, 150);

            textBox_User.Parent = pictureBox_Back;
            textBox_User.Location = new Point(180, 120);

            textBox_Password.Parent = pictureBox_Back;
            textBox_Password.Location = new Point(180, 150);

            label_UserType.Parent = pictureBox_Back;
            label_UserType.Location = new Point(70, 180);

            comboBox_UserType.Parent = pictureBox_Back;
            comboBox_UserType.Location = new Point(180, 180);
            comboBox_UserType.DropDownStyle = ComboBoxStyle.DropDownList;

            button_Log.Parent = pictureBox_Back;
            button_Log.Location = new Point(150, 240);
            button_Log.Size = new Size(80, 30);
            button_Log.BackColor = Color.FromArgb(0, Color.WhiteSmoke);

            button_Visitor.Parent = pictureBox_Back;
            button_Visitor.Location = new Point(280, 245);
            button_Visitor.Size = new Size(100, 25);

            label_LogTitle.Parent = pictureBox_Back;
            label_LogTitle.Location = new Point(140, 30);

            label_Title.Location = new Point(ClientSize.Width / 3, ClientSize.Height / 6);
        }

        public void button_Log_Click(object sender, EventArgs e)
        {
            if (textBox_User.Text == "" || textBox_Password.Text == "") // 用户名和密码是否填写
            {
                MessageBox.Show("请填写用户名或密码！");
            }
            else // 填写后，判断用户类型，以及用户名、密码是否和数据库中的相匹配（匹配还没写）
            {
                if (comboBox_UserType.Text == "报名者")
                {
                     flag = 2;
                 }
                if (comboBox_UserType.Text == "组织者")
                {
                    flag = 3;
                }
                if (comboBox_UserType.Text == "管理员")
                {
                    flag = 4;
                }
                UserLog User = new UserLog(textBox_User.Text, textBox_Password.Text, flag);
                if (!UserJudge(User))
                {
                    MessageBox.Show("用户名或密码不匹配！");
                    return;
                }

                Program.form = Program.mainForm;
                Hide();
            }
        }
             
        public void button_Visitor_Click(object sender, EventArgs e) // 进入游客模式
        {
            Hide();
            Program.form = Program.mainForm;
            flag = 1;
        }

        private void Form_Log_Load(object sender, EventArgs e)
        {

        }

        private bool UserJudge(UserLog User)
        {
            Searcher ER = new Searcher();
            switch (flag)
            {
                case 2:
                    ER.TableName = "participant";
                    ER.idField.Add("PID");
                    break;
                case 3:
                    ER.TableName = "organizer";
                    ER.idField.Add("OID");
                    break;
                default:
                    ER.TableName = "Admin";
                    ER.idField.Add("AID");
                    break;                
            }
            ER.idField.Add("PassWord");
            ER.idData.Add(User.name);
            ER.idData.Add(User.password);
            ER.Fields.Add("PassWord");
            
            Program.gdbDrive.Query(ref ER);
            if (ER.array.Count > 0)
                return true;
            else
                return false;
        }
    }
}