using System.Collections.Generic;
using Exercise.Interfaces;

namespace Exercise.Impl
{
    public class Book : Base, IPurchase
    {
        private readonly IRoyaltyService _royaltyService;
        private readonly INotificationService _notificationService;

        public Book(IRoyaltyService royaltyService, INotificationService notificationService)
        {
            _royaltyService = royaltyService;
            _notificationService = notificationService;
        }
        public List<string> Purchase()
        {
            var result = ProcessPackagingSlip();
            var royaltyResult = _royaltyService.SendRoyalityDetails();
            _notificationService.SendNotification(royaltyResult);
            return new List<string>
            {
                result, royaltyResult
            };
        }

        private string ProcessPackagingSlip()
        {
            var result = "packing slip for shipping";
            _notificationService.SendNotification(result);
            return result;
        }
    }
}