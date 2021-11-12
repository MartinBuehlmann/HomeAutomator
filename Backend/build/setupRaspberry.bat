plink -ssh pi@192.168.1.20 -pw raspberry -no-antispoof "mkdir /home/pi/HomeAutomator"
plink -ssh pi@192.168.1.20 -pw raspberry -no-antispoof "mkdir /home/pi/HomeAutomator/bin"
scp -r HomeAutomator.service pi@192.168.1.20:/lib/systemd/system/
plink -ssh pi@192.168.1.20 -pw raspberry -no-antispoof "sudo systemd daemon-reload"
plink -ssh pi@192.168.1.20 -pw raspberry -no-antispoof "sudo systemctl enable HomeAutomator"
