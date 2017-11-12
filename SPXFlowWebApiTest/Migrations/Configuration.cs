namespace SPXFlowWebApiTest.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SPXFlowWebApiTest.Models;
    using System.Xml.Serialization;
    using System.IO;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<SPXFlowWebApiTest.Models.SPXFlowDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

       
    }
}
