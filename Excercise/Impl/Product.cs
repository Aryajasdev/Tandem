using System.Collections.Generic;
using Exercise.Interfaces;

namespace Exercise.Impl
{
    public class Product : Base, IPurchase
    {
        private readonly INotificationService notificationService;
        public Product(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }
        public List<string> Purchase()
        {
            var result = ProcessPackagingSlip();
            notificationService.SendNotification(result);
            return new List<string>
            {
                result
            };
        }

        private string ProcessPackagingSlip()
        {
            return "packing slip for shipping";
        }
    }
}