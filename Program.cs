using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

using CountyAbbr = System.String;
using CountyName = System.String;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
     c.SwaggerDoc("v1", new OpenApiInfo { Title = "Washington County PA", Description = "Web API for IT", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
   c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API for IT");
});

var counties = new Dictionary <CountyAbbr, CountyName> 
{
    {"AD","Adams"}, 
    {"AL","Allegheny"}, 
    {"AR", "Armstrong"}, 
    {"BE", "Beaver"}, 
    {"BD", "Bedford"}, 
    {"BK","Berks"}, 
    {"BL", "Blair"}, 
    {"BR", "Bradford"}, 
    {"BU", "Bucks"}, 
    {"BT", "Butler"}, 
    {"CA", "Cambria"}, 
    {"CM", "Cameron"}, 
    {"CR", "Carbon"}, 
    {"CE", "Centre"}, 
    {"CH", "Chester"}, 
    {"CL", "Clarion"}, 
    {"CF", "Clearfield"}, 
    {"CN", "Clinton"}, 
    {"CO", "Columbia"}, 
    {"CW", "Crawford"}, 
    {"CU", "Cumberland"}, 
    
};
// array of townships in Washington County, PA
string[] townships = { "Amwell", "Blaine", "Buffalo", "Canton", "Carroll", "Cecil", "Chartiers", "Cross Creek", "Donegal", "East Bethlehem", "East Finley", "East Franklin", "Fallowfield", "Hanover", "Hopewell", "Independence", "Jefferson", "Morris", "Mount Pleasant", "North Bethlehem", "North Franklin", "North Strabane", "Nottingham", "Peters", "Robinson", "Smith", "Somerset", "South Franklin", "South Strabane", "Union", "West Bethlehem", "West Finley", "West Pike Run" };
// array of school districts in Washington County, PA
string[] schoolDistricts = { "Avella Area School District", "Bentworth School District", "Burgettstown Area School District", "California Area School District", "Canon-McMillan School District", "Charleroi Area School District", "Chartiers-Houston School District", "Fort Cherry School District", "McGuffey School District", "Peters Township School District", "Ringgold School District", "Trinity Area School District", "Washington School District" };
// json object of school districts in Washington County, PA with their respective websites using key value pairs
var schoolDistrictsAndWebsites = new Dictionary<string, string>
{
    {"Avella Area School District", "https://www.avella.k12.pa.us/"},
    {"Bentworth School District", "https://www.bentworth.org/"},
    {"Burgettstown Area School District", "https://www.burgettstown.k12.pa.us/"},
    {"California Area School District", "https://www.calsd.org/"},
    {"Canon-McMillan School District", "https://www.cmsd.k12.pa.us/"},
    {"Charleroi Area School District", "https://www.charleroisd.org/"},
    {"Chartiers-Houston School District", "https://www.chsdknights.org/"},
    {"Fort Cherry School District", "https://www.fortcherry.org/"},
    {"McGuffey School District", "https://www.mcguffey.k12.pa.us/"},
    {"Peters Township School District", "https://www.ptsd.k12.pa.us/"},
    {"Ringgold School District", "https://www.ringgold.org/"},
    {"Trinity Area School District", "https://www.trinitypride.org/"},
    {"Washington School District", "https://www.washington.k12.pa.us/"}
};

// Endpoints:
app.MapGet("/", () => Results.Redirect("/swagger"));
app.MapGet("/counties", () => counties);
app.MapGet("/counties/{ab}", (string ab) => counties[ab.ToUpper()]);
app.MapGet("/townships", () => townships);
app.MapGet("/schoolDistricts", () => schoolDistricts);
app.MapGet("/schoolDistrictsAndWebsites", () => schoolDistrictsAndWebsites);

app.Run();
