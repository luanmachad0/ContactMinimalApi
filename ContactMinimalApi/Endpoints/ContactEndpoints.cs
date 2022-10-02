using ContactMinimalApi.Data.Repositories.Interfaces;
using ContactMinimalApi.Models;

namespace ContactMinimalApi.Endpoints
{
    public static class ContactEndpoints
    {
        public static void MapContactEndpoints(this WebApplication app)
        {
            app.MapGet("/contacts",
                async (IContactRepository contactRepository) => await contactRepository.GetAll())
                .WithName("GetContacts");

            app.MapGet("/contacts/{id}",
                async (int id, IContactRepository contactRepository) => await contactRepository.Get(id)
                    is List<Contact> contacts
                        ? Results.Ok(contacts)
                        : Results.NotFound())
                .WithName("GetContactById")
                .Produces<Contact>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound);

            app.MapPost("/contacts", async (Contact contact, IContactRepository contactRepository) =>
            {
                if (contact != null)
                {
                    await contactRepository.Create(contact);

                    return Results.Created($"/contacts/{contact.Id}", contact);
                }
                else
                {
                    return Results.BadRequest("Request inválido");
                }
            })
                .WithName("CreateContact")
                .ProducesValidationProblem()
                .Produces<Contact>(StatusCodes.Status201Created);

            app.MapPut("/contacts", async (Contact contact, IContactRepository contactRepository) =>
            {
                try
                {
                    await contactRepository.Update(contact);
                    return Results.Accepted($"/contacts/{contact.Id}", contact);
                }
                catch (Exception ex)
                {
                    return Results.NotFound(ex.Message);
                }
            })
                .WithName("UpdateContact")
                .ProducesValidationProblem()
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound);

            app.MapDelete("/contacts/{id}", async (int id, IContactRepository contactRepository) =>
            {
                try
                {
                    await contactRepository.Delete(id);
                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    return Results.NotFound(ex.Message);
                }
            })
            .WithName("DeleteContact")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);
        }
    }
}
