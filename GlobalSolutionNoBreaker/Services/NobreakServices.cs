using GlobalSolutionNoBreaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalSolutionNoBreaker.Services
{
    public class NobreakServices
    {
        public static void AdicionarNobreak(NobreakDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Modelo))
                throw new ArgumentException("Selecione um modelo.");

            if (string.IsNullOrWhiteSpace(dto.Localizacao))
                throw new ArgumentException("Selecione a localização.");

            if (!int.TryParse(dto.CapacidadeVA, out int capacidade) || capacidade <= 0)
                throw new ArgumentException("Informe uma capacidade válida (>0).");

            if (dto.DataAquisicao > DateTime.Today)
                throw new ArgumentException("A data de aquisição não pode ser no futuro.");

            if (!int.TryParse(dto.VidaUtil, out int vidaUtil) || vidaUtil <= 0)
                throw new ArgumentException("Informe uma vida útil válida (>0).");

            int ciclo = 0;
            if (!string.IsNullOrWhiteSpace(dto.CicloInicial))
            {
                if (!int.TryParse(dto.CicloInicial, out ciclo) || ciclo < 0)
                    throw new ArgumentException("Informe um ciclo de carga inicial válido (≥0).");
            }

            var nobreak = new Nobreak
            {
                Modelo = dto.Modelo,
                Localizacao = dto.Localizacao,
                CapacidadeVA = capacidade,
                DataAquisicao = dto.DataAquisicao,
                VidaUtilAnos = vidaUtil,
                CicloCarga = ciclo
            };

            Repositories.NobreakRepository.InsertNobreak(nobreak);
        }

        public static void DeletarNobreak(int id)
        {
         
            try
            {
                var nobreak = Repositories.NobreakRepository.GetNobreakById(id);
                if (nobreak == null)
                    throw new ArgumentException("Nobreak não encontrado.");
                else
                {
                    Repositories.NobreakRepository.DeleteNobreak(id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar nobreak: " + ex.Message); 
            }
        }
    }
}
