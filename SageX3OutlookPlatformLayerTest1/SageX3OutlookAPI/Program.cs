using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SageX3OutlookAPI.Controllers;
using SageX3OutlookApplication.Interfaces;
using SageX3OutlookApplication.Services;
using Microsoft.AspNetCore.Builder;
// --- Added these to support the Sage X3 Mock/Real toggle ---
using SageX3OutlookInfrastructure.SageX3;
using SageX3OutlookInfrastructure.Http;
using SageX3OutlookInfrastructure.ERP_Authentication;
using SageX3OutlookInfrastructure.Caching;
using SageX3OutlookAPI.AuthorisationPolicies;

var builder = WebApplication.CreateBuilder(args);

// -----------------------------
// 1. Core Services (Controllers, Swagger, CORS)
// -----------------------------
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowTaskpane",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// -------------------------------------------------------------
// 2. Sage X3 Integration (Mock vs. Real Toggle)
// -------------------------------------------------------------
var useMock = builder.Configuration.GetValue<bool>("ErpSettings:UseMock");

if (useMock)
{
    // Register the MOCK version for testing without a real ERP
    builder.Services.AddScoped<ISageX3Client, MockSageX3Client>();
    Console.WriteLine("--> ERP System: RUNNING IN MOCK MODE");
}
else
{
    // Register the REAL version for production
    builder.Services.AddScoped<ISageX3Client, SageX3Client>();

    // Register the HTTP client needed for the real version
    builder.Services.AddHttpClient<SageHttpClient>(client => {
        client.BaseAddress = new Uri(builder.Configuration["ErpSettings:BaseUrl"] ?? "http://localhost");
    });
    Console.WriteLine("--> ERP System: RUNNING IN PRODUCTION MODE");
}

// Common infrastructure needed for Sage Auth
builder.Services.AddSingleton<ITokenCacheService, DistributedTokenCacheService>();
builder.Services.AddScoped<ISageAuthService, SageAuthService>();
// -------------------------------------------------------------

// -----------------------------
// 3. Application Layer DI
// -----------------------------
builder.Services.AddScoped<ILeadService, LeadService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IKnowledgeService, KnowledgeService>();
builder.Services.AddScoped<IAttachmentService, AttachmentService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IAuditService, AuditService>();
builder.Services.AddScoped<IOpportunityService, OpportunityService>();
builder.Services.AddScoped<IWorkFlowService, WorkflowService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IAutoLinkService, AutoLinkService>();
builder.Services.AddScoped<ISageX3Service, SageX3Service>();

// -----------------------------
// 4. Auth & Security
// -----------------------------
builder.Services.AddAuthorization(options =>
{
    PolicyConfiguration.Configure(options);
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = false
        };
    });

var app = builder.Build();

// -----------------------------
// 5. Middleware Pipeline
// -----------------------------
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseSwagger();
app.UseSwaggerUI(); // Fixed to use UI

app.UseHttpsRedirection();

app.UseCors("AllowTaskpane");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

