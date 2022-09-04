namespace Customer.BAL.Interfaces
{
    public interface IVerifyEmailAppService
    {
        bool IsValidEmail(string email);
    }
}
