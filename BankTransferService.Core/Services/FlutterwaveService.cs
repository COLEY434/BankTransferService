using BankTransferService.Core.DTOS.Response;
using BankTransferService.Core.Intefaces.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BankTransferService.Core.Services
{
    public class FlutterwaveService : IFlutterwaveService
    {
        private readonly HttpClient _httpClient;
        public IConfiguration _config { get; }
        public FlutterwaveService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _config = configuration;
        }

     

        public async Task<BankResponse> GetBankList()
        {
            string url = _config.GetSection("Flutterwave:BankListUrl").Value;
            string secret = _config.GetSection("SecretKey:Flutterwave").Value;
            var result = new BankResponse();
            try
            {
                HttpRequestMessage httpRequestMessage = ConstructPayload(HttpMethod.Get, url);

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    string content = await httpResponseMessage.Content.ReadAsStringAsync();
                    var response = JsonSerializer.Deserialize<FlutterwaveBankListRes>(content);

                    if(response?.status != "success")
                    {
                        result.Code = 200;
                        result.Description = response?.message;         
                    }
                    else
                    {
                        result.Code = 200;
                        result.Description = response?.message;
                        result.BankList = response?.data;
                        
                    }
                }
                else if(httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized)
                {
                    result.Code = 400;
                    result.Description = "You are not authorized to access this resource";
                }
                else
                {
                    result.Code = (int)httpResponseMessage.StatusCode;
                    result.Description = "An error occurred while fetching bank list, Kindly try again.";
                }
            }
            catch (HttpRequestException ex)
            {
                //log here
                result.Code = 500;
                result.Description = "Internal server error, Kindly try again.";
            }

            return result;
        }

        //private async Task PostToWebApi(HttpMethod method, string url, object? data)
        //{
        //    try
        //    {
        //        HttpRequestMessage httpRequestMessage = ConstructPayload(method, url, data);

        //        HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage);

        //        if (httpResponseMessage.IsSuccessStatusCode)
        //        {
        //            string content = await httpResponseMessage.Content.ReadAsStringAsync();

                    
        //        }
        //        else
        //        {
        //            // Handle the error
        //            // ...
        //        }
        //    }
        //    catch (HttpRequestException ex)
        //    {
        //        ex.m
        //    }
            
        //}

        private HttpRequestMessage ConstructPayload(HttpMethod method, string url, object data = null)
        {
            string secretKey = _config.GetSection("SecretKey:Flutterwave").Value;

            var httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", $"{secretKey}");
            httpRequestMessage.RequestUri = new Uri(url);

            if (method == HttpMethod.Post)
            {
                string jsonData = JsonSerializer.Serialize(data);
                httpRequestMessage.Content = new StringContent(jsonData, Encoding.UTF8, Application.Json);
                httpRequestMessage.Method = HttpMethod.Post;
            }
            else
            {
                httpRequestMessage.Method = HttpMethod.Get;
            }

            return httpRequestMessage;
        }
        public Task<List<Banks>> ValidateAccountNumber()
        {
            throw new NotImplementedException();
        }

        public Task<List<Banks>> BankTransfer()
        {
            throw new NotImplementedException();
        }
    }

}
