using OllamaSharp;

var url = new Uri("http://localhost:11434");
var client = new OllamaApiClient(url);

//var models = await client.ListLocalModelsAsync();

//foreach (var model in models)
    //Console.WriteLine(model.Name);

client.SelectedModel = "phi3:latest";

var chat = new Chat(client);
string? prompt = Console.ReadLine() ?? string.Empty;

await foreach (string answer in chat.SendAsync(prompt))
    Console.WriteLine(answer);

Console.WriteLine();    
Console.WriteLine("--");