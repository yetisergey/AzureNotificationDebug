namespace NotificationSender
{
    using Microsoft.Azure.NotificationHubs;
    using System;
    using System.Threading.Tasks;

    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Enter ConnectionString");
            var connectionString = Console.ReadLine();
            Console.WriteLine("Enter HubName");
            var hubName = Console.ReadLine();
            while (true)
            {
                Console.WriteLine("Enter your message");
                var message = "{\"data\":{\"message\":\"" + Console.ReadLine() + "\"}}";
                await SendNotificationAsync(connectionString, hubName, message);
            }
        }

        static async Task SendNotificationAsync(string connectionString, string hubName, string message)
        {
            NotificationHubClient hub = NotificationHubClient.CreateClientFromConnectionString(connectionString, hubName);
            await hub.SendGcmNativeNotificationAsync(message);
        }
    }
}
