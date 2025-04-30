using apiToDo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Models
{
    public class Tarefas
    {
        // Lista estática para simular um banco de dados
        private static List<TarefaDTO> _tarefas = new List<TarefaDTO>
        {
            new TarefaDTO { ID_TAREFA = 1, DS_TAREFA = "Fazer Compras" },
            new TarefaDTO { ID_TAREFA = 2, DS_TAREFA = "Fazer Atividade Faculdade" },
            new TarefaDTO { ID_TAREFA = 3, DS_TAREFA = "Subir Projeto de Teste no GitHub" }
        };

        public List<TarefaDTO> lstTarefas()
        {
            try
            {
                return _tarefas;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar tarefas: {ex.Message}");
            }
        }

        public TarefaDTO ObterTarefaPorId(int id)
        {
            try
            {
                var tarefa = _tarefas.FirstOrDefault(x => x.ID_TAREFA == id);
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

        public void InserirTarefa(TarefaDTO tarefa)
        {
            try
            {
                if (tarefa == null)
                {
                    throw new Exception("Tarefa não pode ser nula.");
                }

                if (_tarefas.Any(x => x.ID_TAREFA == tarefa.ID_TAREFA))
                {
                    throw new Exception($"Já existe uma tarefa com o ID {tarefa.ID_TAREFA}.");
                }

                _tarefas.Add(tarefa);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir tarefa: {ex.Message}");
            }
        }

        public void AtualizarTarefa(TarefaDTO tarefaAtualizada)
        {
            try
            {
                if (tarefaAtualizada == null)
                {
                    throw new Exception("Tarefa não pode ser nula.");
                }

                var tarefaExistente = _tarefas.FirstOrDefault(x => x.ID_TAREFA == tarefaAtualizada.ID_TAREFA);
                if (tarefaExistente == null)
                {
                    throw new Exception($"Tarefa com ID {tarefaAtualizada.ID_TAREFA} não encontrada.");
                }

                tarefaExistente.DS_TAREFA = tarefaAtualizada.DS_TAREFA;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar tarefa: {ex.Message}");
            }
        }

        public void DeletarTarefa(int id)
        {
            try
            {
                var tarefa = _tarefas.FirstOrDefault(x => x.ID_TAREFA == id);
                if (tarefa == null)
                {
                    throw new Exception($"Tarefa com ID {id} não encontrada.");
                }

                _tarefas.Remove(tarefa);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar tarefa: {ex.Message}");
            }
        }
    }
}
