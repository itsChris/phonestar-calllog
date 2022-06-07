// See https://aka.ms/new-console-template for more information
using phonestar_calllog;
using System.Text.Json;

Console.WriteLine("phonstar.ch - get call log..");

HttpClient client = new HttpClient();

try
{
    Console.WriteLine("Please enter api_token:");
    string api_token = Console.ReadLine();
    Console.WriteLine($"api_token provided: {api_token}");

    string sLoginRequest = $"https://my.phonestar.ch/api/login?api_token={api_token}";
    Console.WriteLine($"Login request: {sLoginRequest}");

    var streamTask = client.GetStreamAsync(sLoginRequest);
    var loginResult = await JsonSerializer.DeserializeAsync<LoginResult>(await streamTask);

    Console.WriteLine($"SessionId: {loginResult.session_id}");

    Console.WriteLine($"Enter session_id (if you want to override {loginResult.session_id} - otherwise leave blank/hit enter..");
    string sessionIdOverride = Console.ReadLine();

    string reqGetCdrs = String.Empty;

    if (sessionIdOverride.Length>10)
    {
         reqGetCdrs = $"https://my.phonestar.ch/get_cdrs?start=2022-01-01%2010:00:00&end=2022-06-01%2010:00:00&session_id={sessionIdOverride}";
    }
    else
    {
         reqGetCdrs = $"https://my.phonestar.ch/get_cdrs?start=2022-01-01%2010:00:00&end=2022-06-01%2010:00:00&session_id={loginResult.session_id}";
    }

    Console.WriteLine($"Requesting URL: {reqGetCdrs}");

    var getStreamCallLog = client.GetStreamAsync(reqGetCdrs);
    var callLogResult = await JsonSerializer.DeserializeAsync<CallLogResult>(await getStreamCallLog);

    Console.ReadLine();
}
catch (Exception ex)
{
    Console.WriteLine($"ERROR! -> {ex.Message}");
}


