using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class DATABASECHANGELOG
    {
        public string ID { get; set; }
        public string AUTHOR { get; set; }
        public string FILENAME { get; set; }
        public System.DateTime DATEEXECUTED { get; set; }
        public string MD5SUM { get; set; }
        public string DESCRIPTION { get; set; }
        public string COMMENTS { get; set; }
        public string TAG { get; set; }
        public string LIQUIBASE { get; set; }
    }
}
