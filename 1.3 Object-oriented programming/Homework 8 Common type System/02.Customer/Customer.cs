using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _02.Customer
{
    public class Customer : ICloneable, IComparable<Customer>
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private uint id;
        private string address;
        private string mobilePhone;
        private string email;
        private List<Payment> payments;
        private CustomerType type;

        public Customer(
            string firstName,
            string middleName,
            string lastName, 
            uint id, 
            string address,
            string mobilePhone,
            string email, 
            List<Payment> payments, 
            CustomerType type)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Id = id;
            this.Address = address;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Payments = payments;
            this.Type = type;
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return middleName;
            }

            set
            {
                middleName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }

        public uint Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string MobilePhone
        {
            get
            {
                return mobilePhone;
            }

            set
            {
                mobilePhone = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public List<Payment> Payments
        {
            get
            {
                return payments;
            }

            set
            {
                payments = value;
            }
        }

        internal CustomerType Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(Customer obj)
        {
            int firstComparator = this.FirstName.CompareTo(obj.FirstName);
            if (firstComparator == 0)
            {
                return this.Id.CompareTo(obj.Id);
            }
            return firstComparator;
        }

        public object Clone()
        {
            List<Payment> copyOfPayments = this.payments.ToList();
            return new Customer(
                this.FirstName,
                this.MiddleName,
                this.LastName,
                this.Id,
                this.Address,
                this.MobilePhone,
                this.Email,
                copyOfPayments,
                this.Type
        );

        }

        public static bool operator ==(Customer c1, Customer c2)
        {
            return c2 != null && (c1 != null && c1.Id == c2.Id);
        }

        public static bool operator !=(Customer c1, Customer c2)
        {
            return c1 != null && (c2 != null && c1.Id != c2.Id);
        }
    }
}
