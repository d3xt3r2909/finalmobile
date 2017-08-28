namespace ESBX_db.Helper
{
    interface IAccount
    {
        string LozinkaSalt { get; set; }

        string LozinkaHash { get; set; }

        string Email { get; set; }
    }
}
