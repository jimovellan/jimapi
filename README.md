<h1>API CON ENVIO DE MENSAJES </h1>

<h2>¿Que hace el proyecto?</h2>
<p>
publicación de mensajes a clientes previamente subscritos.
<p>
<h2>Tecnologias usadas<h2>
<ul>
<li> VS2019</li>
<li> .net core 3.1</li>
<li> SignalR (comunicación entre cliente y servidor por medio de subscripciones)</li>
<li> ILogger (Logs, se usa la parte básica logs por consola)</li>
<li> AutoMapper (mapeo de entidades)</li>
<li> Swagger: documentación automatica de la api</li>
<li> Inyección de dependencias proporcionada por asp.net core 3.1</li>
</ul>

<h2>Estructura del proyecto</h2>
<p>
<b>jim.test<b>
</p>
    <ul>
    <li>
    - Test unitarios
    </li>
    <ul>
<p>
<b>jim.common </b>
</p>
<ul>
    <li>
    - Excepciones custom para la aplicación
    </li>
    <li>
    - Ficheros de recursos
    </li>
    <li>
    - Errores para devolver a usuario
    </li>
    
</ul>
<p>
<b>
jim.models 
</b>
</p>
<ul>
<li>
    - entidades
</li>
<li>
    - dtos
</li>
<ul>
<p>
<b>
jim.services 
</b>
</p>
<ul>
    <li>
    Parte de la lógica de proyecto y enlace con DAL si hubiese
    </li>
    <li>
    Servicios comunes a toda la aplicación
    </li>
    </ul>
<p>
<b>
jim.api
</b>
</p>
<ul>
<li>
    - Punto de exposición al exterior como web api
</li>
</ul>
<p>
<b>
jim.client
<b>
</p>
<ul>
<li>
    - proyecto de consola que se suscribe a los mensajes.
    </li>
</ul>

<h2>
Puesta En Marcha
</h2>
<p>
    Al compilar los proyectos nugget debería poder resolver todos los paquetes necesarios.
    El proyecto se compone de dos partes:
<p>
<p>
<b>
jim.api:
</b>
<p> 
                    parte servidora, rest Api y donde se pueden subscribir los clientes para recibir los mensajes.
                    - Establecer como proyecto de inicio compilar y desplegar en el IIS.
                    - No es necesario en principio tocar nada de configuración.
                    - se puede utilizar la ruta /Swagger para acceder a la documentación de la api y hacer desde alli las
                      pruebas a los EndPoint o Usar PostMan
</p> 
                  
                    EndPoints:
                    
                    - Obtener todos los usuarios conectados
                    Get /User: devuelve todos los usuarios conectados
                    
                    - Obtener info de un usuario concreto que se encuentre conectado
                    Get    /User/{IdUsuario} Devueve la info de un usuario
                    
                    
                    envia un mensaje a todos los usuarios subsritos al canal general
                    Post /Msg
                            {
                                "body":"texto del mensaje"
                            }
                    
                    
                    - Enviar un mensaje a un usuario concreto
                    Put /Msg/{IdUsuario}
                            {
                                "body":"texto del mensaje"
                            }
                    
        2) jim.client:

                    Proyecto de consola que se subscribe a los mensajes del servidor,
                    - IMPORTANTE: configurar la ruta donde se encuentra el proyecto servidor jim.api
                      desde el fichero appsettings.json alli estableceremos la ruta:
                      http://{HostServidor}/Hub/Message

                    - Establecer como proyecto de inicio y compilar deberia bajarse todas las dependencias solo

                    - Abrir tantas consolas como deseemos, al arrancar:
                        1) Nos pedira un nombre de usuario (Por identificar a parte de por id a los usuarios)
                        2) Cuando se conecte nos devolvera un mensaje de conectado al canal general.
                        3) estaremos subscritos hasta que le demos a otra tecla para finalizar o cerremos la consola






