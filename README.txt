-------------------------------------------------------------
--------------------------  CZ  -----------------------------
-------------------------------------------------------------

AlzaWebApi je REST API, kter� slou�� k pr�ci s produkty. 
Aplikace je psan� v .Net Core 2.2 kter� vyu��v� Entity Framework Core 2.2.4. Nad aplikac� be�� Swagger dokumentace. 
API m� 3 koncov� body:
	1) Vrac� seznam v�ech produkt�
	2) Vrac� produkt podle Id
	3) Updatuje popis produktu podle Id

Pro spu�t�n� aplikace pou�ijte Visual Studio 2017 nebo 2019 s nainstalovan�m frameworkem .Net Core 2.2.

Prvn� spu�t�n�:
1) Otev�ete "AlzaSolution.sln" ve Visual Studiu.
2) V projektu "AlzaWebApi" a "AlzaWebApi.Tests" v souboru "appsettings.json" dopl�te connection string na V�mi zvolenou datab�zi.
3) Ve Visual Studiu otev�ete "Package Manager Console" a vyberte projekt "Alza.Data". Do p��kazov� ��dky napi�te "Update-Database" a spus�te p��kaz. T�mto se V�mvytvo�� cel� struktura v datab�zi. P�i prvn�m spu�t�n� Api nebo test� budou vytvo�eny testovn� data (5 produkt�).
4) Spu�t�n�:
	a) Api: zm��kni kl�vesu F5.
	b) Testy: klikni prav�m tla��tkem na projekt "AlzaWebApi.Tests" a vyber "Run Tests".


-------------------------------------------------------------
--------------------------  EN  -----------------------------
-------------------------------------------------------------

AlzaWebApi is REST API which work with products.
The application is written in .Net Core 2.2 which uses Entity Framework Core 2.2.4. Above the application is running Swagger documentation.
The API has 3 endpoints:
	1) Returns a list of all products
	2) Returns the product according to Id
	3) Updates the product description according to Id

To run the application, use Visual Studio 2017 or 2019 with the .Net Core 2.2 framework installed.

First run:
1) Open "AlzaSolution.sln" in Visual Studio.
2) In the project "AlzaWebApi" and "AlzaWebApi.Tests" in the file "appsettings.json" fill in the connection string to the database of your choice.
3) In Visual Studio, open the "Package Manager Console" and select the "Alza.Data" project. At the command prompt, type "Update-Database" and run the command. This will create the entire structure in the database. The first time you run Api or tests, test data (5 products) will be created.
4) Starting:
	a) Api: press F5.
	b) Tests: click on "AlzaWebApi.Tests" with right button on mouse and select "Run Tests".