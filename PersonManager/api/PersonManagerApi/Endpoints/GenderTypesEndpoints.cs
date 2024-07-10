using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonManagerApi.Data;
using PersonManagerApi.Models;

namespace PersonManagerApi.Endpoints
{
    public static class GenderTypesEndpoints
    {
        public static void RegisterGenderTypesEndpoints(this WebApplication app)
        {
            _ = app.MapGet("/genderTypes", async (ApplicationDbContext db) =>
            {
                return await db.GenderTypes.ToListAsync();
            });

            _ = app.MapGet("/genderTypes/{genderTypeId}", async (int genderTypeId, ApplicationDbContext db) =>
            {
                GenderType? genderType = await db.GenderTypes.FindAsync(genderTypeId);

                return genderType == null ? Results.NotFound() : Results.Ok(genderType);
            });

            _ = app.MapPut("/genderTypes/{genderTypeId}", async (int genderTypeId, [FromBody] GenderType genderType, ApplicationDbContext db) =>
            {
                GenderType? genderTypeToUpdate = await db.GenderTypes.FindAsync(genderTypeId);

                if (genderTypeToUpdate == null)
                {
                    return Results.NotFound(); // In the futire will return an error 500
                }
                else
                {
                    genderTypeToUpdate.Name = genderType.Name;

                    _ = await db.SaveChangesAsync();

                    return Results.NoContent();
                }
            });

            _ = app.MapPost("/genderTypes", async ([FromBody] GenderType genderType, ApplicationDbContext db) =>
            {
                GenderType genderTypeToAdd = new()
                {
                    Name = genderType.Name,
                    DateCreated = DateTime.Now,
                    IsDeleted = false
                };

                _ = db.GenderTypes.Add(genderTypeToAdd);

                _ = await db.SaveChangesAsync();

                return Results.Created($"/genderTypes/{genderTypeToAdd.GenderTypeId}", genderTypeToAdd);
            });

            _ = app.MapDelete("/genderTypes/{genderTypeId}", async (int genderTypeId, ApplicationDbContext db) =>
            {
                GenderType? genderTypeToRemove = await db.GenderTypes.FindAsync(genderTypeId);

                if (genderTypeToRemove == null)
                {
                    return Results.NotFound();
                }
                else
                {
                    genderTypeToRemove.IsDeleted = true;

                    _ = await db.SaveChangesAsync();

                    return Results.Ok();
                }
            });
        }
    }
}
