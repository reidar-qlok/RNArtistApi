using ArtistApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace ArtistApiTest
{
    public class Test1Api
    {
        private readonly ArtistDbContext _mockContext;
        static readonly HttpClient client = new HttpClient();
        //private readonly MyService _mockService;
        public Test1Api()
        {
            _mockContext = new ArtistDbContext(new DbContextOptionsBuilder<ArtistDbContext>()
                .UseInMemoryDatabase("ArtistTestDb").Options);
            //_mockService = new MyService(_mockContext);
        }
        [Fact]
        public async Task GetItems_ReturnsItemsFromDatabase()
        {
            // Arrange
            var expectedItems = new[] { 
                new ArtistApi.Models.Artist { ArtistId = 1, ArtistName = "Beatles" } };
            _mockContext.Artists.AddRange(expectedItems);
            _mockContext.SaveChanges();
            var client = new HttpClient(); // Konfigurera HttpClient för att anropa din Minimal API

            // Act
            HttpResponseMessage response = await client.GetAsync("https://localhost:7146/artists");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var items = JsonConvert.DeserializeObject<List<ArtistApi.Models.Artist>>(responseString);
            Assert.Equal(expectedItems.Length, items.Count);
        }
    }
}