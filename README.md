#Catálogo de Jogos

Este projeto faz parte do bootcampo de C# da GFT realizado em parceria com a Digital Innovation One.


##Este projeto foi desenvolvido no Linux(Ubuntu), utilizando o VS CODE

##Microsoft Sql Server

Como banco de dados, foi utilizado o SQL server versão "Desenvolvedor"

1- Para instalação do SQL Server, utilizei este tutorial:
https://docs.microsoft.com/en-us/sql/linux/sql-server-linux-setup?view=sql-server-ver15#uninstall

2- Após instalação, foi necessário habilitar o agente do SQL Server, utilizei o seguinte comando no terminal:
/opt/mssql/bin/mssql-conf set sqlagent.enabled true

3- Foi necessário setar o tipo de collation usei o comando:
/opt/mssql/bin/mssql-conf set-collation
Collation: Latin1_General_CI_AI

4- utilizei a porta e o usuário padrão para conexão com o banco
Server=localhost,1433;User Id=SA;Password="senha configurada no momento de instalação do SQL Server";

5- Utilizei a extensão "SQL Server (mssql)" do VS Code para conseguir acessar o banco de dados diretamente pelo VS Code.
Foram utilizados as informações decritas no item 4.


##Criação do Banco de dados em si
Utilizando a extensão do vs code, fiz a criação um novo banco de dados utilizando os seguintes comendos:
  
  CREATE DATABASE Jogo;
  
  USE JOGO;
  
  CREATE LOGIN NewAdminName WITH PASSWORD = 'SenhaApi123';
  
  IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'NewAdminName')
  BEGIN
    CREATE USER [NewAdminName] FOR LOGIN [NewAdminName]
    EXEC sp_addrolemember N'db_owner', N'NewAdminName'
  END;
  
  CREATE table Jogos 
  (Id UNIQUEIDENTIFIER PRIMARY KEY default NEWID(), Nome varchar(50), Produtora varchar(50), 
  Preco float(53))
  
Inseri um registro de testes
  
  insert into Jogos values ('3fa85f64-5717-4562-b3fc-2c963f66afa6', 'JogoJogo', 'MinhaProdutora', 300.11)
  
