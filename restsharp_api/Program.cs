using Newtonsoft.Json.Linq;
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

            //            Person person = new Person("hydro", 26);

            JObject req = new JObject();

            JArray reqArray = new JArray();

            JObject prod = new JObject(
                new JProperty("Test3",3)
                );

            prod.Add("test1", 1);
            //prod.Add("test2", 2);

            reqArray.Add(prod);
            req.Add("SmartSwitch", reqArray);

            //prod.Add("test2", 2);
            //reqArray.Add(prod);
            //req.Add("SmartCurtain", reqArray);

            var request = new RestRequest("index.php",Method.POST);
            request.AddParameter("id", req);
            //request.AddJsonBody(person);
            request.AddParameter("application/json", req, ParameterType.RequestBody);

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
