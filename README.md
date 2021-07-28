# TodoApp

## Indítás
Semmilyen előkészítés nem szükséges, csak el kell indtítani a projektet. Az alkalmazás elindítása után létrehozza magának a db-t, a tesztek futtatása során szintén.

## Seed
A projekt indulásakor 60 példaadatot tesz az alkalmazás a db-be, hogy teszelhetőek legyenek a funkciók.

## Néhány komment a megoldásomhoz

### Felhasználókezelés
Nem volt számomra egyértelmű, hogy kell-e felhasználókezelés de ha megcsináltam volna akkor a beépített EF Core-os Identity-t használtam volna, ezen keresztül Scaffoldolható akár az egész regisztrációs és bejelentkezés oldal.
### Servicek
Megvalósításomban a mediátor mintát használtam, ez egy lazább csatolást biztosít a rétegek között, csak az IMediator interface-től függünk. Természetesen a hagyományos servicekkel is megoldható lett volna a feladat (interface-megvalósítás).
### Tesztek
Nem 100%-os a kódlefedettség, de szerintem jól mutatja azt, hogy képzelem el a tesztelést NUnit eszköz segítségével.
### Domain
Ha ez nagyobb domain entitás halmazzal rendelkező projekt lenne, érdemes lenne kiemelni egy ".Domain" elnevesű projektbe az entitásokat. Akár csak azért, hogy a Dal-ban definiált dolgokkal együtt ne tudja elérni a Web-es projekt.

