using GlobalSolutionNoBreaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalSolutionNoBreaker.Services
{
    /// <summary>
    /// Serviço responsável pelas regras de negócio relacionadas aos Nobreaks.
    /// Implementa validações e coordena operações entre a camada de apresentação e repositório.
    /// </summary>
    public class NobreakServices
    {
        /// <summary>
        /// Adiciona um novo Nobreak ao sistema após validar os dados.
        /// </summary>
        /// <param name="nobreak">Objeto Nobreak contendo os dados a serem inseridos</param>
        /// <exception cref="ArgumentException">
        /// Lançada quando algum campo obrigatório é inválido ou está em branco
        /// </exception>
        /// <remarks>
        /// Valida: modelo válido, localização preenchida, data de aquisição não futura 
        /// e data de garantia não passada antes de inserir no banco de dados.
        /// </remarks>
        public static void AddNobreak(Nobreak nobreak)
        {
            // Valida se foi selecionado um modelo válido
            if (nobreak.ModeloId <= 0)
                throw new ArgumentException("Selecione um modelo válido.");

            // Valida se a localização foi preenchida
            if (string.IsNullOrWhiteSpace(nobreak.Localizacao))
                throw new ArgumentException("Selecione a localização.");

            // Valida se a data de aquisição não é futura
            if (nobreak.DataAquisicao > DateTime.Today)
                throw new ArgumentException("A data de aquisição não pode ser no futuro.");

            // Valida se a data de garantia não é passada
            if (nobreak.DataGarantia < DateTime.Today)
                throw new ArgumentException("A data de garantia não pode ser no passado.");

            // Chama o repositório para inserir o nobreak
            Repositories.NobreakRepository.InsertNobreak(nobreak);
        }

        /// <summary>
        /// Remove um Nobreak do sistema pelo ID.
        /// </summary>
        /// <param name="id">ID único do Nobreak a ser removido</param>
        /// <exception cref="ArgumentException">
        /// Lançada quando o Nobreak com o ID especificado não é encontrado
        /// </exception>
        /// <exception cref="Exception">
        /// Lançada quando ocorre erro durante a busca ou remoção do Nobreak
        /// </exception>
        public static void DeleteNobreak(int id)
        {
            try
            {
                // Verifica se o nobreak existe antes de tentar deletar
                var nobreak = Repositories.NobreakRepository.GetNobreakById(id);
                if (nobreak == null)
                    throw new ArgumentException("Nobreak não encontrado.");
                else
                {
                    // Remove o nobreak do banco de dados
                    Repositories.NobreakRepository.DeleteNobreak(id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar nobreak: " + ex.Message);
            }
        }

        /// <summary>
        /// Atualiza os dados de um Nobreak existente após validar as informações.
        /// </summary>
        /// <param name="nobreak">Objeto Nobreak contendo os dados atualizados</param>
        /// <exception cref="ArgumentException">
        /// Lançada quando algum campo obrigatório é inválido ou está em branco
        /// </exception>
        /// <remarks>
        /// Valida: ID válido, modelo válido, localização preenchida e data de aquisição não futura
        /// antes de atualizar no banco de dados.
        /// </remarks>
        public static void UpdateNobreak(Nobreak nobreak)
        {
            // Valida se o ID é válido
            if (nobreak.Id <= 0)
                throw new ArgumentException("ID inválido.");

            // Valida se foi selecionado um modelo válido
            if (nobreak.ModeloId <= 0)
                throw new ArgumentException("Selecione um modelo válido.");

            // Valida se a localização foi preenchida
            if (string.IsNullOrWhiteSpace(nobreak.Localizacao))
                throw new ArgumentException("Selecione a localização.");

            // Valida se a data de aquisição não é futura
            if (nobreak.DataAquisicao > DateTime.Today)
                throw new ArgumentException("A data de aquisição não pode ser no futuro.");

            // Chama o repositório para atualizar o nobreak
            Repositories.NobreakRepository.UpdateNobreak(nobreak);
        }

        /// <summary>
        /// Registra informações de manutenção para um Nobreak específico.
        /// </summary>
        /// <param name="nobreak">Objeto Nobreak contendo o ID e status operacional para registro</param>
        /// <exception cref="ArgumentException">
        /// Lançada quando o ID é inválido ou o status operacional não foi selecionado
        /// </exception>
        /// <remarks>
        /// Valida: ID válido e status operacional preenchido antes de registrar a manutenção.
        /// </remarks>
        public static void RegistroManutencao(Nobreak nobreak)
        {
            // Valida se o ID é válido
            if (nobreak.Id <= 0)
                throw new ArgumentException("ID inválido.");

            // Valida se foi selecionado um status operacional válido
            if (string.IsNullOrWhiteSpace(nobreak.StatusOperacional))
                throw new ArgumentException("Selecione Status válido.");

            // Chama o repositório para registrar a manutenção
            Repositories.NobreakRepository.RegistroNobreakManutencao(nobreak);
        }
    }
}