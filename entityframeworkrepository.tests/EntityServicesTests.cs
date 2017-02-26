using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Internal;
using entityframeworkrepository.cache;
using entityframeworkrepository.core.entity;
using entityframeworkrepository.core.repository;
using entityframeworkrepository.core.service;
using entityframeworkrepository.core.unitofwork;
using entityframeworkrepository.repository;
using Moq;
using Newtonsoft.Json;
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
            var container = new Container();

            Locator.SetContainer(container);
            Locator.Current.Register<ICacheProvider>(()=> new MemoryCacheProvider());

            _serviceMock = new Mock<IEntityService<BaseEntity>>();
        }



        [Test]
        public void Person_Get_All_Using_FakeDbSet()
        {
            //Arrange
            _serviceMock.Setup(x => x.GetAll()).Returns(
                 new System.Collections.Generic.List<BaseEntity>(new [] { new FakeDbSet<Person>().Create() })
               );

            //Act
            var result = _serviceMock.Object.GetAll();

            //Assert
            Assert.AreEqual(result.ToArray().Length, 1);
        }


        /// <summary>
        /// DictionaryService
        /// </summary>
        internal class DictionaryService : EntityService<Dictionary>
        {
            /// <summary>
            /// DictionaryService
            /// </summary>
            /// <param name="unitOfWork"></param>
            /// <param name="repository"></param>
            public DictionaryService(IUnitOfWork unitOfWork, IGenericDataRepository<Dictionary> repository) : base(unitOfWork, repository)
            {
            }
        }

        [Test]
        public void Should_Create_with_DictionaryTable()
        {

            Dictionary dictionary = new Dictionary
            {
                Code = 100,
                CompanyId = 1,
                CreatedBy = 1,
                DateAdded = DateTime.Now,
                DateUpdated = DateTime.Now,
                DepartmentId = 1,
                Description = "",
                DictionaryType = "INSERTED",
                FullDescription = "INSERTED",
                Hierarchy = 1,
                Id2 = 1,
                Id3 = 1,
                UpdatedBy = 1,
                IsDeleted = false,
                DictionaryTypeId = 20

            };

            var ctx = new WorkBenchContext();
            var dictionaryService = new DictionaryService(
                        new UnitOfWork(ctx),
                        new GenericDataRepository<Dictionary>(new WorkBenchContext())
                       );

            Assert.DoesNotThrow(() =>
            {
                dictionaryService.Create(dictionary);
                dictionaryService.Update(dictionary);
                dictionaryService.GetAll();
                dictionaryService.Delete(dictionary);
            } );

        }

    }
}
