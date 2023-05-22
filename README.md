# powerplant-coding-challenge

*François Le Roy*
## How to use

```bash
cd powerplant-coding-challenge-implementation
dotnet run powerplant-coding-challenge-implementation.csproj
```
## How to test
```bash
curl -X POST https://localhost:8888/productionplan -H "Content-Type: application/json" -d @../example_payloads/payload1.json
```

## Docker version (bonus)
To use the Dockerize version of the app you can use : 
```bash
docker build -t powerplant-coding-challenge-img .
docker run --name powerplant-coding-challenge-docker -d -p 8888:80 powerplant-coding-challenge-img
```
To test, remove the https from the url : 
```bash
curl -X POST http://localhost:8888/productionplan -H "Content-Type: application/json" -d @../example_payloads/payload1.json
```
## How I did
* I did choose C# to do the challenge as I am more confortable with it.  I did use dotnet 6 as it is LTS version.
* I spend a bit more than 6 hours to do the challenge, this lap of time include the analysis, the development and the README writing
* I did use the difference between production and comsuption rate in order to sort the powerplant with the least comsuption first.
* I tried to do a code as clean as possible but I did not have the time to do what I wanted and so the actual version is more like a draft.
