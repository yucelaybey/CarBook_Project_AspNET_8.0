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
    public class GetCommentListByBlogQueryHandler : IRequestHandler<GetCommentListByBlogQuery, List<GetCommentListByBlogQueryResult>>
    {
        private readonly ICommentRepository _commentRepository;

        public GetCommentListByBlogQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<List<GetCommentListByBlogQueryResult>> Handle(GetCommentListByBlogQuery request, CancellationToken cancellationToken)
        {
            var values =await _commentRepository.GetCommentsByBlogId(request.Id);
            return values.Select(x => new GetCommentListByBlogQueryResult
            {
                BlogID = x.BlogID,
                CommentID = x.CommentID,
                CreatedDate = x.CreatedDate,
                Description = x.Description,
                Name = x.Name
            }).ToList();
        }
    }
}
