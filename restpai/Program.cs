using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Data;
using Lab3.Models;
using Microsoft.Graph;
using Microsoft.Graph.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<ModelDB>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        var app = builder.Build();

        app.MapGet("/api/tariffs", async (ModelDB db) => await db.Tariffs.ToListAsync());
        app.MapPost("/api/callrecords", async (CallRecord callRecord, ModelDB db) =>
        {
            await db.CallRecords.AddAsync(callRecord);
            await db.SaveChangesAsync();
            return Results.Json(callRecord);
        });


        app.Run();
    }
}