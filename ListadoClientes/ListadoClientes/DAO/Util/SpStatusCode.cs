namespace ListadoClientes.DAO.Util;
public sealed class SpStatusCode
{
    public static readonly SpStatusCode SUCCESS = new SpStatusCode("0000");
    public static readonly SpStatusCode FAILED = new SpStatusCode("0001");

    private static readonly List<SpStatusCode> _codes = new List<SpStatusCode> { SUCCESS, FAILED };

    public string Code { get; }

    private SpStatusCode(string code)
    {
        Code = code;
    }

    public static SpStatusCode FindByCode(string code)
    {
        foreach (var item in _codes)
        {
            if (item.Code.Equals(code))
            {
                return item;
            }
        }
        throw new Exception($"Estado {code} no definido");
    }

    public override string ToString() => Code;
}
