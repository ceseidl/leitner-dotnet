namespace Leitner;

public static class Simulacao
{
    // Chance base de acerto por tema (o "ponto fraco" simulado).
    private static readonly Dictionary<string, double> Base =
        new()
        {
            ["Computação"] = 0.75,
            ["Armazenamento e dados"] = 0.55,
            ["Identidade e segurança"] = 0.35,
            ["Rede e custos"] = 0.50
        };

    public static void Executar(
        Baralho baralho, DateOnly inicio, int dias, int semente)
    {
        // Semente fixa: a simulação é reproduzível.
        var sorteio = new Random(semente);

        for (var d = 0; d < dias; d++)
        {
            var dia = inicio.AddDays(d);
            var devidas = baralho.Devidas(dia);
            var acertos = 0;

            foreach (var q in devidas)
            {
                // Cada acerto anterior aumenta 8 pontos a chance.
                var chance = Math.Min(
                    0.95, Base[q.Tema] + 0.08 * q.Acertos);
                var acertou = sorteio.NextDouble() < chance;
                baralho.Responder(q.Id, acertou, dia);
                if (acertou) acertos++;
            }

            Console.WriteLine(
                $"Dia {d + 1,2}: devidas {devidas.Count,2}, " +
                $"acertos {acertos,2}");
        }
    }
}
