// Example: call these during startup/host building
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddConfigurations(builder.Configuration); // registers IMongoClient and IMongoDatabase
builder.Services.AddDataLayer(); // registers CarMongoRepository
builder.Services.AddBusinessLayer();

var app = builder.Build();