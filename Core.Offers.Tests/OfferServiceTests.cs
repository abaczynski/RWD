using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using FluentAssertions;
using Infrastructure.Domain.DataInterfaces;
using Core.Model.Offers;
using Core.Model.Users;

namespace Core.Offers.Tests
{
    [TestFixture]
    public class OfferServiceTests
    {
        private Mock<IRepository<Offer, Guid>> _offerRepositoryStub;
        private Mock<IRepository<Core.Model.Property.Property, Guid>> _propertyRepositoryStub;
        private Mock<IUserRepository> _userRepositoryStub;

        private IOfferService _offerService;

        [SetUp]
        public void TestInitialize()
        {
            _offerRepositoryStub = new Mock<IRepository<Offer, Guid>>();
            _propertyRepositoryStub = new Mock<IRepository<Model.Property.Property, Guid>>();
            _userRepositoryStub = new Mock<IUserRepository>();

            _offerService = new OfferService(_offerRepositoryStub.Object, _propertyRepositoryStub.Object, _userRepositoryStub.Object);
        }

        [Test]
        public void GetGetOffersForUser_ShouldReturnTwoOffers_Test() {

            Guid ownerId = Guid.NewGuid();
            var owner = new Mock<User>();
            owner.SetupGet(x => x.Id).Returns(ownerId);

            var offers= new List<Offer>{
                new Offer(){Owner = owner.Object},
                new Offer(){Owner = owner.Object},
            };

           _offerRepositoryStub.Setup(x => x.Get(It.IsAny<Expression<Func<Offer, bool>>>())).Returns<Expression<Func<Offer, bool>>>(x => offers.Where(x.Compile()));

            var result = _offerService.GetOffersForUser(ownerId);

            result.Should().HaveCount(2);
        }
    }
}
