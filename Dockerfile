FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /src

COPY ./src ./

WORKDIR /src/Izeem.API

RUN dotnet restore

RUN dotnet publish -c Release -o output

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS serve
WORKDIR /app
COPY --from=build /src/Izeem.API/output .

EXPOSE 80
EXPOSE 443

ENTRYPOINT [ "dotnet", "Izeem.API.dll" ]