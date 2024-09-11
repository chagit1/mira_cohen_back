﻿using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRep : IDataRepository<User>
    {
        private readonly IContext _context;

        public UserRep(IContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _context.CreateCollectionsIfNotExists().Wait();

        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.Find(user => true).ToListAsync();
        }

        public async Task<User> GetByIdAsync(string id)
        {
            return await _context.Users.Find<User>(user => user.Id == id).FirstOrDefaultAsync();
        }

        public async Task<User> AddAsync(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user)); 
            user.Id = ObjectId.GenerateNewId().ToString();
            //if (user == null) throw new ArgumentNullException(nameof(user));
            await _context.Users.InsertOneAsync(user);
            return user;
        }

        public async Task<User> UpdateAsync(User user)
        {
            if (user == null || string.IsNullOrEmpty(user.Id)) throw new ArgumentNullException(nameof(user)); 
            await _context.Users.ReplaceOneAsync(u => u.Id == user.Id, user);
            return user;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _context.Users.DeleteOneAsync(user => user.Id == id);
            return result.DeletedCount > 0;
        }
    }
}

