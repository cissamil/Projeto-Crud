# Crud de Categoria

Aplicação Windows Forms em camadas (.NET 10) para gerenciar categorias (listar, buscar, inserir, editar e excluir). Utiliza ADO.NET com procedures armazenadas para acesso a dados.

Pré-requisitos
--------------
- .NET 10 SDK instalado
- Visual Studio 2026 (ou `dotnet` CLI)
- SQL Server (ou compatível) com as procedures e tabela necessárias
- Ajustar a string de conexão em `CamadaDados.Conexao.Cn`

Banco de dados
--------------
São esperadas as procedures (ajuste nomes conforme seu banco):
- `SP_MOSTRAR_CATEGORIA`
- `SP_INSERIR_CATEGORIA`
- `SP_EDITAR_CATEGORIA`
- `SP_DELETE_CATEGORIA`
- `SP_BUSCAR_NOME`

Exemplo simples de procedure `SP_MOSTRAR_CATEGORIA` (ajuste conforme seu esquema):

```sql
CREATE PROCEDURE SP_MOSTRAR_CATEGORIA
AS
BEGIN
    SELECT Idcategoria, Nome, Descricao FROM Categoria;
END
```

Como rodar
---------
1. Atualize a string de conexão em `CamadaDados.Conexao.Cn` apontando para o seu banco de dados.
2. Certifique-se de que a tabela `Categoria` e as procedures existam.
3. No Visual Studio 2026: abra a solução e execute o projeto de apresentação (defina-o como startup).
   Ou com o CLI:
   - Construir: `dotnet build`
   - Executar: `dotnet run --project ./CamadaApresentacao1/CamadaApresentacao1.csproj`

Observações
----------
- Evite suprimir exceções em `DCategoria.Mostrar` para não mascarar falhas de acesso a dados.
- Use `using` para conexões/commands e registre erros para facilitar diagnóstico.
- Recomenda-se esconder colunas do `DataGridView` por nome (ou no evento `DataBindingComplete`) em vez de usar índices fixos.