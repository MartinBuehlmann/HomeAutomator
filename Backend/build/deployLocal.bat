cd ..
cd source
rd ../artifacts /s /q
dotnet publish -c Release -r win-x64 -o ../artifacts/publish
