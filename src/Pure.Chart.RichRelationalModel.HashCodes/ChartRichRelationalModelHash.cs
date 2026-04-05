using System.Collections;
using Pure.Chart.Model.HashCodes;
using Pure.Chart.RelationalModel.Abstractions;
using Pure.Chart.RichRelationalModel.Abstractions;
using Pure.HashCodes;
using Pure.HashCodes.Abstractions;

namespace Pure.Chart.RichRelationalModel.HashCodes;

public sealed record ChartRichRelationalModelHash : IDeterminedHash
{
    private static readonly byte[] TypePrefix =
    [
        117,
        93,
        157,
        1,
        80,
        4,
        127,
        115,
        145,
        38,
        48,
        226,
        22,
        89,
        233,
        51,
    ];

    private readonly IDeterminedHash _idHash;

    private readonly IDeterminedHash _titleHash;

    private readonly IDeterminedHash _descriptionHash;

    private readonly IDeterminedHash _typeIdHash;

    private readonly IDeterminedHash _typeHash;

    private readonly IDeterminedHash _xAxisIdHash;

    private readonly IDeterminedHash _xAxisHash;

    private readonly IDeterminedHash _yAxisIdHash;

    private readonly IDeterminedHash _yAxisHash;

    private readonly IDeterminedHash _seriesHash;

    public ChartRichRelationalModelHash(IChartRichRelationalModel model)
        : this(
            new DeterminedHash(model.Id),
            new DeterminedHash((model as IChartRelationalModel).Title),
            new DeterminedHash((model as IChartRelationalModel).Description),
            new DeterminedHash(model.TypeId),
            new ChartTypeHash(model.Type),
            new DeterminedHash(model.XAxisId),
            new AxisHash(model.XAxis),
            new DeterminedHash(model.YAxisId),
            new AxisHash(model.YAxis),
            new DeterminedHash(model.Series.Select(x => new SeriesHash(x)))
        )
    { }

    public ChartRichRelationalModelHash(
        IDeterminedHash idHash,
        IDeterminedHash titleHash,
        IDeterminedHash descriptionHash,
        IDeterminedHash typeIdHash,
        IDeterminedHash typeHash,
        IDeterminedHash xAxisIdHash,
        IDeterminedHash xAxisHash,
        IDeterminedHash yAxisIdHash,
        IDeterminedHash yAxisHash,
        IDeterminedHash seriesHash
    )
    {
        _idHash = idHash;
        _titleHash = titleHash;
        _descriptionHash = descriptionHash;
        _typeIdHash = typeIdHash;
        _typeHash = typeHash;
        _xAxisIdHash = xAxisIdHash;
        _xAxisHash = xAxisHash;
        _yAxisIdHash = yAxisIdHash;
        _yAxisHash = yAxisHash;
        _seriesHash = seriesHash;
    }

    public IEnumerator<byte> GetEnumerator()
    {
        return new DeterminedHash(
            TypePrefix
                .Concat(_idHash)
                .Concat(_titleHash)
                .Concat(_descriptionHash)
                .Concat(_typeIdHash)
                .Concat(_typeHash)
                .Concat(_xAxisIdHash)
                .Concat(_xAxisHash)
                .Concat(_yAxisIdHash)
                .Concat(_yAxisHash)
                .Concat(_seriesHash)
        ).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
