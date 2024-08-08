Step by Step upgrade on-going Project : 

https://ptm.id/UpgradeSHUADSTemplate 

Update ADS V.1.4 :

- Coorporate standard design PHE Subholding Upstream Implementation
- SSO Keycloak Development Implementation
- MFA Integration
- Dynamic change ADS Theme Color
- Fix show/hide menu mobile version
- Get User Profile Picture from IDAMAN
- New Icon Option : FontAwesome, IconSax, and Bootstrap icon
- Addition reusable data : Employee OrgUnit and Entity
- New Sample Form and Grid using kendo

Update ADS V.1.3.2 :

- Perubahan tampilan left menu saat minimized
- Penambahan additional form option untuk Kendo
- Penambahan opsi icon menggunakan Fontawesome, Iconsax dan Bootstrap Icon
- Perubahan Font ADS (Inter)

Update ADS V.1.3.1 :

- Fixing cookie management issue
	* menambahkan class SameSiteCookieManager pada project SHUNetMVC.Web folder Extensions
	* Menambahkan script pada Startup.Auth.cs :

	  //////////////////////////// 

		app.UseCookieAuthentication(new CookieAuthenticationOptions
            	{
                	ExpireTimeSpan = TimeSpan.FromDays(1),
                	CookieManager = new SameSiteCookieManager(new SystemWebCookieManager())
            	});

	  ////////////////////////////

Update ADS V.1.3 :

- Re-Design ADS
- Updated Visualization on header and menu
- Fixing security and Database Connection Issue

Update ADS V.1.2.1 :

- Penambahan APP_LOG
- Perbaikan Pagination di groupFooter
- Perbaikan di Filter untuk SelectAll

Update ADS V.1.2 :

- Penambahan metode enkripsi untuk connection string


NB:
Jika terjadi error Roslyn, Silahkan execute script berikut dengan Nuget Package Manager - Package Manager Console:

Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r