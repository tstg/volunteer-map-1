using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolunteerMap1
{
    class Searcher
    {
        public string TableName { get; set; }
        public List<string> idField { get; set; }
        public List<dynamic> idData { get; set; }
        public List<string> Fields { get; set; }
        public List<List<dynamic>> array { get; set; }

        public Searcher()
        {
            idField = new List<string>();
            idData = new List<dynamic>();
            Fields = new List<string>();
            array = new List<List<dynamic>>();
        }
    }

    class Activity
    {//与数据库中匹配的Activity类
        public string TID { get; set; }
        public long SiteID { get; set; }
        public string FullName { get; set; }
        public string ActStart { get; set; }
        public string ActEnd { get; set; }
        public string Describe { get; set; }

        public Activity(string TID)
        {
            this.TID = TID;
        }
    }
    
    class Organizer
    {
        public string OID { get; set; }
        public string PassWord { get; set; }
        public string FullName { get; set; }
        public string TEL { get; set; }
        
        public Organizer(string OID,string PassWord)
        {
            this.OID = OID;
            this.PassWord = PassWord;
        }
    }

    class Participant
    {
        public string PID { get; set; }
        public string PassWord { get; set; }
        public string FullName { get; set; }
        public short Gender { get; set; }
        public string Institution { get; set; }
        public int Grade { get; set; }

        public Participant(string PID, string PassWord)
        {
            this.PID = PID;
            this.PassWord = PassWord;
        }
    }

    class OANexus
    {
        public string OID { get; set; }
        public string TID { get; set; }
        public short State { get; set; }

        public OANexus(string OID,string TID)
        {
            this.OID = OID;
            this.TID = TID;
            this.State = 0; 
        }
    }

    class PANexus
    {
        public string PID { get; set; }
        public string TID { get; set; }
        public short State { get; set; }

        public PANexus(string PID, string TID)
        {
            this.PID = PID;
            this.TID = TID;
            this.State = 0;
        }
    }

    class UserLog
    {
        public string name { get; set; }
        public string password { get; set; }
        int flag { get; set; }

        public UserLog(string name,string password,int flag)
        {
            this.name = name;
            this.password = password;
            this.flag = flag;
        }
    }

    class GdbDrive
    {
        static string GdpPath = "../../pro.mdb";//数据库文件路径
        private Dictionary<string, IDataset> dict;//数据库字典集

        /***************************************************************************
         * 函数名：GdbDrive
         * 参  数：无
         * 返回值：无
         * 功  能：根据给定的数据库文件路径，链接地理数据库数据库
        ***************************************************************************/
        public GdbDrive()
        {
            try
            {
                AccessWorkspaceFactory wsf = new AccessWorkspaceFactory();
                IWorkspace ws = wsf.OpenFromFile(GdpPath, 0);
                dict = new Dictionary<string, IDataset>();

                IEnumDataset iterator = ws.get_Datasets(esriDatasetType.esriDTAny);
                IDataset dataset = iterator.Next();
                while (dataset != null)
                {
                    if (dataset.Subsets != null)
                    {
                        Console.WriteLine(" + " + dataset.Name + " (Dataset)");
                        IEnumDataset subIterator = dataset.Subsets;
                        IDataset subDataset = subIterator.Next();
                        while (subDataset != null)
                        {
                            Console.Write(" |- " + subDataset.Name);
                            if (subDataset is IFeatureClass)
                            {
                                Console.Write(" (Feature Class)\n");
                                dict[subDataset.Name] = subDataset;
                            }
                            subDataset = subIterator.Next();
                        }
                    }
                    else if (dataset is ITable)
                    {
                        Console.WriteLine(" * " + dataset.Name + " (Table)");
                        dict[dataset.Name] = dataset;
                    }
                    dataset = iterator.Next();
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Source + ": " + ex.Message);
            }
        }

        /***************************************************************************
         * 函数名：GetWorkspace
         * 参  数：无
         * 返回值：IWorkspace
         * 功  能：获取数据库参数
        ***************************************************************************/
        private IWorkspace GetWorkspace()
        {
            IWorkspace ws = null;
            try
            {
                string extension = System.IO.Path.GetExtension(GdpPath);
                if (extension == ".gdb")
                {
                    FileGDBWorkspaceFactory wsf = new FileGDBWorkspaceFactory();
                    ws = wsf.OpenFromFile(GdpPath, 0);
                }
                else if (extension == ".mdb")
                {
                    AccessWorkspaceFactory wsf = new AccessWorkspaceFactory();
                    ws = wsf.OpenFromFile(GdpPath, 0);
                }
                return ws;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /***************************************************************************
          * 函数名：GetDataset
          * 参  数：string：数据库名称
          * 返回值：IDataset：数据库联系
          * 功  能：根据数据库名称获取数据库信息
         ***************************************************************************/
        public IDataset GetDataset(string Name)
        {
            try
            {
                return dict[Name];
            }
            catch
            {
                return null;
            }
        }

        /***************************************************************************
          * 函数名：AddTableRecord
          * 参  数：string：数据库名称，List<string>:数据名称集，List<dynamic>:数据集
          * 返回值：int：1：添加成功
          * 功  能：向数据库中添加数据记录
         ***************************************************************************/
        public int AddTableRecord(string tableName, List<dynamic> values)
        {
            
            ITable table = dict[tableName] as ITable;           

            ICursor cursor = table.Insert(true);
            IRowBuffer pRowBuffer = table.CreateRowBuffer();
            for(int i = 1;i <= values.Count;i++)
            {
                pRowBuffer.Value[i] = values[i - 1];
            }
            cursor.InsertRow(pRowBuffer);
            cursor.Flush();
            return 1;
           
        }

        /***************************************************************************
          * 函数名：AddPointFeature
          * 参  数：string：数据点名称，float:横坐标，float：纵坐标
          * 返回值：int：1：添加成功
          * 功  能：向地理数据库中添加点数据记录
         *******************************************************va********************/
        public int AddPointFeature(string featureClassName, float x, float y)
        {
            try
            {
                //IFeatureClass featureClass = (GetWorkspace() as IFeatureWorkspace).OpenFeatureClass(featureClassName);
                IFeatureClass featureClass = dict[featureClassName] as IFeatureClass;
                IFeature feature = featureClass.CreateFeature();
                IPoint point = new PointClass();
                point.PutCoords(x, y);
                feature.Shape = point;
                feature.Store();
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /***************************************************************************
          * 函数名：ChangeTableRecord
          * 参  数：string：表名称，string:修改检索项，dynamic：修改检索项数据，
          *         List<string>：修改项名，List<dynamic>：修改项数据
          * 返回值：int：1：修改成功
          * 功  能：在地理数据库中修改数据记录
         ***************************************************************************/
        public bool ChangeTableRecord(string tableName, string idFieldName, dynamic id, List<string> fields, List<dynamic> values)
        {
            //ITable table = (GetWorkspace() as IFeatureWorkspace).OpenFeatureClass(tableName) as ITable;
            ITable table = dict[tableName] as ITable;
            IQueryFilter queryFilter = new QueryFilter();
            if (id is string)
            {
                queryFilter.WhereClause = idFieldName + "='" + id + "'";
            }
            else if(id == null)
            {
                    queryFilter.WhereClause = idFieldName + " is null";
            }
            else
            {
                queryFilter.WhereClause = idFieldName + "=" + Convert.ToString(id);
            }
            ICursor cursor = table.Search(queryFilter, true);
            IRow row = cursor.NextRow();
            if (row == null)
                return false;
            for (int i = 0; i < fields.Count; ++i)
            {
                row.Value[table.FindField(fields[i])] = values[i];
            }
            row.Store();
            return true;
        }

        /***************************************************************************
          * 函数名：ChangePoint
          * 参  数：string：数据点名称，float:横坐标，float：纵坐标
          * 返回值：int：1：修改成功
          * 功  能：在地理数据库中修改点数据记录
         ***************************************************************************/
        public void ChangePoint(string featureClassName, string idFieldName, dynamic id, float x, float y)
        {
            try
            {
                //IFeatureClass featureClass = (GetWorkspace() as IFeatureWorkspace).OpenFeatureClass(featureClassName);
                IFeatureClass featureClass = dict[featureClassName] as IFeatureClass;
                IQueryFilter queryFilter = new QueryFilter();
                if (id is string)
                {
                    queryFilter.WhereClause = idFieldName + "='" + id + "'";
                }
                else
                {
                    queryFilter.WhereClause = idFieldName + "=" + Convert.ToString(id);
                }
                IFeatureCursor featureCursor = featureClass.Search(queryFilter, true);
                IFeature feature = featureCursor.NextFeature();
                IPoint point = new PointClass();
                point.PutCoords(x, y);
                feature.Shape = point;
                feature.Store();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /***************************************************************************
          * 函数名：Query
          * 参  数：Searcher：查询辅助类
          * 返回值：void：空
          * 功  能：在地理数据库中查询信息
         ***************************************************************************/
        public void Query(ref Searcher Node)
        {
            ITable table = dict[Node.TableName] as ITable;
            QueryFilter queryFilter = new QueryFilter();
            string WhereClause = "";
            for(int i = 0;i < Node.idField.Count;i++)
            {
                if(Node.idData[i] is string)
                {
                    WhereClause += Node.idField[i];
                    WhereClause += " = '";
                    WhereClause += Node.idData[i];
                    if (i != Node.idField.Count - 1)
                        WhereClause += "' and ";
                    else
                        WhereClause += "'";
                }
                else
                {
                    WhereClause += Node.idField[i];
                    WhereClause += " = ";
                    WhereClause += Node.idData[i];
                    if (i != Node.idField.Count - 1)
                        WhereClause += " and ";
                    else
                        WhereClause += "";
                }
            }
            queryFilter.WhereClause = WhereClause;
            ICursor cursor = table.Search(queryFilter, true);
            IRow row = cursor.NextRow();
            for(int i = 0; row != null;i++)
            {
                List<dynamic> temp = new List<dynamic>();
                for(int j = 0;j < Node.Fields.Count;j++)
                {
                    temp.Add(row.Value[table.Fields.FindField(Node.Fields[j])]);
                }
                Node.array.Add(temp);
                row = cursor.NextRow();
            }
        }
    }
}

