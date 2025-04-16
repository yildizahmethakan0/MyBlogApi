using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyBlogApi.Data;
using MyBlogApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//  JWT Ayarları
var jwt = builder.Configuration.GetSection("Jwt");
var keyBytes = Encoding.UTF8.GetBytes(jwt["Key"]!);

// Veritabanı
builder.Services.AddDbContext<BlogDbContext>(opts =>
    opts.UseSqlite(builder.Configuration.GetConnectionString("Default")));

//  Authentication ve Authorization
builder.Services
  .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
  .AddJwtBearer(options =>
  {
      options.TokenValidationParameters = new TokenValidationParameters
      {
          ValidateIssuer = true,
          ValidIssuer = jwt["Issuer"],
          ValidateAudience = true,
          ValidAudience = jwt["Audience"],
          ValidateLifetime = true,
          IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
          ValidateIssuerSigningKey = true
      };
  });

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

<<<<<<< HEAD
//  Sabit kullanıcı
=======
>>>>>>> 70f359a (front end güncellendi)
var username = "admin";
var password = "Sifre123!";

//  Login endpoint
app.MapPost("/login", (UserLogin creds) =>
{
    Console.WriteLine($"Giriş denemesi: {creds.Username} / {creds.Password}");

    if (creds.Username != username || creds.Password != password)
        return Results.Unauthorized();

    var tokenHandler = new JwtSecurityTokenHandler();
    var key = new SymmetricSecurityKey(keyBytes);
    var tokenDesc = new SecurityTokenDescriptor
    {
        Subject = new ClaimsIdentity(new[]
        {
            new Claim("sub", creds.Username)
        }),
        Expires = DateTime.UtcNow.AddMinutes(int.Parse(jwt["ExpireMinutes"]!)),
        Issuer = jwt["Issuer"],
        Audience = jwt["Audience"],
        SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
    };

    var token = tokenHandler.CreateToken(tokenDesc);
    return Results.Ok(new { token = tokenHandler.WriteToken(token) });
});


//  Blog Endpoints

// 1) Blogları Listele (herkese açık)
app.MapGet("/blogs", async (BlogDbContext db) =>
    await db.BlogPosts.OrderByDescending(b => b.CreatedAt).ToListAsync());

// 2) Tek Blog Getir (herkese açık)
app.MapGet("/blogs/{id:int}", async (int id, BlogDbContext db) =>
    await db.BlogPosts.FindAsync(id) is BlogPost post
        ? Results.Ok(post)
        : Results.NotFound());

// 3) Yeni Blog Ekle
app.MapPost("/blogs",
    [Microsoft.AspNetCore.Authorization.Authorize]
    async (BlogPost post, BlogDbContext db) =>
{
    post.CreatedAt = DateTime.UtcNow;
    db.BlogPosts.Add(post);
    await db.SaveChangesAsync();
    return Results.Created($"/blogs/{post.Id}", post);
});

// 4) Blog Güncelle
app.MapPut("/blogs/{id:int}",
    [Microsoft.AspNetCore.Authorization.Authorize]
    async (int id, BlogPost input, BlogDbContext db) =>
{
    var post = await db.BlogPosts.FindAsync(id);
    if (post is null) return Results.NotFound();

    post.Title = input.Title;
    post.Content = input.Content;
    post.UpdatedAt = DateTime.UtcNow;
    await db.SaveChangesAsync();
    return Results.NoContent();
});

// 5) Blog Sil
app.MapDelete("/blogs/{id:int}",
    [Microsoft.AspNetCore.Authorization.Authorize]
    async (int id, BlogDbContext db) =>
{
    var post = await db.BlogPosts.FindAsync(id);
    if (post is null) return Results.NotFound();

    db.BlogPosts.Remove(post);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();

<<<<<<< HEAD
=======

>>>>>>> 70f359a (front end güncellendi)
public record UserLogin(
    [property: JsonPropertyName("username")] string Username,
    [property: JsonPropertyName("password")] string Password);
