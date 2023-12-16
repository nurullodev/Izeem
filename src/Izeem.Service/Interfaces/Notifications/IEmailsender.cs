using Izeem.Service.DTOs.Register;

namespace Izeem.Service.Interfaces.Notifications
{
    public interface IEmailsender
    {
        public Task<bool> SenderAsync(EmailSenderDto emailMessage);
    }
}
