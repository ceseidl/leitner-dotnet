English | [Português](README.pt-BR.md)

[![License: MIT](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

# leitner-dotnet

> **Quick start**

```bash
dotnet build
dotnet run --project src/Leitner --no-build
```

Needs only the .NET 10 SDK. Details in [How to run](#how-to-run).

A small console review simulator for certification study, built with .NET 10. It applies spaced repetition with the Leitner system (3 boxes) to a sample question bank, and also shows the pace-per-question calculation and the "3 passes" classification. It is the companion code of the article "Estudo para Certificações Técnicas: Estratégia e Revisão Espaçada em .NET".

## What it is

- **Question bank** (`questoes.json`): 12 sample questions, each with a topic, a one-line summary of the statement and the answer.
- **Baralho**: the Leitner deck. A correct answer moves a question up one box; a wrong answer sends it back to box 1. Review intervals: box 1 = 1 day, box 2 = 3 days, box 3 = 7 days.
- **Simulacao**: simulates 10 days of study with a fixed random seed (reproducible) and a different hit chance per topic.
- **Ritmo**: minutes per question (total time / number of questions) and the pass (1, 2 or 3) for a given certainty level.
- The report lists the error rate per topic (weak points) and how many questions are in each box.

The hit chances are made-up numbers for the simulation; they are not real exam statistics.

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)

No NuGet packages beyond the SDK, no database, no network.

## How to run

```bash
dotnet build
dotnet run --project src/Leitner --no-build
```

Expected output (the decimal separator follows the machine culture):

```
Ritmo: 2,4 min/questão
Certeza 90% -> passe 1
Certeza 40% -> passe 2
Certeza  5% -> passe 3

Dia  1: devidas 12, acertos  9
Dia  2: devidas  3, acertos  2
Dia  3: devidas  1, acertos  1
Dia  4: devidas  9, acertos  7
Dia  5: devidas  4, acertos  2
Dia  6: devidas  3, acertos  1
Dia  7: devidas  2, acertos  2
Dia  8: devidas  1, acertos  1
Dia  9: devidas  1, acertos  1
Dia 10: devidas  2, acertos  1

Taxa de erro por tema:
- Identidade e segurança: 50%
- Rede e custos: 33%
- Computação: 0%
- Armazenamento e dados: 0%

Questões por caixa:
- Caixa 1: 1
- Caixa 3: 11
```

## Structure

```
Leitner.slnx
src/
  Leitner/
    Program.cs        loads the JSON, runs the simulation, prints the report
    Questao.cs        question record
    Baralho.cs        Leitner boxes, due questions, weak points
    Simulacao.cs      N-day simulation with a fixed seed
    Ritmo.cs          minutes per question and the 3 passes
    questoes.json     sample question bank
```

Identifiers and sample data are in Portuguese on purpose.

## License

[MIT](LICENSE). Author: Carlos Eduardo Seidl.
