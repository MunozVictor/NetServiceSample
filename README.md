# Consideraciones y Propuestas de Mejora

## 1. Decisiones Técnicas

### .NET 8 como Plataforma de Desarrollo

Se ha elegido **.NET 8** como la versión principal de desarrollo debido a que es una versión **LTS (Long-Term Support)**, lo que garantiza soporte extendido, estabilidad y actualizaciones de seguridad a largo plazo.

### Estructura del Proyecto

Se ha diseñado una estructura modular y escalable de proyectos con el objetivo de garantizar **orden y coherencia** en el desarrollo. Esta estructura permite la evolución del sistema sin comprometer su mantenibilidad.

Ejemplo de estructura utilizada:

- **WineCorp.Service** (Capa de presentación / API)
- **WineCorp.Application** (Servicios de aplicación y lógica de negocio)
- **WineCorp.Infrastructure** (Acceso a datos y configuración de Entity Framework)
- **WineCorp.Domain** (Modelos de dominio y entidades)
- **WineCorp.Migrations** (Manejo de migraciones de la base de datos)
- **WineCorp.Tests** (Proyecto de pruebas unitarias e integración)

### Entity Framework como ORM

Se ha utilizado **Entity Framework Core** para la gestión de la base de datos, facilitando el manejo de migraciones, la abstracción del acceso a datos y la optimización de consultas mediante LINQ.

## 2. Puntos de Mejora

### Modelado de Base de Datos

- Actualmente, las **claves primarias** son enteros autoincrementales. Se recomienda utilizar **GUIDs autogenerados** para mejorar la seguridad y la unicidad en entornos distribuidos.
- **Relaciones entre entidades**: Se deben revisar las configuraciones de restricciones y eliminaciones en cascada para evitar inconsistencias en los datos.
- Uso de **propiedades de navegación** en los modelos para mejorar la fluidez de las consultas y la mantenibilidad del código.

### Mappeos de Entidades y Servicios de Aplicación

- Actualmente, los **mapeos de entidades** y la capa de **servicios de aplicación** no han sido necesarios.
- Sin embargo, si en el futuro se requiere **integración con otros sistemas** o se añade **lógica de negocio más compleja**, será fundamental utilizar **AutoMapper.**

### API y Llamadas HTTP

- Se han detectado inconsistencias en las llamadas API:
  - **Métodos POST** utilizados para recuperar datos en lugar de realizar operaciones de inserción.
  - **Endpoints no coherentes con la lógica de negocio**, lo que dificulta la comprensión y mantenimiento.
  - Se recomienda seguir estrictamente las **convenciones RESTful** y mantener coherencia en los verbos HTTP.

### Inserción Inicial de Datos

- Actualmente, los datos iniciales se insertan en el código, lo que no es recomendable en entornos productivos.

## 3. Proyecto de Migraciones y Comandos Útiles

Se ha incorporado un proyecto específico para gestionar las migraciones de la base de datos utilizando **Entity Framework Core**. Los comandos a utilizar son los siguientes:

### Comandos para gestionar migraciones y base de datos:

```sh
# Listar fuentes de NuGet
 dotnet nuget list source

# Instalar herramientas de EF Core
 dotnet tool install --global dotnet-ef

# Eliminar la base de datos (útil en entornos de desarrollo)
 dotnet ef database drop

# Revertir la base de datos a una migración anterior
 dotnet ef database update PreviousMigration

# Crear una nueva migración
 dotnet ef migrations add InitialCreate

# Aplicar migraciones a la base de datos
 dotnet ef database update
```

## Conclusión

Las decisiones técnicas tomadas han sido adecuadas para el contexto del proyecto, pero existen mejoras clave en la estructura de datos, pruebas unitarias y API que pueden hacer que la aplicación sea más robusta, escalable y mantenible a largo plazo.

