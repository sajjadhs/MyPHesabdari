# MyPHesabdari - My Personal Accounting
Very simple and small blazor based app which will help you to add and control your personal expenses

I am continually updating this repository based on any requirements I feel

## Localizations
I added localization for supporting English, Persian and Turkish languages

## Note About async actions
While an async task is running over database context and we start change the page, It may start another async task which causes exceptions while other one is running.
So I added an interface and injected it as a transient service for database operations and this will prevent any possible exceptions.

## Authentication and Authorization

Cookie based Authentication is added and only authenticated user can access the pages

## Contribution

Any contributions is welcomed :D 
