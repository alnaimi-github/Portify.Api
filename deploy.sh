#!/bin/bash
set -ex

# Install Docker if not installed
if ! command -v docker &> /dev/null; then
  echo "Docker not found. Installing Docker..."
  sudo yum update -y
  sudo yum install -y yum-utils
  sudo yum-config-manager --add-repo https://download.docker.com/linux/centos/docker-ce.repo
  sudo yum install -y docker-ce docker-ce-cli containerd.io
  sudo systemctl enable docker
  sudo systemctl start docker
  sudo usermod -aG docker ec2-user
  # You may need to reboot or log out/in for group changes to take effect
fi

cd /home/ec2-user/project

docker compose down || true
docker compose build
docker compose up -d
