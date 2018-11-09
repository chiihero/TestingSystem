
using Homework6.Service;
using MySql.Data.MySqlClient;
using System;
using System.Data;


namespace Homework6.Models
{
    public class TestpaperitemRepository
    {
        public TestpaperitemRepository()
        {
        }
        public DataSet GetAll()
        {
            CommandType cmdType = CommandType.Text;
            string cmdText = "select * from testpaperitem";
            DataSet dataSet = MysqlHelper.GetDataSet(cmdType, cmdText, null);
            return dataSet;
        }

        public DataSet GetByPaperid(String paperid)
        {
            CommandType cmdType = CommandType.Text;
            string cmdText = "select * from testpaperitem where paperid = ?paperid";
            MySqlParameter param = new MySqlParameter("?paperid", MySqlDbType.String);
            param.Value = paperid;
            return MysqlHelper.GetDataSet(cmdType, cmdText, param);
        }

        public int Add(TestpaperitemModel item)
        {
            CommandType cmdType = CommandType.Text;
            string cmdText = "INSERT INTO testpaperitem (`question`, `paperid`) VALUES (?question, ?paperid);";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?question", MySqlDbType.String),
                new MySqlParameter("?paperid", MySqlDbType.Int32),
            };
            param[0].Value = item.question;
            param[1].Value = item.paperid;
            return MysqlHelper.ExecuteNonQuery(cmdType, cmdText, param);
        }
        public int Remove(int paperid)
        {
            CommandType cmdType = CommandType.Text;
            string cmdText = "Delete FROM testpaperitem WHERE `paperid`= ?paperid";
            MySqlParameter param = new MySqlParameter("?paperid", MySqlDbType.Int32);
            param.Value = paperid;
            return MysqlHelper.ExecuteNonQuery(cmdType, cmdText, param);
        }
        public int Update(TestpaperitemModel item)
        {
            CommandType cmdType = CommandType.Text;
            string cmdText = "UPDATE `testpaperitem` SET `question` = ?question, `paperid`= ?paperid WHERE (`id`=?id);";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?id", MySqlDbType.Int32),
                new MySqlParameter("?question", MySqlDbType.String),
                new MySqlParameter("?paperid", MySqlDbType.Int32),
            };
            param[0].Value = item.id;
            param[1].Value = item.question;
            param[2].Value = item.paperid;
            return MysqlHelper.ExecuteNonQuery(cmdType, cmdText, param);
        }
    }
  
}