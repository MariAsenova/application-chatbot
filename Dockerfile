FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build-env

# Set the working directory to /app
WORKDIR /ChatbotApplication
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /ChatbotApplication
COPY ["ChatbotApplication.csproj", "."]
RUN dotnet restore "ChatbotApplication.csproj"
COPY . .
WORKDIR "/src/ChatbotApplication"
RUN dotnet build "ChatbotApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ChatbotApplication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChatbotApplication.dll"]

