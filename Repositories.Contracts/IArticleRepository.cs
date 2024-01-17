
using Entities;

namespace Repositories.Contracts
{
    public interface IArticleRepository
    {
        Task<List<Article>> GetArticles();
        Task<bool> Create(Article Article);
        Task<Article> Read(int id);
        Task<bool> Update(Article Article);
        Task<bool> Delete(int id);
        Task<List<Article>> Search(string str);
    }
}
