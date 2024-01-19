Para correr o website:
- Dentro da pasta docs/: correr scripts de criacao, povoamento, procedures; (script de user não é preciso)
- Base de dados ligada
- Connection string no app/appsettings.json correta
- entra na pasta app e correr "dotnet watch"
- Se estiver a dar erros => usar "dotnet clean" e "dotnet restore" dentro das subpastas DataLayer, Classes e app (garantir que dependencias estao atualizadas)
