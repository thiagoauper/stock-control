var builder = WebApplication.CreateBuilder(args);

var allowOrigins = "AllowAll";

builder.Services.AddCors(options =>
 {
     options.AddPolicy(allowOrigins,
         builder => builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader());
 });


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(allowOrigins);

app.UseAuthorization();

app.MapControllers();

//TODO: SET UP DEPENDENCY INJECTION !!!

app.Run();
