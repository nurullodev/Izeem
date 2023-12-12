using Izeem.Service.DTOs;

namespace Izeem.Service.Interfaces.Notifications
{
    public interface IEmailsender
    {
        public Task<bool> SenderAsync(EmailSenderDto emailMessage);
    }
}
