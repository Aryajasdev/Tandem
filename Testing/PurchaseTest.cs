using System;
using Exercise.Enums;
using Exercise.Impl;
using Exercise.Interfaces;
using Moq;
using NUnit.Framework;
using Type = Exercise.Enums.Type;

namespace Testing
{
    [TestFixture]
    public class PurchaseTest
    {
        private Mock<IRoyaltyService> royalityService;
        private Mock<INotificationService> notificationService;

        [SetUp]
        public void Init()
        {
            royalityService = new Mock<IRoyaltyService>();
            notificationService = new Mock<INotificationService>();
        }

        [Test]
        public void Book_should_Generate_2_Slips()
        {
            var book = new PurchaseFactory(notificationService.Object, royalityService.Object)
                .GetPurchase(Type.Book, PurchaseType.Buy);
            var result =  book.Purchase();

            Assert.AreEqual(result.Count, 2);

            royalityService.Verify(x => x.SendRoyalityDetails(), Times.Once);
            notificationService.Verify(x => x.SendNotification(It.IsAny<string>()), Times.Exactly(2));
        }

        [Test]
        public void Product_should_Generate_1_Slips()
        {
            var product = new PurchaseFactory(notificationService.Object, royalityService.Object)
                .GetPurchase(Type.Product, PurchaseType.Buy);
            var result = product.Purchase();

            Assert.AreEqual(result.Count, 1);
            royalityService.Verify(x => x.SendRoyalityDetails(), Times.Never);
            notificationService.Verify(x => x.SendNotification(It.IsAny<string>()), Times.Once);

        }

        [Test]
        public void Membership_should_Generate_1_Slip_with_Notification()
        {
            var membership = new PurchaseFactory(notificationService.Object, royalityService.Object)
                .GetPurchase(Type.MemberShip, PurchaseType.Create);
            var result = membership.Purchase();

            Assert.AreEqual(result.Count, 1);

            royalityService.Verify(x => x.SendRoyalityDetails(), Times.Never);
            notificationService.Verify(x => x.SendNotification(It.IsAny<string>()), Times.Once);

        }

        [Test]
        public void Membership_should_Throw_Exception_If_Type_is_Buy()
        {
            var membership = new PurchaseFactory(notificationService.Object, royalityService.Object)
                .GetPurchase(Type.MemberShip, PurchaseType.Buy);
           
            Assert.Throws<ArgumentOutOfRangeException>(() => membership.Purchase());

        }
    }
}
