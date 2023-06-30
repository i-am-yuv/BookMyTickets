using BookMyTickets;

var builder = WebApplication.CreateBuilder(args);

var startupp = new startup(builder.Configuration);
startupp.ConfigureServices(builder.Services);
// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();
startupp.Configure(app, builder.Environment);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.MapRazorPages();
app.Run();