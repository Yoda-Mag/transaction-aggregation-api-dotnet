# Transaction Aggregation API

A .NET 9 Web API for aggregating customer transactions from multiple bank sources. Supports fetching transactions, querying by customer, and aggregating totals by category or date.

---

## Table of Contents

- [Features](#features)
- [Technologies](#technologies)
- [Getting Started](#getting-started)
- [Running the API](#running-the-api)
- [API Endpoints](#api-endpoints)
- [Docker](#docker)
- [Future Enhancements](#future-enhancements)
- [Author](#author)

---

## Features

- Retrieve all transactions
- Retrieve transactions by customer
- Aggregate transactions by category
- Aggregate transactions by date (month/year)
- Swagger UI for interactive testing
- Dockerized for easy deployment

---

## Technologies

- .NET 9 Web API
- C#
- Dependency Injection
- Docker
- Swagger (OpenAPI)

---

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- [Docker](https://www.docker.com/get-started) (optional, for containerized deployment)

### Clone the Repository

```bash
git clone https://github.com/Yoda-Mag/transaction-aggregation-api-dotnet.git
cd transaction-aggregation-api-dotnet/ProjectsTransactionAggregation/TransactionAggregationApi
```

---

## Running the API

### Running Locally

1. Build the project:
```bash
dotnet build
```

2. Run the application:
```bash
dotnet run
```

3. The API will be available at:
   - **HTTPS:** `https://localhost:5139`
   - **HTTP:** `http://localhost:5138`

4. Open Swagger UI at:
   - `https://localhost:5139/swagger`

---

## API Endpoints

| Method | Endpoint                                  | Description                                          |
| ------ | ----------------------------------------- | ---------------------------------------------------- |
| GET    | `/api/transactions`                       | Get all transactions                                 |
| GET    | `/api/transactions/customer/{customerId}` | Get transactions for a specific customer             |
| GET    | `/api/transactions/aggregate/category`    | Get total and count of transactions per category     |
| GET    | `/api/transactions/aggregate/source`      | Get total and count of transactions per month/source |
| GET    | `/api/customers`                          | Get all customers                                    |

### Example Requests

#### Get All Transactions
```bash
curl -X GET "https://localhost:5139/api/transactions"
```

#### Get Transactions by Customer
```bash
curl -X GET "https://localhost:5139/api/transactions/customer/1"
```

#### Aggregate by Category
```bash
curl -X GET "https://localhost:5139/api/transactions/aggregate/category"
```

---

## Docker

### Build Docker Image

```bash
docker build -t transaction-aggregation-api .
```

### Run Container

```bash
docker run -d -p 8081:8080 transaction-aggregation-api
```

The API will be available at:
- `http://localhost:8081`

### Access Swagger in Docker

Navigate to: `http://localhost:8081/swagger`

---

## Future Enhancements

- Add unit tests for services and controllers
- Add DTOs for API responses
- Implement global error handling middleware
- Add request logging and monitoring
- Add filtering/sorting by date range or amount
- Support database storage (SQL Server, PostgreSQL) instead of in-memory data
- Use Docker Compose for multi-container setups
- Implement authentication and authorization
- Add caching for improved performance
- Create CI/CD pipeline

---

## Author

**Letlhogonolo Magano**

[![GitHub](https://img.shields.io/badge/GitHub-Yoda--Mag-181717?style=flat&logo=github)](https://github.com/Yoda-Mag)
