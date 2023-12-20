using BudgetLogger.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Register JsonFileTransactionService as a transient service to be used in dependency injection.
builder.Services.AddTransient<JsonFileTransactionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

// Check if the environment is not development.
if (!app.Environment.IsDevelopment())
{
    // Use the exception handler middleware to handle exceptions and direct to the Error page.
    app.UseExceptionHandler("/Error");
    
    // See: https://aka.ms/aspnetcore-hsts
    app.UseHsts();
}

// Redirect HTTP requests to HTTPS.
app.UseHttpsRedirection();

// Serve static files like CSS, JavaScript, and images.
app.UseStaticFiles();

// Enable routing.
app.UseRouting();

// Add authorization middleware for authentication and authorization handling.
// app.UseAuthorization()

// Map Razor Pages for handling requests.
app.MapRazorPages();

// Run the application.
app.Run();