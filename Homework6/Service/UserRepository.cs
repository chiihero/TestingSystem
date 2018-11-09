
using Homework6.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data;


namespace Homework6.Service
{
    public class UserRepository
    {
        CommandType cmdType = CommandType.Text;
        public UserRepository()
        {
        }
        public DataSet SelectAll()
        {
            string cmdText = "select * from user";
            return MysqlHelper.GetDataSet(cmdType, cmdText, null);
        }

        public DataSet SelectByUserno(String userno)
        {
            string cmdText = "select * from user where userno = ?userno";
            MySqlParameter param = new MySqlParameter("?userno", MySqlDbType.String);
            param.Value = userno;
            return MysqlHelper.GetDataSet(cmdType, cmdText, param);
        }

        public int Insert(UserModel item)
        {
            string cmdText = "INSERT INTO `user` (`userno`, `password`, `papers`, `grade`) VALUES (?userno, ?password,?papers,?grade);";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?userno", MySqlDbType.String),
                new MySqlParameter("?password", MySqlDbType.String),
                new MySqlParameter("?papers", MySqlDbType.String),
                new MySqlParameter("?grade", MySqlDbType.Int32),
            };
            param[0].Value = item.userno;
            param[1].Value = item.password;
            param[2].Value = item.papers;
            param[3].Value = item.grade;
            return MysqlHelper.ExecuteNonQuery(cmdType, cmdText, param);
        }
        //public int Remove(int id)
        //{
        //    CommandType cmdType = CommandType.Text;
        //    string cmdText = "Delete FROM `custom` WHERE `id`= ?id";
        //    MySqlParameter param = new MySqlParameter("?id", MySqlDbType.Int32);
        //    param.Value = id;
        //    return MysqlHelper.ExecuteNonQuery(cmdType, cmdText, param);
        //}
        //public int Update(UserModel item)
        //{
        //    CommandType cmdType = CommandType.Text;
        //    string cmdText = "UPDATE `custom` SET `cname`=?cname, `departID`=?departID, `age`=?age, `ename`=?ename, `password`=?password WHERE (`id`=?id);";
        //    MySqlParameter[] param = new MySqlParameter[]{
        //        new MySqlParameter("?id", MySqlDbType.Int32),
        //        new MySqlParameter("?cname", MySqlDbType.String),
        //        new MySqlParameter("?departID", MySqlDbType.Int32),
        //        new MySqlParameter("?age", MySqlDbType.Int32),
        //        new MySqlParameter("?ename", MySqlDbType.String),
        //        new MySqlParameter("?password", MySqlDbType.String)
        //    };
        //    param[0].Value = item.id;
        //    param[1].Value = item.cname;
        //    param[2].Value = item.departID;
        //    param[3].Value = item.age;
        //    param[4].Value = item.ename;
        //    param[5].Value = item.password;

        //    return MysqlHelper.ExecuteNonQuery(cmdType, cmdText, param);
        //}
    }
  
}