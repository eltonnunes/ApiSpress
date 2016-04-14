using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiSpress.Bibliotecas
{
    public static class nfeRead
    {
        public static NFe.ConvertTxt.NFe Loader(string xml)
        {
            NFe.ConvertTxt.nfeRead read = new NFe.ConvertTxt.nfeRead();
            read.ReadFromString(xml);
            return read.nfe;
        }
        public static NFe.ConvertTxt.Emit LoaderEmit(string xml)
        {
            NFe.ConvertTxt.nfeRead read = new NFe.ConvertTxt.nfeRead();
            read.ReadFromString(xml);
            return (NFe.ConvertTxt.Emit)read.nfe.emit;
        }
    }
}