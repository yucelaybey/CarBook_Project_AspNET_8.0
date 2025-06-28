using CarBook.Application.Features.Mediator.Queries.CommentQueries;
using CarBook.Application.Features.Mediator.Results.CommentResults;
using CarBook.Application.Interfaces.CommentInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class GetCountCommentsByBlogQueryHandler : IRequestHandler<GetCountCommentsByBlogQuery, GetCountCommentsByBlogQueryResult>
    {
        private readonly ICommentRepository _repository;

        public GetCountCommentsByBlogQueryHandler(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCountCommentsByBlogQueryResult> Handle(GetCountCommentsByBlogQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCountCommentsByBlog(request.Id);
            return new GetCountCommentsByBlogQueryResult
            {
                CountCommentsByBlog = value
            };
        }
    }
}
