namespace SchoolMenu.Api.Models;

public class MenuItem
{
	public int Id { get; set; }
	public string Name { get; set; }
	public ICollection<Ingredient> Ingredients { get; set; }
}
