FROM mcr.microsoft.com/dotnet/sdk:6.0
RUN apt-get update
RUN  apt install iputils-ping -y
EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000
ENV DOTNET_URLS=http://+:5000
COPY ./publish/ /app
WORKDIR /app
ENTRYPOINT ["dotnet","ListApplication.dll"]