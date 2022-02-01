using DevDojo.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevDojo.Server
{
    public class ItemConfiguration : IEntityTypeConfiguration<TaskItem>
    {
        public void Configure(EntityTypeBuilder<TaskItem> builder)
        {
            builder.HasData(
                new TaskItem
                {
                    Id = 1,
                    Name = "Walk dog",
                    Status = "Backlog"
                },
                new TaskItem
                {
                    Id = 2,
                    Name = "Gym",
                    Status = "Todo"
                },
                new TaskItem
                {
                    Id = 3,
                    Name = "Paint",
                    Status = "Doing"
                },
                new TaskItem
                {
                    Id = 4,
                    Name = "Run Marathon",
                    Status = "Done"
                },
                new TaskItem
                {
                    Id = 5,
                    Name = "Walk cat",
                    Status = "Backlog"
                },
                new TaskItem
                {
                    Id = 6,
                    Name = "Code",
                    Status = "Backlog"
                },
                new TaskItem
                 {
                     Id = 7,
                     Name = "Send grandma email",
                     Status = "Backlog"
                 },
                new TaskItem
                 {
                     Id = 8,
                     Name = "Make Tea",
                     Status = "Backlog"
                 },
               new TaskItem
               {
                   Id = 9,
                   Name = "fix plug",
                   Status = "Backlog"
               },
               new TaskItem
                {
                     Id = 10,
                     Name = "Buy gift",
                     Status = "Backlog"
                },
               new TaskItem
                  {
                      Id = 11,
                      Name = "Iron Clothes",
                      Status = "Backlog"
                  },
                       new TaskItem
                       {
                           Id = 12,
                           Name = "Get groceries",
                           Status = "Backlog"
                       },
        new TaskItem
        {
            Id = 13,
            Name = "Get ready for party",
            Status = "Backlog"
        }

        );
        }
    }
}
