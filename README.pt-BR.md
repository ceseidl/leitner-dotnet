[English](README.md) | Português

[![License: MIT](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

# leitner-dotnet

> **Início rápido**

```bash
dotnet build
dotnet run --project src/Leitner --no-build
```

Precisa só do SDK do .NET 10. Detalhes em [Como rodar](#como-rodar).

Um pequeno simulador de revisão para estudo de certificações, em console com .NET 10. Aplica repetição espaçada com o sistema de Leitner (3 caixas) a um banco de questões de exemplo, e mostra também o cálculo de tempo por questão e a classificação dos "3 passes". É o código do artigo "Estudo para Certificações Técnicas: Estratégia e Revisão Espaçada em .NET".

## O que é

- **Banco de questões** (`questoes.json`): 12 questões de exemplo, cada uma com tema, resumo do enunciado em uma linha e resposta.
- **Baralho**: o baralho de Leitner. Acertar sobe a questão uma caixa; errar devolve para a caixa 1. Intervalos de revisão: caixa 1 = 1 dia, caixa 2 = 3 dias, caixa 3 = 7 dias.
- **Simulacao**: simula 10 dias de estudo com semente fixa (reproduzível) e chance de acerto diferente por tema.
- **Ritmo**: minutos por questão (tempo total / número de questões) e o passe (1, 2 ou 3) para um nível de certeza.
- O relatório lista a taxa de erro por tema (pontos fracos) e quantas questões estão em cada caixa.

As chances de acerto são números inventados para a simulação; não são estatísticas de provas reais.

## Pré-requisitos

- [SDK do .NET 10](https://dotnet.microsoft.com/download)

Nenhum pacote NuGet além do SDK, sem banco de dados, sem rede.

## Como rodar

```bash
dotnet build
dotnet run --project src/Leitner --no-build
```

Saída esperada (o separador decimal segue a cultura da máquina):

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

## Estrutura

```
Leitner.slnx
src/
  Leitner/
    Program.cs        carrega o JSON, roda a simulação, imprime o relatório
    Questao.cs        record da questão
    Baralho.cs        caixas de Leitner, questões devidas, pontos fracos
    Simulacao.cs      simulação de N dias com semente fixa
    Ritmo.cs          minutos por questão e os 3 passes
    questoes.json     banco de questões de exemplo
```

Identificadores e dados de exemplo estão em português de propósito.

## Licença

[MIT](LICENSE). Autor: Carlos Eduardo Seidl.
