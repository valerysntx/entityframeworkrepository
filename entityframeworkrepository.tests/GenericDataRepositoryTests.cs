﻿using System;
using System.Data.Entity;
using System.Linq;

using entityframeworkrepository.cache;
using entityframeworkrepository.repository;
using entityframeworkrepository.repository.cache;

using NUnit.Framework;
using NUnit.Framework.Internal;

namespace entityframeworkrepository.tests
{
    [TestFixture]
    public class GenericDataRepositoryTests
    {
        [Test]
        public void Should_Create_GenericDataRepository_Instance()
        {
            IGenericDataRepository<Person> repository =
                new GenericDataRepository<Person>((DbContext) new WorkBenchContext());
            Assert.That(repository, Is.Not.Null);
        }


        /// <summary>
        /// Persisting 3 people
        /// </summary>
        public class PersonRepository : GenericDataRepository<Person>
        {
            /// <summary>
            /// PersonRepository
            /// </summary>
            public PersonRepository() : base((DbContext) new WorkBenchContext())
            {
                Add(new Person[] {new Person(), new Person(), new Person()});
                Save();
            }
        }


        /// <summary>
        /// Cache repository tests
        /// </summary>
        public class DictionaryCacheRepository : GenericCacheRepository<Dictionary>
        {
            public DictionaryCacheRepository(DbContext context) : base(context)
            {
                Locator.SetContainer(new Container());
                Locator.Current.Register<ICacheProvider>(() => new MemoryCacheProvider());
            }
        }

        [Test]
        public void Should_Add_Entity_CacheRepository()
        {
            var cache = new DictionaryCacheRepository(new WorkBenchContext());
            cache.Add(
                new Dictionary
                {
                    Code = 100,
                    CompanyId = 1,
                    CreatedBy = 1,
                    DateAdded = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    DepartmentId = 1,
                    Description = "",
                    DictionaryType = "updated",
                    FullDescription = "updated",
                    Hierarchy = 1,
                    Id2 = 1,
                    Id3 = 1,
                    UpdatedBy = 1,
                    IsDeleted = false
                });
            cache.Save();

            Assert.That(cache.GetSingle(x => x.Code == 100), Is.Not.Null);

        }

        [Test]
        public void Should_Update_Entity_CacheRepository()
        {
            var cache = new DictionaryCacheRepository(new WorkBenchContext());
            var item = cache.GetSingle(x => x.Code == 100);

            Assert.That(item, Is.Not.Null);

            item.Description = "updated";
            cache.Update(item);
            cache.Save();

            Assert.That(cache.GetSingle(x => x.Code == 100).Description, Is.EqualTo("updated"));
        }

        [Test]
        public void Should_Invalidate_on_Remove_CacheRepository()
        {
            var cache = new DictionaryCacheRepository(new WorkBenchContext());
            var dictionary = new Dictionary() {Code = 100};
            cache.Remove(dictionary);
            cache.Save();

            Assert.False(cache.GetAll().Contains(dictionary));
        }

        [Test]
        public void Should_Persist_Entity_With_DbContext()
        {
            Assert.That(new PersonRepository(), Is.Not.Null);
            Assert.That(new PersonRepository().GetAll().Count, Is.GreaterThan(0));
        }


        [Test]
        public void Should_Do_Paged_Sets_Properly()
        {
            var people = new PersonRepository()
                .GetPagedList(x => x != null, 1, 2, person => person.Departments);
            Assert.That(people, Is.Not.Null.Or.Empty);
            Assert.That(people.Count, Is.GreaterThan(0));
        }


        [Test]
        public void Should_Do_JobFormResultsView_Complex_Query()
        {
            Locator.Current.Register<ICacheProvider>(() => new MemoryCacheProvider());
            var jobFormResultsViewRepository = new GenericCacheRepository<JobFormResultsView>(new WorkBenchContext());
            var result = jobFormResultsViewRepository.GetAll();
            Assert.That(result, Is.Not.Null.Or.Empty);
        }

        [Test]
        public void Should_Do_Complex_Query_Paged()
        {
            using (var ctx = new WorkBenchContext())
            {
                Locator.SetContainer(new Container());
                Locator.Current.Register<ICacheProvider>(() => new MemoryCacheProvider());

                var repository = new DictionaryCacheRepository(ctx);
                var result = repository.GetPagedList(x => x != null, 0, 1);

                Assert.That(result, Is.Not.Null.Or.Empty);
                Assert.That(result.Count, Is.EqualTo(1));
            }
        }

        [Test]
        public void Should_Do_JobFormResultsView_Join_Linq_Query()
        {
            using (var ctx = new WorkBenchContext())
            {
                Locator.SetContainer(new Container());
                Locator.Current.Register<ICacheProvider>(() => new MemoryCacheProvider());
                var jobFormResultsViewRepository = new GenericCacheRepository<JobFormResultsView>(ctx);

                var result = jobFormResultsViewRepository.GetAll();
                Assert.That(result, Is.Not.Null.Or.Empty);
            }

        }
    }

}
