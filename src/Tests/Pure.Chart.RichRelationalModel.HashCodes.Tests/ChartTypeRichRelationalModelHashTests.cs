using System.Collections;
using Pure.Chart.RichRelationalModel.Abstractions;
using Pure.HashCodes;
using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Random.String;
using Guid = Pure.Primitives.Guid.Guid;

namespace Pure.Chart.RichRelationalModel.HashCodes.Tests;

public sealed record ChartTypeRichRelationalModelHashTests
{
    private readonly byte[] _typePrefix =
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

    [Fact]
    public void ProduceCorrectHashFromModel()
    {
        IGuid id = new Guid();
        IString name = new RandomString();

        IChartTypeRichRelationalModel model = new ChartTypeRichRelationalModel(
            id,
            name
        );

        ChartTypeRichRelationalModelHash expected = new ChartTypeRichRelationalModelHash(model);
        ChartTypeRichRelationalModelHash actual = new ChartTypeRichRelationalModelHash(model);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromValues()
    {
        IGuid id = new Guid();
        IString name = new RandomString();

        IChartTypeRichRelationalModel model = new ChartTypeRichRelationalModel(
            id,
            name);

        ChartTypeRichRelationalModelHash expected = new ChartTypeRichRelationalModelHash(model);
        ChartTypeRichRelationalModelHash actual = new ChartTypeRichRelationalModelHash(
            id,
            name);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromIdHash()
    {
        IGuid id = new Guid();
        IString name = new RandomString();

        IChartTypeRichRelationalModel model = new ChartTypeRichRelationalModel(
            id,
            name);

        ChartTypeRichRelationalModelHash expected = new ChartTypeRichRelationalModelHash(model);
        ChartTypeRichRelationalModelHash actual = new ChartTypeRichRelationalModelHash(
            new DeterminedHash(id),
            name);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromNameHash()
    {
        IGuid id = new Guid();
        IString name = new RandomString();

        IChartTypeRichRelationalModel model = new ChartTypeRichRelationalModel(
            id,
            name);

        ChartTypeRichRelationalModelHash expected = new ChartTypeRichRelationalModelHash(model);
        ChartTypeRichRelationalModelHash actual = new ChartTypeRichRelationalModelHash(
            id,
            new DeterminedHash((model as RelationalModel.Abstractions.IChartTypeRelationalModel).Name));

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromHashes()
    {
        IGuid id = new Guid();
        IString name = new RandomString();

        IChartTypeRichRelationalModel model = new ChartTypeRichRelationalModel(
            id,
            name);

        ChartTypeRichRelationalModelHash expected = new ChartTypeRichRelationalModelHash(model);
        ChartTypeRichRelationalModelHash actual = new ChartTypeRichRelationalModelHash(
            new DeterminedHash(id),
            new DeterminedHash((model as RelationalModel.Abstractions.IChartTypeRelationalModel).Name));

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void EnumeratesAsUntyped()
    {
        IGuid id = new Guid();
        IString name = new RandomString();

        ChartTypeRichRelationalModelHash hash = new ChartTypeRichRelationalModelHash(
            new DeterminedHash(id),
            new DeterminedHash(name)
        );

        IEnumerable hashEnumerable = hash;
        IEnumerator<byte> expectedHash = new DeterminedHash(
            _typePrefix.Concat(new DeterminedHash(id)).Concat(new DeterminedHash(name))
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
        IString name = new RandomString();

        ChartTypeRichRelationalModelHash hash = new ChartTypeRichRelationalModelHash(
            new DeterminedHash(id),
            new DeterminedHash(name)
        );

        IEnumerable<byte> expectedHash = new DeterminedHash(
            _typePrefix.Concat(new DeterminedHash(id)).Concat(new DeterminedHash(name))
        );

        Assert.Equal(expectedHash, hash);
    }
}
