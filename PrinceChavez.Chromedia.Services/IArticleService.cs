using PrinceChavez.Chromedia.Models;
using System;
using System.Threading.Tasks;

namespace PrinceChavez.Chromedia.Services
{
    public interface IArticleService
    {
        Task<ArticleServiceResult> GetData(int page, int limit);
    }
}
