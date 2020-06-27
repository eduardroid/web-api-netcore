#to build Image
docker build --no-cache --pull --rm -f "Dockerfile" -t eduardroid-service:latest "."

#to Run Image, and use port 8080
docker run -d -p 8080:80 --name eduardroid-service eduardroid-service:latest

#try to run it with volumes
docker run -d -p 8080:80 -v ~/dev.eduardroid.services:/app/ -w /app/ --name eduardroid-service eduardroid-service:latest