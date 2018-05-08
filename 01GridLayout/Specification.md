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
|                                          +-----------------------------------------------------+  |
|  +----------+                            | Információk, eredmény, visszajelzés                 |  |
|  |          |                            +-----------------------------------------------------+  |
|  | Toplista |                                                                                     |
|  |          |                                                                                     |
|  |          |                 +---------------------------+        +---------------------------+  |
|  |          |                 |                           |        |                           |  |
|  |          |                 |  Visszajelzés, hogy a     |        |                           |  |
|  |          |                 |  válasz jó volt-e         |        |   Kártya a játékhoz       |  |
|  |          |                 |  vagy sem                 |        |                           |  |
|  |          |                 |                           |        |                           |  |
|  |          |                 |                           |        |                           |  |
|  |          |                 |                           |        |                           |  |
|  |          |                 |                           |        |                           |  |
|  |          |                 |                           |        |                           |  |
|  |          |                 |                           |        |                           |  |
|  |          |                 |                           |        |                           |  |
|  |          |                 |                           |        |                           |  |
|  |          |                 |                           |        |                           |  |
|  +----------+                 |                           |        |                           |  |
|                               +---------------------------+        +---------------------------+  |
|                                                                                                   |
|  +---------------------------------------------------------------------------------------------+  |
|  |   Különbözõ gombok, amik egymás mellett szépen következnek                                  |  |
|  |                                                                                             |  |
|  +---------------------------------------------------------------------------------------------+  |
+---------------------------------------------------------------------------------------------------+

```