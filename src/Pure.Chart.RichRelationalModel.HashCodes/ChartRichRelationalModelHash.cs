using System.Collections;
using Pure.Chart.Model.Abstractions;
using Pure.Chart.Model.HashCodes;
using Pure.Chart.RelationalModel.Abstractions;
using Pure.Chart.RichRelationalModel.Abstractions;
using Pure.HashCodes;
using Pure.HashCodes.Abstractions;
using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;

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
            model.Id,
            (model as IChartRelationalModel).Title,
            (model as IChartRelationalModel).Description,
            model.TypeId,
            model.Type,
            model.XAxisId,
            model.XAxis,
            model.YAxisId,
            model.YAxis,
            model.Series)
    { }

    public ChartRichRelationalModelHash(
        IGuid id,
        IString title,
        IString description,
        IGuid typeId,
        IChartType type,
        IGuid xAxisId,
        IAxis xAxis,
        IGuid yAxisId,
        IAxis yAxis,
        IEnumerable<ISeries> series)
        : this(
            new DeterminedHash(id),
            new DeterminedHash(title),
            new DeterminedHash(description),
            new DeterminedHash(typeId),
            new ChartTypeHash(type),
            new DeterminedHash(xAxisId),
            new AxisHash(xAxis),
            new DeterminedHash(yAxisId),
            new AxisHash(yAxis),
            new DeterminedHash(series.Select(x => new SeriesHash(x))))
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
