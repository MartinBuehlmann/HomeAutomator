set address=192.168.1.25
set password=raspberry
cd ..
cd source
rd ..\artifacts /s /q
dotnet publish HomeAutomator -c Release -r linux-arm --self-contained -o ../artifacts/publish
plink -ssh pi@%address% -pw %password% -no-antispoof "sudo systemctl stop HomeAutomator"
plink -ssh pi@%address% -pw %password% -no-antispoof "mkdir /home/pi/HomeAutomator"
plink -ssh pi@%address% -pw %password% -no-antispoof "mkdir /home/pi/HomeAutomator/bin"
pscp -pw %password% -r ../artifacts/publish/* pi@%address%:/home/pi/HomeAutomator/bin
plink -ssh pi@%address% -pw %password% -no-antispoof "chmod +x /home/pi/HomeAutomator/bin/HomeAutomator"
plink -ssh pi@%address% -pw %password% -no-antispoof "sudo systemctl start HomeAutomator"
pause