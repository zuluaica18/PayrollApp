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
<details><summary>Si es la primera vez que configura el proyecto en <b>eclipse</b>  <b>(Click aqui)</b></summary>

1. Descargar el proyecto **[comun]** al mismo nivel de comercial.
2. En eclipse para gradle 4.6 se debe instalar el plugin:
    ```sh
    https://dist.springsource.com/release/TOOLS/gradle
    ```
3. **Import...** -> **Gradle (STS)** -> **Gradle (STS) Project** `Se usara la version de gradle que esta dentro del proyecto configurada: gradle/wrapper/gradle-wrapper.properties`
4. Instalar lombok `en caso de que el Ide no lo tenga instalado`
    <details><summary><b>En eclipse</b>  <b>(Click aqui)</b></summary>

    * Ir al proyecto `comercial-backend-comando-aplicacion`
    * En `Gradle Dependencies`
    * Click derecho en el jar: `lombok-1.16.18.jar`
    * **Run As** -> **Java Application**
    * En la ventana de instalacion de lombok, seleccionar el eclipse e instalar
    </details>

5. Configurar arranque:
    * **En eclipse** -> **Run** -> **Run Configurations**
    * Click derecho en **Java Application** -> **New Configuration**
    * Diligenciar:
        ```yaml
        Name: comercial
        Project: comercial-backend
        Main class: com.vegaflor.core.Application
        Arguments -> VM arguments: -Dspring.profiles.active=local
        Apply -> Run
        ```
</details>

### Ejecutar
**Run As...** -> **comercial**

[comun]: https://github.com/grupovegaflor/comun

## Frontend
| Herramienta | Version |
| ------ | ------ |
| Compilador | **Viene en el navegador** |
| Ide | **Cualquiera** |
| Administrador de Dependencias | **npm >= 6** `Instalar Node.js` |
| Framwork | **[Angular CLI 7.3.3]** `npm install -g @angular/cli@7.3.3` |

### Configuración inicial
<details><summary><b>Si es la primera vez que configura el proyecto -> ver instrucciones</b></summary>

1. Instalar el [token] para importar el comun-frontend
    * En https://github.com/ ir a **Settings** -> **Developer settings** -> **Personal access tokens** -> **Generate new token**
    * Reemplazar **<TOKEN_HERE>** por el token y ejecutar
        ```sh
        git config --global url."https://<TOKEN_HERE>:x-oauth-basic@github.com/".insteadOf https://x-oauth-basic@github.com/
        ```
2. Instalar Dependencias. **Pendiente:** `npm notice created a lockfile as package-lock.json. You should commit this file.`
    ```sh
    npm install
    ```
3. Agregar al archivo **Hosts** el dominio local
    ```yaml
    127.0.0.1	vegasoft.dev.local
    ```
    * [En MAC]
4. Modificar en el archivo **environment.ts** las propiedades
    ```json
    URLCognito: `https://vegasoftdevelop.auth.us-east-1.amazoncognito.com/login?response_type=code&client_id=3uplh7kivsv4965k6apsoo9jk9&redirect_uri=https://vegasoft.dev.local:4200`,
    URLCognitoLogout: 'https://vegasoftdevelop.auth.us-east-1.amazoncognito.com/logout?client_id=3uplh7kivsv4965k6apsoo9jk9&logout_uri=https://vegasoft.dev.local:4200/',
    ```
</details>

### Ejecutar
1. Ejecutar aplicacion
    ```sh
    npm start
    ```
2. Ingresar a la aplicacion
    * https://vegasoft.dev.local:4200/comercial/home
    * Login:
        ```yaml
        US: pruebas
        PW: 123456
        ```

[Angular CLI 7.3.3]: https://victorroblesweb.es/2018/11/20/instalar-angular-7-paso-a-paso/
[token]: https://stackoverflow.com/questions/23210437/npm-install-private-github-repositories-by-dependency-in-package-json
[En MAC]: https://www.hostinet.com/formacion/hosting-alojamiento/editar-archivo-hosts-mac-os-x-macos/

## DB local
<details><summary><b>Si desea utilizar una BD local con docker -> ver instrucciones</b></summary>

1. Instalar docker
2. Correr imagen de [SQL Server]
    ```sh
    docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=1035911044' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-CU8-ubuntu
    ```
    <details><summary><b>Pequeño manual de docker -> ver instrucciones</b></summary>

    * Instanciar una **imagen** en un nuevo **contenedor**
        ```sh
        docker run ...
        ```
    * Detener **contenedor**
        ```sh
        docker stop <NAME_CONTAINER>
        ```
    * Ver todos los **contenedores** detenidos
        ```sh
        docker ps -a
        ```
    * Reanudar **contenedor**
        ```sh
        docker start <NAME_CONTAINER>
        ```
    * Borrar **contenedor** `Previamente se debe detener`
        ```sh
        docker rm <NAME_CONTAINER>
        ```
    </details>

3. Copiar el **BackUp de la BD** en el contenedor de Docker
    * Buscar el nombre del contenedor
        ```sh
        docker ps
        ```
    * Reemplazar **<NAME_CONTAINER>** por el nombre del contenedor y ejecutar
        ```sh
        docker exec -it <NAME_CONTAINER> mkdir /var/opt/mssql/backup
        ```
    * Reemplazar **<ROUTE_BACKUP>** por la ruta del **BackUp de la BD** y ejecutar
        ```sh
        docker cp <ROUTE_BACKUP>.bak <NAME_CONTAINER>:/var/opt/mssql/backup
        ```
4. Instalar cliente
    * En MAC es recomendado el [Azure Data Studio]
        * Instar el [cliente Azure Data Studio]
        * Habilitar el Azure Data Studio para [Restaurar BD]
        * Restaurar la BD a partir del [BackUp]
5. Datos BD
    ```yaml
    BD: VegaSoftDB
    US: sa
    PW: 1035911044
    PT: 1433
    ```
6. Validar en el archivo **application-local.yml** que las propiedades concuerden:
    ```yaml
    jdbcUrl: jdbc:sqlserver://localhost;databaseName=VegaSoftDB
    username: sa
    password: 1035911044

    spring.flyway.url: jdbc:sqlserver://localhost;databaseName=VegaSoftDB
    spring.flyway.user: sa
    spring.flyway.password: 1035911044
    ```
</details>

[SQL Server]: https://hub.docker.com/_/microsoft-mssql-server
[Azure Data Studio]: https://docs.microsoft.com/en-us/sql/azure-data-studio/quickstart-sql-server?view=sql-server-ver15
[cliente Azure Data Studio]: https://www.quackit.com/sql_server/mac/install_azure_data_studio_on_a_mac.cfm
[Restaurar BD]: https://techcommunity.microsoft.com/t5/sql-server-engine/sql-operation-studio-enable-preview-features-azure-data-studio/m-p/1090921
[BackUp]: https://www.quackit.com/sql_server/mac/how_to_restore_a_bak_file_using_azure_data_studio.cfm

## Subir ambiente local para desarrollar
<details><summary>Subir el contenedor de <b>SQL Server</b>  <b>(Click aqui)</b></summary>

* Buscar el **contenedor**
    ```sh
    docker ps -a
    ```
* Reanudar **contenedor** `en caso de que este detenido`
    ```sh
    docker start <NAME_CONTAINER>
    ```
</details>

<details><summary>Subir el jar de <b>seguridad</b>  <b>(Click aqui)</b></summary>

* Ejecutar jar
</details>

<details><summary>Subir el jar de <b>produccion</b>  <b>(Click aqui)</b></summary>

* En una **consola** ubicarse en la ruta del proyecto **produccion**
* **Compilar** con la version de **gradle 4.6**
    ```sh
    gradle build -x test
    ```
* Ejecutar jar
    ```sh
    java -Dspring.profiles.active=local -jar build/libs/produccion-backend-0.0.1-SNAPSHOT.jar
    ```
</details>

    pruebas en local
        front
        Backend
    Ejecutar jar en local

    

    
        
        