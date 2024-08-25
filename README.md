
#ApiStefaniniTest

##Api criada para o desafio da empresa Stefanini.

A Api desenvolvida, foi feita em .NET 8.0 utilizando padrão DDD jutamente com mediatr, banco de dados SqlServer rodando em um container. Basicamente foi desenvolvido um Crud de Produto e Crud de Pedidos.
Foram criadas 3 tabelas: Produto, Pedido e ItensPedido, onde a ItensPedido tem a função vincular os produtos juntamente com o pedido.

## Instalação

Deve-se realizar o clone do projeto, rodar ele na opção IIS Express.
Foram desenvolvidos os endpoints que estão listados no swagger da aplicação.

O projeto possui controle de entrada de dados para os commands e queries. Não deixando informar dados inválidos...

## Algumas regras da aplicação

Para os pedidos, não será possível realizar a exclusão de um pedido caso ele tenha algum item... dessa forma deverá excluir todos os itens do pedido para depois excluir o pedido em si.
EndPoint /pedido, é um UpSert, então quando não informado um Id será gerado um novo registro jutamente com os itens informados... caso informe um id será entendido que quer realizar a inclusão de novos itens no pedido, dessa forma será valido a existencia desse pedido.
