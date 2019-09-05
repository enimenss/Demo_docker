using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ServiceStack.Redis;

namespace Docker_demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private RedisManagerPool _redis;
        private ILogger _logger;
        public ValuesController(IServiceProvider service,ILogger<ValuesController> logger)
        {
            _redis = service.GetService<RedisManagerPool>();
            _logger = logger;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _logger.LogInformation("Get request");
            int inc = 0;
            if(int.TryParse(_redis.GetClient().GetValue("inc"),out inc))
            {
                inc++;
                _logger.LogInformation("value with 'inc' key exist in redis database, value is incremented");
            }
            else
            {
                _logger.LogInformation("value with 'inc' key doesn`t exist in redis database, value is incremented and set");
            }
            _redis.GetClient().SetValue("inc", inc.ToString());
            return new string[] { "Site has been visited:" + inc.ToString() };
        }      
    }
}
