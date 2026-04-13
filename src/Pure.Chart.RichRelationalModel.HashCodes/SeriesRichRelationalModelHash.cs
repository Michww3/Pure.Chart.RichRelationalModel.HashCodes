using System.Collections;
using Pure.Chart.RelationalModel.Abstractions;
using Pure.Chart.RichRelationalModel.Abstractions;
using Pure.HashCodes;
using Pure.HashCodes.Abstractions;
using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;

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
            model.Id,
            model.ChartId,
            (model as ISeriesRelationalModel).Legend,
            (model as ISeriesRelationalModel).XAxisSource,
            (model as ISeriesRelationalModel).YAxisSource)
    { }

    public SeriesRichRelationalModelHash(
        IGuid id,
        IGuid chartId,
        IString legend,
        IString xAxisSource,
        IString yAxisSource)
        : this(
            new DeterminedHash(id),
            chartId,
            legend,
            xAxisSource,
            yAxisSource)
    { }

    public SeriesRichRelationalModelHash(
        IDeterminedHash idHash,
        IGuid chartId,
        IString legend,
        IString xAxisSource,
        IString yAxisSource)
        : this(
            idHash,
            new DeterminedHash(chartId),
            legend,
            xAxisSource,
            yAxisSource)
    { }

    public SeriesRichRelationalModelHash(
        IGuid id,
        IDeterminedHash chartIdHash,
        IString legend,
        IString xAxisSource,
        IString yAxisSource)
        : this(
            new DeterminedHash(id),
            chartIdHash,
            legend,
            xAxisSource,
            yAxisSource)
    { }

    public SeriesRichRelationalModelHash(
        IGuid id,
        IGuid chartId,
        IString legend,
        IString xAxisSource,
        IDeterminedHash yAxisSourceHash)
        : this(
            new DeterminedHash(id),
            chartId,
            legend,
            xAxisSource,
            yAxisSourceHash)
    { }

    public SeriesRichRelationalModelHash(
        IGuid id,
        IGuid chartId,
        IDeterminedHash legendHash,
        IString xAxisSource,
        IString yAxisSource)
        : this(
            new DeterminedHash(id),
            chartId,
            legendHash,
            xAxisSource,
            yAxisSource)
    { }

    public SeriesRichRelationalModelHash(
        IGuid id,
        IGuid chartId,
        IString legend,
        IDeterminedHash xAxisSourceHash,
        IString yAxisSource)
        : this(
            new DeterminedHash(id),
            chartId,
            legend,
            xAxisSourceHash,
            yAxisSource)
    { }

    public SeriesRichRelationalModelHash(
        IGuid id,
        IGuid chartId,
        IDeterminedHash legendHash,
        IString xAxisSource,
        IDeterminedHash yAxisSourceHash)
        : this(
            new DeterminedHash(id),
            chartId,
            legendHash,
            xAxisSource,
            yAxisSourceHash)
    { }

    public SeriesRichRelationalModelHash(
        IGuid id,
        IGuid chartId,
        IDeterminedHash legendHash,
        IDeterminedHash xAxisSourceHash,
        IString yAxisSource)
        : this(
            new DeterminedHash(id),
            chartId,
            legendHash,
            xAxisSourceHash,
            yAxisSource)
    { }

    public SeriesRichRelationalModelHash(
        IGuid id,
        IDeterminedHash chartIdHash,
        IString legend,
        IDeterminedHash xAxisSourceHash,
        IString yAxisSource)
        : this(
            new DeterminedHash(id),
            chartIdHash,
            legend,
            xAxisSourceHash,
            yAxisSource)
    { }

    public SeriesRichRelationalModelHash(
        IDeterminedHash idHash,
        IGuid chartId,
        IString legend,
        IDeterminedHash xAxisSourceHash,
        IString yAxisSource)
        : this(
            idHash,
            new DeterminedHash(chartId),
            legend,
            xAxisSourceHash,
            yAxisSource)
    { }

    public SeriesRichRelationalModelHash(
        IGuid id,
        IGuid chartId,
        IString legend,
        IDeterminedHash xAxisSourceHash,
        IDeterminedHash yAxisSourceHash)
        : this(
            new DeterminedHash(id),
            chartId,
            legend,
            xAxisSourceHash,
            yAxisSourceHash)
    { }

    public SeriesRichRelationalModelHash(
        IGuid id,
        IDeterminedHash chartIdHash,
        IDeterminedHash legendHash,
        IString xAxisSource,
        IString yAxisSource)
        : this(
            new DeterminedHash(id),
            chartIdHash,
            legendHash,
            xAxisSource,
            yAxisSource)
    { }

    public SeriesRichRelationalModelHash(
        IDeterminedHash idHash,
        IGuid chartId,
        IDeterminedHash legendHash,
        IString xAxisSource,
        IString yAxisSource)
        : this(
            idHash,
            new DeterminedHash(chartId),
            legendHash,
            xAxisSource,
            yAxisSource)
    { }

    public SeriesRichRelationalModelHash(
        IDeterminedHash idHash,
        IDeterminedHash chartIdHash,
        IString legend,
        IString xAxisSource,
        IString yAxisSource)
        : this(
            idHash,
            chartIdHash,
            new DeterminedHash(legend),
            xAxisSource,
            yAxisSource)
    { }

    public SeriesRichRelationalModelHash(
        IDeterminedHash idHash,
        IGuid chartId,
        IString legend,
        IString xAxisSource,
        IDeterminedHash yAxisSourceHash)
        : this(
            idHash,
            new DeterminedHash(chartId),
            legend,
            xAxisSource,
            yAxisSourceHash)
    { }

    public SeriesRichRelationalModelHash(
        IGuid id,
        IDeterminedHash chartIdHash,
        IString legend,
        IString xAxisSource,
        IDeterminedHash yAxisSourceHash)
        : this(
            new DeterminedHash(id),
            chartIdHash,
            legend,
            xAxisSource,
            yAxisSourceHash)
    { }

    public SeriesRichRelationalModelHash(
        IGuid id,
        IGuid chartId,
        IDeterminedHash legendHash,
        IDeterminedHash xAxisSourceHash,
        IDeterminedHash yAxisSourceHash)
        : this(
            new DeterminedHash(id),
            chartId,
            legendHash,
            xAxisSourceHash,
            yAxisSourceHash)
    { }

    public SeriesRichRelationalModelHash(
        IGuid id,
        IDeterminedHash chartIdHash,
        IDeterminedHash legendHash,
        IString xAxisSource,
        IDeterminedHash yAxisSourceHash)
        : this(
            new DeterminedHash(id),
            chartIdHash,
            legendHash,
            xAxisSource,
            yAxisSourceHash)
    { }

    public SeriesRichRelationalModelHash(
        IDeterminedHash idHash,
        IGuid chartId,
        IDeterminedHash legendHash,
        IString xAxisSource,
        IDeterminedHash yAxisSourceHash)
        : this(
            idHash,
            new DeterminedHash(chartId),
            legendHash,
            xAxisSource,
            yAxisSourceHash)
    { }

    public SeriesRichRelationalModelHash(
        IDeterminedHash idHash,
        IGuid chartId,
        IDeterminedHash legendHash,
        IDeterminedHash xAxisSourceHash,
        IString yAxisSource)
        : this(
            idHash,
            new DeterminedHash(chartId),
            legendHash,
            xAxisSourceHash,
            yAxisSource)
    { }

    public SeriesRichRelationalModelHash(
        IGuid id,
        IDeterminedHash chartIdHash,
        IDeterminedHash legendHash,
        IDeterminedHash xAxisSourceHash,
        IString yAxisSource)
        : this(
            new DeterminedHash(id),
            chartIdHash,
            legendHash,
            xAxisSourceHash,
            yAxisSource)
    { }

    public SeriesRichRelationalModelHash(
        IDeterminedHash idHash,
        IGuid chartId,
        IString legend,
        IDeterminedHash xAxisSourceHash,
        IDeterminedHash yAxisSourceHash)
        : this(
            idHash,
            new DeterminedHash(chartId),
            legend,
            xAxisSourceHash,
            yAxisSourceHash)
    { }

    public SeriesRichRelationalModelHash(
        IDeterminedHash idHash,
        IDeterminedHash chartIdHash,
        IString legend,
        IDeterminedHash xAxisSourceHash,
        IString yAxisSource)
        : this(
            idHash,
            chartIdHash,
            new DeterminedHash(legend),
            xAxisSourceHash,
            yAxisSource)
    { }

    public SeriesRichRelationalModelHash(
        IDeterminedHash idHash,
        IDeterminedHash chartIdHash,
        IDeterminedHash legendHash,
        IString xAxisSource,
        IString yAxisSource)
        : this(
            idHash,
            chartIdHash,
            legendHash,
            new DeterminedHash(xAxisSource),
            yAxisSource)
    { }

    public SeriesRichRelationalModelHash(
        IDeterminedHash idHash,
        IDeterminedHash chartIdHash,
        IString legend,
        IString xAxisSource,
        IDeterminedHash yAxisSourceHash)
        : this(
            idHash,
            chartIdHash,
            new DeterminedHash(legend),
            xAxisSource,
            yAxisSourceHash)
    { }

    public SeriesRichRelationalModelHash(
        IGuid id,
        IDeterminedHash chartIdHash,
        IString legend,
        IDeterminedHash xAxisSourceHash,
        IDeterminedHash yAxisSourceHash)
        : this(
            new DeterminedHash(id),
            chartIdHash,
            legend,
            xAxisSourceHash,
            yAxisSourceHash)
    { }

    public SeriesRichRelationalModelHash(
        IDeterminedHash idHash,
        IGuid chartId,
        IDeterminedHash legendHash,
        IDeterminedHash xAxisSourceHash,
        IDeterminedHash yAxisSourceHash)
        : this(
            idHash,
            new DeterminedHash(chartId),
            legendHash,
            xAxisSourceHash,
            yAxisSourceHash)
    { }

    public SeriesRichRelationalModelHash(
        IDeterminedHash idHash,
        IDeterminedHash chartIdHash,
        IDeterminedHash legendHash,
        IDeterminedHash xAxisSourceHash,
        IString yAxisSource)
        : this(
            idHash,
            chartIdHash,
            legendHash,
            xAxisSourceHash,
            new DeterminedHash(yAxisSource))
    { }

    public SeriesRichRelationalModelHash(
        IDeterminedHash idHash,
        IDeterminedHash chartIdHash,
        IDeterminedHash legendHash,
        IString xAxisSource,
        IDeterminedHash yAxisSourceHash)
        : this(
            idHash,
            chartIdHash,
            legendHash,
            new DeterminedHash(xAxisSource),
            yAxisSourceHash)
    { }

    public SeriesRichRelationalModelHash(
        IGuid id,
        IDeterminedHash chartIdHash,
        IDeterminedHash legendHash,
        IDeterminedHash xAxisSourceHash,
        IDeterminedHash yAxisSourceHash)
        : this(
            new DeterminedHash(id),
            chartIdHash,
            legendHash,
            xAxisSourceHash,
            yAxisSourceHash)
    { }

    public SeriesRichRelationalModelHash(
        IDeterminedHash idHash,
        IDeterminedHash chartIdHash,
        IString legend,
        IDeterminedHash xAxisSourceHash,
        IDeterminedHash yAxisSourceHash)
        : this(
            idHash,
            chartIdHash,
            new DeterminedHash(legend),
            xAxisSourceHash,
            yAxisSourceHash)
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
