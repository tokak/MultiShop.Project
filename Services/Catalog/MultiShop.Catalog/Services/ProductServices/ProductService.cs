﻿using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productCollection;
        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;
          
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var map = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(map);
        }

        public async Task DeleteProductAsync(string id)
        {
             await _productCollection.DeleteOneAsync(x=>x.ProductId == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            var map = _mapper.Map<List<ResultProductDto>>(values);
            return map;
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var value = await _productCollection.Find(x=>x.ProductId == id).FirstOrDefaultAsync();
            var map = _mapper.Map<GetByIdProductDto>(value);
            return map;
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var map = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x=>x.ProductId == updateProductDto.ProductId, map);
        }
    }
}
