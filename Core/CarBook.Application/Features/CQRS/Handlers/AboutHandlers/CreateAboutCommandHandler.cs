﻿using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class CreateAboutCommandHandler
    {
        private readonly IRepository<About> _repository;

        public CreateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task Handler(CreateAboutCommand command)
        {
            await _repository.CreateAsync(new About
            {
                Title = command.Title,
                Description = command.Description,
                ImageUrl = command.ImageUrl
            });
        }
    }
}
