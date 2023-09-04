using AssetManagement.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementFrontend.HttpHandler
{
    public class HttpRequestHandler
    {

        public HttpRequestHandler() { 
        
        }

        public async Task HttpPost(string endpoint, string dtoJson) {
            using (HttpClient client = new HttpClient())
            {

                try
                {
                    string fullUrl = ApiUrl.api + endpoint;
                    StringContent content = new StringContent(dtoJson, Encoding.UTF8, "application/JSON");

                    HttpResponseMessage response = await client.PostAsync(fullUrl, content);


                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Successful");
                    }
                    else
                    {
                        string errorResponse = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Error: {errorResponse}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($" fin Error: {ex.Message}");
                }
            }
        }

        public async Task<string> HttpGet(string endpoint) {
            using (HttpClient client = new HttpClient())
            {
                

                string fullUrl = ApiUrl.api + endpoint;

                HttpResponseMessage response = await client.GetAsync(fullUrl);
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return responseContent;
                    //var responseObject = JsonConvert.DeserializeObject<IQueryable>(responseContent);

                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                        
                }
                return null;

                
            }
        }

        
    }
}
