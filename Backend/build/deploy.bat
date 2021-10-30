cd ..
cd source
rd ..\artifacts /s /q
dotnet publish -c Release -r linux-arm -o ../artifacts/publish
scp -r ../artifacts/publish/* pi@192.168.1.20:/home/pi/HomeAutomator/bin