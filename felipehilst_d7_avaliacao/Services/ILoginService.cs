namespace felipehilst_d7_avaliacao.Services
{
    public interface ILoginService
    {
        public bool IsValidUser(string email, string psw);
    }
}
