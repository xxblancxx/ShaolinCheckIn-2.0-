﻿using Shaolin_Check_In.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Shaolin_Check_In.Common
{
    class WSContext
    {
        private HttpClientHandler handler;
        public const string ServerUrl = "http://shaolin123-001-site1.btempurl.com/api/";
        public CancellationTokenSource CancelToken = new CancellationTokenSource();
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
                ObservableCollection<Club> clublist = await response.Content.ReadAsAsync<ObservableCollection<Club>>(CancelToken.Token);
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
                var teamlist = await response.Content.ReadAsAsync<ObservableCollection<Team>>(CancelToken.Token);
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
                var studentlist = await response.Content.ReadAsAsync<ObservableCollection<Student>>(CancelToken.Token);
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
                var registrationlist = await response.Content.ReadAsAsync<ObservableCollection<Registration>>(CancelToken.Token);
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
                var registrationlist = await response.Content.ReadAsAsync<ObservableCollection<StudentRegistration>>(CancelToken.Token);
                // var will give you a variable of type IEnumerable.
                return registrationlist;
            }
        }
        public async Task<ObservableCollection<Registration>> GetStudentRegistration(int id)
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
                var registrationlist = await response.Content.ReadAsAsync<ObservableCollection<Registration>>(CancelToken.Token);
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
                    var response = await client.PostAsJsonAsync("Registrations", registration, CancelToken.Token);
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }

            }
        }

        public async Task CreateStudent(Student student)
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
                    var response = await client.PostAsJsonAsync("Students", student, CancelToken.Token);
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }

            }
        }
        public async Task CreateTeam(Team team)
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
                    var response = await client.PostAsJsonAsync("Teams", team, CancelToken.Token);
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }

            }
        }

        public async Task UpdateTeam(Team team)
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
                    var response = await client.PutAsJsonAsync("Teams/" + team.Id, team, CancelToken.Token);
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }

            }
        }
        public async Task UpdateStudent(Student student)
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
                    var response = await client.PutAsJsonAsync("Students/" + student.Id, student, CancelToken.Token);
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }

            }
        }

        public async Task UpdateClub(Club club)
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
                    var response = await client.PutAsJsonAsync("Clubs/" + club.Id, club, CancelToken.Token);
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }

            }
        }

        public async Task CreateClub(Club club)
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
                    var response = await client.PostAsJsonAsync("Clubs", club, CancelToken.Token);
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }

            }
        }

        public async Task CreateMessage(Message message)
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
                    var response = await client.PostAsJsonAsync("Messages", message, CancelToken.Token);
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }

            }
        }

        public async Task<ObservableCollection<Message>> GetAllMessages()
        {
            handler = new HttpClientHandler();
            //Creates a new HttpClientHandler.
            handler.UseDefaultCredentials = true;
            //true if the default credentials are used; otherwise false. will use authentication credentials from the logged on user on your pc.
            using (HttpClient client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                var task = client.GetAsync("Messages");
                // var means the compiler will determine the explicit type of the variable, based on usage. this would give you a variable of type Client.
                HttpResponseMessage response = await task;
                response.EnsureSuccessStatusCode();
                // check for response code (if response is not 200 throw exception)
                var messageList = await response.Content.ReadAsAsync<ObservableCollection<Message>>(CancelToken.Token);
                // var will give you a variable of type IEnumerable.
                return messageList;
            }
        }

        public async Task<List<UserLogin>> GetAllUserLogins()
        {
            handler = new HttpClientHandler();
            //Creates a new HttpClientHandler.
            handler.UseDefaultCredentials = true;
            //true if the default credentials are used; otherwise false. will use authentication credentials from the logged on user on your pc.
            using (HttpClient client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                var task = client.GetAsync("UserLogins");
                // var means the compiler will determine the explicit type of the variable, based on usage. this would give you a variable of type Client.
                HttpResponseMessage response = await task;
                response.EnsureSuccessStatusCode();
                // check for response code (if response is not 200 throw exception)
                var userLoginList = await response.Content.ReadAsAsync<List<UserLogin>>(CancelToken.Token);
                // var will give you a variable of type IEnumerable.
                return userLoginList;
            }
        }

        #region LoadFromDB Methods
        public async Task LoadClubs()
        { // Load clubs from DB into Singleton
            SingletonCommon.Instance.AllClubs = await GetAllClubs();
            var clubList = new ObservableCollection<Club>();
            foreach (var club in SingletonCommon.Instance.AllClubs)
            {
                if (club.IsActive)
                {
                    clubList.Add(club);
                }
            }
            SingletonCommon.Instance.ClubList = clubList;
        }
        public async Task LoadMessages()
        { // Load  from DB into Singleton
            SingletonCommon.Instance.MessageList = await GetAllMessages();
            SingletonCommon.Instance.SetFrontpageMessage();
        }
        public async Task LoadUserLogins()
        { // Load  from DB into Singleton
            SingletonCommon.Instance.UserLoginList = await GetAllUserLogins();
        }
        public async Task LoadTeams()
        { // Load teams from DB into Singleton
            SingletonCommon.Instance.AllTeams = await GetAllTeams();
            var teamList = new ObservableCollection<Team>();
            foreach (var team in SingletonCommon.Instance.AllTeams)
            {
                if (team.IsActive)
                {
                    teamList.Add(team);
                }
            }
            SingletonCommon.Instance.TeamList = teamList;
        }
        public async Task LoadStudents()
        { // Load students from DB into Singleton
            SingletonCommon.Instance.AllStudents = await GetAllStudents();
            var studentList = new ObservableCollection<Student>();
            foreach (var student in SingletonCommon.Instance.AllStudents)
            {
                if (student.IsActive)
                {
                    studentList.Add(student);
                }
            }
            SingletonCommon.Instance.StudentList = studentList;
        }

        public async Task LoadRegistrations()
        { // Load all Registrations from DB into Singleton
            SingletonCommon.Instance.RegistrationList = await GetAllRegistrations();
        }
        public async Task LoadStudentRegistrations()
        { // Load User registrations from View, into singleton.
            SingletonCommon.Instance.StudentRegistrationList = await GetAllStudentRegistrations();
        }
        #endregion


    }
}
