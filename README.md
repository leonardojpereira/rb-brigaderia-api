
# API RB Brigaderia 🍫

---

## 📋 Descrição do Projeto

A API RB Brigaderia foi desenvolvida para atender às necessidades de gerenciamento de vendas, estoque e métricas de performance de uma brigaderia. Ela oferece funcionalidades completas para controle de usuários, autenticação JWT, movimentações de estoque, relatórios de vendas e métricas operacionais. O objetivo principal é centralizar e organizar as operações da RB Brigaderia em uma solução robusta e segura.

---

## 🛠️ Feito com

- <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/dotnetcore/dotnetcore-original.svg" alt="logo_visual_studio" width="30"/> **.NET 8**: Framework base para desenvolvimento da aplicação.

---

## 💻 Tecnologias Utilizadas

- <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/dotnetcore/dotnetcore-original.svg" alt="logo_dotnet" width="30"/> **ASP.NET Core**: Framework utilizado para criar APIs escaláveis e performáticas.
- <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/microsoftsqlserver/microsoftsqlserver-plain.svg" alt="logo_sqlserver" width="30"/> **Entity Framework Core**: ORM utilizado para gerenciar o acesso ao banco de dados.
- **JWT (JSON Web Token)**: Sistema de autenticação seguro para controle de acessos.
- **Swagger**: Ferramenta para documentação interativa da API.
- <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg" alt="logo_csharp" width="30"/> **C#**: Linguagem principal para desenvolvimento de lógica e operações.

---

## ⚙️ Funcionalidades

### Autenticação e Autorização
- Sistema de autenticação JWT para garantir segurança e controle de acesso.
- Diferenciação de permissões entre usuários e administradores.

### Gerenciamento de Vendas e Estoque
- Criação, leitura, atualização e exclusão (CRUD) de movimentações de estoque.
- Controle completo de vendas e produtos.

### Métricas e Relatórios
- Relatórios detalhados sobre vendas mensais, dias com maior lucro e meses com mais vendas.
- Dados estatísticos para auxiliar na tomada de decisões.

### Controle de Usuários
- Cadastro e autenticação de usuários.
- Perfis de usuário com controle baseado em funções (roles).

---

## :electric_plug: Instalação e Uso

Siga as instruções abaixo para instalar e executar o projeto em sua máquina:

1. Clone este repositório:
   ```
   git clone https://github.com/seu-usuario/seu-repositorio.git
   ```

2. Certifique-se de ter o .NET SDK 7.0 ou superior instalado em sua máquina.

3. Configure o banco de dados (SQL Server) no arquivo `appsettings.json` com suas credenciais.

4. Execute o comando para restaurar as dependências:
   ```
   dotnet restore
   ```

5. Atualize o banco de dados executando as migrações:
   ```
   dotnet ef database update
   ```

6. Inicie o projeto:
   ```
   dotnet run
   ```

7. Acesse o Swagger UI para interagir com os endpoints da API:
   ```
   http://localhost:<porta>/swagger
   ```

---

## 🔐 Autenticação

A API utiliza o padrão **JWT (JSON Web Token)** para autenticação. Para acessar os endpoints protegidos, siga os passos:

1. Faça login utilizando o endpoint `/api/auth/login` com suas credenciais.
2. Receba um token JWT no response.
3. Insira o token no cabeçalho da requisição usando o formato:
   ```
   Authorization: Bearer <seu-token-jwt>
   ```

---

## :memo: Documentação Interativa

O Swagger UI está disponível em:
```
http://localhost:<porta>/swagger
```

Utilize essa interface para explorar e testar os endpoints da API de forma simples e rápida.

---

## :bar_chart: Principais Endpoints

### Usuários
- `POST /api/auth/register`: Cadastrar um novo usuário.
- `POST /api/auth/login`: Autenticar um usuário e receber o token JWT.

### Vendas
- `GET /api/v1/vendas`: Listar todas as vendas realizadas.
- `POST /api/v1/vendas`: Criar uma nova venda.

### Estoque
- `GET /api/v1/estoque`: Consultar movimentações de estoque.
- `PUT /api/v1/estoque/{id}`: Atualizar uma movimentação de estoque.

### Métricas
- `GET /api/v1/metrics/best-selling-day`: Obter o dia com mais vendas.
- `GET /api/v1/metrics/max-profit-day`: Obter o dia com maior lucro.

---

## 📊 Ferramentas de Métricas

A API fornece relatórios detalhados para análise de desempenho:
- Dias com mais vendas e maior lucro.
- Vendas mensais agrupadas.
- Meses com maior volume de vendas.

---

## ⌨️ Desenvolvido por

**Leonardo Barbosa de Jesus Pereira**  
[LinkedIn](https://www.linkedin.com/in/leonardojpereira) | [Portfólio](https://leonardobarbosaportfolio.netlify.app/) 😊

---

### :construction: PROJETO FINALIZADO :construction:
