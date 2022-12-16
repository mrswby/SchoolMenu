using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolMenu.Api.Models;

namespace SchoolMenu.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MenuItemController : ControllerBase
	{
		private readonly SchoolMenuContext _context;

		public MenuItemController(SchoolMenuContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<MenuItem>>> GetMenuItems()
		{
			if (_context.MenuItems == null)
			{
				return NotFound();
			}
			return await _context.MenuItems.ToListAsync();
		}


		[HttpGet("{id}")]
		public async Task<ActionResult<MenuItem>> GetMenuItem(int id)
		{
			if (_context.MenuItems == null)
			{
				return NotFound();
			}
			var menuItem = await _context.MenuItems.FindAsync(id);

			if (menuItem == null)
			{
				return NotFound();
			}

			return menuItem;
		}


		[HttpPut("{id}")]
		public async Task<IActionResult> PutMenuItem(int id, MenuItem menuItem)
		{
			if (id != menuItem.Id)
			{
				return BadRequest();
			}

			_context.Entry(menuItem).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!MenuItemExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}


		[HttpPost]
		public async Task<ActionResult<MenuItem>> PostMenuItem(MenuItem menuItem)
		{
			if (_context.MenuItems == null)
			{
				return Problem("Entity set 'SchoolMenuContext.MenuItems'  is null.");
			}
			_context.MenuItems.Add(menuItem);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetMenuItem", new { id = menuItem.Id }, menuItem);
		}


		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteMenuItem(int id)
		{
			if (_context.MenuItems == null)
			{
				return NotFound();
			}
			var menuItem = await _context.MenuItems.FindAsync(id);
			if (menuItem == null)
			{
				return NotFound();
			}

			_context.MenuItems.Remove(menuItem);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool MenuItemExists(int id)
		{
			return (_context.MenuItems?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
