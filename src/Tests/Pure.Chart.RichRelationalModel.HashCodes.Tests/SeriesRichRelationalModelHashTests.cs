using System.Collections;
using Pure.Chart.RichRelationalModel.Abstractions;
using Pure.HashCodes;
using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Random.String;
using Guid = Pure.Primitives.Guid.Guid;

namespace Pure.Chart.RichRelationalModel.HashCodes.Tests;

public sealed record SeriesRichRelationalModelHashTests
{
    private readonly byte[] _typePrefix =
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

    [Fact]
    public void ProduceCorrectHashFromModel()
    {
        ISeriesRichRelationalModel model = new SeriesRichRelationalModel(
            new Guid(),
            new Guid(),
            new RandomString(),
            new RandomString(),
            new RandomString()
        );

        SeriesRichRelationalModelHash expected = new SeriesRichRelationalModelHash(model);
        SeriesRichRelationalModelHash actual = new SeriesRichRelationalModelHash(model);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromAllHashes()
    {
        ISeriesRichRelationalModel model = new SeriesRichRelationalModel(
            new Guid(),
            new Guid(),
            new RandomString(),
            new RandomString(),
            new RandomString()
        );

        SeriesRichRelationalModelHash expected = new SeriesRichRelationalModelHash(model);
        SeriesRichRelationalModelHash actual = new SeriesRichRelationalModelHash(
            new DeterminedHash(model.Id),
            new DeterminedHash(model.ChartId),
            new DeterminedHash(
                (model as RelationalModel.Abstractions.ISeriesRelationalModel).Legend
            ),
            new DeterminedHash(
                (model as RelationalModel.Abstractions.ISeriesRelationalModel).XAxisSource
            ),
            new DeterminedHash(
                (model as RelationalModel.Abstractions.ISeriesRelationalModel).YAxisSource
            )
        );

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void EnumeratesAsUntyped()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new RandomString();
        IString xAxisSource = new RandomString();
        IString yAxisSource = new RandomString();

        SeriesRichRelationalModelHash hash = new SeriesRichRelationalModelHash(
            new DeterminedHash(id),
            new DeterminedHash(chartId),
            new DeterminedHash(legend),
            new DeterminedHash(xAxisSource),
            new DeterminedHash(yAxisSource)
        );

        IEnumerable hashEnumerable = hash;
        using IEnumerator<byte> expectedHash = new DeterminedHash(
            _typePrefix
                .Concat(new DeterminedHash(id))
                .Concat(new DeterminedHash(chartId))
                .Concat(new DeterminedHash(legend))
                .Concat(new DeterminedHash(xAxisSource))
                .Concat(new DeterminedHash(yAxisSource))
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
        IGuid chartId = new Guid();
        IString legend = new RandomString();
        IString xAxisSource = new RandomString();
        IString yAxisSource = new RandomString();

        SeriesRichRelationalModelHash hash = new SeriesRichRelationalModelHash(
            new DeterminedHash(id),
            new DeterminedHash(chartId),
            new DeterminedHash(legend),
            new DeterminedHash(xAxisSource),
            new DeterminedHash(yAxisSource)
        );

        IEnumerable<byte> expectedHash = new DeterminedHash(
            _typePrefix
                .Concat(new DeterminedHash(id))
                .Concat(new DeterminedHash(chartId))
                .Concat(new DeterminedHash(legend))
                .Concat(new DeterminedHash(xAxisSource))
                .Concat(new DeterminedHash(yAxisSource))
        );

        Assert.Equal(expectedHash, hash);
    }
}
