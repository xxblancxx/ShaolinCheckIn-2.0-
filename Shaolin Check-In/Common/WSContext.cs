using Shaolin_Check_In.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Shaolin_Check_In.Common
{
    class WSContext
    {
        private HttpClientHandler handler;
        public const string ServerUrl = "http://xxblancxx-001-site1.anytempurl.com/api/";
        public async Task<ObservableCollection<Club>> GetAllClubs()
        {
            handler = new HttpClientHandler();
            //Creates a new HttpClientHandler.
            handler.UseDefaultCredentials = true;
            //true if the default credentials are used; otherwise false. will use authentication credentials from the logged on user on your pc.
            using (HttpClient client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                var task = client.GetAsync("clubs");
                // var means the compiler will determine the explicit type of the variable, based on usage. this would give you a variable of type Client.
                HttpResponseMessage response = await task;
                response.EnsureSuccessStatusCode();
                // check for response code (if response is not 200 throw exception)
                ObservableCollection<Club> clublist = await response.Content.ReadAsAsync<ObservableCollection<Club>>();
                // var will give you a variable of type IEnumerable.
                return clublist;
            }
        }


        public async Task<ObservableCollection<Team>> GetAllTeams()
        {
            handler = new HttpClientHandler();
            //Creates a new HttpClientHandler.
            handler.UseDefaultCredentials = true;
            //true if the default credentials are used; otherwise false. will use authentication credentials from the logged on user on your pc.
            using (HttpClient client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                var task = client.GetAsync("Teams");
                // var means the compiler will determine the explicit type of the variable, based on usage. this would give you a variable of type Client.
                HttpResponseMessage response = await task;
                response.EnsureSuccessStatusCode();
                // check for response code (if response is not 200 throw exception)
                var teamlist = await response.Content.ReadAsAsync<ObservableCollection<Team>>();
                // var will give you a variable of type IEnumerable.
                return teamlist;
            }
        }

        public async Task<ObservableCollection<Student>> GetAllStudents()
        {
            handler = new HttpClientHandler();
            //Creates a new HttpClientHandler.
            handler.UseDefaultCredentials = true;
            //true if the default credentials are used; otherwise false. will use authentication credentials from the logged on user on your pc.
            using (HttpClient client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                var task = client.GetAsync("Students");
                // var means the compiler will determine the explicit type of the variable, based on usage. this would give you a variable of type Client.
                HttpResponseMessage response = await task;
                response.EnsureSuccessStatusCode();
                // check for response code (if response is not 200 throw exception)
                var studentlist = await response.Content.ReadAsAsync<ObservableCollection<Student>>();
                // var will give you a variable of type IEnumerable.
                return studentlist;
            }
        }

        //public async Task<Student> GetStudent(int id)
        //{
        //    handler = new HttpClientHandler();
        //    //Creates a new HttpClientHandler.
        //    handler.UseDefaultCredentials = true;
        //    //true if the default credentials are used; otherwise false. will use authentication credentials from the logged on user on your pc.
        //    using (HttpClient client = new HttpClient(handler))
        //    {
        //        client.BaseAddress = new Uri(ServerUrl);
        //        var task = client.GetAsync("Students/"+ id);
        //        // var means the compiler will determine the explicit type of the variable, based on usage. this would give you a variable of type Client.
        //        HttpResponseMessage response = await task;
        //        response.EnsureSuccessStatusCode();
        //        // check for response code (if response is not 200 throw exception)
        //        var student = await response.Content.ReadAsAsync<Student>();
        //        // var will give you a variable of type IEnumerable.
        //        return student;
        //    }
        //}
        public async Task<ObservableCollection<Registration>> GetAllRegistrations()
        {
            handler = new HttpClientHandler();
            //Creates a new HttpClientHandler.
            handler.UseDefaultCredentials = true;

            //true if the default credentials are used; otherwise false. will use authentication credentials from the logged on user on your pc.
            using (HttpClient client = new HttpClient(handler))
            {
                //client.Timeout = TimeSpan.FromSeconds(4);
                client.BaseAddress = new Uri(ServerUrl);
                var task = client.GetAsync("Registrations");
                // var means the compiler will determine the explicit type of the variable, based on usage. this would give you a variable of type Client.
                HttpResponseMessage response = await task;
                response.EnsureSuccessStatusCode();
                // check for response code (if response is not 200 throw exception)
                var registrationlist = await response.Content.ReadAsAsync<ObservableCollection<Registration>>();
                // var will give you a variable of type IEnumerable.
                return registrationlist;
            }
        }

        public async Task<ObservableCollection<StudentRegistration>> GetAllStudentRegistrations()
        { // Looks for registrations connected to a specific student
            handler = new HttpClientHandler();
            //Creates a new HttpClientHandler.
            handler.UseDefaultCredentials = true;

            //true if the default credentials are used; otherwise false. will use authentication credentials from the logged on user on your pc.
            using (HttpClient client = new HttpClient(handler))
            {
                //client.Timeout = TimeSpan.FromSeconds(4);
                client.BaseAddress = new Uri(ServerUrl);
                var task = client.GetAsync("StudentRegistrations");
                // var means the compiler will determine the explicit type of the variable, based on usage. this would give you a variable of type Client.
                HttpResponseMessage response = await task;
                response.EnsureSuccessStatusCode();
                // check for response code (if response is not 200 throw exception)
                var registrationlist = await response.Content.ReadAsAsync<ObservableCollection<StudentRegistration>>();
                // var will give you a variable of type IEnumerable.
                return registrationlist;
            }
        }
        public async Task<ObservableCollection<Registration>> GetStudentRegistrations(int id)
        { // Looks for registrations connected to a specific student
            handler = new HttpClientHandler();
            //Creates a new HttpClientHandler.
            handler.UseDefaultCredentials = true;

            //true if the default credentials are used; otherwise false. will use authentication credentials from the logged on user on your pc.
            using (HttpClient client = new HttpClient(handler))
            {
                //client.Timeout = TimeSpan.FromSeconds(4);
                client.BaseAddress = new Uri(ServerUrl);
                var task = client.GetAsync("Registrations/" + id);
                // var means the compiler will determine the explicit type of the variable, based on usage. this would give you a variable of type Client.
                HttpResponseMessage response = await task;
                response.EnsureSuccessStatusCode();
                // check for response code (if response is not 200 throw exception)
                var registrationlist = await response.Content.ReadAsAsync<ObservableCollection<Registration>>();
                // var will give you a variable of type IEnumerable.
                return registrationlist;
            }
        }
        public async Task CreateRegistration(Registration registration)
        {
            handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = await client.PostAsJsonAsync("Registrations", registration);
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }

            }
        }

    }
}
