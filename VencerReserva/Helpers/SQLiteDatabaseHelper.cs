using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using VencerReserva.Models;

namespace VencerReserva.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDatabaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Equipamento>().Wait();
        }

        public Task<int> Insert(Equipamento equipamento)
        {
            return _conn.InsertAsync(equipamento);
        }

        public Task<List<Equipamento>> Update(Equipamento equipamento)
        {
            string sql = "UPDATE Equipamento SET Nome=?, CheckIn=?, CheckOut=?, Quantidade, Responsavel, Sala WHERE Id=?";

            return _conn.QueryAsync<Equipamento>(sql, equipamento.Nome, equipamento.CheckIn, equipamento.CheckOut, 
                                                 equipamento.Quantidade, equipamento.Responsavel, equipamento.Sala ,equipamento.Id);
        }

        public Task<int> Delete(int id)
        {
            return _conn.Table<Equipamento>().DeleteAsync(i => i.Id == id);
        }

        public Task<List<Equipamento>> GetAll()
        {
            return _conn.Table<Equipamento>().ToListAsync();
        }

        public Task<List<Equipamento>> Search(string query)
        {
            string sql = "SELECT * FROM Equipamento WHERE Nome LIKE '%" + query + "%'";

            return _conn.QueryAsync<Equipamento>(sql);
        }
    }
}
