using System;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;
using IceSocialNet.Model;
using Newtonsoft.Json.Linq;

namespace IceSocialNet.Common
{
    public class RestClientAPI
    {
        private const String url = "http://10.0.2.2/elgg/services/api/rest/json?method={0}";


        public static Result CreateAccount(string api_key, string username, string password, string name, string email)
        {
            var _url = string.Format(url, "user.register");

            var client = new RestClient(_url);

            var request = new RestRequest(Method.POST);

            request.AddParameter("api_key", api_key);

            request.AddParameter("username", username);
            request.AddParameter("password", password);
            request.AddParameter("name", name);
            request.AddParameter("email", email);

            IRestResponse response = client.Execute(request);

            Result result = JsonConvert.DeserializeObject<Result>(response.Content);

            return result;
        }
        public static LoginToken Login(string username, string password)
        {
            var _url = string.Format(url, "auth.gettoken");

            var client = new RestClient(_url);

            var request = new RestRequest(Method.POST);

            request.AddParameter("username", username);
            request.AddParameter("password", password);

            IRestResponse response = client.Execute(request);

            JToken root = JObject.Parse(response.Content);
            JToken status = root["status"];
            LoginToken loginToken = null;
            if (status.ToString().Equals("0"))
            {
                JToken result = root["result"];

                loginToken = JsonConvert.DeserializeObject<LoginToken>(result.ToString());
            }
            
            return loginToken;
        }

        public static Account GetUserProfile(string username, string api_key, string auth_token)
        {
            var _url = string.Format(url, "user.get_profile");

            var client = new RestClient(_url);

            var request = new RestRequest("tokeninfo", Method.GET);

            request.AddParameter("api_key", api_key);
            request.AddParameter("auth_token", auth_token);
            request.AddParameter("username", username);

            IRestResponse response = client.Execute(request);

            JToken root = JObject.Parse(response.Content);
            JToken status = root["status"];
            Account account = null;
            if (status.ToString().Equals("0"))
            {
                JToken result = root["result"];

                account = JsonConvert.DeserializeObject<Account>(result.ToString());
            }
            
            return account;
        }

        public static List<MessageBoard> GetUserMessageBoard(string api_key, string auth_token, string username, int offset = 0, int limit = 10)
        {
            var _url = string.Format(url, "user.get_messageboard");

            var client = new RestClient(_url);

            var request = new RestRequest(Method.GET);

            request.AddParameter("api_key", api_key);
            request.AddParameter("auth_token", auth_token);

            request.AddParameter("username", username);
            request.AddParameter("limit", limit);
            request.AddParameter("offset", offset);

            IRestResponse response = client.Execute(request);

            JToken root = JObject.Parse(response.Content);
            JToken status = root["status"];
            List<MessageBoard> messageBoard = null;

            if (status.ToString().Equals("0"))
            {
                JToken result = root["result"];

                messageBoard = JsonConvert.DeserializeObject<List<MessageBoard>>(result.ToString());
            }

            return messageBoard;
        }

        public static Result PostMessage(string api_key, string auth_token, string message, string toUser, string fromUser)
        {
            var _url = string.Format(url, "user.post_messageboard");

            var client = new RestClient(_url);

            var request = new RestRequest(Method.POST);

            request.AddParameter("api_key", api_key);
            request.AddParameter("auth_token", auth_token);

            request.AddParameter("text", message);
            request.AddParameter("to", toUser);
            request.AddParameter("from", fromUser);

            IRestResponse response = client.Execute(request);

            Result result = JsonConvert.DeserializeObject<Result>(response.Content);

            return result;
        }

        public static List<Activity> GetActivities(string api_key, string auth_token, string username, int offset = 0, int limit = 10)
        {
            var _url = string.Format(url, "wire.get_posts");

            var client = new RestClient(_url);

            var request = new RestRequest(Method.GET);

            request.AddParameter("api_key", api_key);
            request.AddParameter("auth_token", auth_token);

            request.AddParameter("username", username);
            request.AddParameter("limit", limit);
            request.AddParameter("offset", offset);

            IRestResponse response = client.Execute(request);

            JToken root = JObject.Parse(response.Content);
            JToken status = root["status"];
            List<Activity> activities = null;

            if (status.ToString().Equals("0"))
            {
                JToken result = root["result"];

                activities = JsonConvert.DeserializeObject<List<Activity>>(result.ToString());
            }

            return activities;
        }
    }
}
