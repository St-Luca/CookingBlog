
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CookingBlog.csproj", "./"]
RUN dotnet restore "./CookingBlog.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "CookingBlog.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CookingBlog.csproj" -c Release -o /app/publish --no-restore
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CookingBlog.dll"]