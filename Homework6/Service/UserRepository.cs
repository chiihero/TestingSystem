
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
            string cmdText = "INSERT INTO `user` (`userno`, `password`, `type`) VALUES (?userno, ?password, ?type);";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?userno", MySqlDbType.String),
                new MySqlParameter("?password", MySqlDbType.String),
                new MySqlParameter("?type", MySqlDbType.Int32),
            };
            param[0].Value = item.userno;
            param[1].Value = item.password;
            param[2].Value = item.type;

            return MysqlHelper.ExecuteNonQuery(cmdType, cmdText, param);
        }
    }

}