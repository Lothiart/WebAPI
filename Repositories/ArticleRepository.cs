using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private Context _context;
        public ArticleRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<Article>> GetArticles()
        {
            return await _context.Articles.ToListAsync();
        }
        public async Task<bool> Create(Article Article)
        {
            try
            {
                _context.Articles.Add(Article);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<Article> Read(int id)
        {
            return await _context.Articles.FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<bool> Update(Article Article)
        {
            try
            {
                var ArticleToEdit = await _context.Articles.FirstOrDefaultAsync(c => c.Id == Article.Id);
                ArticleToEdit.Contenu = Article.Contenu;
                ArticleToEdit.ClientId = Article.ClientId;

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                _context.Articles.Remove(await _context.Articles.FirstOrDefaultAsync(c => c.Id == id));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<List<Article>> Search(string str)
        {
            return await _context.Articles.Where(c => (c.Id.ToString()).Contains(str) || c.Contenu.Contains(str) || (c.ClientId.ToString()).Contains(str)).ToListAsync();
        }
    }
}
