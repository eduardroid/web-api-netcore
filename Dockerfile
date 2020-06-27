#FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS base
#WORKDIR /app
#EXPOSE 80
#ENV ASPNETCORE_URL=http://*:5000


FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./dev.eduardroid.services/*.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
#WORKDIR /src/.
RUN dotnet build -c Release -o /app/build

#FROM build AS publish
#RUN dotnet publish -c Release -o /app/publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS final
WORKDIR /app
COPY --from=build /app/build .
ENTRYPOINT ["dotnet", "dev.eduardroid.services.dll"]