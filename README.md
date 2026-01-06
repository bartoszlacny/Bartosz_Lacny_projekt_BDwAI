Dokumentacja Projektu: System Zarządzania Schroniskiem

Autor: Bartosz Łacny
Technologia: ASP.NET Core MVC (.NET 8.0)

1. Opis Projektu
Aplikacja internetowa służąca do kompleksowego zarządzania schroniskiem dla zwierząt. System umożliwia prowadzenie ewidencji podopiecznych, zarządzanie infrastrukturą oraz kategoryzację zwierząt. Kluczowym elementem jest moduł adopcyjny, pozwalający użytkownikom na składanie wniosków o adopcję. Aplikacja realizuje podział uprawnień na Administratorów (zarządzanie treścią) oraz Użytkowników (adopcja). Projekt udostępnia również API RESTowe do pobierania danych o zwierzętach.

2. Wymagania systemowe
Aby poprawnie uruchomić projekt, środowisko musi spełniać następujące wymagania:
- System operacyjny: Windows 10/11.
- Środowisko programistyczne: Visual Studio 2022 (wersja z obsługą .NET 8).
- SDK: .NET 8.0 Software Development Kit.
- Baza danych: Microsoft SQL Server.

3. Instalacja i Uruchomienie
A. Pobranie: Skopiuj folder z projektem na dysk lokalny.
B. Otwarcie: Uruchom plik Bartosz_Lacny_projekt_bazy_danych.sln w Visual Studio.
C. Przywracanie pakietów: Visual Studio automatycznie pobierze brakujące biblioteki NuGet przy pierwszym zbudowaniu.
D. Tworzenie bazy danych:
- Wykonaj punkt 4.A w celu zmiany nazwy serwera
- Otwórz konsolę: Tools -> Nuget Package Manager -> Package Manager Console
- Wpisz polecenie: Update-Database
- Zatwierdź Enterem. Spowoduje to utworzenie bazy i tabel na podstawie kodu.
E. Start: Naciśnij klawisz F5 lub zieloną strzałkę "Start" w Visual Studio.

4. Konfiguracja
A. Połączenie z bazą
Konfiguracja znajduje się w pliku appsettings.json. Projekt jest skonfigurowany pod SQL Server Express.

"ConnectionStrings": {
    "DefaultConnection": "Server=DESKTOP-OM1P84F\\SQLEXPRESS;Database=SchroniskoDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
},

W przypadku zmiany serwera na inny, należy edytować fragment Server=...

B. Użytkownicy Testowi i Hasła
System posiada mechanizm Seedowania, który przy pierwszym uruchomieniu automatycznie tworzy konto Administratora i role w bazie danych.

Konto Administratora (Pełne uprawnienia):
- Login: admin@schronisko.pl
- Hasło: Haslo123!

Konto Użytkownika (Uprawnienia podstawowe):
- Można zarejestrować się samodzielnie w aplikacji.
- Przykładowe dane (do utworzenia ręcznie): login user@schronisko.pl, hasło: Haslo123!

5. Opis funkcjonalności
System dostosowuje widok i dostępne funkcje w zależności od roli zalogowanej osoby.

A. Użytkownik Niezalogowany (Gość)
- Ma dostęp do strony głównej.
- Może przeglądać listę zwierząt w zakładce "Zwierzęta".
- Może wejść w "Szczegóły" danego zwierzęcia.
- Nie widzi przycisków edycji, usuwania ani składania wniosków.
- Próba wejścia w strefę chronioną przekierowuje do logowania.

B. Zalogowany Użytkownik (Rola: User)
- Posiada wszystkie uprawnienia Gościa.
- Na pasku na górze story widzi dodatkową zakładkę "Złóż wniosek".
- Może wypełnić formularz adopcyjny (Wniosek). Po wysłaniu wniosku zostanie przekierowany z powrotem do listy zwierząt.
- Ma dostęp do edycji swojego profilu (Zmiana hasła, zmiana danych).

C. Administrator (Rola: Admin)
- Posiada pełną kontrolę nad systemem.
- Moduł Zwierzęta: Może dodawać nowe zwierzęta, edytować ich dane oraz usuwać z bazy.
- Moduł Słowników: Widzi ukryte zakładki "Gatunki" oraz "Klatki" i może nimi zarządzać.
- Moduł Wniosków: Ma dostęp do zakładki "Wnioski", gdzie widzi listę wszystkich zgłoszeń adopcyjnych od użytkowników.

6. Specyfikacja techniczna

A. Wzorzec MVC: Aplikacja podzielona na Modele, Widoki i Kontrolery

B. Encje: Projekt zwaiera modele połączone relacjami:
- Animal (Encja główna)
- Category (Relacja 1:N z Animal)
- Cage (Relacja 1:N z Animal)
- AdoptionApplication (Relaja N:1 z Animal)

C. API: Zaimplementowano API typu REST dla głównej encji (Zwierzęta):
- Adres endpointu: /api/AnimalsApi
- Obsługuje pełny CRUD (GET, POST, PUT, DELETE)
- Zwraca dane w formacie JSON