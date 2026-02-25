using Microsoft.AspNetCore.Components.Authorization;
using SageX3OutlookApplication.Interfaces;
using SageX3OutlookApplication.Services;
using SageX3OutlookInfrastructure;       // Needed for .AddInfrastructure()
using SageX3OutlookInfrastructure.DependencyInjection;
using SageX3OutlookInfrastructure.Resilience; // Needed for SagePolicyFactory
using SageX3OutlookWeb1.Apiservices;
using SageX3OutlookWeb1.Components;
using SageX3OutlookWeb1.UserAuthentication;      // Needed for App component


var builder = WebApplication.CreateBuilder(args);

// === 1️⃣ Add Razor Components for TaskPane ===
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// === 2️⃣ Register HttpClient for API calls with Resilience ===
builder.Services.AddHttpClient<IApiClient, ApiClient>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"] ?? "http://localhost:5000/");
})
// Applying the Polly retry policy we created in SagePolicyFactory
.AddPolicyHandler(SagePolicyFactory.GetHttpRetryPolicy());

// === 3️⃣ Add Authentication/Authorization ===
// Ensure AuthStateProvider.cs exists in the .Authentication namespace
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddAuthorizationCore();

// === 4️⃣ Add Application Layer services ===
// Note: If these services are in a "Services" folder, add 'using SageX3OutlookWeb1.Services;'
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<ILeadService, LeadService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IKnowledgeService, KnowledgeService>();
builder.Services.AddScoped<IAttachmentService, AttachmentService>();
builder.Services.AddScoped<ISageX3Service, SageX3Service>();
builder.Services.AddScoped<IAuditService, AuditService>();

// === 5️⃣ Add Infrastructure Layer ===
// This calls the extension method in your Infrastructure project
builder.Services.AddInfrastructure();

// === Build the App ===
var app = builder.Build();

// === 6️⃣ Static Files & Exception Handling ===
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

// === 7️⃣ Status Code Handling & HTTPS ===
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

// === 8️⃣ Antiforgery for security ===
app.UseAntiforgery();

// === 9️⃣ Map Blazor to App.razor ===
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
