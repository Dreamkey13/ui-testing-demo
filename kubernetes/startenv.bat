
minikube start

kubectl create -f selenium-hub-deployment.yml

kubectl create -f selenium-node-chrome-deployment.yml

kubectl create -f selenium-node-firefox-deployment.yml

kubectl port-forward service/selenium-hub 4444:4444