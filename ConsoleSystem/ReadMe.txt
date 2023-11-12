dotnet tool install --global dotnet-ef

Under DBSystem run this:

dotnet ef migrations add InitialCreate
dotnet ef database update
