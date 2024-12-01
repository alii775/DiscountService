using Discount.IOC;
using Hangfire;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterService();
builder.Services.AddControllers();
builder.Services.AddHangfire(config =>
config.UseSqlServerStorage(builder.Configuration.GetConnectionString("CommandConnection")));
builder.Services.AddHangfireServer();
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


app.UseAuthorization();

app.MapControllers();
app.UseHangfireDashboard("/hangfire");
app.UseHangfireServer();


app.Run();
