using System.Collections;
using Pure.Chart.RelationalModel.Abstractions;
using Pure.Chart.RichRelationalModel.Abstractions;
using Pure.HashCodes;
using Pure.HashCodes.Abstractions;

namespace Pure.Chart.RichRelationalModel.HashCodes;

public sealed record ChartTypeRichRelationalModelHash : IDeterminedHash
{
    private static readonly byte[] TypePrefix =
    [
        117,
        93,
        157,
        1,
        233,
        75,
        27,
        125,
        141,
        146,
        190,
        240,
        18,
        204,
        68,
        87,
    ];

    private readonly IDeterminedHash _idHash;

    private readonly IDeterminedHash _nameHash;

    public ChartTypeRichRelationalModelHash(IChartTypeRichRelationalModel model)
        : this(
            new DeterminedHash(model.Id),
            new DeterminedHash((model as IChartTypeRelationalModel).Name)
        )
    { }

    public ChartTypeRichRelationalModelHash(
        IDeterminedHash idHash,
        IDeterminedHash nameHash
    )
    {
        _idHash = idHash;
        _nameHash = nameHash;
    }

    public IEnumerator<byte> GetEnumerator()
    {
        return new DeterminedHash(
            TypePrefix.Concat(_idHash).Concat(_nameHash)
        ).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
