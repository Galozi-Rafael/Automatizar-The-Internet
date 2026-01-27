# Automatizar The-Internet

Esse repositório tem como objetivo criar soluções de automação para o site [The-Internet](https://the-internet.herokuapp.com/).

## Entendendo o projeto

O projeto consiste em criar uma automação para cada um dos 44 casos apresentados no site.

Cada um dos testes terá a sua própria classe que será chamada apenas quando se fizer necessária sua aplicação.

Cada um dos cenários terá uma explicação mais detalhada no [Readme]() que constará na pasta [Scenarios]().

## Objetivos do projeto

1. Criar soluções de automação para a web;
2. Evitar trabalho repetitivo;
3. Solucionar problemas de automação web;
4. Testar páginas web;
5. Raspar dados da internet;
6. Demonstrar habilidades de programação e automação.

## Tecnologias utilizadas

1. C#;
2. .NET;
3. Playwright.

## Arquitetura de pasta do projeto
``` mermaid
flowchart LR

A[Automatizar The Internet] --> B[Automatizar.TheInternet]
A --> C[.gitignore]
A --> D[README.md]
A --> E[src]
E --> F[Automatizar.TheInternet]
F --> G[Infrastructure]
F --> H[Scenarios]
F --> I[Program.cs]
F --> J[Automatizar.TheInternet.csproj]
G --> K[PlaywrightFactory.cs]
H --> L[ABTest.cs]
H --> M[AddRemoveElements.cs]
H --> N[BasicAuth.cs]
H --> O[BrokenImages.cs]
H --> P[ChallengingDOM.cs]
```
