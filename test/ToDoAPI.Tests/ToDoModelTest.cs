using ToDoAPI.Models;

namespace ToDoAPI.Tests;

public class ToToModelTests
{
    [Fact]
    public void CanChangeName()
    {
        //Arrenge
        var testToDo = new ToDoItem
        {
            Task = "Complete unit tests"
        };

        //Act
        testToDo.Task = "Complete Azure Pipeline";

        //Assert
        Assert.Equal("Complete Azure Pipeline", testToDo.Task);
    }
}