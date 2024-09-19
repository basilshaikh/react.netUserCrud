using Microsoft.Extensions.Options;
using MongoDB.Driver;
using userApplication.Data;
using userApplication.Models;

namespace userApplication.Services
{
    public class UserServices
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserServices(IOptions<DatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.Connection);
            var mongoDb = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _userCollection = mongoDb.GetCollection<User>(settings.Value.CollectionName);
        }

        //get-all-users
        public async Task<List<User>> GetUsersAsync()
        {
            return await _userCollection.Find(_ => true).ToListAsync();
        }

        //get-user-by-id
        public async Task<User?> GetUserById(string id)
        {
            return await _userCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        //create-user
        public async Task CreateUserAsync(User newUser)
        {
            await _userCollection.InsertOneAsync(newUser);
        }

        //update-user
        public async Task UpdateUserAsync(string id, User updatedUser)
        {
            await _userCollection.ReplaceOneAsync(x => x.Id == id, updatedUser);
        }

        //delete-user
        public async Task RemoveUserAsync(string id)
        {
            await _userCollection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
