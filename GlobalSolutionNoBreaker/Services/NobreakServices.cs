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
            if (nobreak.ModeloId <= 0)
                throw new ArgumentException("Selecione um modelo válido.");

            if (string.IsNullOrWhiteSpace(nobreak.Localizacao))
                throw new ArgumentException("Selecione a localização.");

            if (nobreak.DataAquisicao > DateTime.Today)
                throw new ArgumentException("A data de aquisição não pode ser no futuro.");

            if (nobreak.DataGarantia < DateTime.Today)
                throw new ArgumentException("A data de garantia não pode ser no passado.");


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
            if (nobreak.ModeloId <= 0)
                throw new ArgumentException("Selecione um modelo válido.");
            if (string.IsNullOrWhiteSpace(nobreak.Localizacao))
                throw new ArgumentException("Selecione a localização.");
            if (nobreak.DataAquisicao > DateTime.Today)
                throw new ArgumentException("A data de aquisição não pode ser no futuro.");
            Repositories.NobreakRepository.UpdateNobreak(nobreak);
        }

        public static void RegistroManutencao(Nobreak nobreak)
        {
            if (nobreak.Id <= 0)
                throw new ArgumentException("ID inválido.");
            if (string.IsNullOrWhiteSpace(nobreak.StatusOperacional))
                throw new ArgumentException("Selecione Status valido.");
            Repositories.NobreakRepository.RegistroNobreakManutencao(nobreak);

        }
    }
}