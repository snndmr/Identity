using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Models.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(
                new Employee
                {
                    Id = new Guid("b94bcae7-72ca-4f5a-986e-9da2c1ce3326"),
                    Name = "Steward Blaszczynski",
                    Age = 31,
                    Position = "Quality Control Specialist"
                }, new Employee
                {
                    Id = new Guid("4a26a426-963b-43f3-b517-8f38e39c697f"),
                    Name = "Colleen Bosence",
                    Age = 27,
                    Position = "Accountant III"
                }, new Employee
                {
                    Id = new Guid("085fbdc5-6c50-4ca9-a846-71e96e7cf04b"),
                    Name = "Valenka Wiggett",
                    Age = 21,
                    Position = "Senior Developer"
                }, new Employee
                {
                    Id = new Guid("88b52515-eb9e-4f1b-8915-93fd1cae7140"),
                    Name = "Sigismundo McClarence",
                    Age = 31,
                    Position = "Structural Engineer"
                }, new Employee
                {
                    Id = new Guid("19a9e271-55d3-4e28-a408-90fc9bf70fb5"),
                    Name = "Gene Kenefick",
                    Age = 29,
                    Position = "Marketing Manager"
                }
            );
        }
    }
}
