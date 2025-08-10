namespace CRUD_Game_List.DTOs
{
	public record CategoryCreateDto(string Name);

	public record CategoryUpdateDto(string Name);

	public record CategoryDto(long Id, string Name);
}
