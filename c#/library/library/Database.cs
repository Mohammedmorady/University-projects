using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace library
{
    internal class Database
    {
        public SQLiteConnection con;
        public SQLiteCommand com;
        public SQLiteDataAdapter ad;
        public Database()
        {
            con = new SQLiteConnection("data source=library.db");
            con.Open();
            com = new SQLiteCommand(con);
            com.CommandType = CommandType.Text;
            ad = new SQLiteDataAdapter();
        }

        /// <summary>
        /// یافتن یک رکورد خاص در جدول
        /// </summary>
        /// <param name="tableName">نام جدول به صورت رشته</param>
        /// <param name="field">نام ستون مورد جستجو به صورت رشته</param>
        /// <param name="value">مقدار مورد جستجو به صورت عددی</param>
        /// <returns></returns>
        public DataRow find(string tableName, string field, string value)
        {
            DataRow row = null;
            try
            {
                com.CommandText = "SELECT * FROM " + tableName + " WHERE " + field + "=@" + field;
                com.Parameters.AddWithValue("@" + field, value);
                // var reader = com.ExecuteReader();
                DataTable dt = new DataTable();
                // dt.Load(reader);
                ad.SelectCommand = com;
                ad.Fill(dt);
                if (dt.Rows.Count > 0)
                    row = dt.Rows[0];
            }
            catch (Exception e)
            {
                Msg.error(e.ToString());
                throw;
            }

            return row;
        }


        /// <summary>
        /// یافتن یک رکورد خاص در جدول
        /// </summary>
        /// <param name="tableName">نام جدول به صورت رشته</param>
        /// <param name="field">نام ستون مورد جستجو به صورت رشته</param>
        /// <param name="value">مقدار مورد جستجو به صورت عددی</param>
        /// <returns></returns>
        public int countRow(string tableName, string field, string value)
        {
            int count = 0;
            try
            {
                com.CommandText = "SELECT COUNT(*) FROM " + tableName + " WHERE " + field + "=@" + field;
                com.Parameters.AddWithValue("@" + field, value);
                // var reader = com.ExecuteReader();
                count = Convert.ToInt32(com.ExecuteScalar());
                //
                // DataTable dt = new DataTable();
                // dt.Load(reader);
                // DataRow row = dt.Rows[0];
                // int count = Convert.ToInt32(row[0]);
            }
            catch (Exception e)
            {
                Msg.error(e.ToString());
                throw;
            }

            return count;
        }


        /// <summary>
        /// یافتن یک رکورد خاص در جدول
        /// </summary>
        /// <param name="tableName">نام جدول به صورت رشته</param>
        /// <param name="field">نام ستون مورد جستجو به صورت رشته</param>
        /// <param name="value">مقدار مورد جستجو به صورت عددی</param>
        /// <returns></returns>
        public void delete(string tableName, string field, string value)
        {
            try
            {
                com.CommandText = "DELETE FROM " + tableName + " WHERE " + field + "=@" + field;
                com.Parameters.AddWithValue("@id", value);
                com.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Msg.error(e.ToString());
                throw;
            }
        }

        public DataTable select(string tableName)
        {
            DataTable dt = new DataTable();
            try
            {
                com.CommandText = "SELECT * FROM " + tableName + " ORDER by id desc LIMIT 1000";
                // var cmd = com.ExecuteReader();
                ad.SelectCommand = com;
                ad.Fill(dt);
                // dt.Load(cmd);
            }
            catch (Exception e)
            {
                Msg.error(e.ToString());
                throw;
            }

            return dt;
        }

    }
}
