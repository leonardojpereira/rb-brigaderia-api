API RB Brigaderia 🍫
<h2 align="center"> 📋 Descrição do Projeto </h2> <p> A API RB Brigaderia foi desenvolvida para atender às necessidades de gerenciamento de vendas, estoque e métricas de performance de uma brigaderia. Ela oferece funcionalidades completas para controle de usuários, autenticação JWT, movimentações de estoque, relatórios de vendas e métricas operacionais. O objetivo principal é centralizar e organizar as operações da RB Brigaderia em uma solução robusta e segura. </p>
🛠️ Feito com
<img align="center" alt="logo_visual_studio" height="40" width="50" src="https://raw.githubusercontent.com/devicons/devicon/master/icons/dotnetcore/dotnetcore-original.svg"> .NET 7 - Framework base para desenvolvimento da aplicação.
💻 Tecnologias Utilizadas
<img align="center" alt="logo_dotnet" height="40" width="50" src="https://raw.githubusercontent.com/devicons/devicon/master/icons/dotnetcore/dotnetcore-original.svg"> ASP.NET Core: Framework utilizado para criar APIs escaláveis e performáticas.
<img align="center" alt="logo_sqlserver" height="40" width="50" src="https://raw.githubusercontent.com/devicons/devicon/master/icons/microsoftsqlserver/microsoftsqlserver-plain.svg"> Entity Framework Core: ORM utilizado para gerenciar o acesso ao banco de dados.
JWT (JSON Web Token): Sistema de autenticação seguro para controle de acessos.
Swagger: Ferramenta para documentação interativa da API.
<img align="center" alt="logo_csharp" height="40" width="50" src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg"> C#: Linguagem principal para desenvolvimento de lógica e operações.
⚙️ Funcionalidades
Autenticação e Autorização:

Sistema de autenticação JWT para garantir segurança e controle de acesso.
Diferenciação de permissões entre usuários e administradores.
Gerenciamento de Vendas e Estoque:

Criação, leitura, atualização e exclusão (CRUD) de movimentações de estoque.
Controle completo de vendas e produtos.
Métricas e Relatórios:

Relatórios detalhados sobre vendas mensais, dias com maior lucro e meses com mais vendas.
Dados estatísticos para auxiliar na tomada de decisões.
Controle de Usuários:

Cadastro e autenticação de usuários.
Perfis de usuário com controle baseado em funções (roles).
:electric_plug: Instalação e Uso
Siga as instruções abaixo para instalar e executar o projeto em sua máquina:

Clone este repositório:

git clone https://github.com/seu-usuario/seu-repositorio.git
Certifique-se de ter o .NET SDK 7.0 ou superior instalado em sua máquina.
Configure o banco de dados (SQL Server) no arquivo appsettings.json com suas credenciais.
Execute o comando para restaurar as dependências:

dotnet restore
Atualize o banco de dados executando as migrações:

dotnet ef database update
Inicie o projeto:

dotnet run
Acesse o Swagger UI para interagir com os endpoints da API:

http://localhost:<porta>/swagger
🔐 Autenticação
A API utiliza o padrão JWT (JSON Web Token) para autenticação. Para acessar os endpoints protegidos, siga os passos:

Faça login utilizando o endpoint /api/auth/login com suas credenciais.
Receba um token JWT no response.
Insira o token no cabeçalho da requisição usando o formato:
makefile
Authorization: Bearer <seu-token-jwt>
:link: Deploy
A API está hospedada em um ambiente seguro para produção. URL do deploy (se configurado):

arduino
https://rbbrigaderiaapi.com
:memo: Documentação Interativa
O Swagger UI está disponível em:


http://localhost:<porta>/swagger
Utilize essa interface para explorar e testar os endpoints da API de forma simples e rápida.

:bar_chart: Principais Endpoints
Usuários
POST /api/auth/register: Cadastrar um novo usuário.
POST /api/auth/login: Autenticar um usuário e receber o token JWT.
Vendas
GET /api/v1/vendas: Listar todas as vendas realizadas.
POST /api/v1/vendas: Criar uma nova venda.
Estoque
GET /api/v1/estoque: Consultar movimentações de estoque.
PUT /api/v1/estoque/{id}: Atualizar uma movimentação de estoque.
Métricas
GET /api/v1/metrics/best-selling-day: Obter o dia com mais vendas.
GET /api/v1/metrics/max-profit-day: Obter o dia com maior lucro.
📊 Ferramentas de Métricas
A API fornece relatórios detalhados para análise de desempenho:

Dias com mais vendas e maior lucro.
Vendas mensais agrupadas.
Meses com maior volume de vendas.
⌨️ Desenvolvido por:
Leonardo Barbosa de Jesus Pereira
LinkedIn | Portfólio 😊

<h3 align="center">
:construction: PROJETO EM ANDAMENTO :construction:

</h3>
