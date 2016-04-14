using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiRezende.Models.Pgsql;
using WebApiRezende.Models.Pgsql.Mapping;

namespace WebApiRezende.Controllers
{

    public class PetroxController : ApiController
    {

        PetroxContext db = new PetroxContext();

        // GET api/petrox/GetPdv
        public dynamic GetPdv()
        {
            var collection = db.Tab_Pdv
                               .Where(e => e.ind_pdv_desativado.Equals("N"))
                               .OrderBy(e => e.tab_empresa.cod_empresa)
                .Select(s => new
                {
                    Value = s.cod_pdv,
                    Name = (s.tab_empresa.nom_fantasia.Replace("PETROX", "") + " - " + s.des_pdv.Replace(s.num_fabricacao, ""))
                });

            return collection;
        }

        // GET api/petrox/GetPdv?Pdv=Pdv
        public dynamic GetPdv(int Pdv)
        {
                var collection = db.Tab_Pdv
                                   .Where(e => e.ind_pdv_desativado.Equals("N") && e.cod_pdv.Equals(Pdv))
                    .Select(s => new
                    {
                        Value = s.cod_pdv,
                        Name = (s.tab_empresa.nom_fantasia.Replace("PETROX", "") + " - " + s.des_pdv.Replace(s.num_fabricacao, ""))
                    }).FirstOrDefault();

                return collection;

        }

        // GET api/petrox/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/petrox
        public void Post([FromBody]string value)
        {
        }

        // PUT api/petrox/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/petrox/5
        public void Delete(int id)
        {
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
