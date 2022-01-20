using AutoVente.Insight;
using AutoVente.Models;
using AutoVente.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AutoVente.Controllers
{
    public class InsightController : ApiController
    {
        private UtilisateurService utilisateurService;

        public InsightController()
        {
            
            this.utilisateurService = new UtilisateurService();
        }
        public InsightModel Get()
        {
            InsightModel insightM = new InsightModel();
            insightM.OrigineAssigneValues();
            List<DontValues> list = insightM.Origines;
            
            return insightM;
        }

    }
}
