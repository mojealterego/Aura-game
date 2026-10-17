# AURA — architektura

Źródło: „Projekt Gry Aura Na Androida”, 15 stron.

## Granice modułów
- **Cards**: definicja i walidacja kart
- **Core**: deterministyczny automat sesji bez zależności Unity
- **Gameplay**: adapter MonoBehaviour / UI
- **Input**: orientacja kart i czujniki
- **Haptics**: opcjonalny adapter Android

## Reguły bezpieczeństwa i etyki
Mechanika narracyjna jest fikcją interaktywną, nie diagnozą psychologiczną. Nie stosujemy ukrytych poleceń do manipulacji użytkownikiem, nie wyciągamy wniosków o zdrowiu psychicznym z danych sensora. Audio, haptykę i ruch ekranu można wyłączyć.

## Kryteria odbioru
1. Każda karta ma stabilne unikalne ID.
2. Nie można zagrać karty z innej fazy ani ponownie tej samej.
3. Testy EditMode przechodzą w Unity Test Runner.
4. Scena Android uruchamia się offline, bez crashy.
5. Opcje dostępności działają na urządzeniu.
6. Build AAB przechodzi walidację przed publikacją.
