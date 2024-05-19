FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Order/Presentation/OrderManagement.Presentation.API/OrderManagement.Presentation.API.csproj", "Services/Order/Presentation/OrderManagement.Presentation.API/"]
COPY ["BuildingBlocks/Presentation/BuildingBlock.Presentation.API/BuildingBlock.Presentation.API.csproj", "BuildingBlocks/Presentation/BuildingBlock.Presentation.API/"]
COPY ["BuildingBlocks/Core/BuildingBlock.Core.Application/BuildingBlock.Core.Application.csproj", "BuildingBlocks/Core/BuildingBlock.Core.Application/"]
COPY ["BuildingBlocks/Core/BuildingBlock.Core.Domain/BuildingBlock.Core.Domain.csproj", "BuildingBlocks/Core/BuildingBlock.Core.Domain/"]
COPY ["BuildingBlocks/Infrastructure/BuildingBlock.Infrastructure.Serilog/BuildingBlock.Infrastructure.Serilog.csproj", "BuildingBlocks/Infrastructure/BuildingBlock.Infrastructure.Serilog/"]
COPY ["BuildingBlocks/Infrastructure/BuildingBlock.Infrastructure.EntityFrameworkCore/BuildingBlock.Infrastructure.EntityFrameworkCore.csproj", "BuildingBlocks/Infrastructure/BuildingBlock.Infrastructure.EntityFrameworkCore/"]
COPY ["BuildingBlocks/Infrastructure/BuildingBlock.Infrastructure.RabbitMQ/BuildingBlock.Infrastructure.RabbitMQ.csproj", "BuildingBlocks/Infrastructure/BuildingBlock.Infrastructure.RabbitMQ/"]
COPY ["BuildingBlocks/Infrastructure/BuildingBlock.Infrastructure.Redis/BuildingBlock.Infrastructure.Redis.csproj", "BuildingBlocks/Infrastructure/BuildingBlock.Infrastructure.Redis/"]
COPY ["BuildingBlocks/Infrastructure/BuildingBlock.Infrastructure.Identity/BuildingBlock.Infrastructure.Identity.csproj", "BuildingBlocks/Infrastructure/BuildingBlock.Infrastructure.Identity/"]
COPY ["Services/Order/Core/OrderManagement.Core.Application/OrderManagement.Core.Application.csproj", "Services/Order/Core/OrderManagement.Core.Application/"]
COPY ["Services/Order/Core/OrderManagement.Core.Domain/OrderManagement.Core.Domain.csproj", "Services/Order/Core/OrderManagement.Core.Domain/"]
COPY ["Services/Order/Infrastructure/OrderManagement.Infrastructure.EntityFrameworkCore/OrderManagement.Infrastructure.EntityFrameworkCore.csproj", "Services/Order/Infrastructure/OrderManagement.Infrastructure.EntityFrameworkCore/"]
RUN dotnet restore "Services/Order/Presentation/OrderManagement.Presentation.API/OrderManagement.Presentation.API.csproj"
COPY . .
WORKDIR "/src/Services/Order/Presentation/OrderManagement.Presentation.API"
RUN dotnet build "OrderManagement.Presentation.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrderManagement.Presentation.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY SeedOrderData.sql .
ENTRYPOINT ["dotnet", "OrderManagement.Presentation.API.dll"]
