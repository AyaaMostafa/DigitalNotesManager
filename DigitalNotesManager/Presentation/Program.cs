using DigitalNotesManager.Services.Interfaces;
using DigitalNotesManager.Services.ServiceImp;

namespace Presentation
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            IUserService userService = new UserService();
            INotesServices notesService = new NotesServices();
            ICategoryService categoryService = new CategoryService();

            Application.Run(new LoginForm(userService, notesService, categoryService));
        }
    }
}