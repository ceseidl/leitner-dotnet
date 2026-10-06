namespace Leitner;

public record Questao(
    int Id,
    string Tema,
    string Resumo,
    string Resposta,
    int Caixa = 1,
    DateOnly Proxima = default,
    int Acertos = 0,
    int Erros = 0);
