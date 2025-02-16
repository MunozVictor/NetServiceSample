# Consideraciones y Propuestas de Mejora

## 1. Decisiones T�cnicas

### .NET 8 como Plataforma de Desarrollo

Se ha elegido **.NET 8** como la versi�n principal de desarrollo debido a que es una versi�n **LTS (Long-Term Support)**, lo que garantiza soporte extendido, estabilidad y actualizaciones de seguridad a largo plazo.

### Estructura del Proyecto

Se ha dise�ado una estructura modular y escalable de proyectos con el objetivo de garantizar **orden y coherencia** en el desarrollo. Esta estructura permite la evoluci�n del sistema sin comprometer su mantenibilidad.

Ejemplo de estructura utilizada:

- **WineCorp.Service** (Capa de presentaci�n / API)
- **WineCorp.Application** (Servicios de aplicaci�n y l�gica de negocio)
- **WineCorp.Infrastructure** (Acceso a datos y configuraci�n de Entity Framework)
- **WineCorp.Domain** (Modelos de dominio y entidades)
- **WineCorp.Migrations** (Manejo de migraciones de la base de datos)
- **WineCorp.Tests** (Proyecto de pruebas unitarias e integraci�n)

### Entity Framework como ORM

Se ha utilizado **Entity Framework Core** para la gesti�n de la base de datos, facilitando el manejo de migraciones, la abstracci�n del acceso a datos y la optimizaci�n de consultas mediante LINQ.

## 2. Puntos de Mejora

### Modelado de Base de Datos

- Actualmente, las **claves primarias** son enteros autoincrementales. Se recomienda utilizar **GUIDs autogenerados** para mejorar la seguridad y la unicidad en entornos distribuidos.
- **Relaciones entre entidades**: Se deben revisar las configuraciones de restricciones y eliminaciones en cascada para evitar inconsistencias en los datos.
- Uso de **propiedades de navegaci�n** en los modelos para mejorar la fluidez de las consultas y la mantenibilidad del c�digo.

### Mappeos de Entidades y Servicios de Aplicaci�n

- Actualmente, los **mapeos de entidades** y la capa de **servicios de aplicaci�n** no han sido necesarios.
- Sin embargo, si en el futuro se requiere **integraci�n con otros sistemas** o se a�ade **l�gica de negocio m�s compleja**, ser� fundamental utilizar **AutoMapper.**

### API y Llamadas HTTP

- Se han detectado inconsistencias en las llamadas API:
  - **M�todos POST** utilizados para recuperar datos en lugar de realizar operaciones de inserci�n.
  - **Endpoints no coherentes con la l�gica de negocio**, lo que dificulta la comprensi�n y mantenimiento.
  - Se recomienda seguir estrictamente las **convenciones RESTful** y mantener coherencia en los verbos HTTP.

### Inserci�n Inicial de Datos

- Actualmente, los datos iniciales se insertan en el c�digo, lo que no es recomendable en entornos productivos.

## 3. Proyecto de Migraciones y Comandos �tiles

Se ha incorporado un proyecto espec�fico para gestionar las migraciones de la base de datos utilizando **Entity Framework Core**. Los comandos a utilizar son los siguientes:

### Comandos para gestionar migraciones y base de datos:

```sh
# Listar fuentes de NuGet
 dotnet nuget list source

# Instalar herramientas de EF Core
 dotnet tool install --global dotnet-ef

# Eliminar la base de datos (�til en entornos de desarrollo)
 dotnet ef database drop

# Revertir la base de datos a una migraci�n anterior
 dotnet ef database update PreviousMigration

# Crear una nueva migraci�n
 dotnet ef migrations add InitialCreate

# Aplicar migraciones a la base de datos
 dotnet ef database update
```

## Conclusi�n

Las decisiones t�cnicas tomadas han sido adecuadas para el contexto del proyecto, pero existen mejoras clave en la estructura de datos, pruebas unitarias y API que pueden hacer que la aplicaci�n sea m�s robusta, escalable y mantenible a largo plazo.

