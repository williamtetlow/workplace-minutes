FROM microsoft/dotnet:core 
COPY ./bin/Release/netcoreapp1.0/publish /app  
WORKDIR /app  
EXPOSE 5000  
ENTRYPOINT ["dotnet", "mediator.dll"]  