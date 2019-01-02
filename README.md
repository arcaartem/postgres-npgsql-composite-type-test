# Composite types in Postgres and Npgsql

A self contained project to replicate an issue when fetching rows with a composite type column from a Postgres DB.

## Dependencies

* Docker
* dotnet core 2.2

Runs on MacOS High Sierra

## To run

This spins up a Postgres database and a PGAdmin server, sets up a specific schema and runs the app.

```
./start-db
./run-app
```

