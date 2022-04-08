# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS builder
WORKDIR /source
# copy csproj and restore as distinct layers
COPY *.sln .
COPY HUIT2022/*.csproj ./HUIT2022/
RUN dotnet restore
# copy everything else and build app
COPY HUIT2022/. ./HUIT2022/
WORKDIR /source/HUIT2022
RUN dotnet publish -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runner
WORKDIR /app
COPY --from=builder /app ./
ENTRYPOINT ["dotnet", "HUIT2022.dll"]