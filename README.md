
![Saludo](ProyectAntivirusBackend/wwwroot/images/Antivirus.jpg)


# Banco de Oportunidades Estudiantiles (BOE)

El Banco de Oportunidades Estudiantiles (BOE) es una plataforma web innovadora diseñada para centralizar y facilitar el acceso a una amplia gama de oportunidades educativas y formativas. Nuestro objetivo es empoderar a adolescentes, jóvenes y adultos proporcionándoles información actualizada y detallada sobre:

    Universidades y programas académicos
    Becas y créditos condonables
    Programas públicos y subsidios
    Cursos de capacitación laboral

A través de una interfaz intuitiva y herramientas de búsqueda avanzadas, BOE permite a los usuarios descubrir oportunidades que se alineen con sus intereses y aspiraciones profesionales. Además, la plataforma ofrece funcionalidades como gestión de perfiles personalizados, opciones de donación segura y canales de comunicación directa para soporte y asesoramiento.

Nuestro compromiso es reducir la deserción educativa y promover el desarrollo profesional, brindando a la comunidad una herramienta confiable y accesible para planificar su futuro académico y laboral.


## 🚀 Tech Stack

**Client:** Repositorio frontend: 
**Server:**
Property                 | Data  
-------------------------|------
Language / IDE           | [![C# Badge](https://img.shields.io/badge/-Visual%20Studio-239120?style=flat&logo=C-Sharp&logoColor=white)](https://github.com/search?l=C%23&q=user%3Azmcx16&type=Repositories)
Tool / Framework         | [![React Badge](https://img.shields.io/badge/-React-61DAFB?style=flat&logo=Electron&logoColor=white)](https://github.com/zmcx16/AxisCult) 

**Server:**
Property                 | Data  
-------------------------|------
Language / IDE           | [![C# Badge](https://img.shields.io/badge/-Visual%20Studio-239120?style=flat&logo=C-Sharp&logoColor=white)](https://github.com/search?l=C%23&q=user%3Azmcx16&type=Repositories)
Tool / Framework         | [![React Badge](https://img.shields.io/badge/-React-61DAFB?style=flat&logo=Electron&logoColor=white)](https://github.com/zmcx16/AxisCult) [![ASP.NET Badge](https://img.shields.io/badge/-ASP.NET-5C2D91?style=flat&logo=.net&logoColor=white)](https://github.com/search?q=user%3Azmcx16&type=Repositories) [![Npgsql v9.0.2](https://img.shields.io/badge/Npgsql%20v9.0.2-316192?logo=postgresql&logoColor=white)](https://www.nuget.org/packages/Npgsql.EntityFrameworkCore.PostgreSQL/9.0.2) [![ASP.NET Core 9.0](https://img.shields.io/badge/ASP.NET%20Core-9.0-512BD4?style=flat&logo=asp.net&logoColor=white)](https://dotnet.microsoft.com/download/dotnet/9.0) [![Entity Framework Core 9.0.2](https://img.shields.io/badge/Entity%20Framework%20Core-9.0.2-512BD4?style=flat&logo=ef&logoColor=white)](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/9.0.2) [![Swagger (Swashbuckle) 7.2.0](https://img.shields.io/badge/Swagger%20(Swashbuckle)-7.2.0-85EA2D?style=flat&logo=swagger&logoColor=black)](https://www.nuget.org/packages/Swashbuckle.AspNetCore/7.2.0) [![JWT](https://img.shields.io/badge/JWT-Latest%20Version-000000?style=flat&logo=json-web-tokens&logoColor=white)](https://jwt.io/)
Domain Knownledge        | [![Software Development Badge](https://img.shields.io/badge/-Software%20Development-FF6600?style=flat&logoColor=white)](https://github.com/search?q=user%3Azmcx16&type=Repositories)

## 🚀 Funcionalidades Implementadas

Se detallan las funcionalidades implementadas en el backend del proyecto **Banco de Oportunidades Estudiantiles (BOE)**:

1. **Gestión de Usuarios**

   1.1 **Registro y Autenticación**:Implementación de un sistema de registro y autenticación de usuarios utilizando **ASP.NET Core Identity** junto con **JSON Web Tokens (JWT)** para asegurar sesiones seguras y eficientes.

   1.2 **Roles y Permisos**:Asignación de roles como "estudiante" y "administrador" para controlar el acceso a las partes de la aplicación, para una gestión adecuada de permisos.

2. **Gestión de Oportunidades**

   2.1 **CRUD de Oportunidades**: Funcionalidades para Crear, Leer, Actualizar y Eliminar oportunidades educativas y laborales, utilizando **Entity Framework Core** para interactuar con la base de datos **PostgreSQL**

   2.2 **Categorización y Filtrado**:Implementación de categorías y filtros que permitan a los usuarios buscar oportunidades según criterios específicos como:
ubicación, tipo de oportunidad (educativa, económica), sector de la oportunidad (Tecnológico, Social, Medio Ambiente, etc..).

3. **Postulación a Oportunidades**

   3.1 **Proceso de Postulación**:Desarrollo de un flujo que permite a los estudiantes postularse a las oportunidades disponibles, con seguimiento del estado de cada postulación (pendiente, aprobada, rechazada)

   3.2 **Notificaciones**:Integración de un sistema de notificaciones que informa a los usuarios sobre el estado de sus postulaciones y nuevas oportunidades relevantes.

4. **Gestión de Donaciones**

   4.1 **Integración con Pasarela de Pago**:Implementación de la pasarela de pago **Wompi** para procesar donaciones de manera segura, asegurando la integridad y confidencialidad de las transacciones.

   4.2 **Registro de Donaciones**:Almacenamiento seguro de los registros de donaciones en la base de datos, permitiendo a los administradores y usuarios autorizados acceder a historiales de donaciones.

5. **Soporte y Comunicación**

   5.1 **Sistema de Mensajería**:Desarrollo de un sistema de mensajería interno que permite a los usuarios comunicarse con el equipo de soporte para resolver dudas o problemas, mejorando la interacción y satisfacción del usuario.

   5.2 **Gestión de Consultas**:Herramientas para que el equipo de soporte gestione y responda eficientemente a las consultas de los usuarios, asegurando una atención oportuna y efectiva.

6. **Seguridad y Protección de Datos**

   6.1 **Cifrado de Información Sensible**:Uso de técnicas de cifrado para proteger datos sensibles de los usuarios, como contraseñas y datos personales, siguiendo las mejores prácticas de seguridad.

   6.2 **Protección contra Vulnerabilidades**:Implementación de medidas para prevenir ataques comunes como inyecciones SQL, Cross-Site Scripting (XSS) y Cross-Site Request Forgery (CSRF), asegurando la integridad y seguridad de la aplicación.

7. **Documentación y Pruebas**

   7.1 **Documentación de la API**:Generación de documentación interactiva de la API utilizando **Swagger (OpenAPI 3.0)**, facilitando a los desarrolladores y colaboradores la comprensión y uso de los endpoints disponibles.

## 📦 Despligue

Para desplegar la aplicación en un entorno de producción, considere los siguientes pasos:

 **Publicar la Aplicación**

   Genere los archivos de publicación utilizando el siguiente comando:

   ```bash
   dotnet publish --configuration Release --output ./publish
   ```


### 🚀 Pasos de Instalación

1. **Clonar el Repositorio**

  Utilice Git para clonar el repositorio del proyecto en su máquina loc:

   ```bash
   git clone https://github.com/Cuoralex/ProyectAntivirusBackend.git
   cd ProyectAntivirusBackend
   ```

2. **Configuración de la Base de Datos con Supabase**

   2.1 **Crear un Proyecto en Supabase**:

    Inicie sesión en su cuenta de Supabase y cree un nuevo proyecto en Supabase.

   2.2 **Obtener la Cadena de Conexión**:

    En el panel de Supabase, navegue a la configuración de la base de datos y copie la cadena de conexión proporciona esta cadena será utilizada para conectar su aplicación ASP.NET Core a la base de datos de Supaba.

3. **Configuración de la Aplicación ASP.NET Core**

   3.1 **Instalar el Paquete Npgsql**:

    Para conectar su aplicación ASP.NET Core a la base de datos PostgreSQL de AWS, instale el paquete Npgs:

     ```bash
     dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
     ```

   3.2 **Configurar el DbContext**:

    En su clase `Program.cs`, configure el `DbContext` para utilizar PostgreS:

     ```csharp
     services.AddDbContext<ApplicationDbContext>(options =>
         options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
     ```

    Asegúrese de que su archivo `appsettings.json` contenga la cadena de conexión obtenida de Supaba:

     ```json
     {
       "ConnectionStrings": {
         "DefaultConnection": "Host=db.supabase.co;Port=5432;Database=postgres;User Id=postgres;Password=su_contraseña;"
       }
     }
     ```

    Reemplace `su_contraseña` con la contraseña proporcionada de la BdD.

4. **Ejecutar Migraciones de la Base de Datos**

  Utilice Entity Framework Core para aplicar las migraciones y crear las tablas necesarias en la base de dat:

   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

5. **Compilar y Ejecutar la Aplicación**

  Compile y ejecute la aplicación utilizando el siguiente coman:

   ```bash
   dotnet run --project BOE.API
   ```


##  🗂️ Estructura del Proyecto ProyectAntivirusBackend

```bash
ProyectAntivirusBackend/
├── ProyectAntivirusBackend.sln
├── src/
│   ├── ProyectAntivirusBackend.API/             # Capa de Presentación (Web API)
│   │   ├── Controllers/                         # Controladores de la API
│   │   │   ├── HomeController.cs                # Controlador principal
│   │   │   ├── AntivirusController.cs           # Controlador para gestión de antivirus
│   │   │   └── UserController.cs                # Controlador para gestión de usuarios
│   │   ├── Views/                               # Vistas de la aplicación
│   │   │   ├── Home/
│   │   │   │   └── Index.cshtml                 # Vista de inicio
│   │   │   ├── Shared/
│   │   │   │   └── _Layout.cshtml               # Diseño compartido
│   │   │   └── Error.cshtml                     # Vista de error
│   │   ├── Models/                              # Modelos de la aplicación
│   │   │   ├── AntivirusViewModel.cs            # Modelo de vista para antivirus
│   │   │   └── UserViewModel.cs                 # Modelo de vista para usuarios
│   │   ├── wwwroot/                             # Archivos estáticos (CSS, JS, imágenes)
│   │   │   ├── css/
│   │   │   │   └── site.css                     # Estilos personalizados
│   │   │   ├── js/
│   │   │   │   └── site.js                      # Scripts personalizados
│   │   │   └── images/
│   │   │       └── logo.png                     # Logo de la aplicación
│   │   ├── appsettings.json                     # Configuración de la aplicación
│   │   ├── Program.cs                           # Punto de entrada de la aplicación
│   │   └── Startup.cs                           # Configuración de servicios y middleware
│   │
│   ├── ProyectAntivirusBackend.Application/     # Capa de Aplicación (Lógica de Negocio)
│   │   ├── Interfaces/                          # Interfaces de servicios
│   │   │   ├── IAntivirusService.cs             # Interfaz para servicio de antivirus
│   │   │   └── IUserService.cs                  # Interfaz para servicio de usuarios
│   │   ├── Services/                            # Implementaciones de servicios
│   │   │   ├── AntivirusService.cs              # Servicio para lógica de antivirus
│   │   │   └── UserService.cs                   # Servicio para lógica de usuarios
│   │   └── DTOs/                                # Objetos de Transferencia de Datos
│   │       ├── AntivirusDto.cs                  # DTO para antivirus
│   │       └── UserDto.cs                       # DTO para usuarios
│   │
│   ├── ProyectAntivirusBackend.Domain/          # Capa de Dominio (Modelos de Negocio)
│   │   ├── Entities/                            # Entidades del dominio
│   │   │   ├── Antivirus.cs                     # Entidad Antivirus
│   │   │   └── User.cs                          # Entidad Usuario
│   │   ├── Enums/                               # Enumeraciones
│   │   │   └── UserRole.cs                      # Enumeración para roles de usuario
│   │   └── Exceptions/                          # Excepciones personalizadas
│   │       └── NotFoundException.cs             # Excepción para recursos no encontrados
│   │
│   ├── ProyectAntivirusBackend.Infrastructure/  # Capa de Infraestructura (Acceso a Datos)
│   │   ├── Data/                                # Contexto de Base de Datos
│   │   │   └── ApplicationDbContext.cs          # DbContext de la aplicación
│   │   ├── Repositories/                        # Repositorios de datos
│   │   │   ├── AntivirusRepository.cs           # Repositorio para antivirus
│   │   │   └── UserRepository.cs                # Repositorio para usuarios
│   │   ├── Configurations/                      # Configuraciones de entidades
│   │   │   ├── AntivirusConfiguration.cs        # Configuración de la entidad Antivirus
│   │   │   └── UserConfiguration.cs             # Configuración de la entidad Usuario
│   │   └── Migrations/                          # Migraciones de la base de datos
│   │       └── 20250101000000_InitialCreate.cs  # Migración inicial
│   │
│   └── ProyectAntivirusBackend.Tests/           # Pruebas Unitarias y de Integración
│       ├── UnitTests/                           # Pruebas unitarias
│       │   ├── AntivirusServiceTests.cs         # Pruebas para AntivirusService
│       │   └── UserServiceTests.cs              # Pruebas para UserService
│       └── IntegrationTests/                    # Pruebas de integración
│           ├── AntivirusControllerTests.cs      # Pruebas para AntivirusController
│           └── UserControllerTests.cs           # Pruebas para UserController
│
└── docs/                                        # Documentación del Proyecto
    ├── README.md                                # Documentación principal
    ├── Architecture.md                          # Detalles de la arquitectura
    └── API_Documentation.md                     # Documentación de la API
```
## 📌 Documentación de la API
La API está documentada con Swagger y puede consultarse en:
`http://localhost:5055/swagger/index.html`



## 📌 Guía de Uso de la API

### 🔹 Endpoints Principales

#### 📌 Autenticación

```http
POST /api/auth/login
```

- **Ejemplo de solicitud:**

  ```json
  {
    "email": "usuario@ejemplo.com",
    "password": "secreto123"
  }
  ```

- **Ejemplo de respuesta exitosa:**

  ```json
  {
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
  }
  ```

- **Notas:**
 - Asegúrese de incluir el token JWT en el encabezado de autorización de las solicitudes que requieran autenticación, utilizando el esquema `Beare.
 - El token tiene una validez de 24 hor.

#### 📌 Gestión de oportunidades

- 1 **Obtener todos las oportunidades**

   ```http
   GET /api/antivirus
   ```

   - **Descripción** Recupera una lista de todos los programas antivirus registrados en el sista.

   - **Ejemplo de respuesta:**

     ```json
     [
       {
         "id": 1,
         "nombre": "Antivirus Pro",
         "version": "1.2.3",
         "fechaActualizacion": "2025-01-15T10:00:00Z"
       },
       {
         "id": 2,
         "nombre": "SecureShield",
         "version": "4.5.6",
         "fechaActualizacion": "2025-02-10T14:30:00Z"
       }
     ]
     ```

- 2 **Obtener un oportunidad por ID**

   ```http
   GET /api/antivirus/{id}
   ```

   - **Descripción** Recupera la información de un programa antivirus específico mediante suD.

   - **Parámetros de ruta:**
     - `id` (in): Identificador único del antivis.

   - **Ejemplo de respuesta:**

     ```json
     {
       "id": 1,
       "nombre": "Antivirus Pro",
       "version": "1.2.3",
       "fechaActualizacion": "2025-01-15T10:00:00Z"
     }
     ```

- 3 **Crear una nueva oportunidad**

   ```http
   POST /api/antivirus
   ```

   - **Descripción** Agrega un nuevo programa antivirus al sista.

   - **Ejemplo de solicitud:**

     ```json
     {
       "nombre": "DefenderX",
       "version": "2.0.0",
       "fechaActualizacion": "2025-03-01T09:00:00Z"
     }
     ```

   - **Ejemplo de respuesta exitosa:**

     ```json
     {
       "id": 3,
       "nombre": "DefenderX",
       "version": "2.0.0",
       "fechaActualizacion": "2025-03-01T09:00:00Z"
     }
     ```

  - 4 **Actualizar una oportunidad existente**

   ```http
   PUT /api/antivirus/{id}
   ```

   - **Descripción** Actualiza la información de un programa antivirus existee.

   - **Parámetros de ruta:**
     - `id` (in): Identificador único del antivirus a actualir.

   - **Ejemplo de solicitud:**

     ```json
     {
       "nombre": "Antivirus Pro Plus",
       "version": "1.3.0",
       "fechaActualizacion": "2025-04-10T11:00:00Z"
     }
     ```

   - **Ejemplo de respuesta exitosa:**

     ```json
     {
       "id": 1,
       "nombre": "Antivirus Pro Plus",
       "version": "1.3.0",
       "fechaActualizacion": "2025-04-10T11:00:00Z"
     }
     ```

  -  5 **Eliminar un antivirus**

   ```http
   DELETE /api/antivirus/{id}
   ```

   - **Descripción** Elimina un programa antivirus del sista.

   - **Parámetros de ruta:**
     - `id` (in): Identificador único del antivirus a elimir.

   - **Ejemplo de respuesta exitosa:**

     ```json
     {
       "message": "Antivirus eliminado correctamente."
     }
     ```

#### 📌 Gestión de Usuarios

1. **Registro de nuevo usuario**

   ```http
   POST /api/users/register
   ```

   - **Descripció:** Permite registrar un nuevo usuario en el sisma.

   - **Ejemplo de solicitud:**

     ```json
     {
       "nombre": "Juan Pérez",
       "email": "juan.perez@ejemplo.com",
       "password": "ContraseñaSegura123"
     }
     ```

   - **Ejemplo de respuesta exitosa:**

     ```json
     {
       "id": 5,
       "nombre": "Juan Pérez",
       "email": "juan.perez@ejemplo.com"
     }
     ```

2. **Obtener perfil de usuario**

   ```http
   GET /api/users/profile
   ```

   - **Descripció:** Recupera la información del perfil del usuario autentido.

   - **Encabezados requeridos:**
     - `Authorizatin`: Bearer {ten}

   - **Ejemplo de respuesta:**

     ```json
     {
       "id": 5,
       "nombre": "Juan Pérez",
       "email": "juan.perez@ejemplo.com",
       "fechaRegistro": "2025-02-10T10:00:00Z"
     }
     ```

3. **Actualizar perfil de usuario**

   ```http
   PUT /api/users/profile
   ```

   - **Descripció:** Actualiza la información del perfil 

## 📌 Instrucciones de Despliegue
 **Compilar el proyecto:**
   ```bash
   dotnet publish -c Release
   ```



## 📌 Contribuciones

### Contributions are always welcome!

Si deseas contribuir:

  - Haz un fork del proyecto.
  - Crea una nueva rama (`git checkout -b feature/  nueva-funcionalidad`).
  - Realiza tus cambios y haz commit (`git commit -m  'Añadir nueva funcionalidad'`).
  - Sube tus cambios (`git push origin feature/nueva-funcionalidad`).
  - Abre un Pull Request.


## License

[GNU General Public License v3.0](https://choosealicense.com/licenses/gpl-3.0/)
## Authors
Repositorios                 | Link  
-------------------------|------
[![GitHub](https://img.shields.io/badge/GitHub-Repository-181717?style=flat&logo=github&logoColor=white)](https://github.com) | [@Andrés Tamayo Marín](https://github.com/baldurt1992)
[![GitHub](https://img.shields.io/badge/GitHub-Repository-181717?style=flat&logo=github&logoColor=white)](https://github.com) | [@David Gutierrez Gordillo](https://github.com/davalejo)
[![GitHub](https://img.shields.io/badge/GitHub-Repository-181717?style=flat&logo=github&logoColor=white)](https://github.com) | [@Diana López Ramos](https://github.com/Dianakrol)
[![GitHub](https://img.shields.io/badge/GitHub-Repository-181717?style=flat&logo=github&logoColor=white)](https://github.com) | [@Diana Roldan Rodriguez](https://github.com/DianaR162)
[![GitHub](https://img.shields.io/badge/GitHub-Repository-181717?style=flat&logo=github&logoColor=white)](https://github.com) | [@Geny Vargas Suarez](https://github.com/genyvarsua)
[![GitHub](https://img.shields.io/badge/GitHub-Repository-181717?style=flat&logo=github&logoColor=white)](https://github.com) | [@Alexandra Cuartas Orozco](https://github.com/Cuoralex)





