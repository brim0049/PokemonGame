using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace INF11207_TP3_Jeu_de_Pokemons.ViewModels.RelayCommands
{
    class RestApiQueries
    {

        private HttpClient _client;

        public RestApiQueries()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:5000/api/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /* asynchrone requests */
        //Get Invitaiton
        public async Task<List<Models.Invitation>> GetTInvitationAsync(string path)
        {
            HttpResponseMessage response = await _client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                List<Models.Invitation> invitations = JsonConvert.DeserializeObject<List<Models.Invitation>>(data);
                return invitations;
            }

            return new List<Models.Invitation>();
        }
        public List<Models.Invitation> GetInvitation(string path)
        {
            List<Models.Invitation> invitations = new List<Models.Invitation>();

            try
            {
                Task<List<Models.Invitation>> invitation = Task.Run(async () => await GetTInvitationAsync(path));
                invitation.Wait();
                invitations = invitation.Result;
            }
            catch (Exception) { }

            return invitations;
        }
        //Post Invitaiton
        public async Task<bool> AddInvitationAsync(Models.Invitation invitation, string path)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(invitation), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync(path, content);

            if (response.IsSuccessStatusCode)
                return true;
            else
               
                return false;
        }
        public bool AddInvitation(Models.Invitation newinvitation, string path)
        {
            try
            {
                Task<bool> invitation = Task.Run(async () => await AddInvitationAsync(newinvitation, path));
                invitation.Wait();
                return invitation.Result;
            }
            catch (Exception) { }

            return false;
        }

        //Accepte invitaiton
        public async Task<bool> AccepteAsync(Models.Invitation invitation, int playerId, int invitationId, string path)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(invitation), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PatchAsync($"{path}/{playerId}/{invitationId} ", content);

            if (response.IsSuccessStatusCode)
                return true;
            else
                return false;
        }
        public bool AccepteInvitation(Models.Invitation invitation, int playerId, int invitationId, string path)
        {
            try
            {
                Task<bool> accepte = Task.Run(async () => await AccepteAsync(invitation, playerId, invitationId, path));
                accepte.Wait();
                return accepte.Result;
            }
            catch (Exception) { }

            return false;
        }
        //Refuser Invitation

        public async Task<bool> RefuseAsync(Models.Invitation invitation, int playerId, int invitationId, string path)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(invitation), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PatchAsync($"{path}/{playerId}/{invitationId} ", content);

            if (response.IsSuccessStatusCode)
                return true;
            else
                return false;
        }    
        public bool RefuseInvitation(Models.Invitation invitation, int playerId, int invitationId, string path)
        {
            try
            {
                Task<bool> refuse = Task.Run(async () => await RefuseAsync(invitation, playerId, invitationId, path));
                refuse.Wait();
                return refuse.Result;
            }
            catch (Exception) { }

            return false;
        }
        /*---------*/
        //Get one player

        public async Task<Models.Rest.Player> GetPlayerAsync(int playerId, string path)
        {
            HttpResponseMessage response = await _client.GetAsync($"{path}/{playerId}");

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                Models.Rest.Player player = JsonConvert.DeserializeObject<Models.Rest.Player>(data);
                return player;
            }
            return new Models.Rest.Player();
        }
        public Models.Rest.Player GetPlayer(int playerId, string path)
        {
            Models.Rest.Player players = new Models.Rest.Player();

            try
            {
                Task<Models.Rest.Player> player = Task.Run(async () => await GetPlayerAsync(playerId, path));
                player.Wait();
                players = player.Result;
            }
            catch (Exception) { }

            return players;
        }
     
        /*---------*/
        //Get deck
        public async Task<Models.Rest.Deck> GetDeckAsync(int deckId, string path)
        {
            HttpResponseMessage response = await _client.GetAsync($"{path}/{deckId}");

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                Models.Rest.Deck decks = JsonConvert.DeserializeObject<Models.Rest.Deck>(data);
                return decks;
            }
            return new Models.Rest.Deck();
        }
        public Models.Rest.Deck GetDeck(int deckId, string path)
        {
            Models.Rest.Deck decks = new Models.Rest.Deck();

            try
            {
                Task<Models.Rest.Deck> deck = Task.Run(async () => await GetDeckAsync(deckId, path));
                deck.Wait();
                decks = deck.Result;
            }
            catch (Exception) { }

            return decks;
        }
        /*---------*/
        //Post Result
        public async Task<bool> AddResultatAsync(Models.Rest.Result resultat, string path)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(resultat), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync(path, content);

            if (response.IsSuccessStatusCode)
                return true;
            else

                return false;
        }
        public bool AddResultat(Models.Rest.Result newResultat, string path)
        {
            try
            {
                Task<bool> resultat = Task.Run(async () => await AddResultatAsync(newResultat, path));
                resultat.Wait();
                return resultat.Result;
            }
            catch (Exception) { }

            return false;
        }
        //Get Result
        public async Task<List<Models.Rest.Result>> GetResultAsync(string path)
        {
            HttpResponseMessage response = await _client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                List<Models.Rest.Result> resultats = JsonConvert.DeserializeObject<List<Models.Rest.Result>>(data);
                return resultats;
            }

            return new List<Models.Rest.Result>();
        }
        public List<Models.Rest.Result> GetResult(string path)
        {
            List<Models.Rest.Result> resultats = new List<Models.Rest.Result>();

            try
            {
                Task<List<Models.Rest.Result>> results = Task.Run(async () => await GetResultAsync(path));
                results.Wait();
                resultats = results.Result;
            }
            catch (Exception) { }

            return resultats;
        }

    }
}
