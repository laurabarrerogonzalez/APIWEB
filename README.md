#  Proyecto: Apiweb para un pequeño comercio.

##  SNEAKER CITY API 

<img src="https://i.postimg.cc/NFzsF8N3/Black-and-White-Modern-Shoes-Store-Logo.png" alt="" width="500px" />

##### Tabla de contenido:
- [Proyecto](#Proyecto)
- [Requisitos](#Requisitos)
- [Instalacion](#Instalacion)
- [Uso](#Uso)
- [Equipo](#Equipo)
- [Pilas](#Pilas)
- [Metodología](#Metodología)

## Proyecto

<p>Sneaker City API es una API web de venta de zapatillas que permite a los proveedores administrar su catálogo de productos y clientes, así como a los clientes realizar y ver sus pedidos. Los proveedores pueden agregar, modificar y eliminar registros de productos, y también pueden ver el stock de los productos y consultarlos por marca.
</p>

## Requisitos

<p>Para ejecutar la API, asegúrate de tener instaladas las siguientes herramientas:</p>

<ul><li> Visual Studio Code 2022.</li>
<li> .NET Core.</li>
<li> SQL Server.</li>
<li> JSON Server (para pruebas).</li></ul>

###### Instalacion

<ol>
<li>Clona el repositorio desde GitHub:
git clone https://github.com/laurabarrerogonzalez/APIWEB.git</li>
  
<li>Abre el proyecto en Visual Studio Code:.</li>
  
<li>Configura la cadena de conexión de la base de datos en el archivo appsettings.json:</li>
  <img src="https://i.postimg.cc/NFzsF8N3/Black-and-White-Modern-Shoes-Store-Logo.png" alt="" width="300px" />
  
<li>Crea la base de datos ejecutando las migraciones:
dotnet ef database update.</li>
</ol>

###### Uso

La API "Sneaker City" cuenta con los siguientes endpoints para gestionar los proveedores, productos, clientes y pedidos:

## Proveedores

- `GET /api/providers`: Obtiene todos los proveedores.
- `GET /api/providers/{id}`: Obtiene un proveedor por su ID.
- `POST /api/providers`: Agrega un nuevo proveedor.
- `PUT /api/providers/{id}`: Actualiza un proveedor existente.
- `DELETE /api/providers/{id}`: Elimina un proveedor por su ID.

## Productos

- `GET /api/products`: Obtiene todos los productos del catálogo.
- `GET /api/products/{id}`: Obtiene un producto por su ID.
- `POST /api/products`: Agrega un nuevo producto al catálogo.
- `PUT /api/products/{id}`: Actualiza un producto existente.
- `DELETE /api/products/{id}`: Elimina un producto por su ID.
- `GET /api/products/brands/{brand}`: Obtiene todos los productos de una marca específica.

## Clientes

- `GET /api/clients`: Obtiene todos los clientes.
- `GET /api/clients/{id}`: Obtiene un cliente por su ID.
- `POST /api/clients`: Agrega un nuevo cliente.
- `PUT /api/clients/{id}`: Actualiza un cliente existente.
- `DELETE /api/clients/{id}`: Elimina un cliente por su ID.

## Pedidos

- `GET /api/orders`: Obtiene todos los pedidos.
- `GET /api/orders/{id}`: Obtiene un pedido por su ID.
- `POST /api/orders`: Agrega un nuevo pedido.
- `PUT /api/orders/{id}`: Actualiza un pedido existente.
- `DELETE /api/orders/{id}`: Elimina un pedido por su ID.

Para acceder a las gestiones de proveedores, se debe proporcionar una contraseña

###### Equipo
- Laura Barrero  https://github.com/laurabarrerogonzalez /Scrum Master
- Christian Jaiki https://github.com/ChristianJaiki12
- Juan Pablo Lumbi https://github.com/juanpablolumbipoveda

## Pilas
:wrench:

#### Tecnologías:
<p float="left">
  <img src="https://i.postimg.cc/Bn27zs1r/c-sharp-c-logo-02-F17714-BA-seeklogo-com.png" alt="" width="50px" />
  
  <img src="https://i.postimg.cc/nVQWmvhV/entity-image.png" alt="" width="40px" /> 
  
  <img src="https://i.postimg.cc/TPw73bs6/NET-Core-Logo-svg.png" alt="" width="50px" />
</p>

#### Herramientas:

<p float="left">
  <img src="https://i.postimg.cc/zf6jDcWC/microsoft-sql-server4529.jpg" alt="" width="70px" />
  
  <img src="https://i.postimg.cc/fbGcQ0n5/Visual-Studio2022-1000x600.jpg" alt="" width="70px" /> 
  
  <img src="https://i.postimg.cc/cLjYf8HZ/json-1.png" alt="" width="70px" />
  
  <img src="https://i.postimg.cc/43VKtLqb/github-logo-vector.png" alt="" width="70px" />
  
 </p>

## Metodología

<ul>
<li>Metodologia agil </li>
<li>Cada miembro del equipo trabaja en su propio ordenador y crea una rama separada en el repositorio para trabajar en nuevas características o correcciones de errores. Las ramas fueron cada uno con su propio nombre</li>
<li>Creación de ramas: Se utilizo 5 ramas para gestionar el flujo de trabajo:

- Master (o main): Esta rama contiene el código estable y en producción.
- Develop: Esta rama es donde se integran todas las características y se realizan las pruebas previas a la producción.</li>
- Rama independiente ( Juan pablo, LauraBarrero, Christian): Estas son ramas independientes dodne cada uno trabajo segun la tarea asignada.</li>

<p>Esta metodología nos permite trabajar de manera colaborativa y mantener un flujo de trabajo ordenado y eficiente. La utilización de ramas y fusiones nos ayuda a evitar conflictos y mantener un historial claro de cambios en el código. Además, las revisiones de código y pruebas frecuentes garantizan la calidad del software que entregamos.

¡Gracias por tu interés en nuestro proyecto "Sneaker City API"! Si tienes alguna otra pregunta o necesitas más información, no dudes en contactarnos. Estamos emocionados de seguir desarrollando y mejorando nuestra API para ofrecerte una experiencia excepcional en la venta de zapatillas.</p>
