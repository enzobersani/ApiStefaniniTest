
# ApiStefaniniTest

## Descrição

A API foi desenvolvida em .NET 8.0 utilizando o padrão DDD juntamente com MediatR, e utiliza um banco de dados SQL Server rodando em um container. O projeto inclui CRUD para Produtos e Pedidos, com três tabelas principais: Produto, Pedido e ItensPedido. A tabela ItensPedido vincula produtos a pedidos.

## Instalação

1. Clone o repositório:
   ```bash
   git clone https://github.com/usuario/repo.git
2. Navegue até o diretório do projeto e execute na opção IIS Express.
3. Verifique os endpoints disponíveis no Swagger da aplicação.

# Requisitos
  .NET 8.0
   SQL Server (em container ou local)

O projeto possui controle de entrada de dados para os commands e queries. Não deixando informar dados inválidos...

## Regras da Aplicação

Exclusão de Pedido: Não é possível excluir um pedido que contém itens. Todos os itens devem ser excluídos antes de excluir o pedido.
Endpoint /pedido: É um UpSert. Quando um ID não é informado, um novo registro é criado com os itens fornecidos. Se um ID é informado, novos itens são adicionados ao pedido existente, validando a existência do pedido.
