using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Homework6.Models;
using MySql.Data.MySqlClient;

namespace Homework6.Service
{

    public class TestpapersRepository
    {
        CommandType cmdType = CommandType.Text;
        public TestpapersRepository()
        {
        }
        public DataSet SelectAll()
        {
            string cmdText = "select * from testpapers";
            return MysqlHelper.GetDataSet(cmdType, cmdText, null);
        }

        public DataSet SelectByid(int pid)
        {
            string cmdText = "select * from testpapers where pid = ?pid";
            MySqlParameter param = new MySqlParameter("?pid", MySqlDbType.Int32);
            param.Value = pid;
            return MysqlHelper.GetDataSet(cmdType, cmdText, param);
        }

        public int Insert(TestpapersModel item)
        {
            string cmdText = "INSERT INTO testpapers (`papername`, `introduce`, `gradeproduct`, `select1_name`, `select2_name`, `select3_name`, `select4_name`) VALUES (?papername, ?introduce, ?gradeproduct, ?select1_name,?select2_name,?select3_name,?select4_name);";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?papername", MySqlDbType.String),
                new MySqlParameter("?introduce", MySqlDbType.String),
                new MySqlParameter("?gradeproduct", MySqlDbType.Float),
                new MySqlParameter("?select1_name", MySqlDbType.String),
                new MySqlParameter("?select2_name", MySqlDbType.String),
                new MySqlParameter("?select3_name", MySqlDbType.String),
                new MySqlParameter("?select4_name", MySqlDbType.String),
            };
            param[0].Value = item.papername;
            param[1].Value = item.introduce;
            param[2].Value = item.gradeproduct;
            param[3].Value = item.select1_name;
            param[4].Value = item.select2_name;
            param[5].Value = item.select3_name;
            param[6].Value = item.select4_name;
            return MysqlHelper.ExecuteNonQuery(cmdType, cmdText, param);
        }
        public int Delete(int pid)
        {
            string cmdText = "Delete FROM testpapers WHERE `pid`= ?pid";
            MySqlParameter param = new MySqlParameter("?pid", MySqlDbType.Int32);
            param.Value = pid;
            return MysqlHelper.ExecuteNonQuery(cmdType, cmdText, param);
        }
     
    }
}
