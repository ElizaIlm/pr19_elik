using MySql.Data.MySqlClient;
using pr19_elik.Classes.Common;
using pr19_elik.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr19_elik.Classes
{
    public class KinoteatrContext : Kinoteatr
    {
        public KinoteatrContext(int Id, string Name, int CountZal, int Count) : base(Id, Name, CountZal, Count) { }

        public void Add()
        {
            string SQL = "INSERT INTO " +
                "`kinoteatr`(" +
                "`name`, " +
                "`count_zal`, " +
                "`count`) " +
                "VALUES " +
                $"('{this.Name}', " +
                $"{this.CountZal}, " +
                $"{this.Count})";
            MySqlConnection connection = Connection.OpenConnection();
            Connection.Query(SQL, connection);
            Connection.CloseConnection(connection);
        }
        public void Update()
        {
            string SQL = "UPDATE " +
                "`kinoteatr` " +
                "SET " +
                $"'name'='{this.Name}', " +
                $"'count_zal'={this.CountZal}, " +
                $"'count'={this.Count} " +
                "WHERE " +
                $"'id'={this.Id}";
            MySqlConnection connection = Connection.OpenConnection();
            Connection.Query(SQL, connection);
            Connection.CloseConnection(connection);
        }
        public void Delete()
        {
            string SQL = $"DELETE FROM `kinoteatr` WHERE `id` = {this.Id}";
            MySqlConnection connection = Connection.OpenConnection();
            Connection.Query(SQL, connection);
            Connection.CloseConnection(connection);
        }
    }
}
