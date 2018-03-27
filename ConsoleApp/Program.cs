using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DomainModel;
using System.Net.Http.Headers;
using System.Net.Http;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:51639/");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            //####### Friends Seed ########
            Friend friend1 = new Friend();
            friend1.Name = "Samii";
            friend1.SurName = "Portuga";
            friend1.Email = "portuga.samii@psamii.com";
            friend1.Phone = 987609803;
            friend1.Birthday = new DateTime(2001, 7, 21);
            //#############################

            Task<HttpResponseMessage> response = client.PostAsJsonAsync("api/friends", friend1);
            if (response.Result.IsSuccessStatusCode)
                Console.WriteLine($"Amigo {friend1.Name} incluido com sucesso!");

            Console.WriteLine("Vamos imprimir todo mundo agora:");
            Task<HttpResponseMessage> response2 = client.GetAsync("api/friends");
            Task<IEnumerable<Friend>> taskFriends = response2.Result.Content.ReadAsAsync<IEnumerable<Friend>>();
            IEnumerable<Friend> friends = taskFriends.Result;

            foreach (var f in friends)
                Console.WriteLine(f.Name);

            Console.ReadLine();
        }
    }
}
