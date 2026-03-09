# Royal Games

Projeto desenvolvido em dupla para o curso técnico de Desenvolvimento de Sistemas.

O objetivo inicial do projeto foi desenvolver uma **API para gerenciamento de jogos**.  
Posteriormente, o projeto será expandido com um **frontend Next.js** que consumirá a API, com **deploy na Azure**.

---
## Roadmap do Projeto

- [x] Criar API de gerenciamento de jogos  
- [ ] Desenvolver frontend Next.js para consumir a API  
- [ ] Realizar deploy completo na Azure  

---

## Funcionalidades da API

A API permite gerenciar as seguintes entidades, com **CRUD completo** (Criar, Ler, Atualizar e Deletar) e todas as operações protegidas com autorização (`Authorize`):

- **Usuários**  
  - `GET` – listar usuários  
  - `POST` – adicionar novo usuário  
  - `PUT` – atualizar usuário existente  
  - `DELETE` – remover usuário  

- **Gêneros**  
  - `GET` – listar gêneros  
  - `POST` – adicionar novo gênero  
  - `PUT` – atualizar gênero existente  
  - `DELETE` – remover gênero  

- **Plataformas**  
  - `GET` – listar plataformas  
  - `POST` – adicionar nova plataforma  
  - `PUT` – atualizar plataforma existente  
  - `DELETE` – remover plataforma  

- **Jogos**  
  - `GET` – listar jogos  
  - `POST` – adicionar novo jogo  
  - `PUT` – atualizar jogo existente  
  - `DELETE` – remover jogo

- **Classificação**  
  - `GET` – listar Classificações indicativas
  - `POST` – adicionar Classificação indicativa
  - `PUT` – atualizar Classificação indicativa existente  
  - `DELETE` – remover Classificação indicativa
  <br>
---

## Tecnologias

### Backend
- ASP.NET Core  
- SQL Server

### Frontend
- Next.js

### Deploy / Hospedagem
- Microsoft Azure
---
## Como Executar o Projeto

### Backend
```bash
# Entre na pasta do Royal-Games
cd Royal-Games

# Execute o projeto
dotnet run
