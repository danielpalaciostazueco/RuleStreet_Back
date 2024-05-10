using RuleStreet.Business;
using RuleStreet.Api;
using RuleStreet.Models;
using RuleStreet.Data;
using Serilog;
using Serilog.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            ValidAudience = builder.Configuration["JWT:ValidAudience"],
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecretKey"]))
        };
    });



Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("logs/application.log", rollingInterval: RollingInterval.Day)
    .WriteTo.Debug()
    .CreateLogger();
builder.Host.UseSerilog();

var isRunningInDocker = Environment.GetEnvironmentVariable("DOCKER_CONTAINER") == "true";
var keyString = isRunningInDocker ? "ServerDB_Docker" : "ServerDB";
var connectionString = builder.Configuration.GetConnectionString(keyString);

// Configuración de los servicios para la aplicación
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración de Entity Framework para usar SQL Server
builder.Services.AddDbContext<RuleStreetAppContext>(options =>
    options.UseSqlServer(connectionString, sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 10,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorNumbersToAdd: null);
    }));


builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "RuleStreet.Api", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddScoped<CiudadanoService>();
builder.Services.AddScoped<ICiudadanoRepository, CiudadanoRepository>();

builder.Services.AddScoped<PoliciaService>();
builder.Services.AddScoped<IPoliciaRepository, PoliciaRepository>();

builder.Services.AddScoped<MultaService>();
builder.Services.AddScoped<IMultaRepository, MultaRepository>();

builder.Services.AddScoped<CodigoPenalService>();
builder.Services.AddScoped<ICodigoPenalRepository, CodigoPenalRepository>();

builder.Services.AddScoped<VehiculoService>();
builder.Services.AddScoped<IVehiculoRepository, VehiculoRepository>();

builder.Services.AddScoped<AuditoriaService>();
builder.Services.AddScoped<IAuditoriaRepository, AuditoriaRepository>();

builder.Services.AddScoped<PermisoService>();
builder.Services.AddScoped<IPermisoRepository, PermisoRepository>();

builder.Services.AddScoped<DenunciaService>();
builder.Services.AddScoped<IDenunciaRepository, DenunciaRepository>();


builder.Services.AddScoped<NotaService>();
builder.Services.AddScoped<INotaRepository, NotaRepository>();

builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();

builder.Services.AddScoped<RangoService>();
builder.Services.AddScoped<IRangoRepository, RangoRepository>();


builder.Services.AddScoped<EventoService>();
builder.Services.AddScoped<IEventoRepository, EventoRepository>();



builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy",
        policy => policy
            .WithOrigins("*") // Permite solicitudes de cualquier origen
            .AllowAnyMethod() // Permite todos los métodos HTTP
            .AllowAnyHeader()); // Permite todas las cabeceras HTTP
});


var app = builder.Build();

// Configuración del middleware para utilizar Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

// Aplica la política CORS configurada
app.UseCors("MyCorsPolicy");

app.UseAuthorization();
app.UseAuthentication();
// Mapeo de los controladores
app.MapControllers();

// Inicia la aplicación
app.Run();
