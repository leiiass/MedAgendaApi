# MedAgendaApi
**MedAgendaApi** é uma API RESTful desenvolvida como parte do backend da aplicação MedAgenda. O projeto foi construído em **C#** com **.NET 8**, utilizando **Entity Framework Core (EF Core)** como ORM e adotando os princípios da **Onion Architecture** para promover desacoplamento e organização do código.
---

### 🎬 Video da apresentação do projeto
- [Apresentação do projeto](https://drive.google.com/file/d/1zCVifnTDqTuPjPHXvCwBrk5iSBmy432P/view?usp=sharing)

### 👩‍💻👨‍💻 Desenvolvedores do Grupo 13
> - FLAVIO RICARDO PRADO PASTROLIN
> - GUILHERME DE LIMA IRGANG
> - JAYANNE QUEIROZ MOURA
> - KARINE DIAS RAMALHO
> - LEIA SOARES DA SILVA MENDES
> - TIFFANY PAULINO DA SILVA
> - VICTOR DE SOUZA SANTOS

## 🧰 Tecnologias e Ferramentas

- **Linguagem:** C#
- **Framework:** .NET 8
- **ORM:** Entity Framework Core
- **Banco de Dados:** SQLite
- **Arquitetura:** Onion Architecture
- **Autenticação:** JWT (JSON Web Token)
- **Documentação de API:** Swagger

---

## 🗂 Estrutura do Projeto

A solução é composta por 4 camadas principais:
- **MedAgenda.Api**: Camada de apresentação e configuração da aplicação. Contém os controllers e arquivos de inicialização.
- **MedAgenda.Dominio**: Contém as entidades de domínio, interfaces e contratos.
- **MedAgenda.Infraestrutura**: Implementa o acesso ao banco de dados com EF Core, configurações de contexto, migrations e repositórios.
- **MedAgenda.Servicos**: Camada de aplicação com as regras de negócio e serviços utilizados pela API.
---
## 🔐 Autenticação

O projeto utiliza **JWT (JSON Web Token)** para autenticação e autorização dos usuários. As rotas protegidas exigem um token válido no cabeçalho da requisição.

---

## 🧪 Banco de Dados

Utilizamos o **SQLite**, um banco leve e embutido ideal para testes e aplicações pequenas.

- As migrations são gerenciadas com **Entity Framework Core**.
- Arquivos `.db`, `.db-shm` e `.db-wal` são gerados automaticamente ao rodar a aplicação.
  

---

## 🚀 Como Executar o Projeto Localmente

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Editor como Visual Studio, VS Code ou Rider

### Passos para rodar

```bash
# Clone o repositório
git clone https://github.com/seu-usuario/MedAgendaApi.git

# Acesse a pasta principal da API
cd MedAgendaApi/src/MedAgenda.Api

# Restaure os pacotes
dotnet restore

# Execute o projeto
dotnet run





