FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["LeetCode.Problems/LeetCode.Problems.csproj", "LeetCode.Problems/"]
RUN dotnet restore "LeetCode.Problems/LeetCode.Problems.csproj"
COPY . .
WORKDIR "/src/LeetCode.Problems"
RUN dotnet build "LeetCode.Problems.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LeetCode.Problems.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LeetCode.Problems.dll"]
