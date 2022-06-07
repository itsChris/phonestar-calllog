// See https://aka.ms/new-console-template for more information
using phonestar_calllog;
using System.Text.Json;

Console.WriteLine("Hello, World!");

HttpClient client = new HttpClient();

var streamTask = client.GetStreamAsync("https://my.phonestar.ch/api/login?api_token=igpYoQkmbRvbANaPU4TWxXE9hzp$2b$12$Bkg2kYhaSvEOSznn7L0doO");
var loginResult = await JsonSerializer.DeserializeAsync<LoginResult>(await streamTask);

Console.WriteLine($"SessionId: {loginResult.session_id}");

var req = $"https://my.phonestar.ch/get_cdrs?start=2022-01-01%2010:00:00&end=2022-06-01%2010:00:00&session_id={loginResult.session_id}";

Console.WriteLine($"Requesting URL: {req}");

var getStreamCallLog = client.GetStreamAsync(req);
var callLogResult = await JsonSerializer.DeserializeAsync<CallLogResult> (await getStreamCallLog);

Console.ReadLine();
