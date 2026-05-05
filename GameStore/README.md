# 🎮 GameStore API - Arquitetura Monolítica

Bem-vindo à **API FIAP Game Store**! Uma aplicação web moderna e bem estruturada para gerenciar uma loja de jogos.

## 🚀 Quick Start

```bash
# 1. Abra o projeto
cd C:\Fonte\GameStore

# 2. Execute a aplicação
dotnet run --launch-profile http

# 3. Acesse o Swagger
# http://localhost:5277/swagger/index.html
```

## 📊 Estrutura Geral

```
┌─────────────────────────────────────────┐
│          CLIENTES (HTTP/REST)           │
└────────────┬────────────────────────────┘
             │
┌────────────▼────────────────────────────┐
│       CONTROLLERS (API Endpoints)       │
│  ├─ AuthController (Login)              │
│  ├─ UsersController (Usuários)          │
│  └─ GamesController (Jogos)             │
└────────────┬────────────────────────────┘
             │
┌────────────▼────────────────────────────┐
│    REPOSITORIES (Padrão Repository)     │
│  ├─ UsuarioRepository                   │
│  └─ JogoRepository                      │
└────────────┬────────────────────────────┘
             │
┌────────────▼────────────────────────────┐
│    ENTITY FRAMEWORK CORE (ORM)          │
│  └─ ApplicationDbContext                │
└────────────┬────────────────────────────┘
             │
┌────────────▼────────────────────────────┐
│    SQL SERVER (VIVOBOOKNATH)            │
│  └─ Database: fiapStore                 │
└─────────────────────────────────────────┘
```

## 🔑 Funcionalidades Principais

### ✅ Autenticação & Autorização
- Login com JWT Bearer Token
- Dois perfis: **Admin** e **User**
- Token com validade de 1 hora
- Swagger com suporte a teste de token

### ✅ Gerenciamento de Usuários
- ✓ Cadastro de usuários
- ✓ Validação de email (.com ou .com.br obrigatório)
- ✓ Validação de senha (8 caracteres, letras, números, especiais)
- ✓ Listagem, atualização e remoção

### ✅ Gerenciamento de Jogos
- ✓ Cadastro de jogos (apenas Admin)
- ✓ Listagem, busca por ID, atualização e remoção
- ✓ Campos: Título, Descrição, Preço, Categoria, Data de Lançamento

### ✅ Documentação
- Swagger UI com descrição completa
- Versão: v1
- Contato: Nathalie Harenza Pereira
- Exemplos de requisições no arquivo `GameStore.http`

### ✅ Tratamento de Erros
- Middleware global de erros
- Logs estruturados em JSON
- Respostas padronizadas

## 🛠️ Stack Tecnológico

| Tecnologia | Versão | Uso |
|------------|--------|-----|
| **C#** | 12 | Linguagem |
| **.NET** | 8.0 | Framework |
| **ASP.NET Core** | 8.0 | Web API |
| **Entity Framework Core** | 8.0 | ORM |
| **SQL Server** | 2019+ | Banco de Dados |
| **JWT** | - | Autenticação |
| **Swagger** | OpenAPI 3.0 | Documentação |

## 📝 Endpoints Disponíveis

### 🔐 Autenticação
```
POST   /api/auth/login              Realizar login
```

### 👥 Usuários
```
POST   /api/users                   Criar usuário
GET    /api/users                   Listar usuários
GET    /api/users/{id}              Obter usuário por ID
PUT    /api/users/{id}              Atualizar usuário
DELETE /api/users/{id}              Deletar usuário
```

### 🎮 Jogos
```
POST   /api/games                   Criar jogo (Admin)
GET    /api/games                   Listar jogos (Admin)
GET    /api/games/{id}              Obter jogo por ID (Admin)
PUT    /api/games/{id}              Atualizar jogo (Admin)
DELETE /api/games/{id}              Deletar jogo (Admin)
```

## 🧪 Testando os Endpoints

### 1. Faça Login
```bash
curl -X POST http://localhost:5277/api/auth/login \
  -H "Content-Type: application/json" \
  -d '{"usuario":"admin","senha":"admin"}'
```

### 2. Use o Token
```bash
curl -X GET http://localhost:5277/api/users \
  -H "Authorization: Bearer {seu_token_aqui}"
```

### 3. Ou use o Swagger UI
Acesse `http://localhost:5277/swagger/index.html` e clique em "Authorize" para inserir o token.

## 💾 Credenciais de Teste

| Perfil | Usuário | Senha | Acesso |
|--------|---------|-------|--------|
| Admin | admin | admin | ✅ Completo |
| User | user | User@123 | ❌ Limitado |


### Aplicar Migrations
```bash
# No Package Manager Console do Visual Studio
Update-Database

# Ou via CLI
dotnet ef database update
```

## 📂 Estrutura de Arquivos

```
GameStore/
├── Controllers/              # Endpoints da API
├── Entities/                # Modelos de domínio
├── Repositories/            # Padrão Repository
├── Data/                    # DbContext e Configurações
├── Middlewares/             # Tratamento de erros
├── Models/                  # DTOs
├── Migrations/              # Histórico de banco
├── Program.cs               # Configuração central
├── appsettings.json        # Variáveis de ambiente
└── GameStore.http          # Exemplos de requisições
```

## 👤 Autor

**Nathalie Harenza Pereira**  
📧 nathalie.harenzap@gmail.com  

## 📄 Licença

OpenAPI License

---

Desenvolvido com ❤️ para FIAP

