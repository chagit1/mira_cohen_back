﻿using AutoMapper;
using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Service
{
    public class InstitutionService : IInstitutionService
    {
        private readonly IDataRepository<Institution> _repository;
        private readonly IDataRepository<User> _UserRepository;

        private readonly IMapper _mapper;

        public InstitutionService(IDataRepository<Institution> repository, IDataRepository<User> UserRepository, IMapper mapper)
        {
            _repository = repository;
            _UserRepository = UserRepository;
            _mapper = mapper;
        }

        public async Task<List<InstitutionEntities>> GetAllAsync()
        {
            var institutions = await _repository.GetAllAsync();
            return _mapper.Map<List<InstitutionEntities>>(institutions);
        }

        public async Task<InstitutionEntities> GetByIdAsync(string id)
        {
            var institution = await _repository.GetByIdAsync(id);
            return _mapper.Map<InstitutionEntities>(institution);
        }

        public async Task<InstitutionEntities> AddAsync(InstitutionEntities institution)
        {
            var institutionRep = _mapper.Map<Institution>(institution);
            var addedInstitution = await _repository.AddAsync(institutionRep);
            return _mapper.Map<InstitutionEntities>(addedInstitution);
        }

        public async Task<InstitutionEntities> UpdateAsync(InstitutionEntities institution)
        {
            var institutionRep = _mapper.Map<Institution>(institution);
            var updatedInstitution = await _repository.UpdateAsync(institutionRep);
            return _mapper.Map<InstitutionEntities>(updatedInstitution);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
