namespace Powerplant.Models
{
    public class ResultModel
    {
        public string Name { get; set; }
        public int P { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ResultModel() { }

        public ResultModel(string name, int p)
        {
            Name = name;
            P = p;
        }
    }
}
