#!/bin/bash

echo Iniciando Tests...

echo Limpando Pasta...

rm -f *.csv
rm -rf Maps20
rm -rf Maps100
rm -rf Maps20D2
rm -rf Maps100D2

rm -rf Maps20P
rm -rf Maps100P
rm -rf Maps20D2P
rm -rf Maps100D2P


echo 20x20/Random/Never...
dotnet ../bin/Debug/netcoreapp1.1/PF.dll genmap -l Maps20 -w 20 -h 20 -n 100
echo
echo 100x100/Random/Never...
dotnet ../bin/Debug/netcoreapp1.1/PF.dll genmap -l Maps100 -w 100 -h 100 -n 100
echo
echo 20x20/Random/IfAtMostOneObstacle...
dotnet ../bin/Debug/netcoreapp1.1/PF.dll genmap -l Maps20D2 -w 20 -h 20 -n 100 -d 2
echo
echo 100x100/Random/IfAtMostOneObstacle...
dotnet ../bin/Debug/netcoreapp1.1/PF.dll genmap -l Maps100D2 -w 100 -h 100 -n 100 -d 2
echo
echo 20x20/Pattern/Never...
dotnet ../bin/Debug/netcoreapp1.1/PF.dll genmap -l Maps20P -w 20 -h 20 -n 100 -p 2
echo
echo 100x100/Pattern/Never...
dotnet ../bin/Debug/netcoreapp1.1/PF.dll genmap -l Maps100P -w 100 -h 100 -n 100  -p 10
echo
echo 20x20/Pattern/IfAtMostOneObstacle...
dotnet ../bin/Debug/netcoreapp1.1/PF.dll genmap -l Maps20D2P -w 20 -h 20 -n 100 -d 2 -p 2
echo
echo 100x100/Pattern/IfAtMostOneObstacle...
dotnet ../bin/Debug/netcoreapp1.1/PF.dll genmap -l Maps100D2P -w 100 -h 100 -n 100 -d 2  -p 10
echo

echo 20x20/Never/Random..
dotnet ../bin/Debug/netcoreapp1.1/PF.dll batch -a 0 1 3 4 -h 0 1 2 3 -m 2 5 -c 1 2 -f 0 1 2 -l Maps20

echo 20x20/Never/Pattern..
dotnet ../bin/Debug/netcoreapp1.1/PF.dll batch -a 0 1 3 4 -h 0 1 2 3 -m 2 5 -c 1 2 -f 0 1 2 -l Maps20P

echo 20x20/IfAtMostOneObstacle/Random..
dotnet ../bin/Debug/netcoreapp1.1/PF.dll batch -a 0 1 3 4 -h 0 1 2 3 -m 2 5 -c 1 2 -f 0 1 2 -l Maps20D2

echo 20x20/IfAtMostOneObstacle/Pattern..
dotnet ../bin/Debug/netcoreapp1.1/PF.dll batch -a 0 1 3 4 -h 0 1 2 3 -m 2 5 -c 1 2 -f 0 1 2 -l Maps20D2P

echo 20x20/Never/Random..
dotnet ../bin/Debug/netcoreapp1.1/PF.dll batch -a 0 1 3 4 -h 0 1 2 3 -m 2 5 -c 1 2 -f 0 1 2 -l Maps100

echo 20x20/Never/Pattern..
dotnet ../bin/Debug/netcoreapp1.1/PF.dll batch -a 0 1 3 4 -h 0 1 2 3 -m 2 5 -c 1 2 -f 0 1 2 -l Maps100P

echo 20x20/IfAtMostOneObstacle/Random..
dotnet ../bin/Debug/netcoreapp1.1/PF.dll batch -a 0 1 3 4 -h 0 1 2 3 -m 2 5 -c 1 2 -f 0 1 2 -l Maps100D2

echo 20x20/IfAtMostOneObstacle/Pattern..
dotnet ../bin/Debug/netcoreapp1.1/PF.dll batch -a 0 1 3 4 -h 0 1 2 3 -m 2 5 -c 1 2 -f 0 1 2 -l Maps100D2P





