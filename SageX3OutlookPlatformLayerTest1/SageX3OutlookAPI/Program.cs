
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SageX3OutlookApplication.Interfaces;
using SageX3OutlookApplication.Services;
using SageX3OutlookInfrastructure.DependencyInjection;
using SageX3OutlookInfrastructure.SageX3;
using SageX3OutlookInfrastructure.Http;
using SageX3OutlookInfrastructure.Caching;
using SageX3OutlookAPI.AuthorisationPolicies;

var builder = WebApplication.CreateBuilder(args);

// Controllers & Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(o => o.AddPolicy("AllowTaskpane", p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

// ERP Mock / Real toggle
var useMock = builder.Configuration.GetValue<bool>("ErpSettings:UseMock");
if (useMock)
    builder.Services.AddScoped<ISageX3Client, MockSageX3Client>();
else
{
    builder.Services.AddScoped<ISageX3Client, SageX3Client>();
    builder.Services.AddHttpClient<SageHttpClient>(c =>
        c.BaseAddress = new Uri(builder.Configuration["ErpSettings:BaseUrl"] ?? "http://localhost"));
}

// Application Services
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

// Infrastructure DI
builder.Services.AddInfrastructure();

// Auth
builder.Services.AddAuthorization(options => PolicyConfiguration.Configure(options));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => { options.TokenValidationParameters = new TokenValidationParameters(); });

var app = builder.Build();

// Middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseCors("AllowTaskpane");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();