using Microsoft.EntityFrameworkCore;
using ToDoAPI.Data;
using ToDoAPI.Models;

var builder = WebApplication.CreateBuilder(args);

 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("ToDoAPI"));


var app = builder.Build();
 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/todo", async(AppDbContext context) => {
    var toDoItems = await context.ToDoItems.ToListAsync();

    return Results.Ok(toDoItems);
});

app.MapPost("api/todo" , async(AppDbContext context, ToDoItem toDoItem) => {

    await context.ToDoItems.AddAsync(toDoItem);
    await context.SaveChangesAsync();

    return Results.Created($"api/todo/{toDoItem.Id}", toDoItem);

});


app.Run();

 