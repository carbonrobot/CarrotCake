namespace CarrotCake.Web.Api.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using Domain;
    using Microsoft.Practices.Unity;
    using Services;

    [RoutePrefix("inventory")]
    public class InventoryController : ApiController
    {
        [Dependency]
        public InventoryService InventoryService { get; set; }

        [HttpGet]
        [Route("")]
        public IEnumerable<InventoryItem> Index()
        {
            var results = this.InventoryService.List();
            return results;
        }
    }
}