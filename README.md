# 📝 Audit Service – Práctica con Docker

Este proyecto es un servicio monolítico en .NET 8 que expone un pequeño API para registrar y consultar eventos de auditoría. La arquitectura está separada en capas simples:

- Controllers: Exponen endpoints REST.
- Services: Lógica básica de negocio.
- Entities, Repositorios y AppDbContext (EF Core + PostgreSQL).

El objetivo principal de esta práctica no es realizar una lógica compleja en el servicio, sino probar la dockerización de un backend .NET junto con una base de datos PostgreSQL usando Docker Compose.


# 🚀 Ejecución con Docker Compose

El proyecto incluye:

- Un Dockerfile para construir la imagen del servicio backend.
- Un docker-compose.yml que levanta:
    - audit_service → backend .NET 8
    - database → PostgreSQL configurado para persistencia

```bash
docker compose up --build
```

Esto construirá la imagen del servicio, levantará los contenedores y expondrá:

#### Backend: http://localhost:9095
#### PostgreSQL: puerto local 5439 → contenedor 5432

La cadena de conexión es inyectada por variables de entorno desde Docker Compose.

# 📦 Persistencia

El servicio usa EF Core para mapear la tabla Audits.
Los datos se guardan en un volumen Docker:

```
volumes:
  postgres_data:/var/lib/postgresql/data
```
Esto asegura que la base de datos no se pierda al reiniciar los contenedores.

# 📄 Endpoints de prueba (auditoría)

Ejemplos:

- POST /audit → registrar un evento
- GET /audit → listar todos los eventos

Se ingresan manualmente, ya que el propósito del proyecto es únicamente validar el entorno Docker.

## 🧹 Detener el programa con docker

```bash
docker compose down
```

## ❎ Detener el programa y eliminar la base de datos

```bash
docker compose down -v
```
