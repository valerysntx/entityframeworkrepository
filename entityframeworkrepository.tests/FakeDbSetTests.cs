using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entityframeworkrepository.core;
using entityframeworkrepository.core.entity;
using NUnit.Framework;

namespace entityframeworkrepository.tests
{
    [TestFixture]
    public partial class FakeDbSetTests
    {

        [Test]
        public void ShouldCreateFakeDbSet_Of_TypeParamT ()
        {
            Assert.That(new FakeDbSet<BaseEntity>(), Is.Not.Null);
        }

    }
}
