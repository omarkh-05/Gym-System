using BussinessLayer;
using GymSystemApi.Authorization;
using GymSystemAPI.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

builder.Services.AddScoped<IPersonBLL, PersonBLL>();
builder.Services.AddScoped<IAuthService, AuthServiceBLL>();
builder.Services.AddScoped<ISubscribersBLL, SubscribersBLL>();
builder.Services.AddScoped<AccessToken>();

#region Swagger
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();

// Register Swagger generator and customize its behavior.
builder.Services.AddSwaggerGen(options =>
{
    // ===============================
    // 1) Define the JWT Bearer security scheme
    // ===============================
    //
    // This tells Swagger that our API uses JWT Bearer authentication
    // through the HTTP Authorization header.
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        // The name of the HTTP header where the token will be sent.
        Name = "Authorization",
        // Indicates this is an HTTP authentication scheme.
        Type = SecuritySchemeType.Http,
        // Specifies the authentication scheme name.
        // Must be exactly "Bearer" for JWT Bearer tokens.
        Scheme = "Bearer",
        // Optional metadata to describe the token format.
        BearerFormat = "JWT",
        // Specifies that the token is sent in the request header.
        In = ParameterLocation.Header,
        // Text shown in Swagger UI to guide the user.
        Description = "Enter: Bearer {your JWT token}"
    });

    // ===============================
    // 2) Require the Bearer scheme for secured endpoints
    // ===============================
    //
    // This tells Swagger that endpoints protected by [Authorize]
    // require the Bearer token defined above.
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                // Reference the previously defined "Bearer" security scheme.
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            // No scopes are required for JWT Bearer authentication.
            // This array is empty because JWT does not use OAuth scopes here.
            new string[] {}
        }
    });
});
//builder.Services.AddSwaggerGen();
#endregion


#region Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("GymSystemAPIpolicy", policy =>
    {
        policy.WithOrigins(
            "http://127.0.0.1:5501", // الرابط المحلي لواجهة المستخدم
            "https://omarkh-05.github.io"
        )
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials(); // السماح بالوصول مع credentials
    });
});
#endregion


// انه لازم توخدو توكن يعني الي بناديكم لازم يكون عامل لوج ان واعملولي فاليديشن على التوكن شيك على الاوبشنز هاي الي تحت والي حاطينه فيها لازم يكون مطاق للاوبشنز الي حطيناها في التوكن لحظة انشاؤه في الاوث كونترولر Api's هاض بحكي لل 
#region Authentication
var secretKey = builder.Configuration["Gym_JWT_Key"];
if (string.IsNullOrWhiteSpace(secretKey))
{
    throw new Exception("JWT secret key is not configured.");
}
// Register authentication services in the dependency injection container.
// JwtBearerDefaults.AuthenticationScheme tells ASP.NET Core that
// JWT Bearer authentication will be the default authentication method.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        // TokenValidationParameters define how incoming JWTs will be validated.
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // Ensures the token was issued by a trusted issuer.
            ValidateIssuer = true,
            // Ensures the token is intended for this API (audience check).
            ValidateAudience = true,
            // Ensures the token has not expired.
            ValidateLifetime = true,
            // Ensures the token signature is valid and was signed by the API.
            ValidateIssuerSigningKey = true,
            // The expected issuer value (must match the issuer used when creating the JWT).
            ValidIssuer = "GymSystem",
            // The expected audience value (must match the audience used when creating the JWT).
            ValidAudience = "GymSubscribers",
            // The secret key used to validate the JWT signature.
            // This must be the same key used when generating the token.
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))

        };

        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var token = context.Request.Cookies["accessToken"];

                if (!string.IsNullOrEmpty(token))
                {
                    context.Token = token;
                }

                return Task.CompletedTask;
            }
        };
    });
#endregion


#region Authorization
builder.Services.AddSingleton<IAuthorizationHandler, ClientOwnerOrAdminHandler>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ClientOwnerOrAdmin", policy =>
        policy.Requirements.Add(new ClientOwnerOrAdminRequirement()));
});

#endregion


#region RateLimit
builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

    options.AddPolicy("AuthLimiter", httpContext =>
    {
        var ip = httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";

        return RateLimitPartition.GetFixedWindowLimiter(
            partitionKey: ip,
            factory: _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = 5,
                Window = TimeSpan.FromMinutes(2),
                QueueLimit = 0
            });
    });
});
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //  app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseCors("GymSystemAPIpolicy");

#region RateLimit 
app.UseRateLimiter();

app.Use(async (context, next) =>
{
    await next();

    if (context.Response.StatusCode == StatusCodes.Status429TooManyRequests)
    {
        // سجل فقط الرسالة، لا تسلسل context
        context.Response.ContentType = "text/plain";
        await context.Response.WriteAsync("Too many login attempts. Please try again later.");
    }
});
#endregion

app.UseAuthentication();

app.UseAuthorization();

// ✅ Step 6: Global 403 logging middleware (place it HERE)

// او ممكن احط في كل اندبوينت لوج برضو خاص او زي هيك عادي
app.Use(async (context, next) =>
{
    await next();

    // لاحظ أنه يمكن تسجيل أكثر من حالة
    int statusCode = context.Response.StatusCode;

    if (statusCode == StatusCodes.Status401Unauthorized || statusCode == StatusCodes.Status403Forbidden || statusCode == StatusCodes.Status404NotFound || statusCode == StatusCodes.Status400BadRequest)
    {
        var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "anonymous";
        var ip = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";
        var path = context.Request.Path.ToString();
        var reason = statusCode == 401 ? "Unauthorized" : "Forbidden";

        string logMessage = $"Security Alert: {reason}. UserId={userId}, Path={path}, IP={ip}";

        // سجل في Logger أول
        app.Logger.LogWarning(logMessage);

        // سجل في Event Viewer
     //   try
     //   {
     //       if (!System.Diagnostics.EventLog.SourceExists("GymSystemAPI"))
     //       {
     //           System.Diagnostics.EventLog.CreateEventSource("GymSystemAPI", "Application");
     //       }
     //       System.Diagnostics.EventLog.WriteEntry("GymSystemAPI", logMessage,  System.Diagnostics.EventLogEntryType.Warning);
     //   }
     //   catch (Exception ex)
     //   {
     //       app.Logger.LogError("Failed to write security log to Event Viewer: {0}", ex.Message);
     //   }
    }
});

app.MapControllers();

app.Run();
