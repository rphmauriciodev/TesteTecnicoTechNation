using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
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
        public async Task<IEnumerable<NotaFiscal>> GetNotasFiscais(int id_status)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("@ID_Status", id_status);

            return await _connection.QueryAsync<NotaFiscal>(
                sql: @"SELECT
                           id_nota,
                           nome_pagador,
                           dt_emissao,
                           dt_cobranca,
                           dt_pagamento,
                           vl_nota,
                           documento_nota,
                           documento_boleto,
                           id_status,
                           st_nota
                       FROM dbo.GetAllNotas(@ID_Status)",
                param: parametros,
                commandType: CommandType.Text);
        }

        public Task<NotaFiscal> GetNotaFiscalById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<NotaFiscal>> GetNotasFiscaisByMonth(int month, int year, char tipo_data, int id_status)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add("@Tipo_data", tipo_data, DbType.String, size: 1);
            parametros.Add("@Month", month);
            parametros.Add("@Year", year);
            parametros.Add("@ID_Status", id_status);

            return await _connection.QueryAsync<NotaFiscal>(
                sql: @"SELECT
                           id_nota,
                           nome_pagador,
                           dt_emissao,
                           dt_cobranca,
                           dt_pagamento,
                           vl_nota,
                           documento_nota,
                           documento_boleto,
                           id_status,
                           st_nota
                       FROM dbo.GetNotasByMonth(@Month, @Year, @Tipo_data, @ID_Status)",
                param: parametros,
                commandType: CommandType.Text);
        }

        public async Task<IEnumerable<NotaFiscal>> GetNotasFiscaisByStatus(int status)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add("@Status", status);

            return await _connection.QueryAsync<NotaFiscal>(
                sql: @"SELECT
                           id_nota,
                           nome_pagador,
                           dt_emissao,
                           dt_cobranca,
                           dt_pagamento,
                           vl_nota,
                           documento_nota,
                           documento_boleto,
                           id_status,
                           st_nota
                       FROM dbo.GetAllNotas()
                       WHERE id_status = @Status",
                param: parametros,
                commandType: CommandType.Text);
        }
        
        public async Task<IEnumerable<Status>> GetStatus()
        {

            return await _connection.QueryAsync<Status>(
                sql: @"SELECT
                           cd_status,
                           st_nota
                       FROM STATUS",
                commandType: CommandType.Text);
        }
    }
}
