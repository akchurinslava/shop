using System;
using Shop.Core.Dto.EmailDtos;

namespace Shop.Core.ServiceInterface
{
	public interface IEmailServices
	{
		void SendEmail(EmailDto request);
	}
}

