using AutoMapper.Internal;
using RedCloud.Models.Email;

namespace RedCloud.Interfaces
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
