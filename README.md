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
    * The second raises pointing to the development mysql: set the environment variable `SCOPE=local-mysql`.
    <details><summary><b>Example of environment variables</b></summary>

    ```yaml
    SCOPE=local-mysql;
    DB_MYSQL_DESAENV04_PMDEV_PMDEV_WPROD=**<YOUR_DB_PASSWORD>**;
    DB_MYSQL_DESAENV04_PMDEV_PMDEV_WPROD_USERNAME=**<YOUR_DB_USER>**;
    DB_MYSQL_DESAENV04_PMDEV_PMDEV_ENDPOINT=proxysql.master.meliseginf.com:6612
    ```
    </details>

3. Then you can run it with the command
    ```sh
    cd cmd/app
    go run main.go
    ```
    * or
    ```sh
    fury run
    ```
4. And check http://localhost:8080/ping to verify it's running.
5. To run the automated tests you can use
    ```sh
    go test ./...
    ```
    * or
    ```sh
    fury test
    ```
