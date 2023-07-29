using MatchingCampaignAPI;
using MatchingCampaignBL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowSpecificOrigins",
                          policy =>
                          {
                              policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                              //policy.WithOrigins("http://example.com",
                              //                    "http://www.contoso.com")
                              //                    .AllowAnyHeader()
                              //                    .AllowAnyMethod();
                          });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddBLServices();
//builder.Services.AddScoped<IAggregations, TextAggregation>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
app.UseMiddleware();
app.UseCors("MyAllowSpecificOrigins");
app.Run();
