﻿using Newtonsoft.Json;
using RestSharp;

namespace FootBall_Bot.Clients
{
    public class APIClient
    {
        RestClient client;

        public APIClient()
        {
            client = new RestClient();
        }
        public Models.Leagues.Leagues GetLeagues()
        {
            var request = new RestRequest("https://v3.football.api-sports.io/leagues", Method.Get);
            request.AddHeader("x-rapidapi-key", Constants.ApiKey);
            request.AddHeader("x-rapidapi-host", Constants.Host);
            var content = client.Execute(request).Content;
            Models.Leagues.Leagues result = JsonConvert.DeserializeObject<Models.Leagues.Leagues>(content);
            return result;
        }

        public Models.Leagues.Leagues GetLeagues(string name)
        {
            name = FormatToURL(name);
            var request = new RestRequest($"https://v3.football.api-sports.io/leagues?name={name}", Method.Get);
            request.AddHeader("x-rapidapi-key", Constants.ApiKey);
            request.AddHeader("x-rapidapi-host", Constants.Host);
            var content = client.Execute(request).Content;
            Models.Leagues.Leagues result = JsonConvert.DeserializeObject<Models.Leagues.Leagues>(content);
            return result;
        }



        public Models.Fixtures.Fixtures GetFixtures()
        {
            RestRequest request;
            request = new RestRequest($"https://v3.football.api-sports.io/fixtures?live=all", Method.Get);


            request.AddHeader("x-rapidapi-key", Constants.ApiKey);
            request.AddHeader("x-rapidapi-host", Constants.Host);
            var content = client.Execute(request).Content;

            Models.Fixtures.Fixtures result = JsonConvert.DeserializeObject<Models.Fixtures.Fixtures>(content);
            return result;
        }

        public Models.Fixtures.Fixtures GetFixtures(string date)
        {
            RestRequest request;
            request = new RestRequest($"https://v3.football.api-sports.io/fixtures?date={date}", Method.Get);


            request.AddHeader("x-rapidapi-key", Constants.ApiKey);
            request.AddHeader("x-rapidapi-host", Constants.Host);
            var content = client.Execute(request).Content;
            Models.Fixtures.Fixtures result = JsonConvert.DeserializeObject<Models.Fixtures.Fixtures>(content);
            return result;
        }

        public Models.Fixtures.Fixtures GetFixtures(int league, int season)
        {
            RestRequest request;
            request = new RestRequest($"https://v3.football.api-sports.io/fixtures?league={league}&season={season}", Method.Get);

            request.AddHeader("x-rapidapi-key", Constants.ApiKey);
            request.AddHeader("x-rapidapi-host", Constants.Host);
            var content = client.Execute(request).Content;
            Models.Fixtures.Fixtures result = JsonConvert.DeserializeObject<Models.Fixtures.Fixtures>(content);
            return result;
        }

        public Models.Fixtures.Fixtures GetFixtures(int teamID, ushort season)
        {
            RestRequest request;
            request = new RestRequest($"https://v3.football.api-sports.io/fixtures?season={season}&team={teamID}", Method.Get);


            request.AddHeader("x-rapidapi-key", Constants.ApiKey);
            request.AddHeader("x-rapidapi-host", Constants.Host);
            var content = client.Execute(request).Content;
            Models.Fixtures.Fixtures result = JsonConvert.DeserializeObject<Models.Fixtures.Fixtures>(content);
            return result;
        }

        public Models.Fixtures.Fixtures GetFixtures(int teamID, string date)
        {
            var season = int.Parse(date.Split("-")[0]) - 1;
            RestRequest request;
            request = new RestRequest($"https://v3.football.api-sports.io/fixtures?season={season}&team={teamID}&date={date}", Method.Get);


            request.AddHeader("x-rapidapi-key", Constants.ApiKey);
            request.AddHeader("x-rapidapi-host", Constants.Host);
            var content = client.Execute(request).Content;
            Models.Fixtures.Fixtures result = JsonConvert.DeserializeObject<Models.Fixtures.Fixtures>(content);
            return result;
        }

        public Models.Fixtures.Fixtures GetFixtures(int teamID, int season, int league)
        {
            RestRequest request;
            request = new RestRequest($"https://v3.football.api-sports.io/fixtures?league={league}&season={season}&team={teamID}", Method.Get);


            request.AddHeader("x-rapidapi-key", Constants.ApiKey);
            request.AddHeader("x-rapidapi-host", Constants.Host);
            var content = client.Execute(request).Content;
            Models.Fixtures.Fixtures result = JsonConvert.DeserializeObject<Models.Fixtures.Fixtures>(content);
            return result;
        }



        

        public Models.Teams.Teams GetTeamByCode(string code)
        {
            RestRequest request;
            request = new RestRequest($"https://v3.football.api-sports.io/teams?code={code}", Method.Get);

            request.AddHeader("x-rapidapi-key", Constants.ApiKey);
            request.AddHeader("x-rapidapi-host", Constants.Host);
            var content = client.Execute(request).Content;
            Models.Teams.Teams result = JsonConvert.DeserializeObject<Models.Teams.Teams>(content);
            return result;
        }

        public Models.Teams.Teams GetTeam(string teamName)
        {
            RestRequest request;
            teamName = FormatToURL(teamName);
            request = new RestRequest($"https://v3.football.api-sports.io/teams?name={teamName}", Method.Get);

            request.AddHeader("x-rapidapi-key", Constants.ApiKey);
            request.AddHeader("x-rapidapi-host", Constants.Host);
            var content = client.Execute(request).Content;
            Models.Teams.Teams result = JsonConvert.DeserializeObject<Models.Teams.Teams>(content);
            return result;
        }
        public Models.Teams.Teams GetTeam(string code, int league, int season)
        {
            RestRequest request;
            request = new RestRequest($"https://v3.football.api-sports.io/teams?code={code}&league={league}&season={season}", Method.Get);

            request.AddHeader("x-rapidapi-key", Constants.ApiKey);
            request.AddHeader("x-rapidapi-host", Constants.Host);
            var content = client.Execute(request).Content;
            Models.Teams.Teams result = JsonConvert.DeserializeObject<Models.Teams.Teams>(content);
            return result;
        }



        private static string FormatToURL(string name)
        {
            string[] nameParts = name.Split(" ");
            if (nameParts.Length > 1)
            {
                name = "";
                for (int i = 0; i < nameParts.Length; i++)
                {
                    if (i == nameParts.Length - 1)
                    {
                        name += nameParts[i];
                        break;
                    }
                    name += nameParts[i] + "%20";
                }
            }

            return name;
        }

    }
}