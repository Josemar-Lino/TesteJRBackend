using apiToDo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Models
{
    /// <summary>
    /// Classe responsável pela lógica de negócios relacionada às tarefas
    /// Implementa as operações CRUD básicas para gerenciamento de tarefas
    /// </summary>
    public class Tarefas
    {
        // Lista estática que simula um banco de dados em memória
        // Contém as tarefas pré-cadastradas do sistema
        private static readonly List<TarefaDTO> _tarefas = new List<TarefaDTO>
        {
            new TarefaDTO { ID_TAREFA = 1, DS_TAREFA = "Fazer Compras" },
            new TarefaDTO { ID_TAREFA = 2, DS_TAREFA = "Fazer Atividade Faculdade" },
            new TarefaDTO { ID_TAREFA = 3, DS_TAREFA = "Subir Projeto de Teste no GitHub" }
        };

        /// <summary>
        /// Retorna a lista completa de tarefas cadastradas
        /// </summary>
        /// <returns>Lista de TarefaDTO contendo todas as tarefas</returns>
        /// <exception cref="Exception">Lançada quando ocorre algum erro ao listar as tarefas</exception>
        public List<TarefaDTO> lstTarefas()
        {
            try
            {
                return new List<TarefaDTO>(_tarefas); // Retorna uma cópia da lista
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar tarefas: {ex.Message}");
            }
        }

        /// <summary>
        /// Retorna uma tarefa específica com base no ID fornecido
        /// </summary>
        /// <param name="id">ID da tarefa a ser recuperada</param>
        /// <returns>Objeto TarefaDTO correspondente ao ID informado</returns>
        /// <exception cref="Exception">Lançada quando a tarefa não é encontrada ou ocorre algum erro</exception>
        public TarefaDTO ObterTarefaPorId(int id)
        {
            try
            {
                // Busca a tarefa pelo ID na lista
                var tarefa = _tarefas.FirstOrDefault(x => x.ID_TAREFA == id);
                
                // Verifica se a tarefa foi encontrada
                if (tarefa == null)
                {
                    throw new Exception($"Tarefa com ID {id} não encontrada.");
                }
                
                return tarefa;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter tarefa: {ex.Message}");
            }
        }

        /// <summary>
        /// Insere uma nova tarefa na lista
        /// </summary>
        /// <param name="tarefa">Objeto TarefaDTO contendo os dados da nova tarefa</param>
        /// <exception cref="Exception">Lançada quando a tarefa é nula, já existe ou ocorre algum erro</exception>
        public void InserirTarefa(TarefaDTO tarefa)
        {
            try
            {
                // Valida se o objeto tarefa não é nulo
                if (tarefa == null)
                {
                    throw new Exception("Tarefa não pode ser nula.");
                }

                // Verifica se já existe uma tarefa com o mesmo ID
                if (_tarefas.Any(x => x.ID_TAREFA == tarefa.ID_TAREFA))
                {
                    throw new Exception($"Já existe uma tarefa com o ID {tarefa.ID_TAREFA}.");
                }

                // Adiciona a nova tarefa à lista
                _tarefas.Add(tarefa);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir tarefa: {ex.Message}");
            }
        }

        /// <summary>
        /// Atualiza os dados de uma tarefa existente
        /// </summary>
        /// <param name="tarefaAtualizada">Objeto TarefaDTO contendo os dados atualizados</param>
        /// <exception cref="Exception">Lançada quando a tarefa é nula, não existe ou ocorre algum erro</exception>
        public void AtualizarTarefa(TarefaDTO tarefaAtualizada)
        {
            try
            {
                // Valida se o objeto tarefa não é nulo
                if (tarefaAtualizada == null)
                {
                    throw new Exception("Tarefa não pode ser nula.");
                }

                // Busca a tarefa existente pelo ID
                var tarefaExistente = _tarefas.FirstOrDefault(x => x.ID_TAREFA == tarefaAtualizada.ID_TAREFA);
                
                // Verifica se a tarefa foi encontrada
                if (tarefaExistente == null)
                {
                    throw new Exception($"Tarefa com ID {tarefaAtualizada.ID_TAREFA} não encontrada.");
                }

                // Atualiza a descrição da tarefa
                tarefaExistente.DS_TAREFA = tarefaAtualizada.DS_TAREFA;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar tarefa: {ex.Message}");
            }
        }

        /// <summary>
        /// Remove uma tarefa da lista com base no ID fornecido
        /// </summary>
        /// <param name="id">ID da tarefa a ser removida</param>
        /// <exception cref="Exception">Lançada quando a tarefa não é encontrada ou ocorre algum erro</exception>
        public void DeletarTarefa(int id)
        {
            try
            {
                // Busca a tarefa pelo ID
                var tarefa = _tarefas.FirstOrDefault(x => x.ID_TAREFA == id);
                
                // Verifica se a tarefa foi encontrada
                if (tarefa == null)
                {
                    throw new Exception($"Tarefa com ID {id} não encontrada.");
                }

                // Remove a tarefa da lista
                _tarefas.Remove(tarefa);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar tarefa: {ex.Message}");
            }
        }
    }
}
