using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IHotelService,HotelManager>();
builder.Services.AddSingleton<IHotelRepository,HotelRepository>();
builder.Services.AddSwaggerDocument();
var app = builder.Build();



app.MapControllers();
app.UseOpenApi();
app.UseSwaggerUi();

app.Run();
