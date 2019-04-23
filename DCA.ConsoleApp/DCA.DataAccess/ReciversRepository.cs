using DCA.DataAccess.Abstract;
using DCA.Models;
using System;
using System.Collections.Generic;
using Dapper;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

namespace DCA.DataAccess
{
    public class ReciversRepository : IRepository<Reciver>
    {
        private DbConnection _connection;

        public ReciversRepository()
        {
            var connectionString = ConfigurationManager
                .ConnectionStrings["appConnection"]
                .ConnectionString;
            _connection = new SqlConnection(connectionString);
        }

        public void Add(Reciver item)
        {
            var sql = "insert into Recivers values (@Id, @FullName, @Adress, @CreationDate, @DeletedDate)";
            var result = _connection.Execute(sql, item);
            if (result < 1) throw new Exception();
        }

        public void Delete(Reciver item)
        {
            var sql = $"update Recivers set DeletedDate = @DeletedDate where Id = @id";
            _connection.Execute(sql, new { DeletedDate = DateTime.Now, item.Id });
        }

        public void Dispose()
        {
            _connection.Close();
        }

        public ICollection<Reciver> GetAll()
        {
            var sql = "select * from Recivers";
            return _connection.Query<Reciver>(sql).AsList();
        }

        public void Update(Reciver item)
        {
            var sql = $"update Recivers set @FullName = {item.FullName}, @Adress = {item.Adress}";
            _connection.Execute(sql, item);
        }
    }
}
