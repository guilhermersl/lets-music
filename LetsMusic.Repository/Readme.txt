
1 - Criar um database com nome LetsMusicDB

2 - Atualizar a connectionString em LetsMusic.Api > appsettings.json

3 - Via Tools > Nuget Package Manager > Package Manager Console
	A - Para instalar as ferramentas para criar migrations e atualizar a base de dados:
	 > Install-Package Microsoft.EntityFrameworkCore.Tools

	B - Para criar/atualizar as migrations:
	 > Add-Migration NomeDaMigration

	C - Para atualizar a base de dados (aplicar as migrations):
	 > Update-Database
