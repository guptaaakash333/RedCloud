using RedCloud.Application.Models.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Contract.Infrastructure
{
   public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}

