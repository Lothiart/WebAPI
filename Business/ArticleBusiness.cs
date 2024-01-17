using Business.Contracts;
using Entities;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ArticleBusiness : IArticleBusiness
    {
        
            public IArticleRepository _ArticleRepository;
            public ArticleBusiness(IArticleRepository ArticleRepository)
            {
                _ArticleRepository = ArticleRepository;

            }
            public async Task<List<Article>> GetArticles()
            {
                return await _ArticleRepository.GetArticles();
            }
            public async Task<bool> Create(Article Article)
            {
                return await _ArticleRepository.Create(Article);
            }
            public async Task<Article> Read(int id)
            {
                return await _ArticleRepository.Read(id);
            }
            public async Task<bool> Update(Article Article)
            {
                return await _ArticleRepository.Update(Article);
            }
            public async Task<bool> Delete(int id)
            {
                return await _ArticleRepository.Delete(id);
            }
            public async Task<List<Article>> Search(string str)
            {
                return await _ArticleRepository.Search(str);
            }
        }
    }

