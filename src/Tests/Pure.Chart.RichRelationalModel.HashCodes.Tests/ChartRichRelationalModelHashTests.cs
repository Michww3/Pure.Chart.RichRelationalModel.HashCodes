using System.Collections;
using Pure.Chart.Model.Abstractions;
using Pure.Chart.Model.HashCodes;
using Pure.Chart.RichRelationalModel.Abstractions;
using Pure.HashCodes;
using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Random.String;
using Guid = Pure.Primitives.Guid.Guid;

namespace Pure.Chart.RichRelationalModel.HashCodes.Tests;

public sealed record ChartRichRelationalModelHashTests
{
    private readonly byte[] _typePrefix =
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

    [Fact]
    public void ProduceCorrectHashFromModel()
    {
        IChartRichRelationalModel model = new ChartRichRelationalModel(
            new Guid(),
            new RandomString(),
            new RandomString(),
            new Guid(),
            new ChartTypeRichRelationalModel(new Guid(), new RandomString()),
            new Guid(),
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            new Guid(),
            new AxisRichRelationalModel(new Guid(), new Guid(), new RandomString()),
            [
                new SeriesRichRelationalModel(
                    new Guid(),
                    new Guid(),
                    new RandomString(),
                    new RandomString(),
                    new RandomString()
                ),
            ]
        );

        ChartRichRelationalModelHash expected = new ChartRichRelationalModelHash(model);
        ChartRichRelationalModelHash actual = new ChartRichRelationalModelHash(model);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromValues()
    {
        IGuid id = new Guid();
        IString title = new RandomString();
        IString description = new RandomString();
        IGuid typeId = new Guid();
        IChartType type = new ChartTypeRichRelationalModel(
            new Guid(),
            new RandomString()
        );
        IGuid xAxisId = new Guid();
        IAxis xAxis = new AxisRichRelationalModel(
            new Guid(),
            new Guid(),
            new RandomString()
        );
        IGuid yAxisId = new Guid();
        IAxis yAxis = new AxisRichRelationalModel(
            new Guid(),
            new Guid(),
            new RandomString()
        );
        IEnumerable<ISeries> series =
        [
            new SeriesRichRelationalModel(
                new Guid(),
                new Guid(),
                new RandomString(),
                new RandomString(),
                new RandomString()
            ),
        ];

        IChartRichRelationalModel model = new ChartRichRelationalModel(
            id,
            title,
            description,
            typeId,
            type,
            xAxisId,
            xAxis,
            yAxisId,
            yAxis,
            series
        );

        ChartRichRelationalModelHash expected = new ChartRichRelationalModelHash(model);
        ChartRichRelationalModelHash actual = new ChartRichRelationalModelHash(
            id,
            title,
            description,
            typeId,
            type,
            xAxisId,
            xAxis,
            yAxisId,
            yAxis,
            series
        );

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromAllHashes()
    {
        IGuid id = new Guid();
        IString title = new RandomString();
        IString description = new RandomString();
        IGuid typeId = new Guid();
        IChartType type = new ChartTypeRichRelationalModel(
            new Guid(),
            new RandomString()
        );
        IGuid xAxisId = new Guid();
        IAxis xAxis = new AxisRichRelationalModel(
            new Guid(),
            new Guid(),
            new RandomString()
        );
        IGuid yAxisId = new Guid();
        IAxis yAxis = new AxisRichRelationalModel(
            new Guid(),
            new Guid(),
            new RandomString()
        );
        IEnumerable<ISeries> series =
        [
            new SeriesRichRelationalModel(
                new Guid(),
                new Guid(),
                new RandomString(),
                new RandomString(),
                new RandomString()
            ),
        ];

        IChartRichRelationalModel model = new ChartRichRelationalModel(
            id,
            title,
            description,
            typeId,
            type,
            xAxisId,
            xAxis,
            yAxisId,
            yAxis,
            series
        );

        ChartRichRelationalModelHash expected = new ChartRichRelationalModelHash(model);
        ChartRichRelationalModelHash actual = new ChartRichRelationalModelHash(
            new DeterminedHash(id),
            new DeterminedHash(title),
            new DeterminedHash(description),
            new DeterminedHash(typeId),
            new ChartTypeHash(type),
            new DeterminedHash(xAxisId),
            new AxisHash(xAxis),
            new DeterminedHash(yAxisId),
            new AxisHash(yAxis),
            new DeterminedHash(series.Select(x => new SeriesHash(x)))
        );

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void EnumeratesAsUntyped()
    {
        IGuid id = new Guid();
        IString title = new RandomString();
        IString description = new RandomString();
        IGuid typeId = new Guid();
        IChartType type = new ChartTypeRichRelationalModel(
            new Guid(),
            new RandomString()
        );
        IGuid xAxisId = new Guid();
        IAxis xAxis = new AxisRichRelationalModel(
            new Guid(),
            new Guid(),
            new RandomString()
        );
        IGuid yAxisId = new Guid();
        IAxis yAxis = new AxisRichRelationalModel(
            new Guid(),
            new Guid(),
            new RandomString()
        );
        IEnumerable<ISeries> series =
        [
            new SeriesRichRelationalModel(
                new Guid(),
                new Guid(),
                new RandomString(),
                new RandomString(),
                new RandomString()
            ),
        ];

        IEnumerable hashEnumerable = new ChartRichRelationalModelHash(
            new DeterminedHash(id),
            new DeterminedHash(title),
            new DeterminedHash(description),
            new DeterminedHash(typeId),
            new ChartTypeHash(type),
            new DeterminedHash(xAxisId),
            new AxisHash(xAxis),
            new DeterminedHash(yAxisId),
            new AxisHash(yAxis),
            new DeterminedHash(series.Select(x => new SeriesHash(x)))
        );

        IEnumerator<byte> expectedHash = new DeterminedHash(
            _typePrefix
                .Concat(new DeterminedHash(id))
                .Concat(new DeterminedHash(title))
                .Concat(new DeterminedHash(description))
                .Concat(new DeterminedHash(typeId))
                .Concat(new ChartTypeHash(type))
                .Concat(new DeterminedHash(xAxisId))
                .Concat(new AxisHash(xAxis))
                .Concat(new DeterminedHash(yAxisId))
                .Concat(new AxisHash(yAxis))
                .Concat(new DeterminedHash(series.Select(x => new SeriesHash(x))))
        ).GetEnumerator();

        bool equal = true;

        foreach (object item in hashEnumerable)
        {
            _ = expectedHash.MoveNext();
            if ((byte)item != expectedHash.Current)
            {
                equal = false;
                break;
            }
        }

        Assert.True(equal);
    }

    [Fact]
    public void ProducesCorrectHash()
    {
        IGuid id = new Guid();
        IString title = new RandomString();
        IString description = new RandomString();
        IGuid typeId = new Guid();
        IChartType type = new ChartTypeRichRelationalModel(
            new Guid(),
            new RandomString()
        );
        IGuid xAxisId = new Guid();
        IAxis xAxis = new AxisRichRelationalModel(
            new Guid(),
            new Guid(),
            new RandomString()
        );
        IGuid yAxisId = new Guid();
        IAxis yAxis = new AxisRichRelationalModel(
            new Guid(),
            new Guid(),
            new RandomString()
        );
        IEnumerable<ISeries> series =
        [
            new SeriesRichRelationalModel(
                new Guid(),
                new Guid(),
                new RandomString(),
                new RandomString(),
                new RandomString()
            ),
        ];

        IEnumerable<byte> expectedHash = new DeterminedHash(
            _typePrefix
                .Concat(new DeterminedHash(id))
                .Concat(new DeterminedHash(title))
                .Concat(new DeterminedHash(description))
                .Concat(new DeterminedHash(typeId))
                .Concat(new ChartTypeHash(type))
                .Concat(new DeterminedHash(xAxisId))
                .Concat(new AxisHash(xAxis))
                .Concat(new DeterminedHash(yAxisId))
                .Concat(new AxisHash(yAxis))
                .Concat(new DeterminedHash(series.Select(x => new SeriesHash(x))))
        );

        Assert.Equal(
            expectedHash,
            new ChartRichRelationalModelHash(
                new DeterminedHash(id),
                new DeterminedHash(title),
                new DeterminedHash(description),
                new DeterminedHash(typeId),
                new ChartTypeHash(type),
                new DeterminedHash(xAxisId),
                new AxisHash(xAxis),
                new DeterminedHash(yAxisId),
                new AxisHash(yAxis),
                new DeterminedHash(series.Select(x => new SeriesHash(x)))
            )
        );
    }
}
