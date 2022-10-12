using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Ecole42Entity.Entity;
using Ecole42Entity.MainContext;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Ecole42WebUI.Areas.Admin.IntraHelper
{
	public class IntraWorker
	{
		private Context db = new Context();
		public async Task<JArray> GetCoalitionAsync(int userID, string access_token)
		{
			var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization 
                         = new AuthenticationHeaderValue("Bearer", access_token);
            var response = await client.GetAsync($"https://api.intra.42.fr/v2/users/{userID}/coalitions");
            var result = await response.Content.ReadAsStringAsync();
            JArray coalitionJson = (JArray)JsonConvert.DeserializeObject(result);
            return coalitionJson;
		}

		public async Task<JObject> GetIntraUserAsync(string access_token)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization 
                         = new AuthenticationHeaderValue("Bearer", access_token);
            var response = await client.GetAsync("https://api.intra.42.fr/v2/me");
            var result = await response.Content.ReadAsStringAsync();
            JObject userJson = (JObject)JsonConvert.DeserializeObject(result);
            return userJson;
        }

		public async Task<string> GetAccessTokenAsync(string code)
        {
            var client = new HttpClient();
            string uri = "https://api.intra.42.fr/oauth/token/";
            string clientID = "0b2460b728f609af8ef5728b8149a71ee1964bf961f6cdb376036417f1abdce2";
            string grantType = "authorization_code";
            string clientSecret = "444f0803fd6dae2d2059833050c328c0779d5a0df11c43e93032fd0e15f08e1a";
            string redirect_url = "https://localhost:5001/admin/intra-login";

            var jsonData = new {
                grant_type = grantType,
                client_id = clientID,           
                client_secret = clientSecret,
                code = code,
                redirect_uri = redirect_url
            };
            var json = JsonConvert.SerializeObject(jsonData);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(uri, data);
            var result = await response.Content.ReadAsStringAsync();
            var access_json = (JObject)JsonConvert.DeserializeObject(result);
            string access_token = access_json.SelectToken("access_token").ToString();
            return access_token;
        }

		public async Task<User> addIntraUser(JObject userData, int intraID)
		{
			User user = new User(){
                    Name = userData["first_name"].Value<string>(),
                    Surname = userData["last_name"].Value<string>(),
                    Email = userData["email"].Value<string>(),
                    intraID = intraID,
                    Role = "USER",
                    CreateDate = DateTime.Now,
                    LastDateTime = DateTime.Now,
                    ImageUrl = userData["image_url"].Value<string>(),
                };
            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();
			return user;
		}
	}
}
