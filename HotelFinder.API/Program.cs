using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.DataAccess;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSingleton<HotelDbContext>();
builder.Services.AddSingleton<IHotelRepository, HotelRepository>();
builder.Services.AddSingleton<IHotelService,HotelManager>();
builder.Services.AddSwaggerDocument();

var app = builder.Build();

app.UseOpenApi();
app.UseSwaggerUi();

app.UseHttpsRedirection(); 
app.UseStaticFiles(); 

app.UseRouting();

app.UseAuthorization();

app.MapControllers();


app.Run();
