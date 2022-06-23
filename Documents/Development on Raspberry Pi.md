# Development on Raspberry PI

This document describes how to configure Raspberry PI to develop this project.

## Install Flutter
The following section describes step-by-step how to setup Flutter:

1. Install snap

Install latest version of Raspbian snap:
```
sudo apt update
sudo apt install snap
sudo reboot
```

Install the core snap in order to get the latest snapd:
```
sudo snap install core
```

Install Flutter:
```
sudo snap install flutter --classic
```

2. Install Android SDK
To build the Flutter application Android SDK is required:

```
sudo apt install android-sdk
```

## Documentation on the Web
You can find more information here:

[Install Flutter on Raspberry Pi](https://snapcraft.io/install/flutter/raspbian)
