using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PS.Domain
{
    public class Provider : Concept
    {
        public static int NbInstance { get; set; } = 0;

        string password;
        string confirmPassword;
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        //[DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password),
            Required,
            NotMapped,
            Compare("Password")]
        public string ConfirmPassword
        {
            get
            {
                return confirmPassword;
            }
            set
            {
                if (value == password)
                {
                    confirmPassword = value;
                }
                else
                {
                    Console.WriteLine("Erreur, ConfirmPassword invalide");
                }
            }
        }
        [DataType(DataType.Password), MinLength(8),Required]
        public string Password
        {
            get { return password; }
            set
            {
                if (value.Length >= 5 && value.Length <= 20)
                    password = value;
                else
                {
                    Console.WriteLine("Erreur, password invalide");
                }
            }
        }
        public DateTime DateCreated { get; set; }
        public bool IsApproved { get; set; }

        public virtual List<Product> Products { get; set; }
        public int X { get; set; }

        public Provider()
        {
            NbInstance++;
        }

        public Provider(int id, string userName, string password, string confirmPassword, string email)
        {
            Id = id;
            UserName = userName;
            this.password = password;
            this.confirmPassword = confirmPassword;
            Email = email;
            NbInstance++;
        }

        public static void SetIsApproved(Provider p)
        {
            //if (p.password == p.confirmPassword)
            //{ p.IsApproved=true; }
            //else
            //{
            //    p.IsApproved=false;
            //}

            // p.IsApproved = p.password.Equals(p.confirmPassword) ? true : false;
            p.IsApproved = p.password.Equals(p.confirmPassword);
        }

        public static void SetIsApproved(string password, string confirmPassword, ref bool isApproved)
        {
            isApproved = password == confirmPassword;
        }

        //public bool Login(string password, string userName)
        //{
        //    return this.password == password && this.UserName==userName;
        //}

        //public bool Login(string password, string userName, string email)
        //{
        //    return this.password == password && this.UserName == userName && this.Email==email;
        //}

        public bool Login(string password, string userName, string email = null)
        {
            if (email == null)
            {
                return this.password == password && this.UserName == userName;
            }
            else
            {
                return this.password == password && this.UserName == userName && this.Email == email;
            }
        }

        public override string ToString()
        {
            string str = "[" + Id + "," + UserName + "," + Email + "," + IsApproved + "]";
            //for (int i = 0; i < Products.Count; i++)
            //{
            //    str = str + "\n" + Products[i];
            //}

            foreach (Product item in Products)
            {
                str = str + "\n" + item;
            }

            return str;
            //return $"jhsdjfsdjhdhsfd {UserName}";
        }

        public List<Product> GetProducts(string filterType, string filterValue)
        {
            List<Product> list = new List<Product>();
            foreach (var item in Products)
            {
                switch (filterType)
                {
                    case "DateProd":
                        {
                            DateTime x = DateTime.Now;
                            DateTime.TryParse(filterValue, out x);
                            if (item.DateProd == x)
                            {
                                list.Add(item);
                            }
                            break;
                        }
                    case "Name":
                        {
                            if (item.Name == filterValue)
                            {
                                list.Add(item);
                            }
                            break;
                        }
                        
                    default:
                        break;
                }
            }
            return list;
        }

        public override void GetDetails()
        {
            Console.WriteLine(ToString());
        }
    }
}
