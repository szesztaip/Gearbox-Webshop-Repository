using Gearbox_Back_End.Dto;
namespace Gearbox_Back_End.Service.IEmailServices
{
    public interface IEmailService
    {
        void SendEmail(EmailDto email);
    }
}
