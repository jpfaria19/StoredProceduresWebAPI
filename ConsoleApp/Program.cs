using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:51639/");
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //####### Friends Seed ########
            Friend friend1 = new Friend();
            friend1.Name = "Diego";
            friend1.Age = 20;
            //#############################

            Task<HttpResponseMessage> response = client.PostAsJsonAsync("api/friends", friend1);
            if (response.Result.IsSuccessStatusCode)
                Console.WriteLine($"Amigo {friend1.Name} incluido com sucesso!");

            Console.WriteLine("Vamos imprimir todo mundo agora:");
            Task<HttpResponseMessage> response2 = client.GetAsync("api/friends");
            Task<IEnumerable<Friend>> taskFriends = response2.Result.Content.ReadAsAsync<IEnumerable<Friend>>();
            IEnumerable<Friend> friends = taskFriends.Result;

            foreach(var f in friends)
                Console.WriteLine(f.Name);

            Console.ReadLine();
        }

        //public static async Task<HttpResponseMessage> AddFriend(HttpClient client, Friend friend)
        //{
        //    HttpResponseMessage response;
        //    response = await client.PostAsJsonAsync("api/friends", friend);

        //    return response;
        //}
    }
}
