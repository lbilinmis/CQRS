using CQRS.API.Data;
using CQRS.API.QueryCommand.Handles;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<StudentContext>(opt =>
{
    opt.UseSqlServer(@"Data source=IGU-NB-0884; Database=Udemy_YSK_CORSQ;user id=sa;password=s123456*-;");
});
// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(opt =>
{
    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddScoped<GetStudentByIdQueryHandler>();
builder.Services.AddScoped<GetStudentsQueryHandler>();
builder.Services.AddScoped<CreateStudentCommandHandler>();
builder.Services.AddScoped<RemoveStudentCommandHandler>();
builder.Services.AddScoped<UpdateStudentCommandHandler>();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
