# Clean Architecture

Proyecto basado en la plantilla Clean Architecture.

## Pasos para correr el proyecto Backend

(No es necesario crear la base de datos de forma manual, el proyecto se encargara de crear base de datos y tablas de ser necesario)
1. Configurar variable de entorno DB_CONNECTION con el string de conexion de MYSQL usando el formato
server=NOMBRE_SERVIDOR;Database=person_db;Uid=NOMBRE_USUARIO;Pwd=CONTRASENA_USUARIO
2. ejecutar dotnet restore
3. posicionarse en la carpeta /src/Clean.Architecture.Web/
4. ejecutar dotnet run
5. entrar a la url http://localhost:57679/swagger/index.html para verificar los endpoints con Swagger
