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
        public static void AddNobreak(Nobreak nobreak)
        {
            if (string.IsNullOrWhiteSpace(nobreak.Modelo))
                throw new ArgumentException("Selecione um modelo.");

            if (string.IsNullOrWhiteSpace(nobreak.Localizacao))
                throw new ArgumentException("Selecione a localização.");

            if (nobreak.CapacidadeVA <= 0)
                throw new ArgumentException("Informe uma capacidade válida (>0).");

            if (nobreak.DataAquisicao > DateTime.Today)
                throw new ArgumentException("A data de aquisição não pode ser no futuro.");

            if (nobreak.DataGarantia < DateTime.Today)
                throw new ArgumentException("A data de garantia não pode ser no passado.");

            if (nobreak.VidaUtilAnos <= 0)
                throw new ArgumentException("Informe uma vida útil válida (>0).");


            Repositories.NobreakRepository.InsertNobreak(nobreak);
        }

        public static void DeleteNobreak(int id)
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

        public static void UpdateNobreak(Nobreak nobreak)
        {
            if (nobreak.Id <= 0)
                throw new ArgumentException("ID inválido.");
            if (string.IsNullOrWhiteSpace(nobreak.Modelo))
                throw new ArgumentException("Selecione um modelo.");
            if (string.IsNullOrWhiteSpace(nobreak.Localizacao))
                throw new ArgumentException("Selecione a localização.");
            if (nobreak.CapacidadeVA <= 0)
                throw new ArgumentException("Informe uma capacidade válida (>0).");
            if (nobreak.DataAquisicao > DateTime.Today)
                throw new ArgumentException("A data de aquisição não pode ser no futuro.");
            if (nobreak.DataGarantia < DateTime.Today)
                throw new ArgumentException("A data de garantia não pode ser no passado.");
            if (nobreak.VidaUtilAnos <= 0)
                throw new ArgumentException("Informe uma vida útil válida (>0).");
            Repositories.NobreakRepository.UpdateNobreak(nobreak);
        }
    }
}
