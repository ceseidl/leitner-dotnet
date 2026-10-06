namespace Leitner;

public static class Ritmo
{
    // Tempo total / número de questões = minutos por questão.
    public static double MinutosPorQuestao(
        int minutosTotais, int questoes) =>
        (double)minutosTotais / questoes;

    // Os "3 passes": quanto maior a certeza, mais cedo a questão
    // é respondida. Os limites (75 e 25) são ajustáveis.
    public static int Passe(int certezaPercentual) =>
        certezaPercentual switch
        {
            >= 75 => 1,
            >= 25 => 2,
            _ => 3
        };
}
