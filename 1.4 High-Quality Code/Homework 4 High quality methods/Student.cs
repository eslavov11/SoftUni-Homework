namespace Methods
{
    using System;

    public class Student
    {
        private string firstName;
        private string lastName;
        private string otherInfo;

        public Student(string firstName, string lastName, string otherInfo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.OtherInfo = otherInfo;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Student first name is empty.");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Student last name is empty.");
                }

                this.lastName = value;
            }
        }

        public string OtherInfo
        {
            get
            {
                return this.otherInfo;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Student \"other info\" is empty.");
                }

                this.otherInfo = value;
            }
        }

        public bool IsOlderThan(string otherInfo)
        {
            DateTime firstDate =
                DateTime.Parse(this.OtherInfo.Substring(this.OtherInfo.Length - 10));
            DateTime secondDate =
                DateTime.Parse(otherInfo.Substring(otherInfo.Length - 10));
            return firstDate > secondDate;
        }
    }
}
