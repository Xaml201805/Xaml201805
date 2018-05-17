# A játék specifikációja

## A specifikáció létjogosultsága

- az elõttünk lévõ munka megtervezése
- hatékonyabbá teszi a kommunikációt a résztvevõk között (fejlesztõk/felhasználók)
- az ütemterv készítéséhez egy bemeneti információ a specifikáció
- a döntések kikényszerítésének egy kiváló eszköze a specifikáció

## A specifikációkról bõvebben
Joe Sposky [cikkei a specifikációról magyarul](http://hungarian.joelonsoftware.com/Articles/PainlessFunctionalSpecifi-2.html)

## Szerzõ
Plesz Gábor, NetAcademia

## Általános bemutatás
Szeretnénk készíteni egy reakcióidõ mérõ játékot. A játék egymás után mutat kártyalapokat, és nekünk meg kell mondanunk, hogy a mutatott lap egyezik-e az elõzõvel, vagy sem. Ha jól válaszolunk pontot kapunk. A játék méri az egyes reakcióidõt, és az átlagos reakcióidõt is. A végén a top 5 eredményt is megmutatja.

## Szereplõk
- **Remek Elek**: szeretné a mentális állapotát folyamatosan mérni és javítani, így a reakcióidõ mérõ játékkal rendszeresen játszik. Minden játék után tudja, hogy a reakcióideje, a korábbi játékokhoz képest hogy áll.

## Forgatókönyvek
- **Elek** elindítja az alkalmazást, és néhány játékot játszik, ezáltal képet nyer az aktuális reakció idejérõl, koncentrációképességérõl.

## Játékmenet
- [X] Kezdéskor kapunk egy kártyát, 
- [X] majd a játék indításával a kártyánkat egy új váltja fel. A játék indítása, az Indítás gombbal megy.
- [X] A visszajelzésünkre (egyforma/nem egyforma) 
- [X] a játék jelzi egy zöld pipával/piros kereszttel, hogy a válaszunk helyes vagy helytelen.
- [X] a játékot billentyûzettel lehessen játszani
- [X] A válasznak megfelelõ pontot számolja, 
  - [X] méri az egyes reakcióidõt 
  - [X] és az átlagos reakcióidõt is. 
- [ ] A játék meghatározott ideig tart, amit a kezdéstõl egy visszaszámláló óra jelez. 
- [X] A játék végén látjuk a pontszámunkat, 
- [X] és a top 5 pontszámot. 
- [X] Ha akarjuk újrakezdhetjük a játékot, vagy kiléphetünk.

## A játék fõképernyõje

```
+---------------------------------------------------------------------------------------------------+
| +----------+  +---------------------------------------------------------------------------------+ |
| |          |  | Információk, eredmény, visszajelzés                                             | |
| | Toplista |  +---------------------------------------------------------------------------------+ |
| |          |                                                                                      |
| |          |                                                                                      |
| |          |         +---------------------------+         +---------------------------+          |
| |          |         |                           |         |                           |          |
| |          |         |  Visszajelzés, hogy a     |         |                           |          |
| |          |         |  válasz jó volt+e         |         |   Kártya a játékhoz       |          |
| |          |         |  vagy sem                 |         |                           |          |
| |          |         |                           |         |                           |          |
| |          |         |                           |         |                           |          |
| |          |         |                           |         |                           |          |
| |          |         |                           |         |                           |          |
| |          |         |                           |         |                           |          |
| |          |         |                           |         |                           |          |
| |          |         |                           |         |                           |          |
| |          |         |                           |         |                           |          |
| |          |         |                           |         |                           |          |
| |          |         |                           |         |                           |          |
| |          |         +---------------------------+         +---------------------------+          |
| |          |                                                                                      |
| |          |  +---------------------------------------------------------------------------------+ |
| |          |  | Különbözõ gombok, amik egymás mellett szépen következnek                        | |
| |          |  |                                                                                 | |
| +----------+  +---------------------------------------------------------------------------------+ |
+---------------------------------------------------------------------------------------------------+
```

- A képernyõn két oszlop lesz: *top 5 lista* és a képernyõ többi része.
- A top 5 listán szöveg lesz, így nem érdemes kívülrõl átméretezni: így a belsõ tertalomnak kell az oszlop méretét meghatározni. Ezért ez az oszlop szélesség: **Auto**
- a maradék pedig töltse ki a rendelkezésre álló helyet.
- A második oszlopban pedig három sor lesz, az alsó és felsõ a tartalom méretét veszi fel, a középsõ pedig kitölti a rendelkezésre álló teret.

## Kódolási jegyzet
- A kártyák megmutatásához képet kell kezelnünk. Vagy mi rajtolunk, vagy keresünk az Interneten, vagy egy "okos" megoldást használunk. Rajzolni nem fogunk, egyszerûen kártyaképet nem találtunk, a harmadik megoldást választjuk.
  - amire szükségünk van, az a **vektorgrafika**, így el tudjuk kerülni a képméretezés miatti raszteres képeket.
  - érdemes tudni, hogy például a letölthetõ unicode fontok vektorgrafikát tartalmaznak.
  - érdemes tudni, hogy ezt a technológiát az Internet és a www terjedése miatt "minden" támogatja
  - érdemes tudni, hogy egy ideje az ikonokat, ikonkészleteket fontkészletben teszik elérhetõvé a készítõk
  - a [Font Awesome](https://fontawesome.com/) egy ingyenes, [nyílt forráskódú](https://github.com/FortAwesome/Font-Awesome) vektorgrafikus fontban terjesztett ikonkészlet
- Idegen fejlesztõ munkáját szeretnénk felhasználni az alkalmazásunkban. Ezt függõségnek hívjuk, errõl egy [hosszabb leírás itt található](http://netacademia.blog.hu/2016/04/21/hogy_kerulhetjuk_el_a_szoftverpusztulast_12factor_app_2_fuggosegek_kezelese). A teljes [cikksorozat pedig itt](http://netacademia.blog.hu/tags/12FactorApp).
  - csomagkezelésnek hívjuk, ennek az eszköze a .net fejlesztõk számára a [nuget](https://www.nuget.org/).
  - be tudunk hívni az alkalmazásunkba egy vagy több nuget csomagot.
  - a mi általunk kiválasztott csomag, a [FontAwesome.WPF](https://www.nuget.org/packages/FontAwesome.WPF/). A csomag nyílt forráskódú, a [kód a githubon](https://github.com/charri/Font-Awesome-WPF) található.
  - a nuget végzi a verzió ellenõrzést (egy adott verziót és a legutolsó verzió is tudjuk telepíteni)
  - a csomag frissítését is a nuget segítségével tudjuk megoldani.
  - a csomag esetleges függõségeit is telepítjük a segítségével. 
  - Mit csinál?
    - a csomagot letölti a solution Packages könyvtárába.
    - a projektben a packages.config állomány tartalmazza a telepített csomagokat.
    - a telepített csomagokat a nuget felveszi a referenciák közé
  - ahhoz, hogy használjuk, 
    - telepítenünk kell a csomagot
    - a névtér hivatkozást (xmlns:fa="http://schemas.fontawesome.io/icons/") az ablak definíciójához hozzá kell adni!

### Feladatok
- a gombokra kattintással történjen valami
- legyen kártyáknak egy halmaza, amibõl kattintásra egyet megjelenítünk véletlenszerûen
  - létrehozunk egy polcot, amire kártyákat tudunk tenni,
  - a polc egyes elemeire kiteszünk kártyákat,
  - a polc egyes elemei meg vannak számozva 0-tól a kártyák száma-1-ig, 
  - mondunk egy véletlen számot, és az annyiadik kártyát levesszük a polcról.

### Programozás
- a *.xaml a vizuális tervezõ nyelven (XAML: Extended Application Markup Language) megírt **deklaratív** kódot tartalmazza
- a *.xaml.cs pedig az un. **Code Behind**, ami a procedurális kódot tartalmazza. Pl. az egyes eseményekre adott válaszokat.

## Feladatok
- Induláskor csak az Indítás gombra lehessen kattintani.
- Indulás után az Indítás gombra ne lehessen kattintani, csak az Igen/Nem gombokra.

### Programozás
- Amikor elindul az alkalmazás, 
  - le kell tiltani az Igen/Nem gombot, 
  - és engedélyezni kell az Indítást.
- Amikor az Indítást megnyomtuk, 
  - le kell tiltani az Indítást, 
  - és engedélyezni kell az Igen/Nem gombot.


## Feladatok
- értékelni kell, hogy jó gombot nyomtunk-e meg, vagyis tudni kell, hogy az elõzõ két kártya egyforma-e vagy sem.

### Programozás
- el kell tárolni az elõzõ kártyának az értékét
- ehhez nem lokális változót, hanem un. osztályszintû változó (mezõt/field) használtunk
- el kell tudni dönteni, hogy az elõzõ kártya és a mostani egyezik-e (egyezõség vizsgálat)
- ha egyezik, mást csinálni, mintha nem egyezik, ezt hívják feltételvizsgálatnak

## Feladatok
- ikonnal jelezni, hogy a válasz helyes-e?

### Programozás
- baloldali kártyára ikon (pipa/kereszt)
- kártya színének meghatározása (piros/zöld)

## Feladatok
- a válasz helyességének ikonja tûnjön el egy idõ után

### Programozás
- animációval átállítjuk a kártya Opacity értékét 100%-ról 0%-ra

## Feladatok
- Billentyûvel is lehessen a játékot játszani. Ehhez:
  - játékot lehessen indítani billentyûvel (felfelé nyíl)
  - igen és nem-et lehessen válaszolni billentyûvel (jobbra/balra nyíl)

### Programozás
- el kell tudnunk kapni a billentyûleütést
- meg kell tudni mondani, hogy felfelé/jobbra/balra nyíl
- ennek megfelelõen kell a játékot folytatni.

## Feladatok
- az új kártya húzását is animációval jelezni
- a használható billentyûk jelzése a gombokon
- játék az animációval: mit lehet csinálni a gombokkal

## Feladatok
- a pontszám számítása és megmutatása
  - szükséges ismerni a válasz helyességét
    - jó válasz esetén + 100 pont
    - rossz válasz esetán -100 pont
  - szükséges ismerni a válaszhoz szükséges idõt: stopperóra
    - Ehhez idõmérõ idõmérõ infrastruktúra
    - amikor kitesszük a kártyát, amire választ várunk, elindítjuk a stoppert
    - amikor megjön a válasz, megállítjuk a stoppert
  - esetleg érdemes ismerni az átlagos reakcióidõt is.
- az eltelt/visszalévõ játékidõ számítása
  - Ehhez idõmérõ idõmérõ infrastruktúra, valamilyen ismétlõdõ esemény,
    amire feliratkozva már tudjuk az idõt számolni.

## Feladat: TOP 5 eredmény nyilvántartása és megjelenítése
- tartsuk nyilván az eredményeket és mutassuk meg.
- mindig csak a legjobb 5-öt mutassuk meg.
- a top 5 listát elmenteni 
- és a játék kezdetekor visszatölteni a legutolsó állapotot
