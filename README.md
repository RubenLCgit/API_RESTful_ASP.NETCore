# API_RESTful_ASP.NETCore

# ContosoPizzaApp

## Descripción

ContosoPizzaApp es un ejercicio de Microsoft para desarrollar una API RESTfull para una aplicación web diseñada para gestionar una pizzería virtual. Permite a los usuarios visualizar, añadir, actualizar y eliminar pizzas de la carta. Este proyecto demuestra la implementación de una arquitectura de N capas, el patrón repositorio, y la inyección de dependencias en ASP.NET Core.

## Enlace al ejercicio:

https://learn.microsoft.com/es-es/training/modules/build-web-api-aspnet-core/

## Tecnologías y Herramientas

- ASP.NET Core 5.0 o superior
- XUnit para pruebas unitarias

## Características

- API RESTful para la gestión de pizzas.
- Operaciones CRUD (Crear, Leer, Actualizar, Borrar) para pizzas.
- Uso del patrón repositorio para abstraer el acceso a datos.
- Inyección de dependencias para una mejor modularidad y testabilidad.

## Empezando

### Pre-requisitos

- .NET 5.0 SDK o superior
- Visual Studio 2019 o VS Code
- Postman o cualquier cliente HTTP para probar la API

### Instalación

1. Clone el repositorio en su máquina local usando `git clone https://github.com/RubenLCgit/API_RESTful_ASP.NETCore.git`
2. Abra la solución en Visual Studio o VS Code.
3. Restaure los paquetes NuGet ejecutando `dotnet restore`.
4. Inicie la aplicación ejecutando `dotnet run` en el directorio del proyecto.

### Pruebas

Para ejecutar las pruebas unitarias, use el comando `dotnet test` en el directorio de la solución.

## Uso

La aplicación expone varios endpoints para interactuar con la API de pizzas:

- `GET /pizza/`: Obtiene todas las pizzas.
- `GET /pizza/{id}`: Obtiene una pizza por su ID.
- `POST /pizza/`: Crea una nueva pizza.
- `PUT /pizza/{id}`: Actualiza una pizza existente.
- `DELETE /pizza/{id}`: Elimina una pizza.

Utilice Postman o cualquier cliente HTTP para probar estos endpoints.