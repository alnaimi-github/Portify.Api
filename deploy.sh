#!/bin/bash
set -ex

# Install Docker the Amazon Linux way if not present
if ! command -v docker &> /dev/null; then
  echo "Docker not found. Installing Docker..."
  sudo yum update -y
  sudo yum install -y docker
  sudo systemctl enable docker
  sudo systemctl start docker
  sudo usermod -aG docker ec2-user
fi

cd /home/ec2-user/project

docker compose down || true
docker compose build
docker compose up -d
