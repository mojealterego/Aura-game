# AURA — Android Premium Card Game

Narracyjno-strategiczna gra karciana na Androida, inspirowana dokumentem „Projekt Transformacji Cyfrowej i Architektura Systemowa Gry Karcianej Aura”.

## Stan
Wczesny etap implementacji. Repozytorium zawiera fundament logiki rozgrywki, testy EditMode i podstawowe komponenty Unity. Nie ma jeszcze kompletnej sceny ani zweryfikowanego APK/AAB.

## Architektura
- Unity 6.x / C# / Android
- Deterministyczny model sesji: Reflection → Imagination → Complete
- Karty z unikalnymi identyfikatorami; walidacja przejść
- Opcjonalne efekty haptyczne i orientacja żyroskopowa
- Offline-first; bez reklam, telemetryki i mikropłatności

## Uruchomienie
1. Utwórz projekt Unity 6 (Universal 3D/URP).
2. Skopiuj katalog Assets/Scripts i Assets/Tests do projektu Unity.
3. W scenie dodaj Canvas z trzema komponentami Text i Button.
4. Dodaj AuraSessionController do GameObject i przypisz referencje w Inspector.
5. Włącz Android Build Support i uruchom testy w Unity Test Runner.

**Uwaga:** To repozytorium nie jest jeszcze pełnym projektem Unity otwieranym jednym kliknięciem; konfiguracja edytora, grafika i scena są w przygotowaniu.

[Roadmapa](ROADMAP.md) · [Założenia architektoniczne](docs/ARCHITECTURE.md)
