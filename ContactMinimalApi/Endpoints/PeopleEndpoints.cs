using ContactMinimalApi.Data.Repositories.Interfaces;
using ContactMinimalApi.Models;

namespace ContactMinimalApi.Endpoints
{
    public static class PeopleEndpoints
    {
        public static void MapPeopleEndpoints(this WebApplication app)
        {
            app.MapGet("/peoples", 
                async (IPeopleRepository peopleRepository) => await peopleRepository.GetAll())
                .WithName("GetPeoples");

            app.MapGet("/peoples/{id}", 
                async (int id, IPeopleRepository peopleRepository) => await peopleRepository.Get(id)
                    is People people
                        ? Results.Ok(people)
                        : Results.NotFound())
                .WithName("GetPeopleById")
                .Produces<People>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound);

            app.MapPost("/peoples", async (People people, IPeopleRepository peopleRepository) =>
            {
                if (people != null)
                {
                    await peopleRepository.Create(people);

                    return Results.Created($"/peoples/{people.Id}", people);
                }
                else
                {
                    return Results.BadRequest("Request inválido");
                }
            })
                .WithName("CreatePeople")
                .ProducesValidationProblem()
                .Produces<People>(StatusCodes.Status201Created);

            app.MapPut("/peoples", async (People people, IPeopleRepository peopleRepository) =>
            {
                try
                {
                    await peopleRepository.Update(people);
                    return Results.Accepted($"/peoples/{people.Id}", people);
                }
                catch (Exception ex)
                {
                    return Results.NotFound(ex.Message);
                }
            })
                .WithName("UpdatePeople")
                .ProducesValidationProblem()
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound);

            app.MapDelete("/peoples/{id}", async (int id, IPeopleRepository peopleRepository) =>
            {
                try
                {
                    await peopleRepository.Delete(id);
                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    return Results.NotFound(ex.Message);
                }
            })
            .WithName("DeletePeople")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);
        }
    }
}
