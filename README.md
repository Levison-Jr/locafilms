# locafilms
Aplicação backend de uma locadora de filmes. Um dos meus lugares favoritos na infância.

## v1-standard

O CRUD básico das models do usuário e dos filmes.

Essa versão da aplicação contém o básico dos end-points, models, services e repositories.

Também já possui mapeamento feito com o AutoMapper e a conexão com o banco de dados feita.

No arquivo Contexts/AppDbContext.cs está a configuração de mapeamento das tabelas. Logo, aí está
as descrições dos relacionamentos entre as tabelas de usuário, movies e a tabela de junção (movieRentals).

Apesar dea configuração dos relacionamentos entre tabelas está feito, as controllers, services e repositories
existentes somente são os do usuário e dos movies. Não existe nenhuma interação entre eles até aqui por meio
da tabela de junção.
