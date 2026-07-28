# EvaluacionItemTrabajo
Evaluacion practica

Aplicacion backend desarrollada en C# con ASP.NET CORE web API.

Permite registrar ítems de trabajo, asignarlos automáticamente a los usuarios disponibles.

## Proyectos

La solución contiene dos microservicios:

- GestionUsuario
- ItemTrabajo

El microservicio de usuarios permite consultar los usuarios activos.

El microservicio de ítems se encarga del registro, asignación, consulta y actualización de los ítems de trabajo.

## Tecnologías utilizadas

- Visual Studio 2022
- .NET 8
- ASP.NET Core Web API
- SQL Server LocalDB
- Dapper
- Stored Procedures
- Swagger

## Arquitectura

Estructura por capas:

- Controller: recibe las solicitudes de la API.
- Service: contiene las reglas y validaciones del sistema.
- Repository: realiza las consultas hacia la base de datos.
- Data: contiene la configuración para crear la conexión con SQL Server.
- Models y DTOs: representan los datos utilizados por la aplicación.

## Base de datos

Se utilizaron dos bases de datos locales:

- GestionUsuariosDb
- GestionItemsDb

Instancia Local

## Ejecucion

1. Abrir visual studio 2022
2. Ejecutar los scripts de la carpeta Database.
3. Ejecutar los proyectos al mismo tiempo.
4. Realizar las pruebas desde Swagger.

## Ejecucion 

- Swagger

Kevin Andres Cardenas Loachamin.