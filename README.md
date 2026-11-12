# Nordpunkt CMS

En nyhetssite byggd i Umbraco 18 (.NET 10) med Tailwind CSS. Innehåll och dokumenttyper versionshanteras med uSync.

## Funktioner

- Startsida, nyhetsöversikt och artikelsidor
- Kategorier, sortering på datum och relaterade artiklar
- Sök i sidhuvudet
- Standardsidor och navigation
- Formulär för nyhetstips med bekräftelse och statusspårning i backoffice

## Kom igång

Kräver [.NET 10 SDK](https://dotnet.microsoft.com/download) och [Node.js](https://nodejs.org/).

```bash
git clone https://github.com/Grupp-5-CMS/nordpunkt-cms.git
cd nordpunkt-cms/nordpunkt-cms

# Skapa lokala inställningar (appsettings ligger i .gitignore)
cp dummy.appsettings.json appsettings.json
cp dummy.appsettings.Development.json appsettings.Development.json

npm install
dotnet run
```

Siten körs på https://localhost:44307 och backoffice på `/umbraco`.

Vid första starten skapar Umbracos installationsguide databasen och ditt adminkonto. Importera sedan innehållet under **Settings → uSync → Import**.

## Tailwind

```bash
npm run dev    # bygger wwwroot/css/tailwind.css och bevakar ändringar
npm run prod   # minifierad build
```

## Struktur

| Mapp | Innehåll |
| --- | --- |
| `Views/` | Sidmallar och partials |
| `Controllers/`, `ViewModels/` | Tipsformuläret |
| `uSync/v18/` | Dokumenttyper, datatyper, innehåll och media |
| `wwwroot/css/` | Tailwind-källa och genererad CSS |
