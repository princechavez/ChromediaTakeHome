using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrinceChavez.Chromedia.Services;
using PrinceChavez.Chromedia.Models;
using System.Threading.Tasks;

namespace PrinceChavez.Chromedia.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }


        [HttpGet("top")]
        public async Task<IActionResult> Top(int page = 1, int limit = 1)
        {
            return Ok(await _articleService.GetData(page, limit));
        }

    }
}
