namespace PeopleDatabase.People.Contract
{
    public interface IPerson
    {
        string FirstName { get; }

        string LastName { get; }

        int Age { get; }
    }
}
