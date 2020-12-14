
Studenter:
s325906 Pedram Rahdeirjoo
s330325 Ine Camilla Nordnes
s330156 Mohammed Ali Zedan
s331357 Anas Mohammed Dyab






-Pålogging gjøres ved å registrere ny bruker på Admin login-siden
-For koden vi bruker til Admin login og metoder for endre og slett, har vi tatt 
utgangspunkt i kodegjennomgang fra forelesningene, og tilpasset vår applikasjon.
- Vi har benyttet glyphicon i lister, knapper og linker. Dette vil ikke fungere uten 
å være koblet til internett (noe vi forutsetter at man må være for å bestille
en reise via en webapplikasjon).

Avgang(/Avganger):
Legge til: Legger til tid for ny avgang, oppretter en togId og en stasjonId.
Endre: Her er det kun lagt inn mulighet for å endre tidspunkt, da tog er tilknyttet
       faste stasjoner. Det er ikke hensiktsmessig å endre disse, da ville man heller 
       opprettet en ny avgang.

Billetter(/Billter):
Har valgt å ikke implementere mulighet for å legge til eller endre billett.
Dette fordi vi ikke har informasjon om ordre, ordrelinje eller kunde i databasen.
Vi ser derfor ikke at det er hensiktsmeddig å ha med disse funksjonene i vårt prosjekt.
-Vi har også satt et "Gyldig/Ugyldig" felt i tabellen som viser om billetten er gyldig, 
eller ugyldig(Slettet Id, Stasjon e.l.)

Pris(/EndrePrisV):
Input-felter for å sette ny pris. En for hver billetttype. Da pris ikke hentes fra
databasen, men genereres ut i fra type billett, antall og strekning, har vi valgt å 
implementere endring av pris på denne måten.

Stasjoner(/Stasjoner):
Legge til: Legger til et navn på en stasjon, StasjonId blir automatisk generert.
Endre: Endrer kun navn, da det ikke skal forekomme duplisert id, og om man ønsker ny
id kan man like godt opprette ny stasjon. Vi synes dette er mest hensiktsmessig.
Dessuten er id primærnøkkel.

TogListe(/TogListe):
Legge til: Legger til et navn på et tog (dvs. navnet på strekningen). TogId genereres 
automatisk.
Endre: Endrer kun navnet på strekningen. Igjen, ikke hensikstmessig å skulle endre id.
Dette er primærnøkkel.

