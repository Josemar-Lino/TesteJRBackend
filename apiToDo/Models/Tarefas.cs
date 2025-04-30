using apiToDo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Models
{
    public class Tarefas
    {
        public List<TarefaDTO> lstTarefas()
        {
            try
            {
                List<TarefaDTO> lstTarefas = new List<TarefaDTO>();

                lstTarefas.Add(new TarefaDTO
                {
                    ID_TAREFA = 1,
                    DS_TAREFA = "Fazer Compras"
                });

                lstTarefas.Add(new TarefaDTO
                {
                    ID_TAREFA = 2,
                    DS_TAREFA = "Fazer Atividad Faculdade"
                });

                lstTarefas.Add(new TarefaDTO
                {
                    ID_TAREFA = 3,
                    DS_TAREFA = "Subir Projeto de Teste no GitHub"
                });

                return new List<TarefaDTO>();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public void InserirTarefa(TarefaDTO Request)
        {
            try
            {
                List<TarefaDTO> lstResponse = lstTarefas();
                lstResponse.Add(Request);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void DeletarTarefa(int ID_TAREFA)
        {
            try
            {
                // Obtém a lista atual de tarefas
                List<TarefaDTO> lstResponse = lstTarefas();

                // Verifica se a tarefa existe na lista
                var Tarefa = lstResponse.FirstOrDefault(x => x.ID_TAREFA == ID_TAREFA);
                if (Tarefa == null)
                {
                    throw new Exception($"Tarefa com ID {ID_TAREFA} não encontrada.");
                }

                // Busca a tarefa novamente para garantir que ela existe
                TarefaDTO Tarefa2 = lstResponse.Where(x => x.ID_TAREFA == Tarefa.ID_TAREFA).FirstOrDefault();
                if (Tarefa2 == null)
                {
                    throw new Exception($"Erro ao localizar a tarefa {ID_TAREFA} para remoção.");
                }

                // Remove a tarefa da lista
                lstResponse.Remove(Tarefa2);
            }
            catch (Exception ex)
            {
                // Propaga a exceção com uma mensagem mais descritiva
                throw new Exception($"Erro ao deletar tarefa: {ex.Message}");
            }
        }
    }
}
