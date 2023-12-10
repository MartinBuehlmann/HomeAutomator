# HomeAutomator

This project consists of an ASP.NET Core backend and a Flutter based mobile application. The app allows to configure 
one or more Hue lights and assign this setting to a NFC tag. The configuration is stored per mobile device on the 
backend, that means that different people can configure different scenes within the same NFC tag.

This project has been created for educational purpose. The goals were to build an ASP.NET Core based application using
Clean Architecture principles (Onion Architecture). Also the development purpose of the mobile app was to exercise 
mobile app development rather than create a marketplaace ready app.

The backend can be hosted within a Raspberry PI (during development a Raspberry PI 4B with 4 GB ram was used).

The app is only meant to be used within the same network, the backend is not designed for the cloud.
