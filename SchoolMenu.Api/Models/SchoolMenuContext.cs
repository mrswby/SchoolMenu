using Microsoft.EntityFrameworkCore;

namespace SchoolMenu.Api.Models;

public class SchoolMenuContext : DbContext
{
	public SchoolMenuContext(DbContextOptions<SchoolMenuContext> options)
		: base(options)
	{
	}

	public DbSet<Ingredient> Ingredients => Set<Ingredient>();

	public DbSet<MenuItem> MenuItems => Set<MenuItem>();

	public DbSet<MenuItemIngredient> MenuItemIngredients => Set<MenuItemIngredient>();
}