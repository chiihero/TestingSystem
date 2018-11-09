
using Homework6.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data;


namespace Homework6.Service
{
    public class TestpaperitemRepository
    {
        CommandType cmdType = CommandType.Text;

        public TestpaperitemRepository()
        {
        }
        public DataSet SelectAll()
        {
            string cmdText = "select * from testpaperitem";
            return MysqlHelper.GetDataSet(cmdType, cmdText, null);
        }

        public DataSet SelectByPaperid(int paperid)
        {
            string cmdText = "select * from testpaperitem where paperid = ?paperid";
            MySqlParameter param = new MySqlParameter("?paperid", MySqlDbType.Int32);
            param.Value = paperid;
            return MysqlHelper.GetDataSet(cmdType, cmdText, param);
        }

        public int Insert(TestpaperitemModel item)
        {
            string cmdText = "INSERT INTO testpaperitem (`question`, `paperid`) VALUES (?question, ?paperid);";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?question", MySqlDbType.String),
                new MySqlParameter("?paperid", MySqlDbType.Int32),
            };
            param[0].Value = item.question;
            param[1].Value = item.paperid;
            return MysqlHelper.ExecuteNonQuery(cmdType, cmdText, param);
        }
        public int Delete(int paperid)
        {
            string cmdText = "Delete FROM testpaperitem WHERE `paperid`= ?paperid";
            MySqlParameter param = new MySqlParameter("?paperid", MySqlDbType.Int32);
            param.Value = paperid;
            return MysqlHelper.ExecuteNonQuery(cmdType, cmdText, param);
        }
        public int Update(TestpaperitemModel item)
        {
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