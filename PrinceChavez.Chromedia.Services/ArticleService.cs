using Newtonsoft.Json;
using PrinceChavez.Chromedia.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace PrinceChavez.Chromedia.Services
{
    public class ArticleService : IArticleService
    {
        public async Task<ArticleServiceResult> GetData(int page, int limit)
        {
            using (var client = new HttpClient())
            {
                var strResponse = await client.GetStringAsync($"https://jsonmock.hackerrank.com/api/articles?page={page}");

                if (String.IsNullOrWhiteSpace(strResponse))
                {
                    return new ArticleServiceResult
                    {
                        Articles = new List<FormattedArticle>(),
                        Success = false,
                        Message = "Null API response"
                    };
                }

                var response = JsonConvert.DeserializeObject<ExternalApiResponse>(strResponse);

                if (page <1 || page > response.Total_Pages)
                {
                    return new ArticleServiceResult
                    {
                        Articles = new List<FormattedArticle>(),
                        Success = false,
                        Message = $"Page requested is out of bounds; Should be between 1 - {response.Total_Pages}"
                    };
                }

                var formattedArticles = response
                                            .Data
                                                .Select(article =>
                                                        new FormattedArticle {
                                                            Title = article.Title ?? article.Story_Title,
                                                            Comments = article.Num_Comments ?? 0
                                                        }
                                                );

                var validArticles = formattedArticles.Where(article => !String.IsNullOrWhiteSpace(article.Title));

                var sortedArticles = validArticles.OrderByDescending(a => a.Comments).ThenBy(a => a.Title);

                return new ArticleServiceResult
                {
                    Success = true,
                    Articles = sortedArticles.Take(limit).ToList(),
                };

            }
        }
    }
}
