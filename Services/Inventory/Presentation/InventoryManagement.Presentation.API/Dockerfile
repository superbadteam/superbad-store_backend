FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Inventory/Presentation/InventoryManagement.Presentation.API/InventoryManagement.Presentation.API.csproj", "Services/Inventory/Presentation/InventoryManagement.Presentation.API/"]
COPY ["BuildingBlocks/Presentation/BuildingBlock.Presentation.API/BuildingBlock.Presentation.API.csproj", "BuildingBlocks/Presentation/BuildingBlock.Presentation.API/"]
COPY ["BuildingBlocks/Core/BuildingBlock.Core.Application/BuildingBlock.Core.Application.csproj", "BuildingBlocks/Core/BuildingBlock.Core.Application/"]
COPY ["BuildingBlocks/Core/BuildingBlock.Core.Domain/BuildingBlock.Core.Domain.csproj", "BuildingBlocks/Core/BuildingBlock.Core.Domain/"]
COPY ["BuildingBlocks/Infrastructure/BuildingBlock.Infrastructure.Serilog/BuildingBlock.Infrastructure.Serilog.csproj", "BuildingBlocks/Infrastructure/BuildingBlock.Infrastructure.Serilog/"]
COPY ["BuildingBlocks/Infrastructure/BuildingBlock.Infrastructure.EntityFrameworkCore/BuildingBlock.Infrastructure.EntityFrameworkCore.csproj", "BuildingBlocks/Infrastructure/BuildingBlock.Infrastructure.EntityFrameworkCore/"]
COPY ["BuildingBlocks/Infrastructure/BuildingBlock.Infrastructure.RabbitMQ/BuildingBlock.Infrastructure.RabbitMQ.csproj", "BuildingBlocks/Infrastructure/BuildingBlock.Infrastructure.RabbitMQ/"]
COPY ["BuildingBlocks/Infrastructure/BuildingBlock.Infrastructure.Redis/BuildingBlock.Infrastructure.Redis.csproj", "BuildingBlocks/Infrastructure/BuildingBlock.Infrastructure.Redis/"]
COPY ["BuildingBlocks/Infrastructure/BuildingBlock.Infrastructure.Identity/BuildingBlock.Infrastructure.Identity.csproj", "BuildingBlocks/Infrastructure/BuildingBlock.Infrastructure.Identity/"]
COPY ["Services/Inventory/Core/InventoryManagement.Core.Application/InventoryManagement.Core.Application.csproj", "Services/Inventory/Core/InventoryManagement.Core.Application/"]
COPY ["Services/Inventory/Core/InventoryManagement.Core.Domain/InventoryManagement.Core.Domain.csproj", "Services/Inventory/Core/InventoryManagement.Core.Domain/"]
COPY ["Services/Inventory/Infrastructure/InventoryManagement.Infrastructure.EntityFrameworkCore/InventoryManagement.Infrastructure.EntityFrameworkCore.csproj", "Services/Inventory/Infrastructure/InventoryManagement.Infrastructure.EntityFrameworkCore/"]
RUN dotnet restore "Services/Inventory/Presentation/InventoryManagement.Presentation.API/InventoryManagement.Presentation.API.csproj"
COPY . .
WORKDIR "/src/Services/Inventory/Presentation/InventoryManagement.Presentation.API"
RUN dotnet build "InventoryManagement.Presentation.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InventoryManagement.Presentation.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY SeedInventoryData.sql .
ENTRYPOINT ["dotnet", "InventoryManagement.Presentation.API.dll"]
