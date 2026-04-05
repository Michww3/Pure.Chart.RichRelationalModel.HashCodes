using System.Collections;
using Pure.Chart.RelationalModel.Abstractions;
using Pure.Chart.RichRelationalModel.Abstractions;
using Pure.HashCodes;
using Pure.HashCodes.Abstractions;

namespace Pure.Chart.RichRelationalModel.HashCodes;

public sealed record SeriesRichRelationalModelHash : IDeterminedHash
{
    private static readonly byte[] TypePrefix =
    [
        117,
        93,
        157,
        1,
        141,
        123,
        64,
        127,
        167,
        177,
        88,
        45,
        230,
        12,
        33,
        63,
    ];

    private readonly IDeterminedHash _idHash;

    private readonly IDeterminedHash _chartIdHash;

    private readonly IDeterminedHash _legendHash;

    private readonly IDeterminedHash _xAxisSourceHash;

    private readonly IDeterminedHash _yAxisSourceHash;

    public SeriesRichRelationalModelHash(ISeriesRichRelationalModel model)
        : this(
            new DeterminedHash(model.Id),
            new DeterminedHash(model.ChartId),
            new DeterminedHash((model as ISeriesRelationalModel).Legend),
            new DeterminedHash((model as ISeriesRelationalModel).XAxisSource),
            new DeterminedHash((model as ISeriesRelationalModel).YAxisSource)
        )
    { }

    public SeriesRichRelationalModelHash(
        IDeterminedHash idHash,
        IDeterminedHash chartIdHash,
        IDeterminedHash legendHash,
        IDeterminedHash xAxisSourceHash,
        IDeterminedHash yAxisSourceHash
    )
    {
        _idHash = idHash;
        _chartIdHash = chartIdHash;
        _legendHash = legendHash;
        _xAxisSourceHash = xAxisSourceHash;
        _yAxisSourceHash = yAxisSourceHash;
    }

    public IEnumerator<byte> GetEnumerator()
    {
        return new DeterminedHash(
            TypePrefix
                .Concat(_idHash)
                .Concat(_chartIdHash)
                .Concat(_legendHash)
                .Concat(_xAxisSourceHash)
                .Concat(_yAxisSourceHash)
        ).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
