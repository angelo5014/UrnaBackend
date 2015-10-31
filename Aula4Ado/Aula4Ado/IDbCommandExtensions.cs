using System;
using System.Data;

namespace DbExtensions
{

    public static class IDbCommandExtensions
    {
        public static void AddParameter(this IDbCommand cmd, string nome, object value)
        {
            IDbDataParameter param = cmd.CreateParameter();
            param.ParameterName = nome;
            param.Value = value ?? DBNull.Value;

            cmd.Parameters.Add(param);
        }
    }
}