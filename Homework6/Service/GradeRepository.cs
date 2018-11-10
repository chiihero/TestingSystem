
using Homework6.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data;


namespace Homework6.Service
{
    public class GradeRepository
    {
        CommandType cmdType = CommandType.Text;

        public GradeRepository()
        {
        }
        public DataSet SelectAll()
        {
            string cmdText = "select * from grade";
            return MysqlHelper.GetDataSet(cmdType, cmdText, null);
        }

        public DataSet SelectByUserno(int userno)
        {
            string cmdText = "select * from grade where userno = ?userno";
            MySqlParameter param = new MySqlParameter("?userno", MySqlDbType.String);
            param.Value = userno;
            return MysqlHelper.GetDataSet(cmdType, cmdText, param);
        }

        public int Insert(GradeModel item)
        {
            string cmdText = "INSERT INTO grade (`userno`, `paperid`, `grade`) VALUES (?userno, ?paperid,?grade);";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?userno", MySqlDbType.String),
                new MySqlParameter("?paperid", MySqlDbType.Int32),
                new MySqlParameter("?grade", MySqlDbType.Int32),

            };
            param[0].Value = item.userno;
            param[1].Value = item.paperid;
            param[2].Value = item.grade;
            return MysqlHelper.ExecuteNonQuery(cmdType, cmdText, param);
        }
        //public int Delete(int paperid)
        //{
        //    string cmdText = "Delete FROM grade WHERE `paperid`= ?paperid";
        //    MySqlParameter param = new MySqlParameter("?paperid", MySqlDbType.Int32);
        //    param.Value = paperid;
        //    return MysqlHelper.ExecuteNonQuery(cmdType, cmdText, param);
        //}
        //public int Update(GradeModel item)
        //{
        //    string cmdText = "UPDATE `grade` SET `question` = ?question, `paperid`= ?paperid WHERE (`id`=?id);";
        //    MySqlParameter[] param = new MySqlParameter[]{
        //        new MySqlParameter("?id", MySqlDbType.Int32),
        //        new MySqlParameter("?question", MySqlDbType.String),
        //        new MySqlParameter("?paperid", MySqlDbType.Int32),
        //    };
        //    param[0].Value = item.id;
        //    param[1].Value = item.question;
        //    param[2].Value = item.paperid;
        //    return MysqlHelper.ExecuteNonQuery(cmdType, cmdText, param);
        //}
    }
  
}