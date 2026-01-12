using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmoothieShop.Data.Data.Entites;

namespace SmoothieShop.Data.Seeds
{
    /// <summary>
    /// Holds CustomerUser Configuration.
    /// </summary>
    internal class CustomerUserConfiguration : IEntityTypeConfiguration<CustomerUser>
    {
        public void Configure(EntityTypeBuilder<CustomerUser> builder)
        {
            builder.HasData(CreateCustomerUsers());
        }

        // A method used to seed DB with initial data of customerusers.
        private static List<CustomerUser> CreateCustomerUsers()
        {
            var customerUsers = new List<CustomerUser>()
            {
                new CustomerUser()
                {
                   CustomerUserId = 1,
                   ApplicationUserId = "customerUser@customer.com"
                }
            };

            return customerUsers;
        }
    }
}
