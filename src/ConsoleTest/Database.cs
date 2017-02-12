using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
namespace Rations4Animals_MVC.Models
{
    public class Database
    {
        public static string filename;
        public static string severMap;

        public static DataRowCollection getRows(string sql)
        {

            DataSet dataSet;
            string strAccessConn;
            OleDbConnection connection;
            OleDbCommand sqlCommand;
            OleDbDataAdapter apdapter;
            DataRowCollection rows;
            strAccessConn = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}",filename);
            connection = new OleDbConnection(strAccessConn);
            connection.Open();
            dataSet = new DataSet();
            sqlCommand = new OleDbCommand();
            sqlCommand.CommandText = sql;
            sqlCommand.Connection = connection;
            apdapter = new OleDbDataAdapter(sqlCommand);
            apdapter.Fill(dataSet);
            rows = dataSet.Tables[0].Rows;
            connection.Close();
            return rows;


        }

        public static bool ExecuteSQL(string sql)
        {
            DataSet dataSet;
            string strAccessConn;
            OleDbConnection connection;
            OleDbCommand sqlCommand;

            strAccessConn = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}", filename);

            connection = new OleDbConnection(strAccessConn);
            connection.Open();
            dataSet = new DataSet();
            sqlCommand = new OleDbCommand();
            sqlCommand.CommandText = sql;
            sqlCommand.Connection = connection;
            sqlCommand.ExecuteNonQuery();
            connection.Close();
            return true;


        }

        public static bool ExecuteSQL(String[] sql)
        {


            string strAccessConn;
            OleDbConnection connection;
            OleDbCommand sqlCommand;

            strAccessConn = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}", filename);

            connection = new OleDbConnection(strAccessConn);
            connection.Open();

            foreach (string s in sql)
            {
                sqlCommand = new OleDbCommand();
                sqlCommand.CommandText = s;
                sqlCommand.Connection = connection;
                sqlCommand.ExecuteNonQuery();
            }

            connection.Close();
            return true;


        }


        public static string[] getAllTables()
        {


            string strAccessConn;
            OleDbConnection connection;
            List<string> tables = new List<string>();

            strAccessConn = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}", filename);

            connection = new OleDbConnection(strAccessConn);
            connection.Open();

            DataTable schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

            foreach (DataRow row in schemaTable.Rows)
            {
                tables.Add(row[2].ToString());
            }

            return tables.ToArray();
        }

        public static string[][] getAllColumns(string tableName)
        {


            string strAccessConn;
            OleDbConnection connection;
            DataSet dataSet = new DataSet();
            OleDbCommand sqlCommand;
            OleDbDataAdapter apdapter;
            DataColumnCollection col;
            List<string[]> columns = new List<string[]>();

            strAccessConn = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}", filename);

            connection = new OleDbConnection(strAccessConn);
            connection.Open();

            sqlCommand = new OleDbCommand();
            sqlCommand.CommandText = string.Format("Select * From {0}", tableName);
            sqlCommand.Connection = connection;
            apdapter = new OleDbDataAdapter(sqlCommand);
            apdapter.Fill(dataSet);
            col = dataSet.Tables[0].Columns;

            foreach (DataColumn dc in col)
            {
                columns.Add(new string[] { dc.ColumnName, dc.DataType.ToString() });
            }


            return columns.ToArray();
        }

        public static string[] getAllColumnsList(string tableName)
        {
            string strAccessConn;
            OleDbConnection connection;
            DataSet dataSet = new DataSet();
            OleDbCommand sqlCommand;
            OleDbDataAdapter apdapter;
            DataColumnCollection col;
            List<string> columns = new List<string>();

            strAccessConn = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}",filename);

            connection = new OleDbConnection(strAccessConn);
            connection.Open();

            sqlCommand = new OleDbCommand();
            sqlCommand.CommandText = string.Format("Select * From {0}", tableName);
            sqlCommand.Connection = connection;
            apdapter = new OleDbDataAdapter(sqlCommand);
            apdapter.Fill(dataSet);
            col = dataSet.Tables[0].Columns;

            foreach (DataColumn dc in col)
            {
                columns.Add(dc.ColumnName);
            }


            return columns.ToArray();
        }


        public static DataSet getDataSet(string tableName)
        {


            string strAccessConn;
            OleDbConnection connection;
            DataSet dataSet = new DataSet();
            OleDbCommand sqlCommand;
            OleDbDataAdapter apdapter;


            strAccessConn = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}",filename);

            connection = new OleDbConnection(strAccessConn);
            connection.Open();

            sqlCommand = new OleDbCommand();
            sqlCommand.CommandText = string.Format("Select * From {0}",tableName);
            sqlCommand.Connection = connection;
            apdapter = new OleDbDataAdapter(sqlCommand);
            apdapter.Fill(dataSet);
            return dataSet;
        }

    }
}
