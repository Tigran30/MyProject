using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Application.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CallingAnotherApiController : ControllerBase
    {
        private readonly ApiHelper apiHelper= new ApiHelper();
        [HttpGet("Services")]
        public async Task<string> GetRequest()
        {          
            return await apiHelper.GetRequest();
        }

        [HttpGet("ServicesByid")]
        public async Task<string> GetbyIdRequest(int id)
        {          
            return await apiHelper.GetbyIDRequest(id);
        }

        [HttpPost("CreateService")]
        public async Task<string> PostRequest(string servicename, int cost)
        {      
            return await apiHelper.PostRequest(servicename, cost);
        }

        [HttpPut("UpdateService")]
        public async Task<string> PutRequest(int id, string servicename, int cost)
        {          
            return await apiHelper.PutRequest(id, servicename, cost);
        }

        [HttpDelete("DeleteService")]
        public async Task<string> DeleteRequest(int id)
        {
            return await apiHelper.DeleteRequest(id);
        }
    }
}
