using AspNetCoreHero.ToastNotification.Abstractions;
using WebAdmin.Data;
using WebAdmin.Services;

namespace WebAdmin.Models
{
    public class SerieVentas
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public SerieVentas(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        public SerieVentas(string name, bool sliced)
        {
            this.name = name;
            this.sliced = sliced;
            this.sliced = sliced;
            this.selected = selected;
        }

        public string name { get; set; }
        public double y { get; set; }
        public bool sliced { get; set; }
        public bool selected { get; set; }

        public SerieVentas()
        {
        }
    }
}