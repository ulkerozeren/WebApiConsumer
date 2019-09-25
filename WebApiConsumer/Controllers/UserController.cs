using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiConsumer.Models;

namespace WebApiConsumer.Controllers
{
    public class UserController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public UserController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> List()
        {
            Task<IEnumerable<Models.User>> result = null;

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "users");
            var client = _httpClientFactory.CreateClient("deneme");
            HttpResponseMessage httpResponseMessage = await client.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                result = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Models.User>>();
            }

            return View(result.Result);
        }
    }
}
