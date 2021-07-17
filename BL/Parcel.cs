using DL;

namespace BL
{
    public class Parcel
    {
        public string _find;

        public bool DoesThisParcelIDExists()
        {
            MyDB db = new MyDB();
            return db.SearchParcelID(_find);
        }
    }
}