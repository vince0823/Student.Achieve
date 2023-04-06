namespace Student.Achieve.WebApi.Services
{
    public interface ICookieService
    {
        void SetCookie(string key, string value);

        void SetCookie(string key, string value, int expiresTime);

        string GetCookie(string key);

        void DeleteCookie(string key);
    }
}
