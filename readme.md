## INSTRUÇÕES PARA O TESTE TÉCNICO

- Crie um fork deste projeto (https://github.com/CAPYS-IT/TesteJRBackend).
  É preciso estar logado na sua conta Github;
- Quando você começar, faça um commit vazio com a mensagem "Iniciando o teste de tecnologia" e quando terminar, faça o commit com uma mensagem "Finalizado o teste de tecnologia";
- Commit após cada ciclo de refatoração pelo menos;
- Não use branches;
- Você deve prover evidências suficientes de que sua solução está completa indicando, no mínimo, que ela funciona;
- Não há restrição quanto ao uso de bibliotecas de apoio;
- No final envie para o RH o link do seu projeto.
- Uso do Visual Studio 2022

## O TESTE

- Implementar o metodo lstTarefas da classe Tarefas na Tarefascontroller/lstTarefas e retorna a lista de tarefas. **CODE** 200.
- Implementar o metodo InserirTarefa da classe Tarefas na Tarefascontroller/InserirTarefas e retorna a lista de tarefas. **CODE** 200.
- Implementar o metodo DeletarTarefa da classe Tarefas na Tarefascontroller/DeleteTask e retorna a lista de tarefas. **CODE** 200.

---

- Descreva oque esta acontecendo com comentarios em cada linha de codigo do metodo DeletarTarefa da classe Tarefas.

- Faça o tratamento de erro do metodo DeletarTarefa da classe Tarefas. <br/> Parametros:
- O usuario esta tentando deletar a tarefa de codigo 1458..

---

## BÔNUS

- Efetuar tratamento das classes e Controllers com boas praticas seguindo os padrões REST.
- Criar Metodo de Atualizar um item da lista, passando uma objeto e retornando a lista atualizada.
- Criar metodo para pegar um Item da Lista passando um ID e retornando o Objeto da Lista.

---

## PONTOS QUE SERÃO AVALIADOS

- Boas práticas;
- Estrutura de Codigo.

## DOCUMENTAÇÃO DA API

### Endpoints

A API está disponível em:
- HTTPS: https://localhost:5001
- HTTP: http://localhost:5000

A documentação interativa (Swagger) está disponível em:
- https://localhost:5001/swagger
- http://localhost:5000/swagger

### Lista de Endpoints

#### 1. Listar Todas as Tarefas
- **Método**: GET
- **URL**: `/api/tarefas`
- **Descrição**: Retorna a lista completa de tarefas
- **Resposta de Sucesso**: 
  ```json
  [
    {
      "id_TAREFA": 1,
      "ds_TAREFA": "Fazer Compras"
    },
    {
      "id_TAREFA": 2,
      "ds_TAREFA": "Fazer Atividade Faculdade"
    }
  ]
  ```

#### 2. Obter Tarefa por ID
- **Método**: GET
- **URL**: `/api/tarefas/{id}`
- **Parâmetros**: 
  - `id` (int): ID da tarefa
- **Resposta de Sucesso**:
  ```json
  {
    "id_TAREFA": 1,
    "ds_TAREFA": "Fazer Compras"
  }
  ```

#### 3. Criar Nova Tarefa
- **Método**: POST
- **URL**: `/api/tarefas`
- **Corpo da Requisição**:
  ```json
  {
    "id_TAREFA": 4,
    "ds_TAREFA": "Nova Tarefa"
  }
  ```
- **Resposta de Sucesso**: Retorna a lista atualizada de tarefas

#### 4. Atualizar Tarefa
- **Método**: PUT
- **URL**: `/api/tarefas`
- **Corpo da Requisição**:
  ```json
  {
    "id_TAREFA": 1,
    "ds_TAREFA": "Tarefa Atualizada"
  }
  ```
- **Resposta de Sucesso**: Retorna a lista atualizada de tarefas

#### 5. Deletar Tarefa
- **Método**: DELETE
- **URL**: `/api/tarefas/{id}`
- **Parâmetros**:
  - `id` (int): ID da tarefa a ser deletada
- **Resposta de Sucesso**: Retorna a lista atualizada de tarefas

### Códigos de Resposta

- **200 OK**: Requisição bem-sucedida
- **400 Bad Request**: Erro na requisição (dados inválidos, tarefa não encontrada, etc.)
- **404 Not Found**: Recurso não encontrado
- **500 Internal Server Error**: Erro interno do servidor

### Exemplo de Uso

1. Listar todas as tarefas:
```bash
curl -X GET https://localhost:5001/api/tarefas
```

2. Obter uma tarefa específica:
```bash
curl -X GET https://localhost:5001/api/tarefas/1
```

3. Criar uma nova tarefa:
```bash
curl -X POST https://localhost:5001/api/tarefas \
  -H "Content-Type: application/json" \
  -d '{"id_TAREFA": 4, "ds_TAREFA": "Nova Tarefa"}'
```

4. Atualizar uma tarefa:
```bash
curl -X PUT https://localhost:5001/api/tarefas \
  -H "Content-Type: application/json" \
  -d '{"id_TAREFA": 1, "ds_TAREFA": "Tarefa Atualizada"}'
```

5. Deletar uma tarefa:
```bash
curl -X DELETE https://localhost:5001/api/tarefas/1
```

### Observações

- Todos os endpoints retornam a lista atualizada de tarefas após a operação
- A API está configurada com CORS para permitir requisições de qualquer origem
- A documentação Swagger está disponível para facilitar o teste dos endpoints

