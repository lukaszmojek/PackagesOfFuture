# PackagesOfFuture.Backend

## Maintenance:
To performs steps below you need to be in the `PackagesOfFuture.Backend` folder
### Adding migrations
`dotnet ef migrations add {migration_name} --startup-project Api --project Persistance`

### Updating the database
`dotnet ef database update --project Api`