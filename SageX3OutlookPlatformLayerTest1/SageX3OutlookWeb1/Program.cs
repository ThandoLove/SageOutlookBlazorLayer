using Microsoft.AspNetCore.Components.Authorization;
using SageX3OutlookApplication.Interfaces;
using SageX3OutlookApplication.Services;
using SageX3OutlookWeb1.Apiservices;
using SageX3OutlookWeb1.UserAuthentication;
using SageX3OutlookWeb1.Components;

var builder = WebApplication.CreateBuilder(args);

// Razor Components
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

// HttpClient to API
builder.Services.AddHttpClient<IApiClient, ApiClient>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"] ?? "http://localhost:5000"));

// Auth
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddAuthorizationCore();

// Application Layer Services (thin wrappers to API)
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<ILeadService, LeadService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IKnowledgeService, KnowledgeService>();
builder.Services.AddScoped<IAttachmentService, AttachmentService>();
builder.Services.AddScoped<ISageX3Service, SageX3Service>();
builder.Services.AddScoped<IAuditService, AuditService>();

var app = builder.Build();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();
else
    app.UseExceptionHandler("/Error");

app.UseHttpsRedirection();
app.MapStaticAssets();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
app.Run();