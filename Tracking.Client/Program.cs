// See https://aka.ms/new-console-template for more information
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Tracking.Client;

HttpClient client = new();
client.BaseAddress = new Uri("https://localhost:44375");
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

HttpResponseMessage reponse = await client.GetAsync("api/issue");
reponse.EnsureSuccessStatusCode();

if (reponse.IsSuccessStatusCode)
{
    var issues = await reponse.Content.ReadFromJsonAsync<IEnumerable<IssueDto>> ();
    foreach (var issue in issues)
    {
        Console.WriteLine(issue.Title);
        Console.WriteLine(issue.Description);
    }
}
else
{
    Console.WriteLine("No results");
}

Console.ReadLine();