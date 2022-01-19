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
        SCOPE=local-pmdev;
        DB_MYSQL_DESAENV04_PMDEV_PMDEV_WPROD_USERNAME=🔥YOUR_DB_USER🔥;
        DB_MYSQL_DESAENV04_PMDEV_PMDEV_WPROD=🔥YOUR_DB_PASSWORD🔥;
        DB_MYSQL_DESAENV04_PMDEV_PMDEV_ENDPOINT=proxysql.master.meliseginf.com:6612
        ```
        </details>
    * <details><summary><b>DB Data -> DataGrid Example</b></summary>

        ```yaml
        New -> Data Source -> MySQL
            Name: pmdev
            Host: proxysql.master.meliseginf.com
            Port: 6612
            User: 🔥YOUR_DB_USER🔥
            Password: 🔥YOUR_DB_PASSWORD🔥
            Database: pmdev
        Apply -> Test Connection -> Ok
        ```
        </details>
    * <details><summary><b>Local DB</b> If you need to use a local database with docker</summary>

        1. Install **Docker**
        2. Run instance of [MySQL]
            * Start instance
                ```sh
                docker run --name pmlocal -e MYSQL_ROOT_PASSWORD=🔥YOUR_DB_PASSWORD🔥 -e MYSQL_DATABASE=pmlocal -e MYSQL_USER=🔥YOUR_DB_USER🔥 -e MYSQL_PASSWORD=🔥YOUR_DB_PASSWORD🔥 -p 6612:3306 -d mysql:8.0.17
                ```
            * Validate if the container is running
                ```sh
                docker ps -a
                ```
            * <details><summary><b>Little Docker Handbook</b> 👈</summary>

                * Instantiate an **image** in a new **container**
                    ```sh
                    docker run --name pmlocal ...
                    ```
                * Stop **container**
                    ```sh
                    docker stop pmlocal
                    ```
                * Check the status of the **container**
                    ```sh
                    docker ps -a
                    ```
                * Resume **container**
                    ```sh
                    docker start pmlocal
                    ```
                * Delete **container** `Must be stopped first`
                    ```sh
                    docker rm pmlocal
                    ```
                * See **container** log
                    ```sh
                    docker logs pmlocal
                    ```
                </details>

        3. Changes inside the **container**
            * Get in
                ```sh
                docker exec -it pmlocal bash
                
                ```
            * Changes
                * Remove from **dump** an instruction to which we don't have [access]
                    ```sh
                    apt-get update
                    apt-get install vim -y
                    vim -b /usr/bin/mysqldump
                        :%s/SET SQL_QUOTE_SHOW_CREATE/#ET SQL_QUOTE_SHOW_CREATE/g
                        :x!
                    ```
                * [Copy] pmdev **connected to VPN**
                    * Download **dump** to *container**
                        ```sh
                        /usr/bin/mysqldump -u 🔥YOUR_DB_USER🔥 -p --host=proxysql.master.meliseginf.com --port=6612 --lock-tables=FALSE --set-gtid-purged=OFF pmdev > /usr/local/bin/dump_pmdev.sql
                        ```
                    * `Enter 🔥YOUR_DB_PASSWORD🔥, the process may take several minutes`
                    * Load **dump_pmdev** into pmlocal
                        ```sh
                        /usr/bin/mysql -u 🔥YOUR_DB_USER🔥 -p pmlocal < /usr/local/bin/dump_pmdev.sql
                        ```
                    * `Enter 🔥YOUR_DB_PASSWORD🔥`
            * Get out
                ```sh
                exit
                
                ```
            * Optional -> Copy dump_pmdev.sql to local machine
                ```sh
                docker cp pmlocal:/usr/local/bin/dump_pmdev.sql ./dump_pmdev.sql
                ```
        4. install client
        5. Add to the **Hosts** file the [local domain]:
            ```yaml
            127.0.0.1	proxysql.local.meliseginf.com
            ```
        6. DB Data -> DataGrid Example
            ```yaml
            New -> Data Source -> MySQL
                Name: pmlocal
                Host: proxysql.local.meliseginf.com
                Port: 6612
                User: 🔥YOUR_DB_USER🔥
                Password: 🔥YOUR_DB_PASSWORD🔥
                Database: pmlocal
            Apply -> Test Connection -> Ok
            ```
        7. Validate **installation**
            ```yaml
            New -> Query Console
            SELECT VERSION();     >> 8.0.17
            SELECT DATABASE();    >> pmlocal
            ```
        8. Modify Environment variables
            ```sh
            SCOPE=local-pmlocal;
            DB_MYSQL_DESAENV04_PMDEV_PMDEV_WPROD_USERNAME=🔥YOUR_DB_USER🔥;
            DB_MYSQL_DESAENV04_PMDEV_PMDEV_WPROD=🔥YOUR_DB_PASSWORD🔥;
            DB_MYSQL_DESAENV04_PMDEV_PMDEV_ENDPOINT=proxysql.local.meliseginf.com:6612
            ```
        </details>

[MySQL]: https://hub.docker.com/_/mysql
[access]: https://www.markotomic.com/mysqldump-mysql-5-6-problem-solved/
[Copy]: https://www.linuxtotal.com.mx/index.php?cont=info_admon_021
[local domain]: https://help.nexcess.net/how-to-find-the-hosts-file-on-my-mac

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
