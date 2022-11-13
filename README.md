# List
## Build Docker  
docker build -t todo:latest .  
## Run Docker  
docker run -d --rm -p 5000:5000 -e RunTimeSetting__Prefix=data_prefix_ -e AllowedHosts=* -e RunTimeSetting__RemoteHost=http://localhost:5000 -e Logging__LogLevel__Default=debug todo:latest  
docker run -p 81:5001 -e ASPNETCORE_URLS=http://*:5001 todo:latest  
  
## Arguments  
- RunTimeSetting__RemoteHost = Remote query host name  
- RunTimeSetting__Prefix = Prefix for data  
- Logging__LogLevel__Default = logging level (debug, info, warning)  
- RunTimeSetting__DelayTime = delay time in millisecond for /data/getalldelay endpoint  
  
## Build  
dotnet publish --output publish  