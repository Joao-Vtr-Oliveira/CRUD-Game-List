namespace CRUD_Game_List.DTOs
{
	public record CategoryCreateDto(string Name);

	public record CategoryUpdateDto(long Id, string Name);

	public record CategoryDto(long Id, string Name);
}
