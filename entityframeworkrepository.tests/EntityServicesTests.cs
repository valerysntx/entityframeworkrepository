using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entityframeworkrepository.core.entity;
using entityframeworkrepository.core.service;
using Moq;
using NUnit.Framework;

namespace entityframeworkrepository.tests
{
    [TestFixture]
    public class EntityServicesTests
    {
        private Mock<IEntityService<BaseEntity>> _serviceMock;

        [SetUp]
        public void Initialize()
        {
            _serviceMock = new Mock<IEntityService<BaseEntity>>();
        }



        [Test]
        public void Person_Get_All_Using_FakeDbSet()
        {
            //Arrange
            _serviceMock?.Setup(x => x.GetAll())?.Returns(
                 new List<BaseEntity>(new [] { new FakeDbSet<Person>().Create() })
               );

            //Act
            var result = _serviceMock?.Object?.GetAll();

            //Assert
            Assert.AreEqual(result.ToArray().Length, 1);
        }

    }
}
