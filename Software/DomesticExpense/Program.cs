using DomesticExpense.Application.DefaultDI;
using DomesticExpense.Domain.Services.Concepts;
using DomesticExpense.Infraestructure.Contents;
using DomesticExpense.Infraestructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddInversionOfControl();
//builder.Services.AddTransient<IConceptService, ConceptService>();
//builder.Services.AddTransient<IConceptRepository, ConceptRepository>();


//builder.Services.AddInversionOfControl();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
