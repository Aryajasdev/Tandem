using System;
using System.Collections.Generic;
using Exercise.Enums;
using Exercise.Interfaces;

namespace Exercise.Impl
{
    public class Membership : Base, IPurchase
    {
        private readonly INotificationService _notificationService;
        private PurchaseType MemberShipType { get; }

        public Membership(INotificationService notificationService, PurchaseType type)
        {
            this._notificationService = notificationService;
            this.MemberShipType = type;
        }
       

        public List<string> Purchase()
        {
            var result = ProcessMembership(this.MemberShipType);
            _notificationService.SendNotification(result);
            return new List<string>
            {
                result
            };
        }

        private string ProcessMembership(PurchaseType type) => type switch
        {
            PurchaseType.Create => "Membership Activated",
            PurchaseType.Cancel => "Membership Canceled",
            PurchaseType.Downgrade => "Membership Downgraded",
            PurchaseType.Renew => "Membership Renewed",
            PurchaseType.Upgrade => "Membership Upgraded",
            _ => throw new ArgumentOutOfRangeException(nameof(type), $"not expected type : {type}")
        };
    }
}
