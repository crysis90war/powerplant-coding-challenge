namespace PowerplanBLL.Entities;

public class ResultEntity
{
    public string Name { get; set; }
    public int P { get; set; }

    public ResultEntity() {}

    public ResultEntity(string name, int p)
    {
        Name = name;
        P = p;
    }
}
