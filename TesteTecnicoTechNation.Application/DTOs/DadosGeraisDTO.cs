using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteTecnicoTechNation.Application.DTOs
{
	public class DadosGeraisDTO
	{
		public double Valor_total { get; private set; }
		public int ID_Status { get; private set; }
		public string Descricao { get; private set; }
        public DadosGeraisDTO(int id_status, string descricao, double valor)
        {
            ID_Status = id_status;
            Descricao = descricao;
            Valor_total = valor;
        }
    }
}
