using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using IBM.Data.DB2;
using System.IO;

namespace VSBO_Item_List_Generator.SQL
{
    class MSSqlExecuter
    {
        SqlConnection con;
        public SqlConnection connect(string ipPort, string dbName, string uid, string pwd)
        {
            con = new SqlConnection("SERVER=" + ipPort + ";" +
                                    "DATABASE= " + dbName + ";" +
                                    "UID= " + uid + ";" +
                                    "PWD= " + pwd + " " +
                                    "");
            con.Open();
            return con;
        }

        public void close()
        {
            con.Close();
        }

        public void ExecQ(string Query_, SqlConnection sqlConnection)
        {
            SqlTransaction sqlTransaction;
            sqlTransaction = sqlConnection.BeginTransaction();

            try
            {
                SqlCommand cmd = new SqlCommand(Query_, sqlConnection, sqlTransaction);
                cmd.ExecuteNonQuery();
                cmd.CommandTimeout = 0;
                sqlTransaction.Commit();
            }
            catch (SqlException sqlError)
            {
                sqlTransaction.Rollback();
            }
        }

        public SqlDataReader Reader(string q)
        {
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            return rd;
        }

        public object showDGV(string q)
        {
            SqlDataAdapter sda = new SqlDataAdapter(q, con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            object data = ds.Tables[0];
            return data;
        }

        public object showlistbox(string q)
        {
            SqlDataAdapter sda = new SqlDataAdapter(q, con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            object data = ds.Tables[0];
            return data;
        }

        public DataTable queryToDataTable(string q, DataTable ds)
        {
            SqlDataAdapter sda = new SqlDataAdapter(q, con);
            ds = new DataTable();
            sda.Fill(ds);
            return ds;
        }
    }

    class DB2Executer
    {
        DB2Connection con;
        public DB2Connection connect()
        {
            string[] config = File.ReadAllLines(Environment.CurrentDirectory + @"\Configuration\DB2CONFIG.cfg");

            con = new DB2Connection("SERVER=" + config[0] + ";" +
                                    "DATABASE= " + config[1] + ";" +
                                    "UID= " + config[2] + ";" +
                                    "PWD= " + config[3] + " " +
                                    "");
            con.Open();
            return con;
        }

        public void close()
        {
            con.Close();
        }

        public void ExecQ(string q, DB2Connection dB2Connection)
        {
            DB2Transaction DB2Transaction;
            DB2Transaction = dB2Connection.BeginTransaction();

            try
            {
                DB2Command cmd = new DB2Command(q, dB2Connection, DB2Transaction);
                cmd.ExecuteNonQuery();
                cmd.CommandTimeout = 0;
                DB2Transaction.Commit();
            }
            catch (DB2Exception sqlError)
            {
                DB2Transaction.Rollback();
            }
        }

        public DB2DataReader Reader(string q)
        {
            DB2Command cmd = new DB2Command(q, con);
            DB2DataReader rd;
            rd = cmd.ExecuteReader();
            return rd;
        }

        public object showDGV(string q)
        {
            DB2DataAdapter sda = new DB2DataAdapter(q, con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            object data = ds.Tables[0];
            return data;
        }

        public object showlistbox(string q)
        {
            DB2DataAdapter sda = new DB2DataAdapter(q, con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            object data = ds.Tables[0];
            return data;
        }

        public DataTable queryToDataTable(string q, DataTable ds)
        {
            DB2DataAdapter sda = new DB2DataAdapter(q, con);
            ds = new DataTable();
            sda.Fill(ds);
            return ds;
        }
    }

}
