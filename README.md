# Go Starter App

![technology Go](https://img.shields.io/badge/technology-go-blue.svg)

This is a basic Go application created by Fury to be used as a starting point for your project.

### First run


1. On the project root folder, before running
    ```sh
    go mod tidy
    ```
2. Locally it can be run with 2 profiles:
    * The first one raises a sqlite base in memory. For this they have to set the environment variable `SCOPE=local`.
    * The second raises pointing to the development mysql: set the environment variable `SCOPE=local-pmdev`.
    * <details><summary><b>Environment variables</b></summary>

        ```sh
        SCOPE=local-mysql;
        DB_MYSQL_DESAENV04_PMDEV_PMDEV_WPROD_USERNAME=🔥YOUR_DB_USER🔥;
        DB_MYSQL_DESAENV04_PMDEV_PMDEV_WPROD=🔥YOUR_DB_PASSWORD🔥;
        DB_MYSQL_DESAENV04_PMDEV_PMDEV_ENDPOINT=proxysql.master.meliseginf.com:6612
        ```
        </details>
    * <details><summary>Local DB, Si desea utilizar una <b>BD local con docker</b>  `Opcional`</summary>

        1. Instalar docker
        2. Correr imagen de [SQL Server]
            ```sh
            docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Vegasoft!Passw0rd' -p 1433:1433 --name sql_server -d mcr.microsoft.com/mssql/server:2017-CU8-ubuntu
            ```
            <details><summary><b>Pequeño manual de docker</b>  <b>(Click aqui)</b></summary>

            * Instanciar una **imagen** en un nuevo **contenedor**
                ```sh
                docker run --name sql_server ...
                ```
            * Detener **contenedor**
                ```sh
                docker stop sql_server
                ```
            * Consultar el estado del **contenedor**
                ```sh
                docker ps -a
                ```
            * Reanudar **contenedor**
                ```sh
                docker start sql_server
                ```
            * Borrar **contenedor** `Previamente se debe detener`
                ```sh
                docker rm sql_server
                ```
            * Ver log del **contenedor**
                ```sh
                docker logs sql_server
                ```
            </details>

        3. Cambiar la **contraseña** del usuario **sa**
            * Conectarse al sqlcmd del **contenedor**
                ```sh
                docker exec -it sql_server /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P 'Vegasoft!Passw0rd'
                ```
            * Ejecutar los siguientes **comandos** en el mismo orden
                ```sh
                ALTER LOGIN sa ENABLE;
                GO
                ALTER LOGIN sa WITH PASSWORD = '1035911044', CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF;
                GO
                exit
                ```
        4. Copiar el **BackUp de la BD** en el contenedor de Docker
            * Validar quel **contenedor** este corriendo
                ```sh
                docker ps -a
                ```
            * Crear directorio en el **contenedor**
                ```sh
                docker exec -it sql_server mkdir /var/opt/mssql/backup
                ```
            * Reemplazar **<ROUTE_BACKUP>** por la ruta del **BackUp de la BD** y ejecutar
                ```sh
                docker cp <ROUTE_BACKUP>.bak sql_server:/var/opt/mssql/backup
                ```
        5. Instalar cliente
            * En MAC es recomendado el [Azure Data Studio]
                * Instar el [cliente Azure Data Studio]
                * Habilitar el Azure Data Studio para [Restaurar BD]
                * Restaurar la BD a partir del [BackUp]
        6. Datos BD
            ```yaml
            BD: VegaSoftDB
            US: sa
            PW: 1035911044
            PT: 1433
            ```
        7. Validar en el archivo **application-local.yml** que las propiedades concuerden:
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

3. Then you can run it with the command
    ```sh
    cd cmd/app
    go run main.go
    ```
    or
    ```sh
    fury run
    ```
4. And check http://localhost:8080/ping to verify it's running.
5. To run the automated tests you can use
    ```sh
    go test ./...
    ```
    or
    ```sh
    fury test
    ```
