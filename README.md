# NTTData - AmbevDeveloperEvaluation

## Descrição
Um CRUD simples para gerenciar carrinhos de compras (cart sales) e produtos de uma loja virtual.

## Pré-requisitos
- .NET 8 SDK
- Banco de dados PostgreSQL

## Instalação
Passos para instalar e configurar o ambiente de desenvolvimento:

1. Clone o repositório;
2. Navegue até o diretório do projeto;
3. Restaure as dependências;

## Uso
Inicialmente você precisará configurar corretamente a string de conexão com o seu banco de dados no arquivo `appsettings.json`:
```json
{
  "ConnectionStrings": {
	"DefaultConnection": "Host=localhost;Port=5432;Database=nome_do_banco;Username=postgres;Password=postgres"
  }
}
```
Com o banco de dados configurado, você pode executar o projeto e as migrações serão aplicadas automaticamente.
A aplicação estará disponível em http://localhost:5119/swagger/index.html.

## Testes
Infelizmente devido a questões de tempo, não foi possível implementar testes automatizados.

## Observações
Alguns requisitos ainda não foram implementados, como por exemplo:
- paginação e ordenação de resultados e outros requisitos opcionais foram cortados por questões de tempo;
- regras de negócio mais complexas referente aos descontos ficaram obscuras quanto ao entendimento das mesmas;

Com uma nova conversa adoraria entrar em detalhes sobre o projeto e como poderíamos melhorar o mesmo.
