using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Homework.Tool
{
    public class DatasetToModel
    {
        public static List<T> PutAllVal<T>(T entity, DataSet ds) where T : new()
        {
            List<T> lists = new List<T>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    lists.Add(PutVal(new T(), row));
                }
            }
            return lists;
        }
        public static T PutVal<T>(T entity, DataRow row) where T : new()
        {
            //初始化 如果为null
            if (entity == null)
            {
                entity = new T();
            }
            //得到类型
            Type type = typeof(T);
            //取得属性集合
            PropertyInfo[] pi = type.GetProperties();
            foreach (PropertyInfo item in pi)
            {
                //给属性赋值
                if (row[item.Name] != null && row[item.Name] != DBNull.Value)
                {
                    if (item.PropertyType == typeof(System.Nullable<System.DateTime>))
                    {
                        item.SetValue(entity, Convert.ToDateTime(row[item.Name].ToString()), null);
                    }
                    else
                    {
                        item.SetValue(entity, Convert.ChangeType(row[item.Name], item.PropertyType), null);
                    }
                }
            }
            return entity;
        }
    }

}
