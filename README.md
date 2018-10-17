# ABP Module Zero Core Template
Base on https://github.com/aspnetboilerplate/module-zero-core-template/ (v4.0.1)

Replaced `EntityFrameworkCore` with `EntityFramework6`.

Currently, the template is using `AspNetCore` but targeting `net461` due to incompatibility between `EF6` and `netstandard2.0`.

See **ABP** discussion at [aspnetboilerplate#3812](https://github.com/aspnetboilerplate/aspnetboilerplate/issues/3812) 

See **EF6** discussion at [EntityFramework6#271](https://github.com/aspnet/EntityFramework6/issues/271)

As of Sep-2018, Microsoft announced that **EF6** will work with  **.NET Core 3.0** 
See announcement at https://blogs.msdn.microsoft.com/dotnet/2018/05/07/net-core-3-and-support-for-windows-desktop-applications/
