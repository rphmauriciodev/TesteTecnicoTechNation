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
    public class DadosFaturamentoRepository : IDadosFaturamentoRepository
    {
        private IDbConnection _connection;

        public DadosFaturamentoRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        private const string FilterQuery = @"
            WHERE
            (
                (@Year IS NOT NULL AND YEAR(dt_emissao) = @Year
                    AND (@Month IS NULL OR MONTH(dt_emissao) BETWEEN @Month AND ISNULL(@FinalMonth, @Month)))
                OR
                (@Month IS NOT NULL AND MONTH(dt_emissao) = @Month AND @Year IS NULL)
                OR
                (@Year IS NULL AND @Month IS NULL AND @FinalMonth IS NULL)
            )";

        public async Task<IEnumerable<DadosGerais>> GetDadosGerais(int? month = null,
                                                                    int? final_month = null,
                                                                    int? year = null)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("@Month", month);
            parametros.Add("@FinalMonth", final_month);
            parametros.Add("@Year", year);

            return await _connection.QueryAsync<DadosGerais>(
                sql: @"SELECT valor_total,
							  id_status
						FROM dbo.fn_GetResumoNotas(@Month, @FinalMonth, @Year)"
,
                param: parametros);
        }
        public async Task<decimal> GetTotal(int? month = null,
                                            int? final_month = null,
                                            int? year = null)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add("@Month", month);
            parametros.Add("@FinalMonth", final_month);
            parametros.Add("@Year", year);

            var total = await _connection.QueryFirstOrDefaultAsync<decimal>(
                sql: $@"SELECT ISNULL(SUM(vl_nota), 0)
						FROM NOTAS_FISCAIS
						{FilterQuery}",
                param: parametros);
            return total;
        }
        public async Task<decimal> GetTotalAVencer(DateTime data_atual,
                                                    int? month = null,
                                                    int? final_month = null,
                                                    int? year = null)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("@Data_atual", data_atual);
            parametros.Add("@Month", month);
            parametros.Add("@FinalMonth", final_month);
            parametros.Add("@Year", year);

            return await _connection.QueryFirstOrDefaultAsync<decimal>(
                sql: $@"SELECT SUM(vl_nota) 
						FROM NOTAS_FISCAIS
						{FilterQuery}
						AND id_status = 1 
						AND @Data_atual BETWEEN DATEADD(DAY, -7, dt_cobranca) AND dt_cobranca",
                param: parametros);
        }
        public async Task<IEnumerable<Inadimplencia>> GetInadimplenciaByYear(int year)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("@Year", year);

            return await _connection.QueryAsync<Inadimplencia>(
                sql: @"SELECT total_inadimplencia,
                              mes_inadimplencia
                       FROM fn_GetInadimplenciaPorAno(@Year)
                       ORDER BY mes_inadimplencia",
                param: parametros);
        }
        public async Task<IEnumerable<Receita>> GetReceitaByYear(int year)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("@Year", year);

            return await _connection.QueryAsync<Receita>(
                sql: @"SELECT total_receita,
                              mes_pagamento
                       FROM fn_GetReceitaPorAno(@Year)
                       ORDER BY mes_pagamento",
                param: parametros);
        }
    }
}
