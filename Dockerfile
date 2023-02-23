FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2019
SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]
RUN Remove-Website -Name 'Default Web Site'; \
    New-Website -Name 'Player' -PhysicalPath 'C:\inetpub\wwwroot' -Port 80 -Force
WORKDIR /inetpub/wwwroot
COPY ./




#FROM mcr.microsoft.com/windows/servercore/iis
#WORKDIR /app
#
## copy csproj and restore as distinct layers
#COPY ./
#RUN nuget restore
#
## copy everything else and build app
#COPY ./
#WORKDIR /app/Player
#RUN msbuild /p:Configuration=Release
#
#
#FROM mcr.microsoft.com/windows/servercore/iis AS runtime
#WORKDIR /inetpub/wwwroot
#COPY --from=build /app/Player/. ./