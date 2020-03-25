using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace FreeGame
{

    public class CsvReadingHelper : SingletonNoMono<CsvReadingHelper>
    {
        public List<Dialogs_CSV> Dialogs_CSV { get; private set; } = new List<Dialogs_CSV>();

        /// <summary>
        /// 读取所有的csv
        /// </summary>
        public override void Init()
        {
            base.Init();
            if (Dialogs_CSV.Count == 0)
            {
                Dialogs_CSV = CsvHelper.Csv2List<Dialogs_CSV>(CsvNames.Dialogs);
            }
        }
    }

    public static class CsvHelper
    {
        /// <summary>
        /// 根据CSV表名，读取数据并返回对应List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="CsvName"></param>
        /// <returns></returns>
        public static List<T> Csv2List<T>(string CsvName)
        {
            string CsvPath = GetCsvPathByName(CsvName);
            return TableToList<T>(GetDataTable(CsvPath));
        }

        private static string GetCsvPathByName(string CsvName)
        {
            string path = "GameData\\";
            DirectoryInfo direction = new DirectoryInfo(path);
            return direction.Parent + Consts.CsvPath + CsvName;
        }

        /// <summary>
        /// 根据csv路径获取datatable
        /// </summary>
        /// <param name="csvPath"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        private static DataTable GetDataTable(string csvPath)
        {
            var result = GetDt(csvPath, true);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            return result;
        }
        private static DataTable GetDt(string csvPath, bool hasTitle = false)
        {
            var dt = new DataTable();
            try
            {
                //将数据读入到DataTable中  
                if (!File.Exists(csvPath))
                {
                    return null;
                }
                using (StreamReader sr = new StreamReader(csvPath))
                {
                    string line = sr.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        var columes = line.Split(',');
                        //生成列头
                        for (var i = 0; i < columes.Length; i++)
                        {
                            var name = "column" + i;
                            if (hasTitle)
                            {
                                var txt = columes[i];
                                if (!string.IsNullOrWhiteSpace(txt))
                                {
                                    name = txt;
                                }
                            }
                            while (dt.Columns.Contains(name)) name = name + "_1"; //重复行名称会报错。
                            dt.Columns.Add(new DataColumn(name, typeof(string)));
                        }

                        if (!hasTitle)
                        {
                            var dr = dt.NewRow();
                            for (var iCol = 0; iCol < columes.Length; iCol++)
                            {
                                var range = columes[iCol];
                                dr[iCol] = range;
                            }
                            dt.Rows.Add(dr);
                        }
                        line = sr.ReadLine();//跳过第二行的字段类型
                        line = sr.ReadLine();
                        //生成行数据
                        while (!string.IsNullOrWhiteSpace(line))
                        {
                            columes = line.Split(',');
                            var dr = dt.NewRow();
                            for (var iCol = 0; iCol < columes.Length; iCol++)
                            {
                                var range = columes[iCol];
                                dr[iCol] = range;
                            }
                            dt.Rows.Add(dr);
                            line = sr.ReadLine();
                        }
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 将dataTable保存到csv文件
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="csvPath"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        private static bool SaveDataTable(DataTable dt, string csvPath, out string errMsg)
        {
            var result = SaveDt(dt, csvPath, out errMsg);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            return result;
        }

        private static bool SaveDt(DataTable dt, string csvPath, out string errMsg)
        {
            try
            {
                //将数据读入到DataTable中
                using (StreamWriter sr = new StreamWriter(csvPath, false, Encoding.Default))
                {
                    var iRowCount = dt.Rows.Count;
                    var iColCount = dt.Columns.Count;
                    //生成列头
                    StringBuilder firstRow = new StringBuilder();
                    for (var i = 0; i < iColCount; i++)
                    {
                        firstRow.Append(dt.Columns[i].ColumnName + ",");
                    }
                    sr.WriteLine(firstRow.ToString().TrimEnd(','));
                    for (var iRow = 0; iRow < iRowCount; iRow++)
                    {
                        StringBuilder otherRow = new StringBuilder();
                        for (var iCol = 0; iCol < iColCount; iCol++)
                        {
                            otherRow.Append(dt.Rows[iRow][iCol] + ",");
                        }
                        sr.WriteLine(otherRow.ToString().TrimEnd(','));
                    }
                    errMsg = "";
                    return true;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// DataTable转化为List集合
        /// </summary>
        /// <typeparam name="T">实体对象</typeparam>
        /// <param name="dt">datatable表</param> 
        /// <returns>返回list集合</returns>
        private static List<T> TableToList<T>(DataTable dt)
        {
            List<T> list = new List<T>();
            Type type = typeof(T);
            foreach (DataRow row in dt.Rows)
            {
                PropertyInfo[] pArray = type.GetProperties(); //集合属性数组
                T entity = Activator.CreateInstance<T>(); //新建对象实例
                foreach (PropertyInfo p in pArray)
                {
                    if (!dt.Columns.Contains(p.Name) || row[p.Name] == null || row[p.Name] == DBNull.Value)
                    {
                        continue;  //DataTable列中不存在集合属性或者字段内容为空则，跳出循环，进行下个循环
                    }
                    try
                    {
                        var obj = Convert.ChangeType(row[p.Name], p.PropertyType);//类型强转，将table字段类型转为集合字段类型
                        p.SetValue(entity, obj, null);
                    }
                    catch (Exception)
                    {

                    }
                }
                list.Add(entity);
            }
            return list;
        }


        /// <summary>
        /// List集合转DataTable
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="list">传入集合</param> 
        /// <returns>返回datatable结果</returns>
        private static DataTable ListToTable<T>(List<T> list)
        {
            Type tp = typeof(T);
            PropertyInfo[] proInfos = tp.GetProperties();
            DataTable dt = new DataTable();
            foreach (var item in proInfos)
            {
                dt.Columns.Add(item.Name, typeof(string)); //添加列明及对应类型
            }
            foreach (var item in list)
            {
                DataRow dr = dt.NewRow();
                foreach (var proInfo in proInfos)
                {
                    object obj = proInfo.GetValue(item, null);
                    if (obj == null)
                    {
                        continue;
                    }
                    if (proInfo.PropertyType == typeof(DateTime) && Convert.ToDateTime(obj) < Convert.ToDateTime("1753-01-01"))
                    {
                        continue;
                    }
                    dr[proInfo.Name] = obj;
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}