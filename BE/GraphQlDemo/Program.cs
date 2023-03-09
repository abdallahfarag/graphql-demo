using GraphQL;
using GraphQL.Server;
using GraphQlDemo.Contracts;
using GraphQlDemo.DBContext;
using GraphQlDemo.GraphQL.AppSchemas;
using GraphQlDemo.GraphQL.Mutations;
using GraphQlDemo.GraphQL.Queries;
using GraphQlDemo.GraphQL.Types;
using GraphQlDemo.Repositories;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
 {
     options.AddPolicy("Cors", policy =>
     {
         policy.WithOrigins("http://localhost:4200")
                 .AllowCredentials()
                 .AllowAnyHeader()
                 .AllowAnyMethod();
     });
 });
// Add services to the container.
builder.Services.AddDbContext<ApplicationDBContext>(opt =>
        opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<OwnerType>();
builder.Services.AddScoped<AccountType>();
builder.Services.AddScoped<OwnerInputType>();
builder.Services.AddScoped<AccountTypeEnumType>();
builder.Services.AddScoped<AppQuery>();
builder.Services.AddScoped<AppMutation>();
builder.Services.AddScoped<AppSchema>();

builder.Services.AddGraphQL(b => b
    .AddSystemTextJson()
    .AddDataLoader()
    .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true)
    );

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
app.UseCors("Cors");
app.UseAuthorization();
app.UseGraphQL<AppSchema>("/graphql");            // url to host GraphQL endpoint
app.UseGraphQLPlayground(
    "/playground",                               // url to host Playground at
    new GraphQL.Server.Ui.Playground.PlaygroundOptions
    {
        GraphQLEndPoint = "/graphql",         // url of GraphQL endpoint
        SubscriptionsEndPoint = "/graphql",   // url of GraphQL endpoint
    });

app.MapControllers();

app.Run();
