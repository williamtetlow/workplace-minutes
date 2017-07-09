## Deployment Instructions

- Publish web api project
    ````bash 
    dotnet publish mediator/mediator.fsproj -c RELEASE
    ````

- Build docker image
  ````bash
  docker build ./mediator -t willietetlow/mediator:v<version>.<no>
  ````

  (Note use ````bash docker rm <name>```` if it complains about already existing)

- Test docker image
  ````bash
  docker run -p=5000:5000 --name mediator willietetlow/mediator:v<version>.<no> --ip 0.0.0.0
  ````

- Push docker image
  ````bash
  docker push willietetlow/mediator:v<version>.<no>
  ````

- Kubernetes should all be setup but if reconfiguring

  - ````bash kubectl create -f ./some-yaml-file```` to create deployment
  - ````bash kubectl delete -f ./some-yaml-file```` to delete
  - ````bash kubectl proxy```` to view container console

