using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloUWP.Entities
{
    public enum GenderValue
    {
        Male = 1,
        Female = 0
    }
    public enum StatusValue
    {
        Active = 1,
        Deactive = 0,
        Delected = -1
    }
    public class Account
    {
        public int id { get; set; }
        public int role { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string password { get; set; }
        public string resetPassword { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string avatar { get; set; }
        public GenderValue gender { get; set; }
        public string email { get; set; }
        public string birthday { get; set; }
        public StatusValue status { get; set; }
        public override string ToString()
        {
            return $"FirstName {firstName}, LastName {lastName}, Email {email}, Password {password}";
        }

        public string GetStatusAsString()
        {
            if(status == (StatusValue)1)
            {
                return "Active";
            }
            else if(status == 0){ 
                return "Deactive";
            }else if(status == (StatusValue)(-1))
            {
                return "Delected";
            }
            return null;
        }
        public string GetGenderAsString()
        {
            if (gender == (GenderValue)1)
            {
                return "Male";
            }
            else
            {
                return "Female";
            }
        }
    }

}
