# Install HomeAutomator as Service on Raspberry PI

This document describes how to configure Raspberry PI to run HomeAutomator as a service.

## Step-By-Step
The following section describes step-by-step how to setup HomeAutomator as a service:

1. Add HomeAutomator to systemd
To create a systemd service, create a HomeAutomator.service file in the /lib/systemd/system/ directory with the following content: 
```
[Unit]
Description=HomeAutomator Backend
After=nginx.service

[Service]
Type=simple
User=pi
WorkingDirectory=/home/pi/HomeAutomator/bin
ExecStart=/home/pi/HomeAutomator/bin/HomeAutomator
Restart=always
RestartSec=5

[Install]
WantedBy=multi-user.target
```

To edit the file use the following command line:
```
sudo nano /lib/systemd/system/HomeAutomator.service
```

When the configuration of a service has changed, it might be required to reload the configuration:
```
sudo systemctl daemon-reload
```

2. Enable the service
To ensure that the service gets started after starting/rebooting the device, use the following command line:
```
sudo systemctl enable HomeAutomator
```

3. Start/stop the service
The service can be started or stopped by the following commands:
```
sudo systemctl start HomeAutomator
sudo systemctl stop HumeAutomator
```

4. Check state of a service
```
sudo systemctl status HomeAutomator
```

## Documentation on the Web
You can find more information here:

[Hosting an ASP.NET Core 2 application on a Raspberry Pi](https://thomaslevesque.com/2018/04/17/hosting-an-asp-net-core-2-application-on-a-raspberry-pi/)
[Raspberry Pi: Dienste starten, stoppen, neustarten, aktivieren und deaktivieren](https://www.elektronik-kompendium.de/sites/raspberry-pi/2002211.htm)
