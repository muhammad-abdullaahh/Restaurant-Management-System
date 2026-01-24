# Learn about building Web apps in a container at https://aka.ms/customizecontainer
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["FoodHeaven.csproj", "."]
RUN dotnet restore "FoodHeaven.csproj"
COPY . .
RUN dotnet publish "FoodHeaven.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_HTTP_PORTS=80
EXPOSE 80
ENTRYPOINT ["dotnet", "FoodHeaven.dll"]
