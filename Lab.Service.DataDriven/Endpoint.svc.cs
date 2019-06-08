//------------------------------------------------------------------------------
// <copyright file="WebDataService.svc.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using System.Data.Services;
using System.Data.Services.Common;
using System.Data.Services.Providers;
using System.Linq;
using System.ServiceModel.Web;

namespace Lab.Service.DataDriven
{
    // https://marketplace.visualstudio.com/items?itemName=CONWID.WcfDataServiceTemplateExtension

    [JsonFormatter]
    public class Endpoint : EntityFrameworkDataService<LabEntities>
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
            // TODO: set rules to indicate which entity sets and service operations are visible, updatable, etc.
            // Examples:
            config.SetEntitySetAccessRule("*", EntitySetRights.AllRead);
            config.SetServiceOperationAccessRule("*", ServiceOperationRights.All);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;

            config.SetServiceOperationAccessRule("ById", ServiceOperationRights.AllRead);
        }

        // http://localhost:4679/Endpoint.svc/ById?id=1&$format=json
        // http://localhost:4679/Endpoint.svc/ById?id=1
        [WebGet]
        public IQueryable<Aluno> ById(int id)
        {
            return new LabEntities().Aluno.Where(x => x.Id == id).AsQueryable();
        }
    }
}
