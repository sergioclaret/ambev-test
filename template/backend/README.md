# Ambev Developer Evaluation

## Requisitos
- Docker e Docker Compose instalados

## Como rodar o projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/sergioclaret/ambev-test
   cd ambev-test/template/backend
   ```

2. Suba os containers:
   ```bash
   docker-compose up -d
   ```

   Isso vai criar:
   - **API** rodando em `http://localhost:8082` e `https://localhost:8083`.
	- Para acessar a documentação Swagger, acesse em `https://localhost:8083/swagger`. É possível testar a API e visualizar os endpoints disponíveis.
   - **Postgres** na porta `5433` (`5432` dentro do container)
   - **MongoDB** na porta `27017`
   - **Redis** na porta `6379`

   Além disso, as Migrations pendentes serão executadas de forma automática no banco de dados informado no appsettings ao subir a aplicação.
   Esse processo é responsável por manter a estrutura do banco de dados atualizada conforme as alterações feitas no código.

3. Execute a API localmente (caso queira rodar sem Docker):
   ```bash
   cd src/Ambev.DeveloperEvaluation.WebApi
   dotnet run
   ```

## Testes
Para rodar os testes:
```bash
dotnet test .\tests\Ambev.DeveloperEvaluation.Unit\Ambev.DeveloperEvaluation.Unit.csproj
```

---

## Acessos úteis
- API: [http://localhost:8082/swagger](http://localhost:8083/swagger)  
- Banco Postgres: `developer_evaluation` (user: `developer`, senha: `ev@luAt10n`)  
- MongoDB: user `developer`, senha `ev@luAt10n`  
- Redis: senha `ev@luAt10n`  
