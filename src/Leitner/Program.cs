using System.Text.Json;
using Leitner;

var opcoes = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true
};
var arquivo = Path.Combine(
    AppContext.BaseDirectory, "questoes.json");
var questoes = JsonSerializer.Deserialize<List<Questao>>(
    File.ReadAllText(arquivo), opcoes)!;
var baralho = new Baralho(questoes);

// Prova hipotética: 120 minutos, 50 questões.
var ritmo = Ritmo.MinutosPorQuestao(120, 50);
Console.WriteLine($"Ritmo: {ritmo:0.0} min/questão");
foreach (var certeza in new[] { 90, 40, 5 })
    Console.WriteLine(
        $"Certeza {certeza,2}% -> passe {Ritmo.Passe(certeza)}");

Console.WriteLine();
Simulacao.Executar(
    baralho, new DateOnly(2026, 10, 1), dias: 10, semente: 42);

Console.WriteLine();
Console.WriteLine("Taxa de erro por tema:");
foreach (var (tema, erro) in baralho.PontosFracos())
    Console.WriteLine($"- {tema}: {erro:P0}");

Console.WriteLine();
Console.WriteLine("Questões por caixa:");
var caixas = baralho.Todas
    .GroupBy(q => q.Caixa)
    .OrderBy(g => g.Key);
foreach (var g in caixas)
    Console.WriteLine($"- Caixa {g.Key}: {g.Count()}");
