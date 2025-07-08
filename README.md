# Práctica 3: API REST de Fórmula 1 (UTN FRRO - Tecnicatura Universitaria en Programación)

## 🏁 Descripción del Proyecto

Este repositorio contiene el proyecto base para la **Práctica 3 de APIs REST** de la carrera **Tecnicatura Universitaria en Programación** de la **UTN Facultad Regional Rosario (FRRO)**.

El objetivo de este proyecto es simular una API para la gestión de datos de Fórmula 1, centrándose en las entidades `Circuito` y `Piloto`. El proyecto ya incluye la estructura básica, la configuración de Inyección de Dependencias (DI) con servicios en memoria, y la documentación automática con Swagger.

## 🎯 Objetivo de la Práctica

El principal objetivo de esta práctica es que los alumnos:

1.  **Comprendan y apliquen la Inyección de Dependencias (DI):** Utilizando servicios para la lógica de negocio y acceso a datos (en este caso, datos en memoria).
2.  **Implementen operaciones CRUD completas:** Desarrollando los endpoints `GET`, `POST`, `PUT`, `PATCH` y `DELETE` para las entidades `Circuito` y `Piloto`.
3.  **Diseñen una API RESTful:** Entendiendo cómo los verbos HTTP se mapean a las operaciones de negocio y cómo manejar las respuestas HTTP (códigos de estado).
4.  **Utilicen Swagger/OpenAPI:** Para documentar y probar la API de manera interactiva.
5.  **Refuercen conceptos de C# y .NET:** Aplicando validaciones de modelos y buenas prácticas de desarrollo backend.

## 🚀 Cómo Empezar

Sigue estos pasos para poner en marcha el proyecto y comenzar a trabajar:

1.  **Clonar el Repositorio:**
    ```bash
    git clone [URL_DE_TU_REPOSITORIO]
    cd F1ApiBase
    ```
    *(Reemplaza `[URL_DE_TU_REPOSITORIO]` con la URL real de tu repositorio en GitHub/GitLab/etc.)*

2.  **Abrir en tu IDE:**
    Abre la carpeta `F1ApiBase` en tu editor de código preferido (Visual Studio o Visual Studio Code).

3.  **Ejecutar la Aplicación:**
    Abre una terminal integrada en tu IDE (o una consola de comandos en la carpeta `F1ApiBase`) y ejecuta:
    ```bash
    dotnet run
    ```
    Esto compilará y ejecutará la API. Verás mensajes en la consola indicando las URLs donde la API está escuchando.

4.  **Acceder a Swagger UI:**
    Una vez que la aplicación esté corriendo, abre tu navegador web y navega a la URL de Swagger UI. Generalmente es:
    `https://localhost:7000` (o el puerto que te indique la consola, seguido de `/swagger`)

    Aquí podrás ver la documentación de la API y probar los endpoints a medida que los vayas implementando.

## 📝 Tareas a Realizar (Para los Alumnos)

Tu tarea principal es implementar la lógica de los endpoints en los controladores.

1.  Abre los archivos `Controllers/CircuitosController.cs` y `Controllers/PilotosController.cs`.
2.  Dentro de cada método marcado con `// TODO: Implementar...`, escribe el código necesario para realizar las operaciones CRUD (GET, POST, PUT, DELETE) utilizando los servicios inyectados (`_circuitoService` y `_pilotoService`).
3.  Asegúrate de manejar los diferentes códigos de estado HTTP (200 OK, 201 Created, 204 No Content, 400 Bad Request, 404 Not Found) según corresponda.
4.  Puedes usar las validaciones de modelos (`ModelState.IsValid`) que ya están configuradas.
