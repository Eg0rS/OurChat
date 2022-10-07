
# nginx setup
FROM nginx:stable-alpine
COPY env/nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
