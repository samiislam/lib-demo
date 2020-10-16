# LIB-DEMO - Containerize dotnet core library

## Folder structure:
----

| Name                            | Content                                                   |
| :------------------------------ | :-------------------------------------------------------  |
| Folder: <a name="api">api</a> | The output of the myapi project are published here|
| Folder: <a name="console">console</a> | The output of the myconsole project are published here |
| Folder: <a name="lib">lib</a> | The output of the mylib project are published here |
| Folder: myapi | The dotnet core aspnet webapi project |
| Folder: myconsole | The dotnet core runtime console project |
| Folder: mylib | The dotnet class library to be used by the webapi and console projects |
| Dockerfile.apiwithlibcoreaspnet | Create an api image using a lib image that is based on dotnet core aspnet image [Dockerfile.libwithcoreaspnet](#libwithcoreaspnet) |
| Dockerfile.apiwithlibcoreruntime | Create an api image using a lib image that is based on dotnet core runtime image [Dockerfile.libwithcoreruntime](#libwithcoreruntime) - This will not work since the api application requires asp.net to be installed |
| <a name="apiwithlibminimal">Dockerfile.apiwithlibminimal</a> | Create an api image using the lib base image [Dockerfile.libminimal](#libminimal) and including the dotnet core aspnet image here |
| Dockerfile.consolewithlibcoreruntime | Create a console image using the lib image that is based on dotnet core runtime image [Dockerfile.libwithcoreruntime](#libwithcoreruntime) |
| <a name="consolewithlibminimal">Dockerfile.consolewithlibminimal</a> | Create a console image using the lib base image [Dockerfile.libminimal](#libminimal) and including the dotnet core runtime image here |
| <a name="libminimal">Dockerfile.libminimal</a> | Create a lib base image from scratch |
| <a name="libwithcoreaspnet">Dockerfile.libwithcoreaspnet</a>  | Create a lib image using the dotnet core aspnet image |
| <a name="libwithcoreruntime">Dockerfile.libwithcoreruntime</a> | Create a lib image using the dotnet core runtime image |
| README.md | This file |

----

<br />
<br />


## Steps:
----
| Step                            | Command                                                   |
| :------------------------------ | :-------------------------------------------------------  |
| 1. Build mylib | dotnet build mylib/mylib.csproj -c release |
| 2. Publish mylib in [lib](#lib) | dotnet publish mylib/mylib.csproj -c release -o lib --no-restore |
| 3. Build myconsole | dotnet build myconsole/myconsole.csproj -c release |
| 4. Publish myconsole in [console](#console) | dotnet publish myconsole/myconsole.csproj -c release -o console --no-restore |
| 5. Build myapi | dotnet build myapi/myapi.csproj -c release |
| 6. Publish myapi in [api](#api) | dotnet publish myapi/myapi.csproj -c release -o api --no-restore |
| 7. Build docker image for base lib | docker image build -f [Dockerfile.libminimal](#libminimal) --no-cache=true -t s/lib . | 
| 8. View the layers of the base lib image | docker image history s/lib |
| 9. Build docker image for console using the base lib | docker image build -f [Dockerfile.consolewithlibminimal](#consolewithlibminimal) --no-cache=true -t s/console . |
| 10. View the layers of the console image | docker image history s/console |
| 11. Run a container based on the console image | docker container run --rm --name consoleapp s/console |
| 12. Build a docker image for api using the base lib | docker image build -f [Dockerfile.apiwithlibminimal](#apiwithlibminimal) --no-cache=true -t s/api . |
| 13. View the layers of the api image | docker image history s/api |
| 14. Run a container based on the api image | docker container run -d --rm --name webapi --publish mode=ingress,target=80,published=5000 s/api |
| 15. Connect to the api service | http://localhost:5000/callmylib |
----
