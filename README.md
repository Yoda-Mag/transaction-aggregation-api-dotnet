# Transaction Aggregation API

A **.NET 9 Web API** for aggregating customer transactions from multiple bank sources.
Supports fetching transactions, querying by customer, and aggregating totals by category, source, and direction (money in/out).

---

## Table of Contents

* [Features](#features)
* [Technologies](#technologies)
* [Getting Started](#getting-started)
* [Running the API](#running-the-api)
* [API Endpoints](#api-endpoints)
* [Docker](#docker)
* [Future Enhancements](#future-enhancements)
* [Author](#author)

---

## Features

* Retrieve all customers
* Retrieve all transactions
* Retrieve transactions by customer
* Aggregate transactions by **category**, **source**, and **money direction (in/out)**
* Swagger UI for interactive testing
* Dockerized for easy deployment

---

## Technologies

* .NET 9 Web API
* C#
* Dependency Injection
* Docker
* Swagger (OpenAPI)

---

## Getting Started

### Prerequisites

* [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
* [Docker](https://www.docker.com/get-started) *(optional, for containerized deployment)*

### Clone the Repository
```bash
git clone https://github.com/Yoda-Mag/transaction-aggregation-api-dotnet.git
cd transaction-aggregation-api-dotnet/ProjectsTransactionAggregation/TransactionAggregationApi
```

---

## Running the API

### Running Locally

1. **Build the project**
```bash
   dotnet build
```

2. **Run the application**
```bash
   dotnet run
```

3. **Access the API**

   * HTTPS → `https://localhost:5139`
   * HTTP → `http://localhost:5138`

4. **Swagger UI**

   * Visit: `https://localhost:5139/swagger/index.html`

---

## API Endpoints

| Method | Endpoint                                      | Description                                      |
| ------ | --------------------------------------------- | ------------------------------------------------ |
| GET    | `/api/customers`                              | Get all customers                                |
| GET    | `/api/transactions/all`                       | Get all transactions                             |
| GET    | `/api/transactions/customer/{customerId}`     | Get transactions for a specific customer         |
| GET    | `/api/transactions/aggregate/category`        | Get total and count of transactions per category |
| GET    | `/api/transactions/aggregate/source-by-month` | Get totals per source, grouped by month          |
| GET    | `/api/transactions/aggregate/moneyIn`         | Get total amount and count of all incoming funds |
| GET    | `/api/transactions/aggregate/moneyOut`        | Get total amount and count of all outgoing funds |

---

### Example Requests

#### Get All Transactions
```bash
curl -X GET "https://localhost:5139/api/transactions/all"
```

#### Get Transactions by Customer
```bash
curl -X GET "https://localhost:5139/api/transactions/customer/{customerId}"
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

**API will be available at:**  
-> `http://localhost:8081`

**Swagger (inside Docker):**  
-> `http://localhost:8081/swagger/index.html`

---

### Docker Compose

**Build and Run:**
```bash
docker-compose up -d --build
```

**Stop Services:**
```bash
docker-compose down
```

**Access via Docker Compose:**  
-> `http://localhost:8081`

---

## Future Enhancements

* Add unit and integration tests
* Introduce global exception handling middleware
* Add structured logging and request monitoring
* Enable filtering/sorting by date range or amount
* Integrate with a SQL or NoSQL database
* Add authentication & authorization (JWT or OAuth)
* Introduce caching for performance
* Add CI/CD pipeline (GitHub Actions)

---

## Author

**Letlhogonolo Magano**  
 *Final Year IT Student | Backend & Data Enthusiast*

[![GitHub](https://img.shields.io/badge/GitHub-Yoda--Mag-181717?style=flat&logo=github)](https://github.com/Yoda-Mag)

---
