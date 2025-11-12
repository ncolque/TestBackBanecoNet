# API REST - Sistema de Gestión de Tareas

Este proyecto es un backend desarrollado con .NET 6, aplicando principios de Arquitectura Limpia y buenas prácticas profesionales.
Su objetivo es gestionar tareas, permitiendo crear, consultar, actualizar y eliminar tareas, almacenadas en un archivo .json.

## Características principales

✅ **Arquitectura Limpia:** Separación clara por capas (Entities, Repositories, Services, Controllers).

✅ **Almacenamiento en JSON:** Persistencia sencilla sin necesidad de base de datos relacional.

✅ **Control de errores:** Respuestas uniformes ante fallos o datos inválidos.

✅ **Validaciones de datos:** Validación de campos obligatorios y valores permitidos.

✅ **Escalabilidad:** Estructura preparada para migrar a base de datos si se requiere.

✅ **Inyección de dependencias:** Patrón aplicado en servicios.

## Funcionalidades del sistema

✅ Crear tarea: Permite agregar una nueva tarea con título, descripción y estado.

✅ Consultar tareas: Listado completo de tareas o por ID.

✅ Actualizar tarea: Modificación de título, descripción y estado de una tarea existente.

✅ Eliminar tarea: Eliminación de una tarea por ID.

Validaciones:

Titulo y Descripcion obligatorios.

Estado solo acepta "Pendiente", "EnProgreso" o "Completada".

## Posibles mejoras del sistema

1. Paginación y filtros para la consulta de tareas.

2. Implementar autenticación y roles para control de acceso.

3. Migración de almacenamiento a base de datos SQL Server o NoSQL.

4. Auditoría de cambios (quién creó, actualizó o eliminó tareas).

## Stack Tecnológico

- Framework: .NET 6
- Almacenamiento: Archivo JSON (tareas.json)
- Validaciones: Propias
- Frontend: Angular 20 + Angular Material

## Instalación

Clonar el repositorio:

```bash
git clone https://github.com/tu-usuario/TestBackTareasNet.git
cd TestBackTareasNet
```

Restaurar dependencias en este caso no

```bash
dotnet restore
```

Ejecutar la API

```bash
dotnet run --project Api
```

La API estará disponible en la siguiente direccion o una por default que le asigne el sistema:
- http://localhost:5000/swagger (HTTP)
- https://localhost:5001/swagger (HTTPS)

---

## Estructura del Proyecto

```
src/
├── Api/                       
│   ├── Controllers/
│   │   └── TareaController.cs
│   └── Program.cs / appsettings.json
│
├── Services/                  
│   └── TareaService.cs
│
├── Repositories/                
│   └── TareaRepository.cs
│
├── Entities/                    
│   └── Tarea.cs
│
└── README.md                    
```

---

## Endpoints principales

**Listar todas las tareas**

GET /api/tarea

Response 200 OK:

```json
[
  {
    "id": 1,
    "titulo": "Comprar insumos",
    "descripcion": "Comprar material de oficina",
    "estado": "Pendiente"
  },
  {
    "id": 2,
    "titulo": "Revisión mensual",
    "descripcion": "Revisar informes de proyectos",
    "estado": "EnProgreso"
  }
]
```

**Obtener tarea por ID**

GET /api/tarea/{id}

Response 200 OK:

```json
{
  "id": 1,
  "titulo": "Comprar insumos",
  "descripcion": "Comprar material de oficina",
  "estado": "Pendiente"
}
```

**Crear nueva tarea**

POST /api/tarea

Request:

```json
{
  "titulo": "Nueva Tarea",
  "descripcion": "Descripción de la tarea",
  "estado": "Pendiente"
}
```

**Actualizar tarea**

PUT /api/tarea/{id}

Request:

```json
{
  "titulo": "Tarea Actualizada",
  "descripcion": "Descripción modificada",
  "estado": "Completada"
}
```

**Eliminar tarea**

DELETE /api/tarea/{id}

Response 200 OK:

```json
"Tarea con ID 3 eliminada correctamente."

```

---

## Autor

- Desarrollador: Nicolás Colque
- Versión: 1.0.0
- Framework: .NET 6

## Licencia
Este proyecto se distribuye bajo la licencia MIT. Consulta el archivo [LICENSE](LICENSE) para más información.

---
© 2025 Nicolás Colque — Todos los derechos reservados.
