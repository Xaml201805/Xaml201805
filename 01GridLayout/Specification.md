# A j�t�k specifik�ci�ja

## A specifik�ci� l�tjogosults�ga

- az el�tt�nk l�v� munka megtervez�se
- hat�konyabb� teszi a kommunik�ci�t a r�sztvev�k k�z�tt (fejleszt�k/felhaszn�l�k)
- az �temterv k�sz�t�s�hez egy bemeneti inform�ci� a specifik�ci�
- a d�nt�sek kik�nyszer�t�s�nek egy kiv�l� eszk�ze a specifik�ci�

## A specifik�ci�kr�l b�vebben
Joe Sposky [cikkei a specifik�ci�r�l magyarul](http://hungarian.joelonsoftware.com/Articles/PainlessFunctionalSpecifi-2.html)

## Szerz�
Plesz G�bor, NetAcademia

## �ltal�nos bemutat�s
Szeretn�nk k�sz�teni egy reakci�id� m�r� j�t�kot. A j�t�k egym�s ut�n mutat k�rtyalapokat, �s nek�nk meg kell mondanunk, hogy a mutatott lap egyezik-e az el�z�vel, vagy sem. Ha j�l v�laszolunk pontot kapunk. A j�t�k m�ri az egyes reakci�id�t, �s az �tlagos reakci�id�t is. A v�g�n a top 5 eredm�nyt is megmutatja.

## Szerepl�k
- **Remek Elek**: szeretn� a ment�lis �llapot�t folyamatosan m�rni �s jav�tani, �gy a reakci�id� m�r� j�t�kkal rendszeresen j�tszik. Minden j�t�k ut�n tudja, hogy a reakci�ideje, a kor�bbi j�t�kokhoz k�pest hogy �ll.

## Forgat�k�nyvek
- **Elek** elind�tja az alkalmaz�st, �s n�h�ny j�t�kot j�tszik, ez�ltal k�pet nyer az aktu�lis reakci� idej�r�l, koncentr�ci�k�pess�g�r�l.

## J�t�kmenet
- [X] Kezd�skor kapunk egy k�rty�t, 
- [X] majd a j�t�k ind�t�s�val a k�rty�nkat egy �j v�ltja fel. A j�t�k ind�t�sa, az Ind�t�s gombbal megy.
- [X] A visszajelz�s�nkre (egyforma/nem egyforma) 
- [X] a j�t�k jelzi egy z�ld pip�val/piros kereszttel, hogy a v�laszunk helyes vagy helytelen.
- [X] a j�t�kot billenty�zettel lehessen j�tszani
- [X] A v�lasznak megfelel� pontot sz�molja, 
  - [X] m�ri az egyes reakci�id�t 
  - [X] �s az �tlagos reakci�id�t is. 
- [ ] A j�t�k meghat�rozott ideig tart, amit a kezd�st�l egy visszasz�ml�l� �ra jelez. 
- [X] A j�t�k v�g�n l�tjuk a pontsz�munkat, 
- [ ] �s a top 5 pontsz�mot. 
- [X] Ha akarjuk �jrakezdhetj�k a j�t�kot, vagy kil�phet�nk.

## A j�t�k f�k�perny�je

```
+---------------------------------------------------------------------------------------------------+
| +----------+  +---------------------------------------------------------------------------------+ |
| |          |  | Inform�ci�k, eredm�ny, visszajelz�s                                             | |
| | Toplista |  +---------------------------------------------------------------------------------+ |
| |          |                                                                                      |
| |          |                                                                                      |
| |          |         +---------------------------+         +---------------------------+          |
| |          |         |                           |         |                           |          |
| |          |         |  Visszajelz�s, hogy a     |         |                           |          |
| |          |         |  v�lasz j� volt+e         |         |   K�rtya a j�t�khoz       |          |
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
| |          |  | K�l�nb�z� gombok, amik egym�s mellett sz�pen k�vetkeznek                        | |
| |          |  |                                                                                 | |
| +----------+  +---------------------------------------------------------------------------------+ |
+---------------------------------------------------------------------------------------------------+
```

- A k�perny�n k�t oszlop lesz: *top 5 lista* �s a k�perny� t�bbi r�sze.
- A top 5 list�n sz�veg lesz, �gy nem �rdemes k�v�lr�l �tm�retezni: �gy a bels� tertalomnak kell az oszlop m�ret�t meghat�rozni. Ez�rt ez az oszlop sz�less�g: **Auto**
- a marad�k pedig t�ltse ki a rendelkez�sre �ll� helyet.
- A m�sodik oszlopban pedig h�rom sor lesz, az als� �s fels� a tartalom m�ret�t veszi fel, a k�z�ps� pedig kit�lti a rendelkez�sre �ll� teret.

## K�dol�si jegyzet
- A k�rty�k megmutat�s�hoz k�pet kell kezeln�nk. Vagy mi rajtolunk, vagy keres�nk az Interneten, vagy egy "okos" megold�st haszn�lunk. Rajzolni nem fogunk, egyszer�en k�rtyak�pet nem tal�ltunk, a harmadik megold�st v�lasztjuk.
  - amire sz�ks�g�nk van, az a **vektorgrafika**, �gy el tudjuk ker�lni a k�pm�retez�s miatti raszteres k�peket.
  - �rdemes tudni, hogy p�ld�ul a let�lthet� unicode fontok vektorgrafik�t tartalmaznak.
  - �rdemes tudni, hogy ezt a technol�gi�t az Internet �s a www terjed�se miatt "minden" t�mogatja
  - �rdemes tudni, hogy egy ideje az ikonokat, ikonk�szleteket fontk�szletben teszik el�rhet�v� a k�sz�t�k
  - a [Font Awesome](https://fontawesome.com/) egy ingyenes, [ny�lt forr�sk�d�](https://github.com/FortAwesome/Font-Awesome) vektorgrafikus fontban terjesztett ikonk�szlet
- Idegen fejleszt� munk�j�t szeretn�nk felhaszn�lni az alkalmaz�sunkban. Ezt f�gg�s�gnek h�vjuk, err�l egy [hosszabb le�r�s itt tal�lhat�](http://netacademia.blog.hu/2016/04/21/hogy_kerulhetjuk_el_a_szoftverpusztulast_12factor_app_2_fuggosegek_kezelese). A teljes [cikksorozat pedig itt](http://netacademia.blog.hu/tags/12FactorApp).
  - csomagkezel�snek h�vjuk, ennek az eszk�ze a .net fejleszt�k sz�m�ra a [nuget](https://www.nuget.org/).
  - be tudunk h�vni az alkalmaz�sunkba egy vagy t�bb nuget csomagot.
  - a mi �ltalunk kiv�lasztott csomag, a [FontAwesome.WPF](https://www.nuget.org/packages/FontAwesome.WPF/). A csomag ny�lt forr�sk�d�, a [k�d a githubon](https://github.com/charri/Font-Awesome-WPF) tal�lhat�.
  - a nuget v�gzi a verzi� ellen�rz�st (egy adott verzi�t �s a legutols� verzi� is tudjuk telep�teni)
  - a csomag friss�t�s�t is a nuget seg�ts�g�vel tudjuk megoldani.
  - a csomag esetleges f�gg�s�geit is telep�tj�k a seg�ts�g�vel. 
  - Mit csin�l?
    - a csomagot let�lti a solution Packages k�nyvt�r�ba.
    - a projektben a packages.config �llom�ny tartalmazza a telep�tett csomagokat.
    - a telep�tett csomagokat a nuget felveszi a referenci�k k�z�
  - ahhoz, hogy haszn�ljuk, 
    - telep�ten�nk kell a csomagot
    - a n�vt�r hivatkoz�st (xmlns:fa="http://schemas.fontawesome.io/icons/") az ablak defin�ci�j�hoz hozz� kell adni!

### Feladatok
- a gombokra kattint�ssal t�rt�njen valami
- legyen k�rty�knak egy halmaza, amib�l kattint�sra egyet megjelen�t�nk v�letlenszer�en
  - l�trehozunk egy polcot, amire k�rty�kat tudunk tenni,
  - a polc egyes elemeire kitesz�nk k�rty�kat,
  - a polc egyes elemei meg vannak sz�mozva 0-t�l a k�rty�k sz�ma-1-ig, 
  - mondunk egy v�letlen sz�mot, �s az annyiadik k�rty�t levessz�k a polcr�l.

### Programoz�s
- a *.xaml a vizu�lis tervez� nyelven (XAML: Extended Application Markup Language) meg�rt **deklarat�v** k�dot tartalmazza
- a *.xaml.cs pedig az un. **Code Behind**, ami a procedur�lis k�dot tartalmazza. Pl. az egyes esem�nyekre adott v�laszokat.

## Feladatok
- Indul�skor csak az Ind�t�s gombra lehessen kattintani.
- Indul�s ut�n az Ind�t�s gombra ne lehessen kattintani, csak az Igen/Nem gombokra.

### Programoz�s
- Amikor elindul az alkalmaz�s, 
  - le kell tiltani az Igen/Nem gombot, 
  - �s enged�lyezni kell az Ind�t�st.
- Amikor az Ind�t�st megnyomtuk, 
  - le kell tiltani az Ind�t�st, 
  - �s enged�lyezni kell az Igen/Nem gombot.


## Feladatok
- �rt�kelni kell, hogy j� gombot nyomtunk-e meg, vagyis tudni kell, hogy az el�z� k�t k�rtya egyforma-e vagy sem.

### Programoz�s
- el kell t�rolni az el�z� k�rty�nak az �rt�k�t
- ehhez nem lok�lis v�ltoz�t, hanem un. oszt�lyszint� v�ltoz� (mez�t/field) haszn�ltunk
- el kell tudni d�nteni, hogy az el�z� k�rtya �s a mostani egyezik-e (egyez�s�g vizsg�lat)
- ha egyezik, m�st csin�lni, mintha nem egyezik, ezt h�vj�k felt�telvizsg�latnak

## Feladatok
- ikonnal jelezni, hogy a v�lasz helyes-e?

### Programoz�s
- baloldali k�rty�ra ikon (pipa/kereszt)
- k�rtya sz�n�nek meghat�roz�sa (piros/z�ld)

## Feladatok
- a v�lasz helyess�g�nek ikonja t�nj�n el egy id� ut�n

### Programoz�s
- anim�ci�val �t�ll�tjuk a k�rtya Opacity �rt�k�t 100%-r�l 0%-ra

## Feladatok
- Billenty�vel is lehessen a j�t�kot j�tszani. Ehhez:
  - j�t�kot lehessen ind�tani billenty�vel (felfel� ny�l)
  - igen �s nem-et lehessen v�laszolni billenty�vel (jobbra/balra ny�l)

### Programoz�s
- el kell tudnunk kapni a billenty�le�t�st
- meg kell tudni mondani, hogy felfel�/jobbra/balra ny�l
- ennek megfelel�en kell a j�t�kot folytatni.

## Feladatok
- az �j k�rtya h�z�s�t is anim�ci�val jelezni
- a haszn�lhat� billenty�k jelz�se a gombokon
- j�t�k az anim�ci�val: mit lehet csin�lni a gombokkal

## Feladatok
- a pontsz�m sz�m�t�sa �s megmutat�sa
  - sz�ks�ges ismerni a v�lasz helyess�g�t
    - j� v�lasz eset�n + 100 pont
    - rossz v�lasz eset�n -100 pont
  - sz�ks�ges ismerni a v�laszhoz sz�ks�ges id�t: stopper�ra
    - Ehhez id�m�r� id�m�r� infrastrukt�ra
    - amikor kitessz�k a k�rty�t, amire v�laszt v�runk, elind�tjuk a stoppert
    - amikor megj�n a v�lasz, meg�ll�tjuk a stoppert
  - esetleg �rdemes ismerni az �tlagos reakci�id�t is.
- az eltelt/visszal�v� j�t�kid� sz�m�t�sa
  - Ehhez id�m�r� id�m�r� infrastrukt�ra, valamilyen ism�tl�d� esem�ny,
    amire feliratkozva m�r tudjuk az id�t sz�molni.

## Feladat: TOP 5 eredm�ny nyilv�ntart�sa �s megjelen�t�se
- tartsuk nyilv�n az eredm�nyeket �s mutassuk meg.
- mindig csak a legjobb 5-�t mutassuk meg.
- a top 5 list�t elmenteni �s a j�t�k kezdetekor visszat�lteni a legutls� �llapotot
