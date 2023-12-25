using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using R54_M11_Class_01_Work_02.Models;
using R54_M11_Class_01_Work_02.ViewModels;

namespace R54_M11_Class_01_Work_02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IWebHostEnvironment env;
        private readonly ProductDbContext _context;
        public ImagesController(IWebHostEnvironment env, ProductDbContext _context)
        {
            this.env = env;
            this._context = _context;
        }
        [HttpGet]
        public ActionResult<string[]> Get()
        {
            return new string[] { "Ab", "Bb" };
        }
        [HttpPost("Upload/{id}")]
        public async  Task<ActionResult<UploadResponse>> Upload(int id, IFormFile file)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
            if (product == null) return NotFound();
            string ext = Path.GetExtension(file.FileName);
            string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ext;
            string savePath = Path.Combine(this.env.WebRootPath, "Pictures", fileName);
            if (!Directory.Exists(Path.Combine(this.env.WebRootPath, "Pictures")))
            {
                Directory.CreateDirectory(Path.Combine(this.env.WebRootPath, "Pictures"));
            }
            FileStream fs = new FileStream(savePath, FileMode.Create);
            await file.CopyToAsync(fs);
            fs.Close();
            product.Picture = fileName;
            await _context.SaveChangesAsync();
            return new UploadResponse { FileName=fileName};
            
        }
    }
}
