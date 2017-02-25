using System.Data.Entity;
using entityframeworkrepository.core.repository;
using entityframeworkrepository.repository;
using NUnit.Framework;

namespace entityframeworkrepository.tests
{
    [TestFixture]
    public class GenericDataRepositoryTests
    {
        [Test]
        public void Should_Create_GenericDataRepository_Instance()
        {
          IGenericDataRepository<Person> repository = new GenericDataRepository<Person>((DbContext)new WorkBenchContext());
          Assert.That(repository, Is.Not.Null);
        }


        /// <summary>
        /// Persisting 3 people
        /// </summary>
        public class PersonRepository: GenericDataRepository<Person>
        {
            /// <summary>
            /// PersonRepository
            /// </summary>
            public PersonRepository() : base((DbContext)new WorkBenchContext())
            {
                Add(new Person[] {new Person(), new Person(), new Person()});
                Save();
            }
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
                            .GetPagedList( x => x != null, 1, 2, person => person.Departments);
            Assert.That(people,Is.Not.Null.Or.Empty);
            Assert.That(people.Count, Is.EqualTo(2));
        }


    }
}
