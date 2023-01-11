FROM mcr.microsoft.com/windows/servercore/iis
WORKDIR /app

# copy csproj and restore as distinct layers
COPY ./
RUN nuget restore

# copy everything else and build app
COPY ./
WORKDIR /app/Player
RUN msbuild /p:Configuration=Release


FROM mcr.microsoft.com/windows/servercore/iis AS runtime
WORKDIR /inetpub/wwwroot
COPY --from=build /app/Player/. ./