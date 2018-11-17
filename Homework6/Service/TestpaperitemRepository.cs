
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
            string cmdText = "INSERT INTO testpaperitem (`question`, `paperid`, `select1_score`, `select2_score`, `select3_score`, `select4_score`) VALUES (?question, ?paperid,?select1_score,?select2_score,?select3_score,?select4_score);";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?question", MySqlDbType.String),
                new MySqlParameter("?paperid", MySqlDbType.Int32),
                new MySqlParameter("?select1_score", MySqlDbType.Float),
                new MySqlParameter("?select2_score", MySqlDbType.Float),
                new MySqlParameter("?select3_score", MySqlDbType.Float),
                new MySqlParameter("?select4_score", MySqlDbType.Float),

            };
            param[0].Value = item.question;
            param[1].Value = item.paperid;
            param[2].Value = item.select1_score;
            param[3].Value = item.select2_score;
            param[4].Value = item.select3_score;
            param[5].Value = item.select4_score;

            return MysqlHelper.ExecuteNonQuery(cmdType, cmdText, param);
        }
        public int Delete(int iid)
        {
            string cmdText = "Delete FROM testpaperitem WHERE `iid`= ?iid";
            MySqlParameter param = new MySqlParameter("?iid", MySqlDbType.Int32);
            param.Value = iid;
            return MysqlHelper.ExecuteNonQuery(cmdType, cmdText, param);
        }
        public int Update(TestpaperitemModel item)
        {
            string cmdText = "UPDATE `testpaperitem` SET `question` = ?question, `paperid`= ?paperid, `select1_score`= ?select1_score, `select2_score`= ?select2_score, `select3_score`= ?select3_score, `select4_score`= ?select4_score WHERE (`iid`=?iid);";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?question", MySqlDbType.String),
                new MySqlParameter("?paperid", MySqlDbType.Int32),
                new MySqlParameter("?select1_score", MySqlDbType.Float),
                new MySqlParameter("?select2_score", MySqlDbType.Float),
                new MySqlParameter("?select3_score", MySqlDbType.Float),
                new MySqlParameter("?select4_score", MySqlDbType.Float),

            };
            param[0].Value = item.question;
            param[1].Value = item.paperid;
            param[2].Value = item.select1_score;
            param[3].Value = item.select2_score;
            param[4].Value = item.select3_score;
            param[5].Value = item.select4_score;

            return MysqlHelper.ExecuteNonQuery(cmdType, cmdText, param);
        }
    }

}