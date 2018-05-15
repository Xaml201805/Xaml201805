# Xaml201805
A NetAcademia Kártyajáték XAML és C# használatával című tanfolyamának kiegészítő kódtára

## Felkészülés
A tanfolyamon a **Visual Studio 2017 Community** változatát fogom használni. Mivel ez sok helyet foglal el, így akinek a **Visual Studio 2015 Community** változat van fenn, nem kell megijedni, minden gond nélkül tudja a tanfolyamot követni. Mindkettő ingyenese elérhető önálló fejlesztők, nyílt forráskódú projektek, akadémiai kutatók számára. Továbbá oktatási célokra és kis (max 5 fős) fejlesztőcsapatoknak.

### Chocolatey telepítése
1. indítsunk egy adminisztrátori parancssort ([elevated command prompt](http://www.computerhope.com/jargon/e/elevated.htm)),

2. tegyük vágólapra ezt (igen, az egészet!):

**@powershell -NoProfile -ExecutionPolicy Bypass -Command "iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))" && SET "PATH=%PATH%;%ALLUSERSPROFILE%\chocolatey\bin"**

3. majd a parancssorunkba illesszük be és futtassuk le.

Ezzel telepítettünk egy csomagkezelőt, innentől kezdve nem kell letölteni és telepíteni kattintgatásokkal az alkalmazásainkat, hanem a csomagkezelőnkre bizhatjuk a dolgot, legalábbis [jelenleg már több, mint 5000 alkalmazás esetében](https://chocolatey.org/packages).

### Visual Studio Community 2017 telepítése 
#### Telepítés letöltéssel

Letölteni a telepítőt [erről az oldalról](https://www.visualstudio.com/downloads/) lehet. Válasszuk a Visual Studio Community 2017-et, töltsük le és telepítsük. Figyelem, meglehetősen sok helyet foglal, nekem simán elkért 15GB-ot, így ha ez gondot okoz, akkor válasszuk a 2015-öt.

#### Telepítés Chocolatey-vel
Mivel van csomagkezelőnk, a Visual Studio Community 2017 telepítése 
[adminisztrátori parancssorból így megy](https://chocolatey.org/packages/VisualStudio2017Community)

**cinst visualstudio2017community**

### Visual Studio 2015 Community telepítése
#### Telepítés letöltéssel
Ezt letölteni [erről az oldalról](https://docs.microsoft.com/hu-hu/visualstudio/releasenotes/vs2015-version-history) lehet, itt a Download Visual Studio 2015 gombot választva letöltjük a telepítőt. Ezt a szokásos módon lefuttatva települ a fejlesztőkörnyezet.

#### Telepítés chocolatey-vel

Mivel van csomagkezelőnk, a Visual Studio Community 2015 telepítése [adminisztrátori parancssorból így megy](https://chocolatey.org/packages/VisualStudio2015Community):

**cinst visualstudio2015community**


# Házi feladat 1
- Tegyünk ki egy GridSplittert a meglévő grid layout-ra, ami az első és a második oszlop közözzi méretezést végzi el.
- Tegyünk ki egy GridSplittert, ami vizszintesen végzi a sorok méretezését.

# Elérhetőségek
- A csoportba [itt lehet jelentkezni](https://www.facebook.com/groups/dotnetcapak/)
- email: [plesz.gabor@netacademia.hu](emailto: plesz.gabor@netacademia.hu)

# Házi feladat 2
- próbáljuk ki, hogy a kártyapakli nem 6 elemű, és nem ezek a kártyák vannak benne
- a gombok eseményvezérlőiben üzenjük ki, hogy hányadik kártyalapot húztuk, esetleg azt is, hogy melyiket

# Házi feladat 3
- Debuggoljátok végig a program egyes részeit, keressetek felesleges duplázódásokat.
- A gombokat tervezzétek át úgy, hogy az ikon a szöveg fölött legyen.


# Tanulás felnőtt fejjel
- Figyelem
- Létrehozás, alkotás
- Érzelem
- Elegendő idő
[AGES: Attention, Generation, Emotion, Spacing](https://www.inc.com/laura-garnett/four-secrets-to-learning-anything-according-to-neuroscience.html)

# Házi feladat 4
- a ciklusokat próbálgatni, milyen hibákat tud okozni
- a "*" billentyű a játék végén kezdje újra a játékot
- kitalálni, hogy előre számláló idő helyett, hogy lehet visszaszámlálást csinálni?
- a top 5 nyilvántartásán gondolkodni