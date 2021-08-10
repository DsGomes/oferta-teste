Decidi realizar uma arquitetura de 3 camadas mais simples e limpa, devido ao prazo de entrega não ser grande e o sistema não exigir uma complexidade alta.

Criei alguns testes de unidade utilizando Xunit, porém haveria inúmeros novos testes caso o tempo para desenvolvimento fosse maior.

Para rodar o projeto back-end: dotnet run --project "oferta-api/src/oferta-api/oferta-api.csproj"

Para acessar a documentação da API (swagger), acessar: https://localhost:5001/swagger

Para autenticação da API, utilizei JWT(Json Web Token).

{ "nome": "OfertaSystem", "email": "oferta@wechip.com.br", "role": "Sistema" }

Para rodar o projeto front, vá até a pasta oferta-front e execute o comando:

npm run start 
O projeto ficará acessível em: http://localhost:4200

Continuando o projeto, adicionaria mais tratamento de erros.
