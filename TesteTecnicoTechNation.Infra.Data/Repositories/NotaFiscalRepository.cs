using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using TesteTecnicoTechNation.Domain.Entities;
using TesteTecnicoTechNation.Domain.Interfaces.Repositories;

namespace TesteTecnicoTechNation.Infra.Data.Repositories
{
    public class NotaFiscalRepository : INotaFiscalRepository
    {
        private IDbConnection _connection;

        public NotaFiscalRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<IEnumerable<NotaFiscal>> GetAllNotasFiscais()
        {
            return await _connection.QueryAsync<NotaFiscal>(
                sql: @"SELECT * FROM notasFiscais"
                );
        }

        public async Task<NotaFiscal> GetNotaFiscalById(int id)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add("@ID_Nota", id);

            return await _connection.QueryFirstOrDefaultAsync<NotaFiscal>(
                sql: @"SELECT * FROM notasFiscais WHERE id_nota = @ID_Nota",
                param: parametros,
                commandType: CommandType.Text);
        }
    }
}
