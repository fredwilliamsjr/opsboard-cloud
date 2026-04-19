# OpsBoard Cloud

A production-style cloud platform for incident management, deployment tracking, and service monitoring.

---

## Overview
OpsBoard Cloud is a real-world SaaS-style backend system designed to simulate internal tools used by engineering teams.

This project demonstrates:
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
| GET | /api/services/{id} | Get service by ID |
| POST | /api/services | Create a new service |
| PUT | /api/services/{id} | Update a service |
| DELETE | /api/services/{id} | Delete a service |

---

## How to Run Locally

1. Clone the repo
```bash
git clone https://github.com/fredwilliamsjr/opsboard-cloud.git
