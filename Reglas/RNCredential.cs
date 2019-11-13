using SalesCrack.Datos;
using SalesCrack.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SalesCrack.Reglas
{
    public class RNCredential
    {
        public static SalesCrackContext context = new SalesCrackContext();

        public static void AddCredential(Credential cred)
        {
            context.Credential.Add(cred);
            context.SaveChanges();

        }
        
    }
}