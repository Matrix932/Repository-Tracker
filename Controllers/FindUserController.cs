using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using WebApplication22.Models;

namespace WebApplication22.Controllers
{


    public class FindUserController : Controller
    {

        private readonly JsonSerializerOptions _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public async Task<IActionResult> Index(string UserName,[FromServices] IHttpClientFactory _httpClientFactory)
        {
            if (String.IsNullOrEmpty(UserName))
            {
                string message = "Input field cannot be empty";
                return RedirectToAction("Index", "Home",message);
  
            }
            var client = _httpClientFactory.CreateClient(name: "GithubUser");
            
            var response = await client.GetAsync(requestUri: "users/" + UserName);
            if (response.IsSuccessStatusCode) {

                var user = await response.Content.ReadFromJsonAsync<GithubUserDetails>();

                var responseRepos = await client.GetAsync(requestUri: "users/" + UserName + "/repos");
                var stream = await responseRepos.Content.ReadAsStreamAsync();
                var repos = await JsonSerializer.DeserializeAsync<GithubRepository[]>(stream, _options);

                GithubUserDetails user2 = user;
                user2.Repositories = repos;
                return View(user2);
            }
            else
            {
                string message = "No user with found";
                return RedirectToAction("Index", "Home", message);
            }
            
        }

        public async Task<IActionResult> MultipleUsers(string UserName, [FromServices] IHttpClientFactory _httpClientFactory)
        {
            List<GithubUserDetails> userList = new List<GithubUserDetails>();
            if (String.IsNullOrEmpty(UserName))
            {
                string message = "Input field cannot be empty";
                return RedirectToAction("Index", "Home", message);

            }
            string trimmed = String.Concat(UserName.Where(c => !Char.IsWhiteSpace(c)));
            String[]  usernames =trimmed.Split(",");


            var client = _httpClientFactory.CreateClient(name: "GithubUser");

            foreach (string username in usernames)
            {
                var response = await client.GetAsync(requestUri: "users/"+username);

                if (response.IsSuccessStatusCode)
                {

                    var user = await response.Content.ReadFromJsonAsync<GithubUserDetails>();

                    var responseRepos = await client.GetAsync(requestUri: "users/"+username +"/repos");
                    var stream = await responseRepos.Content.ReadAsStreamAsync();
                    var repos = await JsonSerializer.DeserializeAsync<GithubRepository[]>(stream, _options);

                    GithubUserDetails user2 = user;
                    user2.Repositories = repos;
                    userList.Add(user2);
                }
                else
                {
                    string s = "123";
                }
            }
            return View(userList);

            
            

        }
    }
}
