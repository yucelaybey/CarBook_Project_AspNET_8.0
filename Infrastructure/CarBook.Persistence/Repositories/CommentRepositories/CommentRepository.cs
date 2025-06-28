using CarBook.Application.Interfaces.CommentInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CommentRepositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly CarBookContext _carBookContext;

        public CommentRepository(CarBookContext carBookContext)
        {
            _carBookContext = carBookContext;
        }

        public async Task<List<Comment>> GetCommentsByBlogId(int id)
        {
            return await _carBookContext.Comments.Where(y => y.BlogID == id).ToListAsync();
        }

        public int GetCountCommentsByBlog(int id)
        {
            return _carBookContext.Comments.Count(x => x.BlogID == id);
        }
    }
}
