namespace CRUD_Game_List.Domain.Exceptions
{
	public abstract class BaseDomainException : Exception
	{
		protected BaseDomainException(string message) : base(message) { }
	}
}
