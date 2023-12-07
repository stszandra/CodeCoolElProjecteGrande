using System.Net;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using OfferOasisBackend.Contract;
using OfferOasisBackend.Models;
using OfferOasisBackend.Service.Authentication;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace OfferOasisBackend.IntegrationTests;

public class AuthControllerIntegrationTests
{
     private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            var factory = new WebApplicationFactory<Program>();
            string connectionString = Environment.GetEnvironmentVariable("MyConnectionString");
            Environment.SetEnvironmentVariable("CONNECTION_STRING", connectionString);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

           
            _client = factory.CreateClient();
        }

        [Test]
        public async Task Register_InputsCorrect_Data()
        {
            // Arrange
            Random random = new Random();
            var userNumber=random.Next(1, 10000);
            var newUser = new RegistrationRequest($"user{userNumber}@gmail.com",$"user"+userNumber.ToString(), "password123","XXX","YYY","CCC");
            var jsonString = JsonSerializer.Serialize(newUser);
            var jsonStringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
        
            // Act
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            
            var response = await _client.PostAsync("/Auth/Register", jsonStringContent);
        
            var content = response.Content.ReadAsStringAsync().Result;
            var desContent = JsonSerializer.Deserialize<AuthResponse>(content,options);
            
            // Assert
            response.EnsureSuccessStatusCode();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(desContent.Email, Is.EqualTo(newUser.Email));
            Assert.That(desContent.UserName, Is.EqualTo(newUser.Username));
        }

        [Test]
        public async Task Login_Returns_CorrectEmail()
        {
            //Arrange
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            AuthRequest authRequest = new AuthRequest("admin@admin.com", "admin123");
            var jsonString = JsonSerializer.Serialize(authRequest);
            var jsonStringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            
            //Act
            var response = _client.PostAsync("/Auth/Login", jsonStringContent).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            var desContent = JsonSerializer.Deserialize<AuthResponse>(content,options);
            var token = desContent.Token;
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            
            //Assert
            Assert.That(desContent.Email, Is.EqualTo(authRequest.Email));
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            
        }
}