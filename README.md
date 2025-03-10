# 📌 README - Despliegue del Proyecto

## 🛠️ Configuración y Despliegue del Proyecto
Este documento proporciona instrucciones detalladas sobre cómo **construir, configurar y desplegar** la API y la aplicación web, así como la base de datos requerida para su correcto funcionamiento.

---

## 📂 1. Requisitos Previos
Antes de iniciar, asegúrese de contar con las siguientes herramientas instaladas:

- **.NET 8 SDK** 👉 [Descargar](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- **Node.js (versión recomendada 18+)** 👉 [Descargar](https://nodejs.org/)
- **SQL Server** (o Azure SQL) con permisos de administrador
- **SQL Server Management Studio (SSMS)** o equivalente
- **Angular CLI** 👉 `npm install -g @angular/cli`
- **Git** 👉 [Descargar](https://git-scm.com/)
- **Visual Studio 2022** (con .NET y herramientas para API REST)
- **Visual Studio Code** (opcional para la app web)

---

## 🛠️ 2. Configuración de la Base de Datos

### 🔹 Paso 1: Crear la Base de Datos
Ejecute el siguiente script en **SQL Server Management Studio (SSMS)** o en su herramienta SQL favorita para crear la base de datos y poblarla con datos de prueba:

```sql
-- Crear la base de datos
CREATE DATABASE StoreSample;
GO

-- Usar la base de datos
USE StoreSample;
GO

-- Crear tabla Customers
CREATE TABLE Customers (
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerName NVARCHAR(100) NOT NULL
);
GO

-- Crear tabla Employees
CREATE TABLE Employees (
    EmpID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL
);
GO

-- Crear tabla Shippers
CREATE TABLE Shippers (
    ShipperID INT IDENTITY(1,1) PRIMARY KEY,
    CompanyName NVARCHAR(100) NOT NULL
);
GO

-- Crear tabla Products
CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(100) NOT NULL
);
GO

-- Insertar datos en las tablas
INSERT INTO Customers (CustomerName) VALUES
('Juan Pérez'), ('María González'), ('Carlos Mendoza'), ('Ana Ramírez'), ('Luis Torres');

INSERT INTO Employees (FirstName, LastName) VALUES
('Pedro', 'Gómez'), ('Laura', 'Fernández'), ('Andrés', 'Ramírez'), ('Mariana', 'López'), ('Ricardo', 'Torres');

INSERT INTO Shippers (CompanyName) VALUES
('DHL Express'), ('FedEx Corporation'), ('UPS United Parcel Service'), ('Blue Cargo Logistics'), ('Servientrega');

INSERT INTO Products (ProductName) VALUES
('Laptop Dell XPS 13'), ('Monitor LG UltraWide'), ('Teclado Mecánico Logitech'), ('Mouse Inalámbrico Microsoft'),
('Disco Duro Externo Seagate 1TB'), ('Memoria RAM Kingston 16GB'), ('Silla Ergonómica para Oficina'),
('Impresora Multifuncional HP'), ('Tablet Samsung Galaxy Tab S7'), ('Auriculares Sony WH-1000XM4');
GO
```

---

## 🚀 3. Despliegue de la API .NET 8

### 🔹 Paso 2: Configurar la cadena de conexión en `appsettings.json`
1. Dirígete a `appsettings.json` en la API y reemplaza la conexión encriptada con la de tu servidor.
2. **Ejemplo de conexión encriptada en `appsettings.json`**:
```json
"ConnectionStrings": {
  "ConnectionType": "1",
  "DevConnection": "WS9ScRltNoK1d7pDYx...",
  "ProdConnection": ""
}

### 🔹 Paso 3: Construir y ejecutar la API
Ejecuta los siguientes comandos en la terminal dentro de la carpeta del API:

```sh
# Restaurar paquetes
dotnet restore

# Construir la API
dotnet build --configuration Release

# Ejecutar la API localmente
dotnet run
```

📌 **La API estará disponible en:** `http://localhost:5171/api`

---

## 🌐 4. Despliegue de la Aplicación Web Angular

### 🔹 Paso 4: Configurar conexión con la API
1. Abre el archivo `sales.service.ts` y cambia la URL base de la API:
```typescript
private baseUrl = 'http://TU_SERVIDOR:5171/api';
```
2. Guarda los cambios.

### 🔹 Paso 5: Construir y ejecutar la aplicación
Ejecuta los siguientes comandos en la terminal dentro de la carpeta del proyecto Angular:

```sh
# Instalar dependencias
npm install

# Construir la aplicación
ng build --configuration production

# Ejecutar la aplicación en modo desarrollo
ng serve --open
```

📌 **La aplicación estará disponible en:** `http://localhost:4200/`

---

## ✅ 5. Checklist para el Despliegue Final
☑️ **Base de datos creada** en SQL Server con datos insertados.  
☑️ **Cadena de conexión actualizada** en `appsettings.json`.  
☑️ **API .NET 8 construida y en ejecución** (`dotnet run`).  
☑️ **Aplicación Angular configurada** para apuntar a la API.  
☑️ **Aplicación web compilada y desplegada** (`ng build`).  

---

## 📌 6. Información Adicional sobre la Prueba
- Se evaluó el despliegue de una API REST en **.NET 8** con conexión a SQL Server.
- Se implementó un **sistema de encriptación de credenciales** en la API.
- Se creó una aplicación **Angular 19** para el consumo de los servicios.
- Se validó la **interacción entre el frontend y backend** mediante pruebas locales y con Swagger.

---

## 📜 7. Conclusión
Siguiendo estos pasos, podrás desplegar correctamente la API, la base de datos y la aplicación web en cualquier servidor compatible. 🚀
