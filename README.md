# titulo: proyecto sistema de gestion de usuarios
Este desarrollo se desarrollo con el framework ASP.NET CORE con la arquitectura MVC, 
* se implemento los patrones de diseño Repositorio para desacoplar la logica de las clases proporcianadas por el EntityFramework para la base de datos SqlServer Para que si se quiere implementar otro provedor de base de datos se pueda agregrar una nueva clase 
 con otra implementacion de los metodos y no se afecte el controlador.
 Tambien se utilizo el patron de diseño inyeccion de depencencias paraq ue el controlador no dependa de los metodos del entityFramework si no de una interfax creada con sus metodos establecidos paraq ue no dependa de clase de contexto de entityFramwork si que de la interfax creada.
 * El ORM utilizado es EntityFrameWork el cual se configuro con agregando las librerias indicadas:
- Microsoft.EntityFrameworkCore.Tools
 - Microsoft.EntityFrameworkCore.SqlServer
 - Microsoft.EntityFrameworkCore.Design
 - Microsoft.EntityFrameworkCore
 - se agrego el link de coneccion en el archivo appsettings.json
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=Usuario;User Id=sa;Password=SqlServer@:c19;TrustServerCertificate=True"
  },
- luego en el archivo Program.cs se registro el servido para la conexion para la base de ddatos sql server con el link de conexion antes hecho
  builder.Services.AddDbContext<AppDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

  - luego se realizo las migraciones para crear la base de datos y la tablas y campos con los siguientes comandos:
  - dotnet ef migrations add InitialCreate
  - dotnet ef database update
    
## modelos de las paginas creadas en el proyecto web

<h3>Pagina incio</h3>
<img src="https://i.ibb.co/7bVf27X/Listado-Usuarios.png" alt="Listado-Usuarios" border="0">

<h3>Pagina de crear</h3>
<img src="https://i.ibb.co/SsBYfjh/Creacion.png" alt="Creacion" border="0">

<h3>Pagina de editar</h3>
<img src="https://i.ibb.co/3d3Pq3r/editar.png" alt="editar" border="0">

<h3>Pagina de Eliminar</h3>
<img src="https://i.ibb.co/yScRNTc/Eliminar.png" alt="Eliminar" border="0">

<h3>Servicio Api REST</h3>
<a href="https://ibb.co/xSL2vWG"><img src="https://i.ibb.co/0j2nNTZ/aPI.png" alt="aPI" border="0"></a>

## Autor
Este proyecto fue realizado por David Esteban Rodriguez 
