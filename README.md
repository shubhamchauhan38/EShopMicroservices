# EShopMicroservices
A fast, scalable e-commerce platform built with .NET Core & Angular.
## **Project Structure**

<img width="799" height="406" alt="image" src="https://github.com/user-attachments/assets/de4cad06-86f3-4e1c-8fd1-15aa31d8913b" />

## 📦 Catalog Microservice
The **Catalog Microservice** manages product data and serves as the core product store for the platform.

### 🔑 Key Features
- Built with **ASP.NET Core Minimal APIs** using latest features of **.NET 8** and **C# 12**
- Implements **Vertical Slice Architecture** with feature folders (one `.cs` file contains related classes)
- **CQRS** pattern with **MediatR** for clean separation of commands/queries
- Validation pipeline behaviors with **MediatR + FluentValidation**
- Uses **Marten** (PostgreSQL-based transactional document DB) for persistence
- Minimal API endpoint definition with **Carter**
- Cross-cutting concerns: **Logging, Global Exception Handling, Health Checks**
  
<img width="823" height="445" alt="image" src="https://github.com/user-attachments/assets/7da5ff50-0f22-4e44-9692-66a651a9e07f" />

---

## 🛒 Basket Microservice
The **Basket Microservice** handles user shopping carts and pricing logic.

### 🔑 Key Features
- Built with **ASP.NET Core 8 Web API**, following REST API principles
- CRUD operations for basket management
- Uses **Redis** as a distributed cache for basket data
- Implements **Proxy, Decorator, and Cache-aside patterns**
- Consumes **Discount gRPC Service** for real-time price calculation
- Publishes **BasketCheckout** events using **MassTransit + RabbitMQ**

<img width="804" height="408" alt="image" src="https://github.com/user-attachments/assets/0aa4f5f6-568d-4025-b8d8-bf4de7d73fff" />

---

## 🎟️ Discount Microservice
The **Discount Microservice** manages product discounts and communicates with other services via gRPC.

### 🔑 Key Features
- Built with **ASP.NET Core gRPC Server**
- Provides high-performance **inter-service gRPC communication** with Basket Microservice
- Defines **Protobuf messages** for service contracts
- Uses **Entity Framework Core** with **SQLite** for data persistence and migrations
- Containerized **SQLite database**
- Exposes gRPC services for syncing discounts
  
<img width="799" height="402" alt="image" src="https://github.com/user-attachments/assets/fbbe1d91-b079-43b3-b0c5-ca1d22e2edd0" />
---

## 📦 Ordering Microservice
The **Ordering Microservice** manages the order lifecycle with domain-driven design principles.

### 🔑 Key Features
- Implements **DDD, CQRS, and Clean Architecture**
- Uses **MediatR**, **FluentValidation**, and **Mapster** for command handling and validation
- Subscribes to **BasketCheckout events** via **MassTransit + RabbitMQ**
- Persists data with **SQL Server** using **Entity Framework Core**
- Auto-migration to SQL Server on application startup
  
<img width="807" height="398" alt="image" src="https://github.com/user-attachments/assets/2996a3c6-728d-4adb-8e38-26c6e9a59982" />
---

## 🔗 Microservices Communication
- **Synchronous Communication:** gRPC (Basket ↔ Discount)  
- **Asynchronous Communication:** RabbitMQ with **MassTransit**  
  - Basket publishes `BasketCheckout` events  
  - Ordering consumes and processes events  
- **EventBus.Messages Library:** Shared contracts for reliable message passing
  <img width="844" height="354" alt="image" src="https://github.com/user-attachments/assets/36ec2b7c-1abb-4900-a7ee-2bad8a80efb1" />


