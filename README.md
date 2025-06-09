# 💧 FlowGuard

FlowGuard é um sistema completo de monitoramento de alagamentos baseado em IoT, com um backend em .NET e banco Oracle, além de um aplicativo mobile integrado. O sistema permite que cidadãos registrem ocorrências em tempo real e que regiões críticas sejam monitoradas por gestores públicos.

---

##  Sumário

- Integrantes
- Vídeos
-  Tecnologias Utilizadas
- nstruções de Execução e Testes
-  Rotas Disponíveis (via Swagger)
-  Diagrama da Solução
-  Exemplos de JSON para teste
-  Provas funcionamento
-  Considerações Finais e Impacto Social

---

## 👥 Integrantes

- **Iris Tavares Alves** - 557728 - 2TDSPM  
- **Taís Tavares Alves** - 557553 - 2TDSPM

---

## 🎥 Vídeos

> <a href="https://youtu.be/2FZtU9p_QFM?si=WXAlWfOYOdt-qaK5">Vídeo pitch</a> </br>
> <a href="https://youtu.be/V0hH6RgmKWQ?si=J6i1oNL5WEU-zqZ9">Vídeo demonstração</a>

---

## ⚙️ Tecnologias Utilizadas

| Tecnologia/Componente     | Função                                   |
|--------------------------|------------------------------------------|
| C# / ASP.NET Core 8      | Backend RESTful com API estruturada em camadas     |
| Oracle SQL      | Banco de dados relacional com modelagem 3FN        |
| Entity Framework |  migrations      |
| Swagger                 | Testes e documentação da API             |


---

## 🔎 Instruções de Execução e Testes

### 1. Clone o repositório
```bash
git clone https://github.com/Irissuu/csharp_gs.git
```

### 2. Configure a string de conexão no appsettings.json
```text
"ConnectionStrings": {
  "OracleDB": "User Id=SEU_USUARIO;Password=SUA_SENHA;Data Source=oracle.fiap.com.br:1521/orcl;"
}
```

### 3.  Instale os pacotes e Gere o banco de dados com Entity Framework Core
``` text
dotnet restore
dotnet ef migrations add Inicial
dotnet ef database update
```

### 4.Execute o projeto
```text
dotnet run
```

## 🔁 Rotas Disponíveis (via Swagger)


### 🔹 UsuarioController

| Método | Rota                | Descrição                      |
|--------|---------------------|-------------------------------|
| GET    | `/api/usuario`      | Lista todos os usuários       |
| GET    | `/api/usuario/{id}` | Busca um usuário por ID       |
| POST   | `/api/usuario`      | Cadastra um novo usuário      |
| PUT    | `/api/usuario/{id}` | Atualiza um usuário           |
| DELETE | `/api/usuario/{id}` | Remove um usuário             |



### 🔹 OcorrenciaController

| Método | Rota                   | Descrição                            |
|--------|------------------------|---------------------------------------|
| GET    | `/api/ocorrencia`      | Lista todas as ocorrências           |
| GET    | `/api/ocorrencia/{id}` | Busca uma ocorrência por ID          |
| POST   | `/api/ocorrencia`      | Cadastra uma nova ocorrência         |
| DELETE | `/api/ocorrencia/{id}` | Remove uma ocorrência                |



### 🔹 RegiaoController

| Método | Rota              | Descrição                      |
|--------|-------------------|-------------------------------|
| GET    | `/api/regiao`     | Lista todas as regiões        |
| GET    | `/api/regiao/{id}`| Busca uma região por ID       |
| POST   | `/api/regiao`     | Cadastra uma nova região      |

---

## 📑  Diagrama da Solução
![image](https://github.com/user-attachments/assets/5fcdfacd-3d66-4dc8-9687-7530dc9db014)


---

## 📄 Exemplos de JSON para teste 

### POST /api/usuario
```json
{
  "nome": "Maria Eduarda Silva",
  "cpf": 45879612348,
  "email": "maria@gmail.com",
  "senha": "chokito"
}
```
### PUT /api/usuario/{id}
```json
{
  "nome": "Maria Eduarda Silva",
  "email": "maria@gmail.com",
  "senha": "DORITOS"
}
```

### POST /api/regiao
```json
{
  "estado": "SP",
  "distrito": "Itaquera"
}

```

### POST /api/ocorrencia
```json
{
  "descricao": "Alagamento próximo à escola",
  "data": "04/06/2025",
  "usuarioId": 1
}
```
---

## ✅ Provas funcionamento




---

### Considerações Finais e Impacto Social
O FlowGuard é uma solução simples, eficaz e de baixo custo que ajuda a prevenir alagamentos com monitoramento em tempo real. Combinando sensores e conectividade, ele protege vidas e torna as cidades mais seguras.
