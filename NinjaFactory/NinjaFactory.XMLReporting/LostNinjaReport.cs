using NinjaFactory.DataBase;

namespace NinjaFactory.XMLReporting
{
    public class LostNinjaReport
    {
        public Client Client { get; set; }

        public Job Job { get; set; }

        public Ninja Ninja { get; set; }
    }
}