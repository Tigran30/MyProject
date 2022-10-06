using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace SuperHeroAPI.Models
{
    public class ApiHelper
    {

        public HttpClient Client { set; get; } = new HttpClient();

        public ApiHelper()
        {

        }
        public async Task<string> GetRequest()
        {

            var response = await Client.GetAsync("https://localhost:7061/api/Services/AllServices");
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetbyIDRequest(int id)
        {
            var response = await Client.GetAsync("https://localhost:7061/api/Services" + $"/{id}");
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> PostRequest(string servicename, int servicecost)
        {
            Parameters datas = new Parameters(servicename, servicecost);
            var newpostJson = JsonConvert.SerializeObject(datas);
            var payload = new StringContent(newpostJson, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("https://localhost:7061/api/Services", payload);
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> PutRequest(int id, string servicename, int servicecost)
        {
            Parameters datas = new Parameters(id, servicename, servicecost);
            var newpostJson = JsonConvert.SerializeObject(datas);
            var payload = new StringContent(newpostJson, Encoding.UTF8, "application/json");
            var response = await Client.PutAsync("https://localhost:7061/api/Services", payload);
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> DeleteRequest(int id)
        {
            var response = await Client.DeleteAsync("https://localhost:7061/api/Services" + $"/{id}");
            return await response.Content.ReadAsStringAsync();

        }

    }
    public class Parameters
    {
        public Parameters(string serviceName, int serviceCost)
        {
            ServiceName = serviceName;
            ServiceCost = serviceCost;
        }

        public Parameters(int iD, string serviceName, int serviceCost)
        {
            ID = iD;
            ServiceName = serviceName;
            ServiceCost = serviceCost;
        }

        public int ID { set; get; }
        public string ServiceName { set; get; }
        public int ServiceCost { set; get; }
    }
}
