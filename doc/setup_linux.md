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

dotnet user-secrets set ConnStr "Server=localhost; Database=WebseiteDB; User Id=Benutzer; Password=****;"

cd ..
```