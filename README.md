# CRUD de Categorias em C# (Arquitetura em Camadas)

Aplicação **Windows Forms (.NET 10)** que gerencia categorias de produtos de um sistema comercial (*SysComercio*): **listar, buscar, inserir, editar e excluir**. O acesso ao banco SQL Server é feito por **ADO.NET** com **stored procedures**.

> **CRUD** = *Create, Read, Update, Delete* (criar, ler, atualizar e excluir), as 4 operações básicas de qualquer cadastro.

---

## 📍 Contexto

Projeto de estudo desenvolvido durante minha formação em **Análise e Desenvolvimento de Sistemas**, para praticar como sistemas comerciais reais são organizados por dentro. O cadastro escolhido foi o de **categorias**, base para cadastros maiores como produtos e clientes.

## ❗ Problema

Em projetos iniciantes é comum colocar **tudo dentro da tela**: o botão "Salvar" abre a conexão, monta o SQL e mostra a mensagem, tudo no mesmo lugar. Isso causa três problemas:

- **Difícil de manter:** mudar o banco obriga a mexer em todas as telas.
- **Código repetido:** a mesma lógica aparece em vários formulários.
- **Risco de segurança:** SQL montado concatenando texto abre espaço para *SQL Injection* (injeção de comandos maliciosos pelo campo de texto).

## 🛠️ Solução (o que e como fiz)

Dividi o sistema em **3 camadas**, cada uma com uma única responsabilidade:

```
[ Tela ]  ──▶  [ Negócio ]  ──▶  [ Dados ]  ──▶  SQL Server
frmCategoria    NCategoria       DCategoria      Stored Procedures
```

| Camada | Classe | Responsabilidade |
|---|---|---|
| **Apresentação** | `frmCategoria` | Mostra a tela e recebe o que o usuário digita |
| **Negócio** | `NCategoria` | Recebe o pedido da tela e repassa para os dados (é onde ficam as regras) |
| **Dados** | `DCategoria` + `Conexao` | Conecta no banco e executa as procedures |

**Analogia:** é como um restaurante. O **garçom** (tela) anota o pedido, o **gerente** (negócio) confere se está tudo certo e a **cozinha** (dados) prepara. O cliente nunca entra na cozinha.

**Exemplo do fluxo ao inserir uma categoria:**

```csharp
// Tela chama o Negócio
NCategoria.Inserir("Bebidas", "Refrigerantes e sucos");

// Negócio monta o objeto e chama os Dados
obj.Inserir(obj);

// Dados executa a procedure com parâmetros (sem concatenar texto)
SqlCmd.CommandText = "SP_INSERIR_CATEGORIA";
SqlCmd.Parameters.Add(ParNome);
```

**Ferramentas:** C#, .NET 10, Windows Forms, ADO.NET (`Microsoft.Data.SqlClient`), SQL Server e stored procedures.

## 📊 Resultado (Antes × Depois)

| Antes (tudo na tela) | Depois (em camadas) |
|---|---|
| SQL espalhado pelos formulários | Todo acesso ao banco concentrado em `DCategoria` |
| Mudar o banco = mexer em todas as telas | Mudar o banco = mexer só na camada de dados |
| SQL concatenado, vulnerável a *SQL Injection* | Stored procedures com parâmetros tipados |
| Lógica repetida | Cada operação escrita uma única vez e reaproveitada |

---

## ▶️ Como rodar

1. Crie no SQL Server o banco `dbcomercio` com a tabela `Categoria` e as procedures:
   `SP_MOSTRAR_CATEGORIA`, `SP_INSERIR_CATEGORIA`, `SP_EDITAR_CATEGORIA`, `SP_DELETE_CATEGORIA` e `SP_BUSCAR_NOME`.
2. Ajuste a string de conexão em `CamadaDados/Conexao.cs`.
3. Abra a solução no Visual Studio e execute o projeto.
