
using System.Xml.Linq;

public static class MMPSIntegration
{
    private static readonly HttpClient client = new HttpClient();
    private const string BaseUrl = "https://service.someprovider.ru:8443/payment_app.cgi";

    // Check Method
    public static async Task CheckSubscriberAsync(string txnId, string account, decimal sum)
    {
        var url = $"{BaseUrl}?command=check&txn_id={txnId}&account={account}&sum={sum:0.00}";
        Console.WriteLine($"Request: {url}");

        var response = await client.GetStringAsync(url);
        var xmlResponse = XDocument.Parse(response);

        string result = xmlResponse.Root.Element("result").Value;
        Console.WriteLine($"Check Result: {result}");
    }

    // Pay Method
    public static async Task PayAsync(string txnId, string account, decimal sum)
    {
        var txnDate = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
        var url = $"{BaseUrl}?command=pay&txn_id={txnId}&txn_date={txnDate}&account={account}&sum={sum:0.00}";

        Console.WriteLine($"Request: {url}");

        var response = await client.GetStringAsync(url);
        var xmlResponse = XDocument.Parse(response);

        string result = xmlResponse.Root.Element("result").Value;
        Console.WriteLine($"Pay Result: {result}");
    }

    // Test Method
    public static async Task getPaid()
    {
        string txnId = "1234567";
        string account = "0957835959";
        decimal sum = 10.45m;

        Console.WriteLine("Starting MMPS Integration...");

        // Step 1: Check Subscriber
        await CheckSubscriberAsync(txnId, account, sum);

        // Step 2: Pay if check is OK
        await PayAsync(txnId, account, sum);
    }
}
