namespace WebBackendService.Models.USER
{
    public class ChangePasswordModel : User
    {
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
    }
}
