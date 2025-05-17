
# 🛒 SuperBad Store Backend

**The future competitor of Chợ Tốt (Good Market)**

SuperBad Store Backend is a scalable, modular e-commerce backend built with .NET Core and modern microservices architecture. It leverages Domain-Driven Design (DDD), Clean Architecture, and CQRS patterns to ensure maintainability and scalability.

---

## 🚀 Features

- **Microservices Architecture**: Modular services for user management, product catalog, orders, and more.
- **API Gateway**: Centralized entry point for routing and authentication.
- **Event-Driven Communication**: Utilizes RabbitMQ for asynchronous messaging between services.
- **Data Storage**: PostgreSQL for relational data and Redis for caching.
- **gRPC Support**: High-performance communication between internal services.
- **Logging**: Integrated Serilog for structured and centralized logging.
- **Containerization**: Dockerized services orchestrated via Docker Compose.

---

## 🧱 Project Structure

```
superbad-store_backend/
├── APIGateway/             # API Gateway service
├── BuildingBlocks/         # Shared utilities and base classes
├── Services/
│   ├── Identity/           # User identity and authentication
│   ├── Inventory/          # Inventory management
│   ├── Order/              # Order processing
│   ├── Review/             # Product review handling
│   ├── Shared/             # Common components
│   ├── Shopping/           # Shopping cart
├── docker-compose.yml      # Docker orchestration file
├── SuperBadStore.sln       # Solution file
```

---

## 🛠️ Tech Stack

- **Language**: C# (.NET Core)
- **Databases**: PostgreSQL, Redis
- **Messaging**: RabbitMQ
- **Communication**: gRPC
- **Architecture**: Microservices, CQRS, DDD, Clean Architecture
- **Logging**: Serilog
- **Containerization**: Docker, Docker Compose

---

## ⚙️ Getting Started

### Prerequisites

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- [Docker](https://www.docker.com/get-started)

### Installation

1. **Clone the repository:**

   ```bash
   git clone https://github.com/superbadteam/superbad-store_backend.git
   cd superbad-store_backend
   ```

2. **Build and run the services:**

   ```bash
   docker-compose up --build
   ```

3. **Access the API Gateway:**

   Once all services are up, the API Gateway will be accessible at `http://localhost:3000` (or the port specified in your configuration).

---

## 📦 Services Overview

- **API Gateway**: Handles routing, authentication, and acts as the single entry point for clients.
- **Identity Service**: Manages user authentication, authorization, and profile data.
- **Inventory Service**: Handles product listings, categories, and inventory.
- **Order Service**: Manages shopping carts, orders, and order history.
- **Review Service**: Enables users to submit and view product reviews.
- **Shopping Service**: Handles home page and shopping cart logic.
- **Building Blocks**: Contains shared utilities, base classes, and interfaces used across services.

---

## 📄 License

This project is licensed under the [MIT License](LICENSE).

---

## 🤝 Contributing

Contributions are welcome! Please fork the repository and submit a pull request for any enhancements or bug fixes.

---

## 📫 Contact

For questions or support, please open an issue in the repository.
