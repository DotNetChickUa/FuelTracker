# FuelTracker

FuelTracker is a web app that helps drivers record fuel fill-ups and analyze consumption and costs over time. It supports multiple vehicles per user, calculates per-fill and rolling metrics, and provides brand/grade comparisons. Storage is canonical (km, liters); views respect user preferences for units and currency.

Features at a glance
- Authentication
  - Sign up with email + password, sign in, sign out.
  - Passwords are stored hashed.
- Profile & Settings
  - Preferred currency (ISO), distance unit (km/mi), volume unit (L/gal), time zone.
  - Unit changes update labels and calculations without altering stored data.
  - Data export (CSV) and account deletion.
- Vehicle management
  - Add, edit, delete vehicles (name, make/model, year, fuel type).
- Fuel entry management
  - Add, edit, delete fill-ups with date, odometer (km), station, brand, grade, volume (L), total amount, notes.
  - Validation: positive volume and amount, non-future date, odometer strictly increasing per vehicle.
  - History with filters (date range, brand, grade, station, vehicle) and date-desc sorting.
- Derived metrics
  - Per-fill: distance since last, unit price, consumption (L/100km), cost per km.
  - Rolling window: averages for cost per volume and consumption, total spend, total distance, avg cost/km, avg distance/day.
  - Per brand and per grade: averages and counts.
  - Rounding: currency 2 decimals, volume 2 decimals, price per volume 2–3 decimals (default 2), L/100km 1 decimal, distances whole km/mi.
- Dashboards & statistics
  - Overview Dashboard with period selector (Last 30/90, YTD, Custom) and vehicle selector.
  - Charts: cost per volume over time, consumption over time.
  - Brand/Grade comparison page with period and vehicle filters.
  - Empty states when no data in the selected range.
- Legal pages
  - Terms of Service and Privacy Policy.
- Security & privacy basics
  - HTTP-only cookies, user data isolation at query layer, PII kept minimal (email).

Getting started (Docker)
1) Prerequisites
- Docker and Docker Compose installed.

2) Run locally
- git clone <your-repo-url>
- cd FuelTracker
- docker compose up --build

3) Open the app
- Navigate to the service URL printed by Docker (commonly http://localhost:8080 or per compose.yaml).
- Register a new account, then sign in.

Quick usage
- Add your vehicle(s) on the Vehicles page.
- Record fill-ups on the Fuel page. Use inline validation and helper text to ensure correct values.
- Explore the Dashboard for rolling stats and charts. Use the vehicle and period selectors.
- Open the Brand/Grade statistics page for comparisons by brand and fuel grade.
- Adjust units and currency on the Profile page; export data as CSV or delete your account if needed.

Units and storage
- Data is stored in km and liters. Views convert to your preferences (mi/gal) at display time.
- Use the Profile page to select units and currency; changes apply across the app immediately.

Key pages
- Home: Overview dashboard with selectors, cards, charts, and per-fill metrics table.
- Vehicles: Manage your vehicles.
- Fuel: History list with filters and fill-up CRUD.
- Statistics - Brand/Grade: Comparison tables by brand and grade.
- Profile: Units, currency, timezone, CSV export, account deletion.
- Legal: Terms of Service and Privacy Policy.

Notes
- The application aims to remain simple and production-ready, emphasizing secure-by-default patterns and clear tenant isolation.
- Performance-oriented indexes are added on common query dimensions (user/vehicle/date).
