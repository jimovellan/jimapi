<h1>API CON ENVIO DE MENSAJES </h1>

<h2>¿Que hace el proyecto?</h2>
<p>
Publicación de mensajes a clientes previamente subscritos.
<p>
<h2>Tecnologias usadas</h2>
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
<b>jim.test</b>
</p>
    <ul>
    <li>
    - Test unitarios
    </li>
    </ul>
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
    <li>
     - Todo lo necesario para uso de cualquier proyecto, extensiones ...
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
</ul>
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
</b>
</p>
<ul>
    <li>
    proyecto de consola que se suscribe a los mensajes.
    </li>
</ul>

<h2>
Puesta En Marcha
</h2>
<p>
    Al compilar los proyectos nugget debería poder resolver todos los paquetes necesarios.
    El proyecto se compone de dos partes, jim.api y jim.client ambas deberemos compilarlas estableciendo cada uno como proyecto de inicio:
</p>

<h3>
1) (PARTE SERVIDORA, REST API) jim.api, Configuración y uso:
</h3>

<p> 
                    parte servidora, rest Api y donde se pueden subscribir los clientes para recibir los mensajes que se publican.
</p>
<ul>
        <li> Establecer como proyecto de inicio compilar y desplegar en el IIS.</li>
        <li>No es necesario en principio tocar nada de configuración.</li>
        <li>se puede utilizar la ruta /Swagger para acceder a la documentación de la api y hacer desde alli las
                        pruebas a los EndPoint o Usar PostMan.</li>
               
  </ul>
<h3> EndPoints </h3>
<blockquote>
<h4>USUARIOS END POINT</h4>
<b>GET</b>

<p>/User</p>
<p>Devuelve todos los usuarios conectados</p>
<b>GET</b>
<p>/User/<b>{IdUsuario}</b></p>
<p>Devuelve información del usuario buscado</p>
</blockquote>

<blockquote>
<h4>MENSAJES END POINT</h4>
<b>POST</b>
<p>Envio de un mensaje a todos los usuarios</p>
<p>/Msg<p>
<pre>
                            {
                                "body":"texto del mensaje"
                            }
                    
                    
                  
            
</pre>
<b>PUT</b>
<p>Envio de un mensaje a un usuario determinado</p>
<p>/Msg/<b>{IdUsuario}</b><p>
<pre>
                            {
                                "body":"texto del mensaje"
                            }
                    
                    
                  
            
  </pre>  
</blockquote> 
<blockquote> 
<H4>Conexion de los clientes para subscribirse</H4>
    <p>
        /hub/Message
    </p>
    <p>
        Aqui se encuentra el punto donde se conectan mediante socket a las publicaciones
    </p>
</blockquote> 
                            
<h3>
2) (PARTE CLIENTE, CONSOLA) jim.client, configuración y uso:
</h3>
<p>
                    Proyecto de consola que se subscribe a los mensajes del servidor
</p>
<ul>
                     <li><p><b>IMPORTANTE:</b> configurar la ruta donde se encuentra el proyecto servidor <b>jim.api</b> desde el fichero appsettings.json que se encuentra en el proyecto <b>jim.client</b> alli estableceremos la ruta </p></li>
<pre>
                                        {
                                          "endpoints": 
                                          {

                                            "ServerHub": "http://{HOST_SERVIDOR_JIM.API}/Hub/Message"

                                          }
</pre>
    
<li>Establecer como proyecto de inicio y compilar deberia bajarse todas las dependencias solo.</li>

<li>Abrir tantas consolas como deseemos, al arrancar cada una de ellas estos serán los pasos</li>
<ol>
<li> Nos pedira un nombre de usuario (Por identificar a parte de por id a los usuarios)</li>
<li>Cuando se conecte nos devolvera un mensaje de conectado al canal general.</li>
<li>estaremos subscritos hasta que le demos a una tecla para finalizar o cerremos la consola</li>
</ol>
</ul>






