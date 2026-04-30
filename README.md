# EventTix

A microservice backend for event ticket booking, built to practice .NET, RabbitMQ, JWT, Kubernetes, and xUnit.

## Stack
- .NET 8
- PostgreSQL (via Docker)
- EF Core
- RabbitMQ
- xUnit
- Kubernetes

## Services
- **Identity** — registration, login, JWT issuance
- **Events** — event CRUD 
- **Booking** — ticket reservations 
- **Payment** — mocked payment processor 
- **Notifications** — email fan-out
