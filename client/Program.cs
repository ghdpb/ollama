using OllamaSharp;

var uriString = "http://192.168.0.148:11434";
var modelDefault = "phi3:latest";
var url = new Uri(uriString);

var client = new OllamaApiClient(url, modelDefault);
var models = await client.ListLocalModelsAsync();

Console.WriteLine("LISTA DE MODELOS: ");
foreach (var model in models) Console.WriteLine(model.Name);

var chat = new Chat(client);

while (true)
{
    Console.WriteLine("");
    Console.WriteLine("Para sair, basta digitar 'SAIR'.");
    Console.WriteLine("");
    Console.Write("PROMPT: ");
    string? prompt = Console.ReadLine() ?? string.Empty;

    if (prompt.ToUpper().Equals("SAIR")) break;
    
    await foreach (string answer in chat.SendAsync(prompt)) Console.Write(answer);

    Console.WriteLine("");
}