# CatFactsApp.Backend

Backend para la aplicación **CatFactsApp**, desarrollado con **.NET 9** y arquitectura por capas (API, Business, Data, Core). Esta API actúa como intermediaria entre el frontend y dos servicios externos:

* [Cat Facts API](https://catfact.ninja) — para obtener datos aleatorios sobre gatos.
* [Giphy API](https://developers.giphy.com/) — para buscar y retornar GIFs relacionados.

Además, permite guardar y consultar el historial de búsquedas realizadas.

---

## 🧰 Tecnologías utilizadas

* .NET 9.0
* ASP.NET Core Web API
* Entity Framework Core 9
* SQL Server
* AutoMapper
* Swagger (Swashbuckle)
* Docker (opcional, para facilitar la ejecución de SQL Server)

---

## 🚀 Requisitos previos

* [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
* SQL Server (instalado localmente o mediante Docker)
* Git
* Docker (opcional, recomendado para levantar SQL Server de forma rápida)

---

## ⚙️ Configuración del entorno local

### 1. Clonar el repositorio

```bash
git clone https://github.com/staradrik/CatFactsApp.Backend.git
cd CatFactsApp.Backend
```

### 2. Configurar SQL Server

#### 🐳 Opción rápida con Docker

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=your_password" \
   -p 1435:1433 --name catfacts-sql -d mcr.microsoft.com/mssql/server:2022-latest
```

Esto levantará SQL Server en `localhost:1435`.

#### 🔧 Configurar la cadena de conexión

Crear el archivo `CatFactsApp.Backend.API/appsettings.Development.json` para configurar la conexión a la base de datos:

```json
"Logging": {
  "LogLevel": {
    "Default": "Information",
    "Microsoft.AspNetCore": "Warning"
  }
},
"ConnectionStrings": {
  "DefaultConnection": "Server=your_server;Database=CatFactsApp_DB;TrustServerCertificate=True;User Id=your_user;Password=your_password;"
},
"AllowedHosts": "*",
"Giphy": {
  "ApiKey": ""
}
```

Ajusta los valores según tu entorno.

### 3. Restaurar dependencias y compilar el proyecto

```bash
dotnet restore
dotnet build
```

### 4. Ejecutar migraciones y crear la base de datos

```bash
dotnet ef database update --project CatFactsApp.Backend.Data --startup-project CatFactsApp.Backend.API
```

### 5. Ejecutar el backend

```bash
dotnet run --project CatFactsApp.Backend.API --launch-profile https
```

La API estará disponible en:

* [https://localhost:7063](https://localhost:7063)
* [http://localhost:5065](http://localhost:5065)

---

## 📡 Endpoints principales

| Método | Endpoint                  | Descripción                               |
| ------ | ------------------------- | ----------------------------------------- |
| GET    | `/api/fact`               | Obtener un dato aleatorio sobre gatos     |
| GET    | `/api/fact/gif?query=...` | Buscar y devolver un GIF relacionado      |
| GET    | `/api/fact/with-gif`      | Obtener dato + GIF y guardar en historial |
| GET    | `/api/fact/history`       | Consultar historial de búsquedas          |

---

## 📁 Estructura del proyecto

```
CatFactsApp.Backend/
├── CatFactsApp.Backend.API       → Web API
├── CatFactsApp.Backend.Business  → Lógica de negocio y servicios
├── CatFactsApp.Backend.Core      → Entidades, DTOs, interfaces, mapeos
├── CatFactsApp.Backend.Data      → Repositorios y contexto EF
└── CatFactsApp.Backend.sln       → Solución
```

---

## 🔐 API Keys

La API Key pública para Giphy ya está incluida en `appsettings.json` para facilitar la prueba técnica:

```json
"Giphy": {
  "ApiKey": ""
}
```

