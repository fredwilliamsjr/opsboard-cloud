# OpsBoard Cloud

A production-style cloud backend built with ASP.NET Core to simulate real-world engineering tools for incident management, service tracking, and deployments.
---

## Overview
OpsBoard Cloud is a real-world SaaS-style backend system designed to simulate internal tools used by engineering teams.

This project demonstrates the following engineering concepts:
- Clean architecture
- RESTful API design
- Database integration with Entity Framework Core
- Scalable cloud-ready backend structure

---

## Tech Stack
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL (planned)
- Docker (planned)
- AWS ECS Fargate (planned)
- Terraform (planned)
- GitHub Actions (planned)

---

## API Endpoints (Current)

| Method | Endpoint | Description |
|-------|--------|------------|
| GET | /api/services | Get all services |
| GET | /api/services/{id} | Get a service by ID |
| POST | /api/services | Create a new service |
| PUT | /api/services/{id} | Update a service |
| DELETE | /api/services/{id} | Delete a service |

---

## How to Run Locally

1. Clone the repo

```bash
git clone https://github.com/fredwilliamsjr/opsboard-cloud.git

2. Navigate into the project

```bash
cd opsboard-cloud

3. Run the application

```bash
dotnet run

4. Open Swagger in browser

```bash
https://localhost:7045/swagger/index.html
