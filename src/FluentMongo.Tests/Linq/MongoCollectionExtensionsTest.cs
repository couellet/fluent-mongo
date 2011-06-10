using NUnit.Framework;
using System.Linq;

namespace FluentMongo.Linq
{
    [TestFixture]
    public class MongoCollectionExtensionsTest : LinqTestBase
    {
        [Test]
        public void ShouldUpdateCorrectly()
        {
            var person = new Person {MidName = "Charles"};

            Collection.Insert(person);

            Collection.UpdateSingleElement(person, x => x.MidName, "Test");

            var updatedP = Collection.AsQueryable().Single(x => x.Id == person.Id);
            
            Assert.That(updatedP.MidName, Is.EqualTo("Test"));
        }
    }
}