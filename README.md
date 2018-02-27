# Swampnet.Services
A selection of random services / R&amp;D


@Notes
nuget.exe sources Add -Name "Swampnet" -Source "https://swampnet.pkgs.visualstudio.com/_packaging/Swampnet/nuget/v3/index.json"

@Todo
- Images service could probably just be a generic File service...


pdf stuff.
- Needed to copy libwkhtmltox.dll to the dinktopdf nuget package directory cache, which for me is: C:\Users\petej\.nuget\packages\dinktopdf\1.0.8\lib\netstandard1.6
- This was the x64 version of the library
- There's an issue describing this at: https://github.com/rdvojmoc/DinkToPdf/issues/5
- Pinched a solution from above (basically deciding which version to run at run-time) which works ok
- Works in azure, but had to bump service plan up (wouldn't work on free version, probably due to sandbox restrictions)
