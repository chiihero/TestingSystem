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

        public DataSet SelectByid(int id)
        {
            string cmdText = "select * from testpapers where id = ?id";
            MySqlParameter param = new MySqlParameter("?id", MySqlDbType.Int32);
            param.Value = id;
            return MysqlHelper.GetDataSet(cmdType, cmdText, param);
        }

        public int Insert(TestpapersModel item)
        {
            string cmdText = "INSERT INTO testpapers (`papername`, `introduce`, `select1_name`, `select1_score`, `select2_name`, `select2_score`, `select3_name`, `select3_score`, `select4_name`, `select4_score`) VALUES (?papername, ?introduce, ?select1_name,?select1_score,?select2_name,?select2_score,?select3_name,?select3_score,?select4_name,?select4_score);";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?papername", MySqlDbType.String),
                new MySqlParameter("?introduce", MySqlDbType.String),
                new MySqlParameter("?select1_name", MySqlDbType.String),
                new MySqlParameter("?select1_score", MySqlDbType.Float),
                new MySqlParameter("?select2_name", MySqlDbType.String),
                new MySqlParameter("?select2_score", MySqlDbType.Float),
                new MySqlParameter("?select3_name", MySqlDbType.String),
                new MySqlParameter("?select3_score", MySqlDbType.Float),
                new MySqlParameter("?select4_name", MySqlDbType.String),
                new MySqlParameter("?select4_score", MySqlDbType.Float),
            };
            param[0].Value = item.papername;
            param[1].Value = item.introduce;
            param[2].Value = item.select1_name;
            param[3].Value = item.select1_score;
            param[4].Value = item.select2_name;
            param[5].Value = item.select2_score;
            param[6].Value = item.select3_name;
            param[7].Value = item.select3_score;
            param[8].Value = item.select4_name;
            param[9].Value = item.select4_score;
            return MysqlHelper.ExecuteNonQuery(cmdType, cmdText, param);
        }
        public int Delete(int id)
        {
            string cmdText = "Delete FROM testpapers WHERE `id`= ?id";
            MySqlParameter param = new MySqlParameter("?id", MySqlDbType.Int32);
            param.Value = id;
            return MysqlHelper.ExecuteNonQuery(cmdType, cmdText, param);
        }
        public int Update(TestpapersModel item)
        {
            string cmdText = "UPDATE `testpapers` SET `papername` = ?papername, `introduce` = ?introduce, `select1_name` = ?select1_name, `select1_score` = ?select1_score, `select2_name` = ?select2_name, `select2_score` = ?select2_score, `select3_name` = ?select3_name, `select3_score` = ?select3_score, `select4_name` = ?select4_name, `select4_score` = ?select4_score WHERE (`id`=?id);";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?papername", MySqlDbType.String),
                new MySqlParameter("?introduce", MySqlDbType.String),
                new MySqlParameter("?select1_name", MySqlDbType.String),
                new MySqlParameter("?select1_score", MySqlDbType.Float),
                new MySqlParameter("?select2_name", MySqlDbType.String),
                new MySqlParameter("?select2_score", MySqlDbType.Float),
                new MySqlParameter("?select3_name", MySqlDbType.String),
                new MySqlParameter("?select3_score", MySqlDbType.Float),
                new MySqlParameter("?select4_name", MySqlDbType.String),
                new MySqlParameter("?select4_score", MySqlDbType.Float),
            };
            param[0].Value = item.papername;
            param[1].Value = item.introduce;
            param[2].Value = item.select1_name;
            param[3].Value = item.select1_score;
            param[4].Value = item.select2_name;
            param[5].Value = item.select2_score;
            param[6].Value = item.select3_name;
            param[7].Value = item.select3_score;
            param[8].Value = item.select4_name;
            param[9].Value = item.select4_score;
            return MysqlHelper.ExecuteNonQuery(cmdType, cmdText, param);
        }
    }
}
