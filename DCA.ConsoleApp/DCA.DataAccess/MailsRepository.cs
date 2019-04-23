using Dapper;
using DCA.DataAccess.Abstract;
using DCA.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCA.DataAccess
{
    public class MailsRepository : IRepository<Mail> 
    {
        private DbConnection _connection;

        public MailsRepository()
        {
            var connectionString = ConfigurationManager
                .ConnectionStrings["appConnection"]
                .ConnectionString;
            _connection = new SqlConnection(connectionString);
        }

        public void Add(Mail item)
        {
            var sql = "insert into Mails values (@Id, @ReciverId, @Theme, @Text, @CreationDate, @DeletedDate)";
            var result = _connection.Execute(sql, item);
            if (result < 1) throw new Exception();
        }

        public void Delete(Mail item)
        {
            var sql = $"update Mails set @DeleteDate = {DateTime.Now} where @Id = {item.Id}";
            _connection.Execute(sql, new { item.Id });
        }

        public void Dispose()
        {
            _connection.Close();
        }

        public ICollection<Mail> GetAll()
        {
            var sql = "select * from Mails";
            return _connection.Query<Mail>(sql).AsList();
        }

        public void Update(Mail item)
        {
            var sql = $"update Mails set @Theme = {item.Theme}, @Text = {item.Text} where @Id = {item.Id}";
            _connection.Execute(sql, item);
        }
    }
}
