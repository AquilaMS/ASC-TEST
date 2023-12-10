
![Spring Hunter](https://github.com/AquilaMS/ASC-TEST/assets/26696249/4c57e218-ef25-44bb-9a2c-319588ec649c)


# Teste Técnico ASC Solution

O sistema foi separado em 3 containers. Um para o banco de dados e outros para o backend e frontend. Mas, estão todos no mesmo Compose.
Foi usando Angular para os formulários de autenticação e SQL Server para o banco de dados.

Para executar:

    git clone https://github.com/AquilaMS/ASC-TEST.git 
-

    docker-compose up

A imagem da aplicação em Angular foi enviada para uma conta pessoal no Docker Hub para facilitar a comunicação entre as 3 partes. 

Respositório Angular: https://github.com/AquilaMS/asc-test-frontend

Imagem: https://hub.docker.com/repository/docker/aquilams/asctestfrontend/general

Restou alguns pendentes, como uso de variáveis de ambiente e um melhor feedback de resultado nos formulários.

Mas, dos diferenciais citados foi utilizado autenticação via token JWT. Onde o servidor é responsável por retornar um token e caso necessário, o valide para acessar algum tipo dado. Para testar essa situação há uma rota a mais para retornar o nome do usuário que enviou o token pelo header de Authorization.

As migrations do banco são aplicadas assim que o container for iniciado. Para visualização das inserções do bando usei o DBeaver. Para acessar direto pelo computador, basta usar o localhost com a porta padrão 1433.

Credenciais:
   
     usuário: sa
     senha: Ep2uU9ytumP1

Após o download e carregamento do compose as URLs de acesso são:
    
    frontend: localhost:4200
    api: localhost:8090

Resultados do front são exibidos no console.
