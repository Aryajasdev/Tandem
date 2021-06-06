using System;
using Exercise.Interfaces;

namespace Exercise.Impl
{
    public class Notification : INotificationService
    {
        public void SendNotification(string message)
        {
            Console.WriteLine("Notification Sent");
        }
    }
}