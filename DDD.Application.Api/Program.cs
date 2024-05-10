using DDD.Infra.PostegresSQL;
using DDD.Infra.PostegresSQL.Interfaces;
using DDD.Infra.PostegresSQL.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//IOC - Dependency Injection
//builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
//builder.Services.AddScoped<IAlunoRepository, AlunoRepositorySqlServer>();
//builder.Services.AddScoped<IBibliotecariaRepository, BibliotecariaRepositorySqlServer>();
//builder.Services.AddScoped<IDisciplinaRepository, DisciplinaRepositorySqlServer>();
//builder.Services.AddScoped<IEmprestimoRepository, EmprestimoRepositorySqlServer>();
//builder.Services.AddScoped<ILivroRepository, LivroRepositorySqlServer>();
//builder.Services.AddScoped<IMatriculaRepository, MatriculaRepositorySqlServer>();


builder.Services.AddScoped<IAlunoRepository, AlunoRepositoryPostgresql>();
builder.Services.AddScoped<IBibliotecariaRepository, BibliotecariaRepositoryPostgreSql>();
builder.Services.AddScoped<IDisciplinaRepository, DisciplinaRepositoryPostgreSql>();
builder.Services.AddScoped<IEmprestimoRepository, EmprestimoRepositoryPostgreSql>();
builder.Services.AddScoped<ILivroRepository, LivroRepositoryPostgreSql>();
builder.Services.AddScoped<IMatriculaRepository, MatriculaRepositoryPostgreSql>();

//builder.Services.AddScoped<SqlContext, SqlContext>();
builder.Services.AddDbContext<PostgresContext>();
//builder.Services.AddEntityFrameworkNpgsql()

builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

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

app.UseAuthorization();

app.MapControllers();

app.Run();
