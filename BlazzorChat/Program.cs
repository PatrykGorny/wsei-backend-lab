using ApplicationCore.Interfaces.UserService;
using BlazzorChat.Components;
using BlazzorChat.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();               
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSingleton<IChatUserService, ChatUserService>();
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.MapHub<BlazorChatHub>(BlazorChatHub.HubUrl);
app.Run();