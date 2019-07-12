using blu.MyProject.Domain;
using blu.MyProject.EntityFrameworkCore;

namespace blu.MyProject.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly MyProjectDbContext _context;

        public TestDataBuilder(MyProjectDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
            _context.People.AddRange(
                new Person("Jack", 19),
                new Person("Azra", 20) { State = Person.PersonState.Completed }
                );
        }
    }
}