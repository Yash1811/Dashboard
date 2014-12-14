using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using LocalAccountsApp.Models;
using LocalAccountsApp.Services;

namespace LocalAccountsApp.Controllers
{
    [Authorize]
    [RoutePrefix("api/DashBoard")]
    public class Ec2InstancesController : ApiController
    {
        private ApplicationDbContext db;
        private E2CInstanceService e2CInstanceService;

        public Ec2InstancesController()
        {
            this.db = new ApplicationDbContext();
            this.e2CInstanceService = new E2CInstanceService(db);
        }
        // GET api/DashBoard/GetEc2Instances?pageNum=<pageNum>&pageSize=<pageSize>
        [Route("GetEc2Instances")]
        public async Task<ElasticCloudDataModel> Get(int pageNum, int pageSize)
        {
            var e2CActiveInstances = await this.e2CInstanceService.GetAllActiveEc2Instances(pageNum, pageSize);
            return e2CActiveInstances;
        }
    }
}
