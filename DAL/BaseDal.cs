using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// 基础数据层
    /// </summary>
    public abstract class BaseDal
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        #region 取得列表
        /// <summary>
        /// 取得数据列表
        /// </summary>
        /// <param name="strSql">Sql语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public DataSet ExecuteDataset(string strSql, params SqlParameter[] parameters)
        {
            return SqlHelper.ExecuteDataset(this.ConnectionString, CommandType.Text, strSql, parameters);
        }
        /// <summary>
        /// 取得数据列表
        /// </summary>
        /// <param name="strSql">Sql语句</param>
        /// <returns></returns>
        public DataSet ExecuteDataset(string strSql)
        {
            return SqlHelper.ExecuteDataset(this.ConnectionString, CommandType.Text, strSql.ToString());
        }
        /// <summary>
        /// 执行存储过程取得数据列表
        /// </summary>
        /// <param name="spName">存储过程名称</param>
        /// <returns></returns>
        public DataSet SP_ExecuteDataset(string spName)
        {
            return SqlHelper.ExecuteDataset(this.ConnectionString, CommandType.StoredProcedure, spName);
        }
        /// <summary>
        /// 执行存储过程取得数据列表
        /// </summary>
        /// <param name="spName">存储过程名称</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public DataSet SP_ExecuteDataset(string spName, params SqlParameter[] parameters)
        {
            return SqlHelper.ExecuteDataset(this.ConnectionString, CommandType.StoredProcedure, spName, parameters);
        }
        #endregion

        #region 执行SQL语句
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="strSql">Sql语句</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string strSql)
        {
            return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, strSql);
        }
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="strSql">Sql语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string strSql, params SqlParameter[] parameters)
        {
            return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, strSql, parameters);
        }
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="spName">存储过程名称</param>
        /// <returns>返回影响行数</returns>
        public int SP_ExecuteNonQuery(string spName)
        {
            return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, spName);
        }
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="spName">存储过程名称</param>
        /// <param name="parameters">参数</param>
        /// <returns>返回影响行数</returns>
        public int SP_ExecuteNonQuery(string spName, params SqlParameter[] parameters)
        {
            return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, spName, parameters);
        }
        #endregion

        #region 取得单记录
        /// <summary>
        /// 取得第一行的第一个字段
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object ExecuteScalar(string sql)
        {
            return SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql);
        }
        /// <summary>
        /// 得第一行的第一个字段
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        public object ExecuteScalar(string sql, params SqlParameter[] pars)
        {
            return SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, pars);
        }
        /// <summary>
        /// 存储过程得第一行的第一个字段
        /// </summary>
        /// <param name="spName">存储过程名称</param>
        /// <returns></returns>
        public object SP_ExecuteScalar(string spName)
        {
            return SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.StoredProcedure, spName);
        }
        /// <summary>
        /// 得第一行的第一个字段
        /// </summary>
        /// <param name="sql">存储过程名称</param>
        /// <param name="pars">参数</param>
        /// <returns></returns>
        public object SP_ExecuteScalar(string sql, params SqlParameter[] pars)
        {
            return SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, pars);
        }
        #endregion

        #region 执行Reader SQL语句
        /// <summary>
        /// 执行Reader SQL语句
        /// </summary>
        /// <param name="strSql">Sql语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(string strSql, params SqlParameter[] parameters)
        {
            return SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, strSql, parameters);
        }
        /// <summary>
        /// 执行存储过程Reader 语句
        /// </summary>
        /// <param name="spName">存储过程名称</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public SqlDataReader SP_ExecuteReader(string spName, params SqlParameter[] parameters)
        {
            return SqlHelper.ExecuteReader(ConnectionString, CommandType.StoredProcedure, spName, parameters);
        }
        /// <summary>
        /// 执行Reader SQL语句
        /// </summary>
        /// <param name="strSql">Sql语句</param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(string strSql)
        {
            return SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, strSql);
        }
        /// <summary>
        /// 执行存储过程Reader 语句
        /// </summary>
        /// <param name="spName">存储过程名称</param>
        /// <returns></returns>
        public SqlDataReader SP_ExecuteReader(string spName)
        {
            return SqlHelper.ExecuteReader(ConnectionString, CommandType.StoredProcedure, spName);
        }
        #endregion
    }
}
