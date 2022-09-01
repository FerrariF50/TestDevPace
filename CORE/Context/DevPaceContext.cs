using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Context
{
    public class DevPaceContext : DbContext
    {
        public DevPaceContext() { }

        public DevPaceContext(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }
}
