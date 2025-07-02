using CarBook.Application.Features.Mediator.Queries.AppUserQueries;
using CarBook.Application.Features.Mediator.Results.AppUserResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.AppUserInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.AppUserHandlers
{
	public class GetCheckAppUserQueryHandler : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResult>
	{
		private readonly IRepository<AppUser> _appUserrepository;
		private readonly IRepository<AppRole> _appRolerepository;

		public GetCheckAppUserQueryHandler(IRepository<AppUser> appUserrepository, IRepository<AppRole> appRolerepository)
		{
			_appUserrepository = appUserrepository;
			_appRolerepository = appRolerepository;
		}

		public async Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
		{
			var values = new GetCheckAppUserQueryResult();
			var user = await _appUserrepository.GetByFilterAsync(x => x.Username == request.Username && x.Password == request.Password);
			if (user == null)
			{
				values.IsExist = false;
			}
			else
			{
				values.IsExist = true;
				values.Username = user.Username;
				values.Role = (await _appRolerepository.GetByFilterAsync(x => x.AppRoleId == user.AppRoleId)).AppRoleName;
			}
			return values;
		}
	}
}
