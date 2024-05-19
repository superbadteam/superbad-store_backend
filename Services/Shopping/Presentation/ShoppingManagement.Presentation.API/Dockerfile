FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Shopping/Presentation/ShoppingManagement.Presentation.API/ShoppingManagement.Presentation.API.csproj", "Services/Shopping/Presentation/ShoppingManagement.Presentation.API/"]
COPY ["BuildingBlocks/Presentation/BuildingBlock.Presentation.API/BuildingBlock.Presentation.API.csproj", "BuildingBlocks/Presentation/BuildingBlock.Presentation.API/"]
COPY ["BuildingBlocks/Core/BuildingBlock.Core.Application/BuildingBlock.Core.Application.csproj", "BuildingBlocks/Core/BuildingBlock.Core.Application/"]
COPY ["BuildingBlocks/Core/BuildingBlock.Core.Domain/BuildingBlock.Core.Domain.csproj", "BuildingBlocks/Core/BuildingBlock.Core.Domain/"]
COPY ["BuildingBlocks/Infrastructure/BuildingBlock.Infrastructure.Serilog/BuildingBlock.Infrastructure.Serilog.csproj", "BuildingBlocks/Infrastructure/BuildingBlock.Infrastructure.Serilog/"]
COPY ["BuildingBlocks/Infrastructure/BuildingBlock.Infrastructure.EntityFrameworkCore/BuildingBlock.Infrastructure.EntityFrameworkCore.csproj", "BuildingBlocks/Infrastructure/BuildingBlock.Infrastructure.EntityFrameworkCore/"]
COPY ["BuildingBlocks/Infrastructure/BuildingBlock.Infrastructure.RabbitMQ/BuildingBlock.Infrastructure.RabbitMQ.csproj", "BuildingBlocks/Infrastructure/BuildingBlock.Infrastructure.RabbitMQ/"]
COPY ["BuildingBlocks/Infrastructure/BuildingBlock.Infrastructure.Redis/BuildingBlock.Infrastructure.Redis.csproj", "BuildingBlocks/Infrastructure/BuildingBlock.Infrastructure.Redis/"]
COPY ["BuildingBlocks/Infrastructure/BuildingBlock.Infrastructure.Identity/BuildingBlock.Infrastructure.Identity.csproj", "BuildingBlocks/Infrastructure/BuildingBlock.Infrastructure.Identity/"]
COPY ["Services/Shopping/Core/ShoppingManagement.Core.Application/ShoppingManagement.Core.Application.csproj", "Services/Shopping/Core/ShoppingManagement.Core.Application/"]
COPY ["Services/Shopping/Core/ShoppingManagement.Core.Domain/ShoppingManagement.Core.Domain.csproj", "Services/Shopping/Core/ShoppingManagement.Core.Domain/"]
COPY ["Services/Shopping/Infrastructure/ShoppingManagement.Infrastructure.EntityFrameworkCore/ShoppingManagement.Infrastructure.EntityFrameworkCore.csproj", "Services/Shopping/Infrastructure/ShoppingManagement.Infrastructure.EntityFrameworkCore/"]
RUN dotnet restore "Services/Shopping/Presentation/ShoppingManagement.Presentation.API/ShoppingManagement.Presentation.API.csproj"
COPY . .
WORKDIR "/src/Services/Shopping/Presentation/ShoppingManagement.Presentation.API"
RUN dotnet build "ShoppingManagement.Presentation.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShoppingManagement.Presentation.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY SeedShoppingData.sql .
ENTRYPOINT ["dotnet", "ShoppingManagement.Presentation.API.dll"]
