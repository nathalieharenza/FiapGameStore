# language: pt
Funcionalidade: Validação do Customer
  Como sistema
  Quero validar os dados de um cliente
  Para garantir que apenas dados válidos sejam cadastrados

  Esquema do Cenário: Construtor padrão gera Id único
    Dado que dois clientes são criados com o construtor padrão
    Então os Ids devem ser diferentes e não vazios
    Exemplos:
      |                id                  | nome  | email          | senha     |
      |1b0234f9-7453-4712-8b71-378ca9834609| João  | joao@email.com | Senha@123 |
      |2c0345f9-8564-4823-9c82-489db9845710| Maria | maria@email.com| Senha@456 |

  Esquema do Cenário: Construtor com parâmetros preenche propriedades
    Dado que um cliente é criado com nome "<nome>", email "<email>" e senha "<senha>"
    Então o cliente deve ter nome "<nome>", email "<email>" e senha "<senha>"
    Exemplos:
      | nome  | email          | senha     |
      | João  | joao@email.com | Senha@123 |

  Esquema do Cenário: Validar email válido
    Dado que um cliente possui o email "<email>"
    Quando o email for validado
    Então o resultado deve ser verdadeiro
    Exemplos:
      | email                  |
      | usuario@email.com      |
      | usuario@empresa.com.br |
      | USUARIO@EMAIL.COM      |

  Esquema do Cenário: Validar email inválido
    Dado que um cliente possui o email "<email>"
    Quando o email for validado
    Então o resultado deve ser falso
    Exemplos:
      | email               |
      |                     |
      | semArroba.com       |
      | @email.com          |
      | usuario@            |
      | usuario@email       |

  Esquema do Cenário: Validar senha válida
    Dado que um cliente possui a senha "<senha>"
    Quando a senha for validada
    Então o resultado deve ser verdadeiro
    Exemplos:
      | senha     |
      | Senha@123 |
      | Abc!1234  |
      | P@ssw0rd  |

  Esquema do Cenário: Validar senha inválida
    Dado que um cliente possui a senha "<senha>"
    Quando a senha for validada
    Então o resultado deve ser falso
    Exemplos:
      | senha        |
      |              |
      | curta@1      |
      | semNumero@   |
      | 12345678@    |
      | SemEspecial1 |

  Cenário: Validar todos os dados válidos
    Dado que um cliente é criado com nome "Maria", email "maria@email.com" e senha "Senha@123"
    Quando todos os dados forem validados
    Então o resultado deve ser verdadeiro

  Esquema do Cenário: Validar todos com dados inválidos
    Dado que um cliente é criado com nome "<nome>", email "<email>" e senha "<senha>"
    Quando todos os dados forem validados
    Então o resultado deve ser falso
    Exemplos:
      | nome  | email            | senha     |
      |       | maria@email.com  | Senha@123 |
      | Maria | emailinvalido    | Senha@123 |
      | Maria | maria@email.com  | fraca     |
