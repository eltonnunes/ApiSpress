using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class sysarticleupdate
    {
        public int artid { get; set; }
        public int pubid { get; set; }
        public int sync_ins_proc { get; set; }
        public int sync_upd_proc { get; set; }
        public int sync_del_proc { get; set; }
        public bool autogen { get; set; }
        public int sync_upd_trig { get; set; }
        public Nullable<int> conflict_tableid { get; set; }
        public Nullable<int> ins_conflict_proc { get; set; }
        public bool identity_support { get; set; }
    }
}
