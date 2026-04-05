using System.Collections;
using Pure.Chart.RichRelationalModel.Abstractions;
using Pure.HashCodes;
using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Random.String;
using Guid = Pure.Primitives.Guid.Guid;

namespace Pure.Chart.RichRelationalModel.HashCodes.Tests;

public sealed record AxisRichRelationalModelHashTests
{
    private readonly byte[] _typePrefix =
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

    [Fact]
    public void ProduceCorrectHashFromModel()
    {
        IAxisRichRelationalModel model = new AxisRichRelationalModel(
            new Guid(),
            new Guid(),
            new RandomString()
        );

        AxisRichRelationalModelHash expected = new AxisRichRelationalModelHash(model);
        AxisRichRelationalModelHash actual = new AxisRichRelationalModelHash(model);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromAllHashes()
    {
        IAxisRichRelationalModel model = new AxisRichRelationalModel(
            new Guid(),
            new Guid(),
            new RandomString()
        );

        AxisRichRelationalModelHash expected = new AxisRichRelationalModelHash(model);
        AxisRichRelationalModelHash actual = new AxisRichRelationalModelHash(
            new DeterminedHash(model.Id),
            new DeterminedHash(model.ChartId),
            new DeterminedHash(
                (model as RelationalModel.Abstractions.IAxisRelationalModel).Legend
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

        AxisRichRelationalModelHash hash = new AxisRichRelationalModelHash(
            new DeterminedHash(id),
            new DeterminedHash(chartId),
            new DeterminedHash(legend)
        );

        IEnumerable hashEnumerable = hash;
        IEnumerator<byte> expectedHash = new DeterminedHash(
            _typePrefix
                .Concat(new DeterminedHash(id))
                .Concat(new DeterminedHash(chartId))
                .Concat(new DeterminedHash(legend))
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

        AxisRichRelationalModelHash hash = new AxisRichRelationalModelHash(
            new DeterminedHash(id),
            new DeterminedHash(chartId),
            new DeterminedHash(legend)
        );

        IEnumerable<byte> expectedHash = new DeterminedHash(
            _typePrefix
                .Concat(new DeterminedHash(id))
                .Concat(new DeterminedHash(chartId))
                .Concat(new DeterminedHash(legend))
        );

        Assert.Equal(expectedHash, hash);
    }
}
