﻿using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;

namespace CarBook.Persistance.Repositories.CommentRepositories
{
    public class CommentRepository<T> : IGenericRepository<Comment>
    {
        private readonly CarBookContext _context;

        public CommentRepository(CarBookContext context)
        {
            _context = context;
        }

        public void Create(Comment entity)
        {
            _context.Comments.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var value = _context.Comments.Find(id);
            _context.Comments.Remove(value);
            _context.SaveChanges();
        }

        public List<Comment> GetAll()
        {
            return _context.Comments.Select(x => new Comment
            {
                CommentId = x.CommentId,
                BlogId = x.BlogId,
                CreatedDate = x.CreatedDate,
                Description = x.Description,
                Name = x.Name,
            }).ToList();
        }

        public Comment GetById(int id)
        {
            return _context.Comments.Find(id);
        }

        public List<Comment> GetCommentsByBlogId(int id)
        {
            return _context.Set<Comment>().Where(x => x.BlogId == id).ToList();
        }

        public void Update(Comment entity)
        {
            _context.Comments.Update(entity);
            _context.SaveChanges();
        }

        public int GetCountCommentByBlogId(int id)
        {
            return _context.Comments.Where(x => x.BlogId == id).Count();
        }
    }
}
