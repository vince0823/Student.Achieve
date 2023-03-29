#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0-bullseye-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-bullseye-slim AS build
WORKDIR /src
COPY ["src/Student.Achieve.WebApi/Student.Achieve.WebApi.csproj", "src/Student.Achieve.WebApi/"]
COPY ["src/Student.Achieve.Infrastructure/Student.Achieve.Infrastructure.csproj", "src/Student.Achieve.Infrastructure/"]
COPY ["src/Student.Achieve.Domain/Student.Achieve.Domain.csproj", "src/Student.Achieve.Domain/"]
COPY ["src/Student.Achieve.Domain.Shared/Student.Achieve.Domain.Shared.csproj", "src/Student.Achieve.Domain.Shared/"]
RUN dotnet restore "src/Student.Achieve.WebApi/Student.Achieve.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Student.Achieve.WebApi"
RUN dotnet build "Student.Achieve.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Student.Achieve.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Student.Achieve.WebApi.dll"]
