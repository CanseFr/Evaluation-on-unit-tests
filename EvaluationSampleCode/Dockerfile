FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["EvaluationSampleCode/EvaluationSampleCode.csproj", "EvaluationSampleCode/"]
RUN dotnet restore "EvaluationSampleCode/EvaluationSampleCode.csproj"
COPY . .
WORKDIR "/src/EvaluationSampleCode"
RUN dotnet build "EvaluationSampleCode.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EvaluationSampleCode.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EvaluationSampleCode.dll"]
