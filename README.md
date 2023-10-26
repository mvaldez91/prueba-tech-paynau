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

## Pasos para correr el proyecto frontend
1. posicionarse en la ruta /frontend/
2. asegurarse de contar con Node JS instalado (el proyecto fue creado con Node 20)
3. correr npm install
4. crear el archivo .env.local con la variable de entorno VITE_API_URL=http://localhost:57678
5. correr vite

