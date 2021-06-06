using System;
using Exercise.Enums;
using Exercise.Interfaces;
using Type = Exercise.Enums.Type;

namespace Exercise.Impl
{
    public class PurchaseFactory
    {
        private readonly INotificationService _notificationService;
        private readonly IRoyaltyService _royaltyService;

        public PurchaseFactory(INotificationService notificationService, IRoyaltyService royaltyService)
        {
            _notificationService = notificationService;
            _royaltyService = royaltyService;
        }

        public IPurchase GetPurchase(Type productType, PurchaseType type) => productType switch
        {
            Type.Product => new Product(_notificationService),
            Type.Book => new Book(_royaltyService, _notificationService),
            Type.MemberShip => new Membership(_notificationService, type),
            _ => throw new ArgumentOutOfRangeException(nameof(productType), $"not expected type : {productType}")
        };

    }
}