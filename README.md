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



