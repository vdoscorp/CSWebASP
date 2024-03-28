using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebRazorEFC;

namespace WebRazorEFC.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly WebRazorEFC.ApplicationContext _context;

        public IndexModel(WebRazorEFC.ApplicationContext context)
        {
            _context = context;
        }

        public IList<Course> Course { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Course = await _context.Courses.ToListAsync();
        }
    }
}
