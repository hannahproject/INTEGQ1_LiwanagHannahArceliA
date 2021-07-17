using DL;

namespace BL
{
    public class User
    {
        public string _username {get;set;}
        public string _password {get;set;}

        public bool IsUsernameAndPasswordCorrect()
        {
            MyDB db = new MyDB();
            return db.LoginValidation(_username, _password);
        }
    }
}