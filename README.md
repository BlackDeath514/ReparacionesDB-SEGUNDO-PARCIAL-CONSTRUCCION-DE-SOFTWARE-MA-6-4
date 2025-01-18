## Sistema de Gestión para Reparaciones de Celulares
#### Descripción del Proyecto
Este proyecto es un sistema desarrollado en **Visual Studio** C# basado en el modelo **MVC (Modelo-Vista-Controlador)** para gestionar eficientemente reparaciones de celulares. El sistema permite realizar operaciones como registro de reparaciones, clientes, técnicos, equipos celulares, entre otras funcionalidades relacionadas con el negocio.
#### **Arquitectura del Proyecto**
El proyecto está estructurado en tres capas:

- Capa de Datos:
	- Gestiona la conexión y operaciones directas con la base de datos.
	- Utiliza SQL Server Management Studio para administrar los datos.
	- Contiene los procedimientos almacenados y consultas necesarias para el funcionamiento del sistema.
- Capa de Negocios:
	- Implementa la lógica empresarial del sistema.
	- Maneja validaciones, procesos intermedios y transformación de datos entre las capas de datos y presentación.
- Capa de Presentación:
	- Es la interfaz gráfica del usuario (GUI).
	- Permite al usuario interactuar con el sistema para realizar operaciones.
	- Está diseñada para ser intuitiva y eficiente.
	
#### Base de datos
El sistema se conecta a una base de datos en SQL Server, la cual contiene las tablas y relaciones necesarias para almacenar información relacionada con:
- Clientes.
- Técnicos
- Reparaciones
- Equipos celulares

#### Documentación
Se incluye una carpeta llamada Documentación dentro del repositorio, que contiene:
- Documento de plan de pruebas
- Documento de especificación
- Manual técnico para instalación y configuración.
- Bitácoras

#### Requisitos
##### Software Necesario
- Visual Studio 2022 o superior (compatible con proyectos en C#).
- SQL Server Management Studio (SSMS) para gestionar la base de datos.
- .NET Framework instalado en tu máquina.