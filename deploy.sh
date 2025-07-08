
# Install Docker if not installed
if ! command -v docker &> /dev/null; then
  echo "Docker not found. Installing Docker..."
  # For Amazon Linux 2:
  sudo yum update -y
  sudo amazon-linux-extras install docker -y
  sudo service docker start
  sudo usermod -a -G docker ec2-user
  # You may need to reboot or log out/in for group changes to take effect
fi

#!/bin/bash
set -ex

# Docker install block as above...

cd /home/ec2-user/project

docker compose down || true
docker compose build
docker compose up -d
