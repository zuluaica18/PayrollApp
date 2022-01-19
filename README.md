# Go Starter App

![technology Go](https://img.shields.io/badge/technology-go-blue.svg)

This is a basic Go application created by Fury to be used as a starting point for your project.

### First run


On the project root folder, before running

    go mod tidy
    
Locally it can be run with 2 profiles:
    * The first one raises a sqlite base in memory. For this they have to set the environment variable SCOPE = local.
    * The second raises pointing to the development mysql: set the environment variable SCOPE = local-mysql.
    <details><summary><b>Example of environment variables</b></summary>

    SCOPE=local-mysql;DB_MYSQL_DESAENV04_PMDEV_PMDEV_WPROD=**<YOUR_DB_PASSWORD>**;DB_MYSQL_DESAENV04_PMDEV_PMDEV_WPROD_USERNAME=**<YOUR_DB_USER>**;DB_MYSQL_DESAENV04_PMDEV_PMDEV_ENDPOINT=proxysql.master.meliseginf.com:6612
    </details>

Then you can run it with the command

    cd cmd/app
    go run main.go

or

    fury run

And check http://localhost:8080/ping to verify it's running.

To run the automated tests you can use

    go test ./...

or

    fury test