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
- Kezdéskor kapunk egy kártyát, majd a játék kezdésével a kártyánkat egy új váltja fel. 
- A visszajelzésünkre (egyforma/nem egyforma) a játék jelzi egy zöld pipával/piros kereszttel, hogy a válaszunk helyes vagy helytelen. 
- A válasznak megfelelõ pontot számolja, 
- méri az egyes reakcióidõt 
- és az átlagos reakcióidõt is. 
- A játék meghatározott ideig tart, amit a kezdéstõl egy visszaszámláló óra jelez. 
- A játék végén látjuk a pontszámunkat, 
- és a top 5 pontszámot. 
- Ha akarjuk újrakezdhetjük a játékot, vagy kiléphetünk.

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