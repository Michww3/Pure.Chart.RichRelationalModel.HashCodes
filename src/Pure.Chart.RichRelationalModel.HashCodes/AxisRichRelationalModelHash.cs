using System.Collections;
using Pure.Chart.RelationalModel.Abstractions;
using Pure.Chart.RichRelationalModel.Abstractions;
using Pure.HashCodes;
using Pure.HashCodes.Abstractions;
using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;

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
            model.Id,
            model.ChartId,
            (model as IAxisRelationalModel).Legend)
    { }

    public AxisRichRelationalModelHash(
        IGuid id,
        IGuid chartId,
        IString legend)
        : this(
            new DeterminedHash(id),
            chartId,
            legend)
    { }

    public AxisRichRelationalModelHash(
        IDeterminedHash idHash,
        IGuid chartId,
        IString legend)
        : this(
            idHash,
            new DeterminedHash(chartId),
            legend)
    { }

    public AxisRichRelationalModelHash(
        IGuid id,
        IDeterminedHash chartIdHash,
        IString legend)
        : this(
            new DeterminedHash(id),
            chartIdHash,
            legend)
    { }

    public AxisRichRelationalModelHash(
        IGuid id,
        IGuid chartId,
        IDeterminedHash legendHash)
        : this(
            new DeterminedHash(id),
            chartId,
            legendHash)
    { }

    public AxisRichRelationalModelHash(
        IDeterminedHash idHash,
        IDeterminedHash chartIdHash,
        IString legend)
        : this(
            idHash,
            chartIdHash,
            new DeterminedHash(legend))
    { }

    public AxisRichRelationalModelHash(
        IDeterminedHash idHash,
        IGuid chartId,
        IDeterminedHash legendHash)
        : this(
            idHash,
            new DeterminedHash(chartId),
            legendHash)
    { }

    public AxisRichRelationalModelHash(
        IGuid id,
        IDeterminedHash chartIdHash,
        IDeterminedHash legendHash)
        : this(
            new DeterminedHash(id),
            chartIdHash,
            legendHash)
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
