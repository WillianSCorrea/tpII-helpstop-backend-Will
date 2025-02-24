
using HelpApp.Domain.Validation;
using System.Collections.Generic;


namespace HelpApp.Domain.Entity
{
    public class Category
    {
        #region Atributos 
        public int Id { get; set; }
        public string Name { get; set; }
        #endregion

        #region Construtores
        public Category(string name)
        {

            ValidateDomain(name);
        }
        
        public ICollection<Product> Products { get; set; }

        #endregion

        #region
        private void ValidateDomain(string Name)
        {
            DomainExcpetionValidation.When(string.IsNullOrEmpty(Name), "Invalid Name , Name is Required");
            DomainExcpetionValidation.When(Name.Length < 3, "Invalid Name , too short , minimum 3 characters");
        }
        #endregion
    }
}
