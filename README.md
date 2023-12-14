# HomeAutomator

This project consists of an ASP.NET Core backend and a Flutter based mobile application. The app allows to configure 
one or more Hue lights and assign these settings to a NFC tag. The settings is stored per mobile device on the 
backend, that means that different mobile devices can configure different scenes within the same NFC tag.

This project has been created for educational purpose. The goal was to build an ASP.NET Core based application using
Clean Architecture principles (Onion Architecture). The development purpose of the mobile app was to exercise 
mobile app development rather than create a marketplace ready app.

The backend can be hosted within a Raspberry PI (during development a Raspberry PI 4B with 4 GB RAM was used).

The app is only meant to be used within the same network, the backend is not designed for the cloud.

![Configure Area](/Documents/Images/02_Menu.jpg)

![Configure Area](/Documents/Images/06_AreaSettings.jpg)

![Configure Area](/Documents/Images/07_ConfigureLight.jpg)

More screenshots can be found under /Documents/Images in the repository.