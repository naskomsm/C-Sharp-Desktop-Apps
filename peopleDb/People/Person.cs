namespace PeopleDatabase.People
{
    using System;
    using PeopleDatabase.People.Contract;

    public class Person : IPerson
    {
        private string firstName;
        private string lastName;
        private int age;

        public int Id { get; set; }

        public string FirstName
        {
            get => this.firstName;
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("First name cannot be less than 3 symbols!");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get => this.lastName;
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Second name cannot be less than 3 symbols!");
                }

                this.lastName = value;
            }

        }

        public int Age
        {
            get => this.age;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age cannot be less or equal to 0");
                }

                this.age = value;
            }
        }
    }
}
