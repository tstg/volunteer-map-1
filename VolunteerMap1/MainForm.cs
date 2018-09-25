using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VolunteerMap1
{
    public partial class MainForm : Form
    {
        Button button;
        Form_Log logForm;
        DataGridView signUpGrid; // 报名表
        DataGridView lookupGrid; // 查找表
        DataGridView resultGrid; // 结果表
        DataGridView orgInfoGrid;   // 组织者信息表
        DataGridView studentInfoGrid;   // 学生信息表
        DataGridView proInfoGrid;   // 支教活动信息表
        DataGridView locationGrid;  // 地理位置信息表

        TextBox orgPreName;  // 组织者原来的名称
        TextBox orgNowName;  // 组织者现在的名称
        TextBox proID;       // 支教活动ID

        IFeature pfeature;
        GdbDrive gdb;
        IFeatureClass pFeatureClass;
        long SiteID = -1;

        public MainForm(Form_Log logForm)
        {
            gdb = Program.gdbDrive;
            this.logForm = logForm;

            InitializeComponent();
            VisualToView("china", axMapControl_Main.Map,false);
            VisualToView("site", axMapControl_Main.Map,true);

            if (logForm.flag == 1) // 游客模式，只能查找和查看热力图
            {
                报名ToolStripMenuItem.Visible = false;
                添加ToolStripMenuItem.Visible = false;
                修改ToolStripMenuItem.Visible = false;
            }

            if (logForm.flag == 2) // 报名者模式，只能查找、查看热力图和报名
            {
                添加ToolStripMenuItem.Visible = false;
                修改ToolStripMenuItem.Visible = false;
            }

            if(logForm.flag == 3) // 组织者模式，不能报名
            {
                报名ToolStripMenuItem.Visible = false;
                组织者ToolStripMenuItem.Visible = false;
                学生ToolStripMenuItem.Visible = false;
                组织者ToolStripMenuItem1.Visible = false;
                地理位置ToolStripMenuItem.Visible = false;
            }

            if(logForm.flag == 4) // 管理员模式，不能报名
            {
                报名ToolStripMenuItem.Visible = false;
                支教活动ToolStripMenuItem.Visible = false;
                支教活动ToolStripMenuItem1.Visible = false;
            }
        }

        private void VisualToView(string DatasetName, IMap axpMap,bool Selectable)
        {
            //将地理数据集转化为地理要素
            if (gdb.GetDataset(DatasetName) is IFeatureClass)
                pFeatureClass = (IFeatureClass)gdb.GetDataset(DatasetName);
            ////新建工作空间
            //IFeatureWorkspace pFeatWorkspace;
            //pFeatWorkspace = pWorkspaceFactory.Open(pPropertyset, 0) as IFeatureWorkspace;
            //IFeatureClass pFeatClass;
            //pFeatClass = pFeatWorkspace.OpenFeatureClass(DatasetName);
            //将地理要素放在工作空间的图层上
            IFeatureLayer pFeatureLayer;
            pFeatureLayer = new FeatureLayerClass();
            pFeatureLayer.FeatureClass = pFeatureClass;
            pFeatureLayer.Selectable = Selectable;
            IMap pMap;
            pMap = axpMap;
            pMap.AddLayer(pFeatureLayer);

        }

        //**************************  游客模式（基础功能）
        private void 查找ToolStripMenuItem_Click(object sender, EventArgs e) // 查找功能
        {
            panel_Result.Controls.Clear();

            // 实例化结果表格
            resultGrid = new DataGridView();
            resultGrid.Parent = panel_Result;
            resultGrid.Dock = DockStyle.Fill;
            resultGrid.BackgroundColor = Color.White;
            resultGrid.ColumnCount = 7;
            resultGrid.ReadOnly = true;
            resultGrid.Columns[0].HeaderText = "活动ID";
            resultGrid.Columns[1].HeaderText = "活动名称";
            resultGrid.Columns[2].HeaderText = "组织名称";
            resultGrid.Columns[3].HeaderText = "地点";
            resultGrid.Columns[4].HeaderText = "开始时间";
            resultGrid.Columns[5].HeaderText = "结束时间";
            resultGrid.Columns[6].HeaderText = "描述";

            Label resultLabel = new Label();
            resultLabel.Parent = panel_Result;
            resultLabel.Text = "结果显示";
            resultLabel.TextAlign = ContentAlignment.MiddleCenter;
            resultLabel.Dock = DockStyle.Top;

            // 实例化查找表格
            lookupGrid = new DataGridView();
            lookupGrid.Parent = panel_Result;
            lookupGrid.Dock = DockStyle.Top;
            lookupGrid.BackgroundColor = Color.White;
            lookupGrid.ColumnCount = 1;
            lookupGrid.RowCount = 2;
            lookupGrid.AllowUserToAddRows = false;
            lookupGrid.Columns[0].HeaderText = "活动ID";

            Label queryLabel = new Label();
            queryLabel.Parent = panel_Result;
            queryLabel.Text = "查找";
            queryLabel.TextAlign = ContentAlignment.MiddleCenter;
            queryLabel.Dock = DockStyle.Top;

            // 实例化查找按钮
            button = new Button();
            button.Parent = panel_Result;
            button.Dock = DockStyle.Bottom;
            button.Text = "查找";
            button.Click += new EventHandler(lookupButt_Click);

            LookUp(null);
        }

        private void lookupButt_Click(object sender, EventArgs e)
        {
            string queryID;
            if (lookupGrid.Rows[0].Cells[0].Value != null)
                queryID = lookupGrid.Rows[0].Cells[0].Value.ToString();
            else
                queryID = null;

            LookUp(queryID);
        }

        private void LookUp(string TID)
        {
            List<List<dynamic>> AR = ActivityQuery(TID);
            if (AR == null)
            {
                MessageBox.Show("查询无结果");
                return;
            }

            if(resultGrid != null)
            {
                resultGrid.Rows.Clear();
                //输出查询数据
                for (int i = 0; i < AR.Count; i++)
                {
                    resultGrid.Rows.Add();
                    for (int j = 0; j < 7; j++)
                        resultGrid.Rows[i].Cells[j].Value = AR[i][j];
                }
                resultGrid.AllowUserToAddRows = false;
            }
            if(signUpGrid != null)
            {
                signUpGrid.Rows.Clear();
                //输出查询数据
                for (int i = 0; i < AR.Count; i++)
                {
                    signUpGrid.Rows.Add();
                    for (int j = 0; j < 7; j++)
                        signUpGrid.Rows[i].Cells[j].Value = AR[i][j];
                }
                signUpGrid.AllowUserToAddRows = false;
            }
            
        }

        List<List<dynamic>> ActivityQuery(string TID)
        {
            List<List<dynamic>> AR = new List<List<dynamic>>();

            Searcher ER = new Searcher();
            if(TID != null)
            {
                ER.idField.Add("TID");
                ER.idData.Add(TID);
            }
            ER.TableName = "Activity";
            ER.Fields.Add("ActName");
            ER.Fields.Add("ActStart");
            ER.Fields.Add("ActEnd");
            ER.Fields.Add("Describe");
            ER.Fields.Add("TID");
            gdb.Query(ref ER);
            if (ER.array.Count < 1)
                return null;

            Searcher ERs = new Searcher();
            Searcher ERo = new Searcher();
            Searcher ERg = new Searcher();
            Searcher ERa = new Searcher();

            for (int i = 0;i < ER.array.Count;i++)
            {
                //获取地点编号
                ERa.TableName = "SANexus";
                ERa.idField.Clear();
                ERa.idField.Add("TID");
                ERa.idData.Clear();
                ERa.idData.Add(ER.array[i][4]);
                ERa.Fields.Clear();
                ERa.Fields.Add("SID");
                ERa.array.Clear();
                gdb.Query(ref ERa);

                //获取地点名称
                ERs.TableName = "site";
                ERs.idField.Clear();
                ERs.idField.Add("OBJECTID");
                ERs.idData.Clear();
                ERs.idData.Add(ERa.array[0][0]);
                ERs.Fields.Clear();
                ERs.Fields.Add("Name");
                ERs.array.Clear();
                gdb.Query(ref ERs);

                //根据活动信息中的TID，查询对应的OID;
                ERo.TableName = "OANexus";
                ERo.idField.Clear();
                ERo.idField.Add("TID");
                ERo.idData.Clear();
                ERo.idData.Add(ER.array[i][4]);
                ERo.Fields.Clear();
                ERo.Fields.Add("OID");
                ERo.array.Clear();
                gdb.Query(ref ERo);

                //根据查询到的OID，获取组织名称
                ERg.TableName = "organizer";
                ERg.idField.Clear();
                ERg.idField.Add("OID");
                ERg.idData.Clear();
                ERg.idData.Add(ERo.array[0][0]);
                ERg.Fields.Clear();
                ERg.Fields.Add("FullName");
                ERg.array.Clear();
                gdb.Query(ref ERg);

                List<dynamic> ar = new List<dynamic>();
                ar.Add(ER.array[i][4]);
                ar.Add(ER.array[i][0]);
                ar.Add(ERg.array[0][0]);
                ar.Add(ERs.array[0][0]);
                ar.Add(ER.array[i][2]);
                ar.Add(ER.array[i][3]);
                ar.Add(ER.array[i][4]);
                AR.Add(ar);
            }
            return AR;
        }

        private void 热力图ToolStripMenuItem_Click(object sender, EventArgs e) //查看热力图功能
        {
            
        }

        // 在地图上点击学校，获取支教信息
        private void axMapControl_Main_OnMouseDown(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseDownEvent e)
        {
            // 选择学校
            IMap pMap = axMapControl_Main.Map;
            IEnumLayer pEnumLayer = pMap.get_Layers(null, true);
            pEnumLayer.Reset();
            ILayer pLayer = pEnumLayer.Next();
            IFeatureLayer pFeatureLayer;
            while (pLayer != null)
            {
                if (pLayer.Name == "china")
                {
                    pFeatureLayer = (IFeatureLayer)pLayer;
                    pFeatureLayer.Selectable = false;
                }
                pLayer = pEnumLayer.Next();
            }

            IGeometry selectGeometry = null;
            IEnvelope pEnv;
            IActiveView pActiveView = axMapControl_Main.ActiveView;
            pEnv = axMapControl_Main.TrackRectangle();
            if (pEnv.IsEmpty == true)
            {
                ESRI.ArcGIS.esriSystem.tagRECT r;
                r.bottom = e.y + 5;
                r.top = e.y - 5;
                r.left = e.x - 5;
                r.right = e.x + 5;
                pActiveView.ScreenDisplay.DisplayTransformation.TransformRect(pEnv, ref r, 4);
                pEnv.SpatialReference = pActiveView.FocusMap.SpatialReference;
            }
            selectGeometry = pEnv as IGeometry;
            axMapControl_Main.Map.ClearSelection();
            axMapControl_Main.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            axMapControl_Main.Map.SelectByShape(selectGeometry, null, false);
            axMapControl_Main.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null);

            // 显示信息
            ISelection pselect = pMap.FeatureSelection;

            IEnumFeatureSetup pEnumFeatureSetup = (IEnumFeatureSetup)pselect;
            pEnumFeatureSetup.AllFields = true;  
            IEnumFeature pEnumFeature = (IEnumFeature)pEnumFeatureSetup;
            //pEnumFeature.Reset();
            pfeature = pEnumFeature.Next();            

            if (pfeature == null)
                return;

            SiteID = (dynamic)pfeature.get_Value(0);
            //GdbDrive Gdp = new GdbDrive();
            Searcher GDs = new Searcher();
            GDs.TableName = "SANexus";
            GDs.idField.Add("SID");
            GDs.idData.Add(SiteID);
            GDs.Fields.Add("TID");
            gdb.Query(ref GDs);

            if(GDs.array.Count < 1)
            {
                MessageBox.Show("该地区无支教活动！");
                return;
            }
            LookUp(GDs.array[0][0]);
                

                //resultGrid.Rows[0].Cells[0].Value = name;
                //signUpGrid.Rows[0].Cells[0].Value = pfeature.get_Value(2).ToString();
            
        }
        
        //*************************** 报名者模式（报名功能）
        public void 报名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_Result.Controls.Clear();

            // 实例化，展示选择的点信息
            signUpGrid = new DataGridView();
            signUpGrid.Parent = panel_Result;
            signUpGrid.Dock = DockStyle.Fill;
            signUpGrid.BackgroundColor = Color.White;
            signUpGrid.ColumnCount = 7;
            signUpGrid.RowCount = 2;
            signUpGrid.AllowUserToAddRows = false;
            signUpGrid.ReadOnly = true;

            signUpGrid.Columns[0].HeaderText = "活动ID";
            signUpGrid.Columns[1].HeaderText = "活动名称";
            signUpGrid.Columns[2].HeaderText = "组织名称";
            signUpGrid.Columns[3].HeaderText = "地点";
            signUpGrid.Columns[4].HeaderText = "开始时间";
            signUpGrid.Columns[5].HeaderText = "结束时间";
            signUpGrid.Columns[6].HeaderText = "描述";

            // 实例化按钮
            button = new Button();
            button.Parent = panel_Result;
            button.Dock = DockStyle.Bottom;
            button.Text = "报名";
            button.Click += new EventHandler(signUpButt_Click);
        }

        private void signUpButt_Click(object sender, EventArgs e)
        {
            // 选择地图上的学校，点击报名
            if (signUpGrid.Rows[0].Cells[0].Value == null)
            {
                MessageBox.Show("请选择学校");
            }
            else
            {
                string PTID = logForm.textBox_User.Text;
                string TTID = Convert.ToString(signUpGrid.Rows[0].Cells[0].Value);

                Searcher pJudge = new Searcher();
                pJudge.TableName = "PANexus";
                pJudge.idField.Add("PID");
                pJudge.idData.Add(PTID);
                pJudge.idField.Add("TID");
                pJudge.idData.Add(TTID);
                pJudge.Fields.Add("TID");

                //GdbDrive Gdp = new GdbDrive();
                gdb.Query(ref pJudge);

                if (pJudge.array.Count > 0)
                {
                    MessageBox.Show("请勿重复报名！");
                    return;
                }

                gdb.AddTableRecord("PANexus",pJudge.idData);
                MessageBox.Show("报名成功！");
            }
          
        }
        

        // 退出按键
        private void button_LogOut_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Log out");
            Program.logForm.Show();
            Close();
        }

        //***************************添加***************************//
        // 添加组织者
        private void 组织者ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_Result.Controls.Clear();

            // 实例化添加信息表
            orgInfoGrid = new DataGridView();
            orgInfoGrid.Parent = panel_Result;
            orgInfoGrid.Dock = DockStyle.Fill;
            orgInfoGrid.BackgroundColor = Color.White;
            orgInfoGrid.ColumnCount = 4;
            orgInfoGrid.RowCount = 2;
            orgInfoGrid.AllowUserToAddRows = false;
            orgInfoGrid.Columns[0].HeaderText = "组织ID";
            orgInfoGrid.Columns[1].HeaderText = "登录密码";
            orgInfoGrid.Columns[2].HeaderText = "组织名称";
            orgInfoGrid.Columns[3].HeaderText = "组织电话";

            // 实例化按钮
            button = new Button();
            button.Parent = panel_Result;
            button.Dock = DockStyle.Bottom;
            button.Text = "添加";
            button.Click += new EventHandler(AddOrgButt_Click);
        }

        private void AddOrgButt_Click(object sender, EventArgs e)
        {
            //GdbDrive Gdp = new GdbDrive();
            Searcher SER = new Searcher();

            SER.TableName = "organizer";
            SER.idField.Add("OID");
            SER.idData.Add(orgInfoGrid.Rows[0].Cells[0].Value);
            SER.Fields.Add("OID");
            gdb.Query(ref SER);
            if(SER.array.Count > 0)
            {
                MessageBox.Show("该组织已存在！");
                return;
            }
            
            List<dynamic> values = new List<dynamic>();
            for(int i = 0;i < 4;i++)
            {
                values.Add(orgInfoGrid.Rows[0].Cells[i].Value);
            }
            
            gdb.AddTableRecord("organizer",values);
            MessageBox.Show("添加成功！");
        }

        private void 学生ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_Result.Controls.Clear();

            // 实例化添加信息表
            studentInfoGrid = new DataGridView();
            studentInfoGrid.Parent = panel_Result;
            studentInfoGrid.Dock = DockStyle.Fill;
            studentInfoGrid.BackgroundColor = Color.White;
            studentInfoGrid.ColumnCount = 5;
            studentInfoGrid.RowCount = 2;
            studentInfoGrid.AllowUserToAddRows = false;
            studentInfoGrid.Columns[0].HeaderText = "学号";
            studentInfoGrid.Columns[1].HeaderText = "登录密码";
            studentInfoGrid.Columns[2].HeaderText = "名字";
            studentInfoGrid.Columns[3].HeaderText = "学院";
            studentInfoGrid.Columns[4].HeaderText = "年级";

            // 实例化按钮
            button = new Button();
            button.Parent = panel_Result;
            button.Dock = DockStyle.Bottom;
            button.Text = "添加";
            button.Click += new EventHandler(AddStudentButt_Click);
        }

        private void AddStudentButt_Click(object sender, EventArgs e)
        {
            //GdbDrive gdb = new GdbDrive();
            Searcher SER = new Searcher();

            SER.TableName = "participant";
            SER.idField.Add("PID");
            SER.idData.Add(studentInfoGrid.Rows[0].Cells[0].Value);
            SER.Fields.Add("PID");
            gdb.Query(ref SER);
            if (SER.array.Count > 0)
            {
                MessageBox.Show("该学生已存在！");
                return;
            }

            List<dynamic> values = new List<dynamic>();

            for(int i = 0;i < 5;i++)
            {
                values.Add(studentInfoGrid.Rows[0].Cells[i].Value);
            }

            gdb.AddTableRecord("participant",values);
            MessageBox.Show("添加成功！");
        }

        private void 支教活动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_Result.Controls.Clear();

            // 实例化添加信息表
            proInfoGrid = new DataGridView();
            proInfoGrid.Parent = panel_Result;
            proInfoGrid.Dock = DockStyle.Fill;
            proInfoGrid.BackgroundColor = Color.White;
            proInfoGrid.ColumnCount = 5;
            proInfoGrid.Columns[0].HeaderText = "活动ID";
            proInfoGrid.Columns[1].HeaderText = "活动名称";
            proInfoGrid.Columns[2].HeaderText = "活动开始时间";
            proInfoGrid.Columns[3].HeaderText = "活动结束时间";
            proInfoGrid.Columns[4].HeaderText = "描述";

            // 实例化按钮
            button = new Button();
            button.Parent = panel_Result;
            button.Dock = DockStyle.Bottom;
            button.Text = "添加";
            button.Click += new EventHandler(AddProButt_Click);
        }

        private void AddProButt_Click(object sender, EventArgs e)
        {
            //GdbDrive Gdp = new GdbDrive();
            Searcher SER = new Searcher();
            List<dynamic> values = new List<dynamic>();

            if(SiteID < 0)
            {
                MessageBox.Show("未选中活动点！");
                return;
            }

            SER.TableName = "SANexus";
            SER.idField.Add("SID");
            SER.idData.Add(SiteID);
            SER.Fields.Add("TID");
            gdb.Query(ref SER);
            if(SER.array.Count > 0)
            {
                MessageBox.Show("该地已有活动！");
                return;
            }

            SER.idField[0] = "TID";
            SER.idData[0] = Convert.ToString(proInfoGrid.Rows[0].Cells[0].Value);
            gdb.Query(ref SER);
            if (SER.array.Count > 0)
            {
                MessageBox.Show("该活动ID已存在！");
                return;
            }

            DialogResult dr = MessageBox.Show("请确认日期格式如2008-8-8！","警告", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.Cancel)
                return;

            values.Clear();
            for (int i = 0; i < 5; i++)
                values.Add(proInfoGrid.Rows[0].Cells[i].Value);
            try { gdb.AddTableRecord("Activity", values);}
            catch
            {
                MessageBox.Show("日期格式有误！");
                return;
            }

            values.Clear();
            values.Add(proInfoGrid.Rows[0].Cells[0].Value);
            values.Add(SiteID);
            gdb.AddTableRecord("SANexus",values);

            values.Clear();
            values.Add(logForm.textBox_User.Text);
            values.Add(proInfoGrid.Rows[0].Cells[0].Value);
            gdb.AddTableRecord("OANexus", values);
        }

        private void 地理位置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_Result.Controls.Clear();

            // 实例化添加信息表
            locationGrid = new DataGridView();
            locationGrid.Parent = panel_Result;
            locationGrid.Dock = DockStyle.Fill;
            locationGrid.BackgroundColor = Color.White;
            locationGrid.ColumnCount = 3;
            locationGrid.RowCount = 2;
            locationGrid.AllowUserToAddRows = false;
            locationGrid.Columns[2].HeaderText = "地点名称";
            locationGrid.Columns[0].HeaderText = "经度";
            locationGrid.Columns[1].HeaderText = "纬度";

            // 实例化按钮
            button = new Button();
            button.Parent = panel_Result;
            button.Dock = DockStyle.Bottom;
            button.Text = "添加";
            button.Click += new EventHandler(AddLocationButt_Click);
        }

        private void AddLocationButt_Click(object sender, EventArgs e)
        {
            if(Convert.ToSingle(locationGrid.Rows[0].Cells[0].Value) < 73 ||
                Convert.ToSingle(locationGrid.Rows[0].Cells[0].Value) > 135 ||
                Convert.ToSingle(locationGrid.Rows[0].Cells[1].Value) > 53 ||
                Convert.ToSingle(locationGrid.Rows[0].Cells[1].Value) < 23)
            {
                MessageBox.Show("经纬度输入越界，请重新输入！");
                return;
            }
            
            //GdbDrive Gdp = new GdbDrive();
            gdb.AddPointFeature("site",Convert.ToSingle(locationGrid.Rows[0].Cells[0].Value), Convert.ToSingle(locationGrid.Rows[0].Cells[1].Value));
            List<string> fields = new List<string>();
            fields.Add("Name");
            List<dynamic> datas = new List<dynamic>();
            datas.Add(Convert.ToString(locationGrid.Rows[0].Cells[2].Value)); 
            gdb.ChangeTableRecord("site","Name",null,fields,datas);
            axMapControl_Main.ActiveView.Refresh();
            MessageBox.Show("添加成功");
        }


        //***************************修改***************************//
        // 修改组织者
        private void 组织者ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panel_Result.Controls.Clear();

            button = new Button();
            button.Parent = panel_Result;
            button.Dock = DockStyle.Top;
            button.Text = "修改";
            button.Click += new EventHandler(RewriteOrgButt_Click);

            // 组织者现在的名称
            orgNowName = new TextBox();
            orgNowName.Parent = panel_Result;
            orgNowName.Dock = DockStyle.Top;

            Label resultLabel = new Label();
            resultLabel.Parent = panel_Result;
            resultLabel.Text = "修改为";
            resultLabel.TextAlign = ContentAlignment.MiddleCenter;
            resultLabel.Dock = DockStyle.Top;

            // 组织者以前的名称
            orgPreName = new TextBox();
            orgPreName.Parent = panel_Result;
            orgPreName.Dock = DockStyle.Top;

            Label resultLabel1 = new Label();
            resultLabel1.Parent = panel_Result;
            resultLabel1.Text = "组织者名称";
            resultLabel1.TextAlign = ContentAlignment.MiddleCenter;
            resultLabel1.Dock = DockStyle.Top;
        }

        private void RewriteOrgButt_Click(object sender, EventArgs e)
        {
            //GdbDrive Gdp = new GdbDrive();
            List<string> fields = new List<string>();
            List<dynamic> value = new List<dynamic>();

            value.Add(orgNowName.Text.ToString());
            fields.Add("FullName");

            bool Judge = gdb.ChangeTableRecord("organizer","FullName",orgPreName.Text.ToString(),fields,value);
            if (Judge)
                MessageBox.Show("修改成功！");
            else
                MessageBox.Show("没有该组织！");
        }


        // 修改支教活动
        private void 支教活动ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panel_Result.Controls.Clear();

            comboBox_List.Visible = true;
            textBox_Rewrite.Visible = true;

            button = new Button();
            button.Parent = panel_Result;
            button.Dock = DockStyle.Top;
            button.Text = "修改";
            button.Click += new EventHandler(RewriteProButt_Click);

            textBox_Rewrite.Parent = panel_Result;
            textBox_Rewrite.Dock = DockStyle.Top;

            comboBox_List.Parent = panel_Result;
            comboBox_List.Dock = DockStyle.Top;

            Label resultLabel1 = new Label();
            resultLabel1.Parent = panel_Result;
            resultLabel1.Text = "信息修改为：";
            resultLabel1.TextAlign = ContentAlignment.MiddleCenter;
            resultLabel1.Dock = DockStyle.Top;

            proID = new TextBox();
            proID.Parent = panel_Result;
            proID.Dock = DockStyle.Top;

            Label resultLabel = new Label();
            resultLabel.Parent = panel_Result;
            resultLabel.Text = "将支教活动ID为：";
            resultLabel.TextAlign = ContentAlignment.MiddleCenter;
            resultLabel.Dock = DockStyle.Top;
        }

        private void RewriteProButt_Click(object sender, EventArgs e)
        {
            bool T = false;
            //GdbDrive Gdp = new GdbDrive();

            List<string> idfields = new List<string>();
            List<dynamic> iddata = new List<dynamic>();

            switch(comboBox_List.Text.ToString())
            {
                case "活动名称":
                    idfields.Add("ActName");
                    break;
                case "活动开始时间":
                    idfields.Add("ActStart");
                    T = true;
                    break;
                case "活动结束时间":
                    idfields.Add("ActEnd");
                    T = true;
                    break;
                case "描述":
                    idfields.Add("Describe");
                    break;
            }
            iddata.Add(textBox_Rewrite.Text.ToString());
            if(T)
            {
                DialogResult dr = MessageBox.Show("请确认日期格式如2008-8-8！", "警告", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.Cancel)
                    return;
            }
                        
            try
            {
                bool Judge = gdb.ChangeTableRecord("Activity", "TID", proID.Text.ToString(), idfields, iddata);
                if (Judge)
                    MessageBox.Show("修改成功！");
                else
                    MessageBox.Show("没有该组织！");
            }
            catch
            {
                MessageBox.Show("输入格式有误！");
                return;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
