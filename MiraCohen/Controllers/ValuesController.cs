using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Repository;

namespace MiraCohen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IContext _context;
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(IContext context, ILogger<ValuesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("check-connection")]
        public async Task<IActionResult> CheckMongoConnection()
        {
            try
            {
                var collection = _context.GetCollection<BsonDocument>("TestCollection");
                var document = new BsonDocument { { "name", "test document" }, { "createdAt", DateTime.UtcNow } };
                await collection.InsertOneAsync(document);

                var count = await collection.CountDocumentsAsync(Builders<BsonDocument>.Filter.Empty);
                return Ok(new { success = true, message = $"Connection successful. Document count: {count}" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = $"Error connecting to MongoDB: {ex.Message}" });
            }
        }
    }
}