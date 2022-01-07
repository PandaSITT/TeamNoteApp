# Runtime

## dotnet

### deb

```
wget https://packages.microsoft.com/config/ubuntu/21.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
```

### dotnet Pakete

```
sudo apt install dotnet-runtime-5.0
sudo apt install dotnet-sdk-5.0
```



## node

### node Pakete

```
sudo apt update
sudo apt install nodejs npm
```

# Umgebung Configurieren

## user secrets configurieren 
```
cd WebUI

dotnet user-secrets set ConnectionStrings:MySQL "Server=localhost; Database=WebseiteDB; User Id=Benutzer; Password=****;"

cd ..
```

## docker mysql setup
```
docker pull mysql/mysql-server:latest

docker run --name=mysql1 -p 3306:3306 -e MYSQL_ROOT_PASSWORD=73r6eWVMUBfc73Bv -d mysql/mysql-server:latest
```

MySQL:
```
CREATE USER 'devAdmin'@'%' IDENTIFIED WITH mysql_native_password BY '73r6eWVMUBfc73Bv';

-- Scripte laufen lassen (oder scripte in die konsole kopieren)

Use WebseiteDB;

GRANT ALL PRIVILEGES ON WebseiteDB.* TO 'devAdmin'@'%';

FLUSH PRIVILEGES;
```