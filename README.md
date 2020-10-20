# comercial

<img src="https://le-cdn.website-editor.net/4aa03d26578c4b949aa4f65e52d7e4c0/dms3rep/multi/opt/Logo+Vegaflor+copy-4df30103-320w.png" align="right" alt="Vegaflor" width="148" height="50">

## Backend
| Herramienta | Version |
| ------ | ------ |
| Compilador | **JDK 1.8** |
| Ide | **Cualquiera** |
| Administrador de Dependencias | **gradle 4.6** `Ya esta en el proyecto, no es necesario instalar` |
| Framwork | **Spring Boot 2.1.2.RELEASE** `gradle lo instala` |

### Configuración inicial
Si es la primera vez que configura el proyecto en eclipse
<details><summary><b>Ver instrucciones</b></summary>

1. Descargar el proyecto **[comun]** al mismo nivel de comercial.
2. En eclipse para gradle 4.6 se debe instalar el plugin:
    ```sh
    https://dist.springsource.com/release/TOOLS/gradle
    ```
3. **Import...** -> **Gradle (STS)** -> **Gradle (STS) Project** `Se usara la version de gradle que esta dentro del proyecto configurada: gradle/wrapper/gradle-wrapper.properties`
4. Instalar lombok `en caso de que el Ide no lo tenga instalado`
    <details><summary><b>En eclipse -> ver instrucciones</b></summary>

    1. Ir al proyecto `comercial-backend-comando-aplicacion`
    2. En `Gradle Dependencies`
    3. Click derecho en el jar: `lombok-1.16.18.jar`
    4. **Run As** -> **Java Application**
    5. En la ventana de instalacion de lombok, seleccionar el eclipse e instalar
    </details>

5. Configurar arranque:
    1. **En eclipse** -> **Run** -> **Run Configurations**
    2. Click derecho en **Java Application** -> **New Configuration**
    3. Diligenciar:
        * Name: `comercial`
        * Project: `comercial-backend`
        * Main class: `com.vegaflor.core.Application`
        * Arguments -> VM arguments: `-Dspring.profiles.active=local`
        * Apply -> Run
</details>

### Ejecutar
**Run As...** -> **comercial**

[comun]: https://github.com/grupovegaflor/comun

## Frontend
Compilador | Viene en el navegador
Ide | Cualquiera 
Admin Depend | npm >= 6 "Instalar Node.js"
Framwork | Angular CLI 7.3.3 "npm install -g @angular/cli@7.3.3" -- https://victorroblesweb.es/2018/11/20/instalar-angular-7-paso-a-paso/
# Ejectuar
    # Instalar el token para importar el comun-frontend -- https://stackoverflow.com/questions/23210437/npm-install-private-github-repositories-by-dependency-in-package-json
        # En https://github.com/ ir a Settings -> Developer settings -> Personal access tokens -> Generate new token
        # Reemplazar <TOKEN_HERE> por el token y ejecutar
            git config --global url."https://<TOKEN_HERE>:x-oauth-basic@github.com/".insteadOf https://x-oauth-basic@github.com/
    # Instalar Dependencias -- npm notice created a lockfile as package-lock.json. You should commit this file.
        npm install
    # Agregar al archivo Hosts el dominio local
        # En MAC -- https://www.hostinet.com/formacion/hosting-alojamiento/editar-archivo-hosts-mac-os-x-macos/
            127.0.0.1	vegasoft.dev.local
    # Modificar en el archivo environment.ts las propiedades
        URLCognito: `https://vegasoftdevelop.auth.us-east-1.amazoncognito.com/login?response_type=code&client_id=3uplh7kivsv4965k6apsoo9jk9&redirect_uri=https://vegasoft.dev.local:4200`,
        URLCognitoLogout: 'https://vegasoftdevelop.auth.us-east-1.amazoncognito.com/logout?client_id=3uplh7kivsv4965k6apsoo9jk9&logout_uri=https://vegasoft.dev.local:4200/',
    # Ejecutar aplicacion
        npm start
    # Ingresar a la aplicacion
        https://vegasoft.dev.local:4200/comercial/home
        US: pruebas
        PW: 123456
        
# DB local
# Instalar docker
# Correr imagen de SQL Server -- https://hub.docker.com/_/microsoft-mssql-server
    docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Vegasoft!Passw0rd' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-CU8-ubuntu
# Copiar el BackUp de la BD en el contenedor de Docker
    # Buscar el nombre del contenedor
        docker ps
    # Reemplazar <NAME_CONTAINER> por el nombre del contenedor y ejecutar
        docker exec -it <NAME_CONTAINER> mkdir /var/opt/mssql/backup
    # Reemplazar <ROUTE_BACKUP> por la ruta del BackUp y ejecutar
        docker cp <ROUTE_BACKUP>/vegasoftdb_2020_06_26_Test_OK.bak <NAME_CONTAINER>:/var/opt/mssql/backup
# Instalar cliente
    # En MAC es recomendado el Azure Data Studio -- https://docs.microsoft.com/en-us/sql/azure-data-studio/quickstart-sql-server?view=sql-server-ver15
        # Instar cliente Azure Data Studio -- https://www.quackit.com/sql_server/mac/install_azure_data_studio_on_a_mac.cfm
        # Habilitar el Azure Data Studio para Restaurar BD -- https://techcommunity.microsoft.com/t5/sql-server-engine/sql-operation-studio-enable-preview-features-azure-data-studio/m-p/1090921
        # Restaurar la BD a partir del BackUp -- https://www.quackit.com/sql_server/mac/how_to_restore_a_bak_file_using_azure_data_studio.cfm
# Datos BD
    BD: vegasoftdb
    US: sa
    PW: Vegasoft!Passw0rd
    PT: 1433
# Modificar en el archivo application-local.yml las propiedades
    jdbcUrl: jdbc:sqlserver://localhost;databaseName=vegasoftdb
    username: sa
    password: Vegasoft!Passw0rd
    spring.flyway.url: jdbc:sqlserver://localhost;databaseName=vegasoftdb
    spring.flyway.user: sa
    spring.flyway.password: Vegasoft!Passw0rd

    pruebas en local
        front
        Backend
    Ejecutar jar en local

    Subir ambiente local
        Docker BD
        Ejecutar jar seguridad en local
        Ejecutar jar produccion en local

    produccion
        /Users/sebastian/gradle/gradle-6.6/bin/gradle build -x test
        java -Dspring.profiles.active=local -jar build/libs/produccion-backend-0.0.1-SNAPSHOT.jar
    
    docker run
    docker stop
    docker ps -a
    docker start
    docker rm