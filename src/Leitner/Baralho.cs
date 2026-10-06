namespace Leitner;

public class Baralho(IEnumerable<Questao> questoes)
{
    // Dias até a próxima revisão em cada caixa (1, 2 e 3).
    public static readonly int[] Intervalos = [1, 3, 7];

    private readonly List<Questao> _questoes = [.. questoes];

    public IReadOnlyList<Questao> Todas => _questoes;

    public IReadOnlyList<Questao> Devidas(DateOnly dia) =>
        _questoes.Where(q => q.Proxima <= dia).ToList();

    public void Responder(int id, bool acertou, DateOnly dia)
    {
        var i = _questoes.FindIndex(q => q.Id == id);
        var q = _questoes[i];

        // Acertou: sobe uma caixa. Errou: volta para a caixa 1.
        var caixa = acertou
            ? Math.Min(q.Caixa + 1, Intervalos.Length)
            : 1;

        _questoes[i] = q with
        {
            Caixa = caixa,
            Proxima = dia.AddDays(Intervalos[caixa - 1]),
            Acertos = q.Acertos + (acertou ? 1 : 0),
            Erros = q.Erros + (acertou ? 0 : 1)
        };
    }

    // Temas ordenados do maior para o menor percentual de erro.
    public IEnumerable<(string Tema, double Erro)>
        PontosFracos() =>
        _questoes
            .GroupBy(q => q.Tema)
            .Select(g => (g.Key, TaxaDeErro(g)))
            .OrderByDescending(t => t.Item2);

    private static double TaxaDeErro(IEnumerable<Questao> qs)
    {
        var erros = qs.Sum(q => q.Erros);
        var total = qs.Sum(q => q.Acertos + q.Erros);
        return total == 0 ? 0 : (double)erros / total;
    }
}
