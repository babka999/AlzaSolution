-------------------------------------------------------------
--------------------------  CZ  -----------------------------
-------------------------------------------------------------

AlzaWebApi je REST API, které slouí k práci s produkty. 
Aplikace je psaná v .Net Core 2.2 která vyuívá Entity Framework Core 2.2.4. Nad aplikací beí Swagger dokumentace. 
API má 3 koncové body:
	1) Vrací seznam všech produktù
	2) Vrací produkt podle Id
	3) Updatuje popis produktu podle Id

Pro spuštìní aplikace pouijte Visual Studio 2017 nebo 2019 s nainstalovanım frameworkem .Net Core 2.2.

První spuštìní:
1) Otevøete "AlzaSolution.sln" ve Visual Studiu.
2) V projektu "AlzaWebApi" a "AlzaWebApi.Tests" v souboru "appsettings.json" doplòte connection string na Vámi zvolenou databázi.
3) Ve Visual Studiu otevøete "Package Manager Console" a vyberte projekt "Alza.Data". Do pøíkazové øádky napište "Update-Database" a spuste pøíkaz. Tímto se Vámvytvoèí celá struktura v databázi. Pøi prvním spuštìní Api nebo testù budou vytvoøeny testovní data (5 produktù).
4) Spuštìní:
	a) Api: zmáèkni klávesu F5.
	b) Testy: klikni pravım tlaèítkem na projekt "AlzaWebApi.Tests" a vyber "Run Tests".


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