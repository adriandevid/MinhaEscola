FROM node:18-alpine
RUN mkdir -p /app
WORKDIR /app
COPY . .

ENV NODE_TLS_REJECT_UNAUTHORIZED=0

RUN npm install --verbose
RUN npm run build --verbose
RUN ls

EXPOSE 3000
CMD ["npm", "start"]