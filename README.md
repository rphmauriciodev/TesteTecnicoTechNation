# Descrição
Este projeto é um teste técnico desenvolvido, especialmente, para avaliar as suas 
habilidades como desenvolvedor fullstack. Para isso, você deve usar no frontend HTML, 
CSS, JS, jQuery, Bootstrap e biblioteca para criação de gráficos. E para o backend C# com a 
versão LTS mais recente do .Net e SQL Server. 
A proposta é a criação de uma tela do sistema financeiro de uma empresa com os 
dados das notas fiscais emitidas no ano passado (2023) e um dashboard. Essa ferramenta 
será utilizada pelo pessoal responsável pelo financeiro para manter o controle das notas e 
saber os principais indicadores.

# Tecnologias utilizadas
- .NET 8.0
- SQL SERVER
- jQuery 3.7.1
- Razor
- Dapper ORM
- Docker
- HTML, CSS, JS

# Como iniciar
- Acessar o local no repositório
- Utilizar o comando `docker-compose up -d`
- Conectar no SQL-SERVER criado pelo container utilizando a ConnectionString = `Server=database,1433;User ID=sa;Password=YourStrong@Passw0rd;Trusted_Connection=False;TrustServerCertificate=True;`
- Utilizar o script em `./SQL/unecontDB.sql` para criação e povoamento do banco `unecontDB`

# Considerações importantes
- Pensando em um sistema escalável foi utilizado o Dapper ORM para mapeamento do banco de dados por ser mais performático.
- As lógicas de consultas mais complexas estão armazenadas no banco em TVFs (Table-valued functions).
- A arquitetura do sistema foi desenvolvida visando os conceitos de CleanArchitecture, SOLID, DDD e CleanCode.
