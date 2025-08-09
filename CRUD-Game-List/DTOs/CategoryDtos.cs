namespace CRUD_Game_List.DTOs
{
	public record CategoryCreateDto(string Name);

	public record CategoryUpdateDto(int Id, string Name);

	public record CategoryDto(int Id, string Name);
}
