🐰 Catapult Game – Unity-peli
🎯 Sovelluksen käyttötarkoitus
Tämä on Unityllä toteutettu katapulttipeli, jossa pelaaja laukaisee pupun katapultista ja yrittää osua maaleihin. Tavoitteena on kerätä pisteitä osumalla laatikoihin tai pistealueisiin.

🔄** Sovelluksen toiminta**
--> Katapultin laukaisu
Space = Ammu pupu katapultista 
Hahmo laukaistaan painamalla välilyöntiä (Space).

Laukaisu tapahtuu Launch()-funktiolla, joka:

Vapauttaa Rigidbody-komponentin liikkeelle

Lisää impulssivoiman valittuun suuntaan

Käynnistää katapultin animaation


**--> Katapultin pyöritys**

Katapultin suuntaa voi muuttaa nuolinäppäimillä (vasen/oikea).

HandleRotation() hoitaa pyörityksen Horizontal-akselin mukaan.

Hahmon asento seuraa katapulttia, kun sitä ei ole vielä laukaistu.

Nuolinäppäimet = Pyöritä katapulttia ( tai A/D)

**--> Katapultin resetointi**
R = Resetoi pupu alkuun (Painamalla R-näppäintä hahmo palautuu alkuasentoon)
ResetCatapult() asettaa hahmon takaisin katapultin kärkeen ja estää liikkeen (isKinematic = true).

T= Heittää 3 kertää

**--> Uusi ominaisuus: Automaattinen laukaisusilmukka**

Koodi;

 IEnumerator TestMultipleLaunches(int count, float delay)
    {
        for (int i = 0; i < count; i++)
        {
            Debug.Log($"Launch {i + 1}");
            Launch();
            yield return new WaitForSeconds(delay);
            ResetCatapult();
            yield return new WaitForSeconds(0.5f); // pieni tauko resetin jälkeen
        }
    }
    Painamalla T-näppäintä funktio käynnistyy:
    StartCoroutine(TestMultipleLaunches(3, 3f));
    Hahmo laukaisee 3 kertaa, 3 sekunnin välillä.
    Jokaisen laukaisun jälkeen katapultti palautuu ja odottaa hetken ennen seuraavaa kierrosta.

  Kun pupu osuu pistealueeseen, saat pisteitä.
**Jatkokehitysideoita**
-Mahdollisuus määrittää laukaisujen määrä ja viive suoraan pelin valikosta,
-Mahdollisuus valita erilaisia hahmoja,
-Mahdollisuus siirtyä seuraavalle tasolle.



[👉 Pelää tästä](https://yadicim.itch.io/katapultti)




![Näyttökuva 2025-06-18 102346](https://github.com/user-attachments/assets/e08fe75a-08ba-4cb7-84c7-e6ecc0cb1092)

![Näyttökuva 2025-06-18 105309](https://github.com/user-attachments/assets/92e63840-78bd-4bc6-b3f8-96fdf46ce59e)

![Näyttökuva 2025-06-18 105330](https://github.com/user-attachments/assets/7dfa0e10-f146-4c02-9610-61f7e82f768a)

![Näyttökuva 2025-06-18 105343](https://github.com/user-attachments/assets/7d7fd9b7-2674-4d28-9446-f8e272104d43)

![Näyttökuva 2025-06-18 105356](https://github.com/user-attachments/assets/5c1d07c1-fb18-419e-9c63-8a104e821e09)

![Näyttökuva 2025-06-18 105436](https://github.com/user-attachments/assets/6b71cfca-f88d-4de2-ae7d-539482f4edbb)

![Näyttökuva 2025-06-18 105256](https://github.com/user-attachments/assets/01923f45-4c8f-437f-b646-224d6b2a5623)

