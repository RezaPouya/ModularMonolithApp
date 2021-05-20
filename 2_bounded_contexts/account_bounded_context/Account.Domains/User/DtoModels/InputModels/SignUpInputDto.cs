namespace Account.Domains.User.DtoModels.InputModels
{
    public class SignUpInputDto
    {
        public string UserName { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
    }
}