// See https://aka.ms/new-console-template for more information
using MovieDatabase.Data;
using MovieDatabase.Menus;

using DataContext _context = new DataContext();    
MovieMenu movieMenu = new MovieMenu(_context);

movieMenu.UserAddMovie();
