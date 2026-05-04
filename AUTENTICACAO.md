# GameStore API - Guia de Autenticação

## 🔐 Endpoints de Autenticação

Todos os endpoints de gerenciamento de jogos requerem um **token JWT com perfil Admin**.

### Login

**Endpoint:** `POST /api/auth/login`

#### Credenciais Disponíveis:

**Usuário Admin:** (Acesso total aos endpoints protegidos)
- Username: `admin`
- Senha: `admin`

**Usuário Comum:** (Sem acesso aos endpoints de jogos)
- Username: `user`
- Senha: `User@123`

#### Exemplo de Requisição:
```http
POST http://127.0.0.1:5277/api/auth/login
Content-Type: application/json

{
  "username": "admin",
  "senha": "admin"
}
```

#### Resposta de Sucesso (200 OK):
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "mensagem": "Login realizado com sucesso"
}
```

---

## 🎮 Endpoints de Jogos (Requerem Perfil Admin)

### 1. Cadastrar Novo Jogo
- **Método:** `POST`
- **Rota:** `/api/games`
- **URL:** `http://127.0.0.1:5277/api/games`
- **Autenticação:** ✅ Requerida (Admin)
- **Status esperado:** 201 Created

### 2. Listar Todos os Jogos
- **Método:** `GET`
- **Rota:** `/api/games`
- **URL:** `http://127.0.0.1:5277/api/games`
- **Autenticação:** ✅ Requerida (Admin)
- **Status esperado:** 200 OK

### 3. Consultar Jogo pelo ID
- **Método:** `GET`
- **Rota:** `/api/games/{id}`
- **URL:** `http://127.0.0.1:5277/api/games/{id}`
- **Autenticação:** ✅ Requerida (Admin)
- **Status esperado:** 200 OK

### 4. Atualizar Jogo
- **Método:** `PUT`
- **Rota:** `/api/games/{id}`
- **URL:** `http://127.0.0.1:5277/api/games/{id}`
- **Autenticação:** ✅ Requerida (Admin)
- **Status esperado:** 200 OK

### 5. Deletar Jogo
- **Método:** `DELETE`
- **Rota:** `/api/games/{id}`
- **URL:** `http://127.0.0.1:5277/api/games/{id}`
- **Autenticação:** ✅ Requerida (Admin)
- **Status esperado:** 200 OK

---

## 📝 Como Usar os Endpoints Protegidos

### Passo 1: Obter o Token
Faça uma requisição POST ao endpoint de login:
```http
POST http://127.0.0.1:5277/api/auth/login
Content-Type: application/json

{
  "username": "admin",
  "senha": "admin"
}
```

### Passo 2: Copiar o Token
Copie o valor do campo `token` da resposta.

### Passo 3: Usar o Token nos Headers
Adicione o token ao header `Authorization` com o prefixo `Bearer`:
```http
Authorization: Bearer <seu_token_aqui>
```

### Exemplo Completo:
```http
POST http://127.0.0.1:5277/api/games
Content-Type: application/json
Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...

{
  "titulo": "Elden Ring",
  "descricao": "RPG de ação desenvolvido pela FromSoftware",
  "preco": 249.90,
  "categoria": "RPG",
  "dataLancamento": "2022-02-25"
}
```

---

## ⚠️ Erros Comuns

### 401 Unauthorized
- **Causa:** Token ausente ou inválido
- **Solução:** Faça login novamente e use o novo token

### 403 Forbidden
- **Causa:** Usuário não tem perfil Admin
- **Solução:** Use as credenciais de admin (`username: admin`)

### 400 Bad Request
- **Causa:** Dados do jogo inválidos
- **Solução:** Verifique se todos os campos obrigatórios foram preenchidos

### SSL/TLS Error (NotSslRecordException)
- **Causa:** Tentativa de conectar via HTTPS em porta HTTP (ou vice-versa)
- **Solução:** Use `http://127.0.0.1:5277` para desenvolvimento com HTTP

---

## 🧪 Testando com Visual Studio ou Rider

Use o arquivo `GameStore.http` para testar os endpoints:
1. Abra o arquivo `GameStore.http`
2. Execute o endpoint de login (1-2)
3. Copie o token da resposta
4. Substitua `@adminToken` nas variáveis ou no campo `Authorization` dos outros endpoints
5. Execute os endpoints desejados

---

## 🔑 Configuração de Segurança

A configuração JWT está em `appsettings.json`:

```json
"Jwt": {
  "Key": "Simba123@",
  "Issuer": "GameStore"
}
```

⚠️ **Em produção**, altere a chave secreta e armazene-a de forma segura (ex: Azure Key Vault).

---

## 📚 Informações Adicionais

- **Token Expiration:** 1 hora
- **Issuer:** GameStore
- **Audience:** GameStoreAPI
- **Algoritmo:** HMAC SHA256
- **Porta (HTTP):** 5277 (apenas para testes sem SSL)
- **Porta (HTTPS):** 7202 (recomendado para desenvolvimento)


