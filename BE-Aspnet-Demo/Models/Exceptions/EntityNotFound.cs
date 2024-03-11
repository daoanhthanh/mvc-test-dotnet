namespace be_aspnet_demo.models.exceptions;

public class EntityNotFound : BaseException
{
    public EntityNotFound(string message) : base("ENTITY_NOT_FOUND", message, StatusCodes.Status404NotFound)
    {
    }
}