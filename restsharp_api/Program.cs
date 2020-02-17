using RestSharp;
using System;

namespace restsharp_api
{

    class Person {

        public string name;
        public int age;

        public Person(string name, int age) {
            this.name = name;
            this.age = age;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("http://localhost/test_api");

            Person person = new Person("hydro", 26);

            var request = new RestRequest("index.php",Method.POST);
            request.AddParameter("id", 5);
            //request.AddJsonBody(person);

            try
            {

                client.ExecuteAsync(request, response =>
                {
                    Console.WriteLine("Status:" + response.StatusCode + "\nResponse:" + response.Content);
                });

            }
            catch (Exception ex) {

                Console.WriteLine("Error In RestSharpRequest:" + ex);

            }

            Console.ReadLine();
        }
    }
}
