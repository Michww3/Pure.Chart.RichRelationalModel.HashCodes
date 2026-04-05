using System.Collections;
using Pure.Chart.RelationalModel.Abstractions;
using Pure.Chart.RichRelationalModel.Abstractions;
using Pure.HashCodes;
using Pure.HashCodes.Abstractions;

namespace Pure.Chart.RichRelationalModel.HashCodes;

public sealed record AxisRichRelationalModelHash : IDeterminedHash
{
    private static readonly byte[] TypePrefix =
    [
        116,
        93,
        157,
        1,
        112,
        81,
        34,
        125,
        166,
        203,
        161,
        255,
        81,
        169,
        177,
        171,
    ];

    private readonly IDeterminedHash _idHash;

    private readonly IDeterminedHash _chartIdHash;

    private readonly IDeterminedHash _legendHash;

    public AxisRichRelationalModelHash(IAxisRichRelationalModel model)
        : this(
            new DeterminedHash(model.Id),
            new DeterminedHash(model.ChartId),
            new DeterminedHash((model as IAxisRelationalModel).Legend)
        )
    { }

    public AxisRichRelationalModelHash(
        IDeterminedHash idHash,
        IDeterminedHash chartIdHash,
        IDeterminedHash legendHash
    )
    {
        _idHash = idHash;
        _chartIdHash = chartIdHash;
        _legendHash = legendHash;
    }

    public IEnumerator<byte> GetEnumerator()
    {
        return new DeterminedHash(
            TypePrefix.Concat(_idHash).Concat(_chartIdHash).Concat(_legendHash)
        ).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
