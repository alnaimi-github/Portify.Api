#!/bin/bash

cd /home/ec2-user/project

docker compose down || true
docker compose build
docker compose up -d
