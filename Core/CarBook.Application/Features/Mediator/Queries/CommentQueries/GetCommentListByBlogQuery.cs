﻿using CarBook.Application.Features.Mediator.Results.CommentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.CommentQueries
{
    public class GetCommentListByBlogQuery:IRequest<List<GetCommentListByBlogQueryResult>>
    {
        public int Id { get; set; }

        public GetCommentListByBlogQuery(int id)
        {
            Id = id;
        }
    }
}
