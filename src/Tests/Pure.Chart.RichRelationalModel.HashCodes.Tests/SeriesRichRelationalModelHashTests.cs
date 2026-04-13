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
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new RandomString();
        IString xAxisSource = new RandomString();
        IString yAxisSource = new RandomString();

        ISeriesRichRelationalModel model = new SeriesRichRelationalModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource
        );

        SeriesRichRelationalModelHash expected = new SeriesRichRelationalModelHash(model);
        SeriesRichRelationalModelHash actual = new SeriesRichRelationalModelHash(model);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromValues()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new RandomString();
        IString xAxisSource = new RandomString();
        IString yAxisSource = new RandomString();

        ISeriesRichRelationalModel model = new SeriesRichRelationalModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource);

        SeriesRichRelationalModelHash expected = new SeriesRichRelationalModelHash(model);
        SeriesRichRelationalModelHash actual = new SeriesRichRelationalModelHash(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromIdHash()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new RandomString();
        IString xAxisSource = new RandomString();
        IString yAxisSource = new RandomString();

        ISeriesRichRelationalModel model = new SeriesRichRelationalModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource);

        SeriesRichRelationalModelHash expected = new SeriesRichRelationalModelHash(model);
        SeriesRichRelationalModelHash actual = new SeriesRichRelationalModelHash(
            new DeterminedHash(id),
            chartId,
            legend,
            xAxisSource,
            yAxisSource);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromChartIdHash()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new RandomString();
        IString xAxisSource = new RandomString();
        IString yAxisSource = new RandomString();

        ISeriesRichRelationalModel model = new SeriesRichRelationalModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource);

        SeriesRichRelationalModelHash expected = new SeriesRichRelationalModelHash(model);
        SeriesRichRelationalModelHash actual = new SeriesRichRelationalModelHash(
            id,
            new DeterminedHash(chartId),
            legend,
            xAxisSource,
            yAxisSource);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromIdHashChartIdHash()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new RandomString();
        IString xAxisSource = new RandomString();
        IString yAxisSource = new RandomString();

        ISeriesRichRelationalModel model = new SeriesRichRelationalModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource);

        SeriesRichRelationalModelHash expected = new SeriesRichRelationalModelHash(model);
        SeriesRichRelationalModelHash actual = new SeriesRichRelationalModelHash(
            new DeterminedHash(id),
            new DeterminedHash(chartId),
            legend,
            xAxisSource,
            yAxisSource);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromLegendHash()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new RandomString();
        IString xAxisSource = new RandomString();
        IString yAxisSource = new RandomString();

        ISeriesRichRelationalModel model = new SeriesRichRelationalModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource);

        SeriesRichRelationalModelHash expected = new SeriesRichRelationalModelHash(model);
        SeriesRichRelationalModelHash actual = new SeriesRichRelationalModelHash(
            id,
            chartId,
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).Legend),
            xAxisSource,
            yAxisSource);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromIdHashLegendHash()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new RandomString();
        IString xAxisSource = new RandomString();
        IString yAxisSource = new RandomString();

        ISeriesRichRelationalModel model = new SeriesRichRelationalModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource);

        SeriesRichRelationalModelHash expected = new SeriesRichRelationalModelHash(model);
        SeriesRichRelationalModelHash actual = new SeriesRichRelationalModelHash(
            new DeterminedHash(id),
            chartId,
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).Legend),
            xAxisSource,
            yAxisSource);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromChartIdHashLegendHash()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new RandomString();
        IString xAxisSource = new RandomString();
        IString yAxisSource = new RandomString();

        ISeriesRichRelationalModel model = new SeriesRichRelationalModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource);

        SeriesRichRelationalModelHash expected = new SeriesRichRelationalModelHash(model);
        SeriesRichRelationalModelHash actual = new SeriesRichRelationalModelHash(
            id,
            new DeterminedHash(chartId),
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).Legend),
            xAxisSource,
            yAxisSource);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromIdHashChartIdHashLegendHash()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new RandomString();
        IString xAxisSource = new RandomString();
        IString yAxisSource = new RandomString();

        ISeriesRichRelationalModel model = new SeriesRichRelationalModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource);

        SeriesRichRelationalModelHash expected = new SeriesRichRelationalModelHash(model);
        SeriesRichRelationalModelHash actual = new SeriesRichRelationalModelHash(
            new DeterminedHash(id),
            new DeterminedHash(chartId),
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).Legend),
            xAxisSource,
            yAxisSource);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromXAxisSourceHash()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new RandomString();
        IString xAxisSource = new RandomString();
        IString yAxisSource = new RandomString();

        ISeriesRichRelationalModel model = new SeriesRichRelationalModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource);

        SeriesRichRelationalModelHash expected = new SeriesRichRelationalModelHash(model);
        SeriesRichRelationalModelHash actual = new SeriesRichRelationalModelHash(
            id,
            chartId,
            legend,
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).XAxisSource),
            yAxisSource);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromIdHashXAxisSourceHash()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new RandomString();
        IString xAxisSource = new RandomString();
        IString yAxisSource = new RandomString();

        ISeriesRichRelationalModel model = new SeriesRichRelationalModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource);

        SeriesRichRelationalModelHash expected = new SeriesRichRelationalModelHash(model);
        SeriesRichRelationalModelHash actual = new SeriesRichRelationalModelHash(
            new DeterminedHash(id),
            chartId,
            legend,
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).XAxisSource),
            yAxisSource);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromChartIdHashXAxisSourceHash()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new RandomString();
        IString xAxisSource = new RandomString();
        IString yAxisSource = new RandomString();

        ISeriesRichRelationalModel model = new SeriesRichRelationalModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource);

        SeriesRichRelationalModelHash expected = new SeriesRichRelationalModelHash(model);
        SeriesRichRelationalModelHash actual = new SeriesRichRelationalModelHash(
            id,
            new DeterminedHash(chartId),
            legend,
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).XAxisSource),
            yAxisSource);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromIdHashChartIdHashXAxisSourceHash()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new RandomString();
        IString xAxisSource = new RandomString();
        IString yAxisSource = new RandomString();

        ISeriesRichRelationalModel model = new SeriesRichRelationalModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource);

        SeriesRichRelationalModelHash expected = new SeriesRichRelationalModelHash(model);
        SeriesRichRelationalModelHash actual = new SeriesRichRelationalModelHash(
            new DeterminedHash(id),
            new DeterminedHash(chartId),
            legend,
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).XAxisSource),
            yAxisSource);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromLegendHashXAxisSourceHash()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new RandomString();
        IString xAxisSource = new RandomString();
        IString yAxisSource = new RandomString();

        ISeriesRichRelationalModel model = new SeriesRichRelationalModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource);

        SeriesRichRelationalModelHash expected = new SeriesRichRelationalModelHash(model);
        SeriesRichRelationalModelHash actual = new SeriesRichRelationalModelHash(
            id,
            chartId,
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).Legend),
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).XAxisSource),
            yAxisSource);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromIdHashLegendHashXAxisSourceHash()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new RandomString();
        IString xAxisSource = new RandomString();
        IString yAxisSource = new RandomString();

        ISeriesRichRelationalModel model = new SeriesRichRelationalModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource);

        SeriesRichRelationalModelHash expected = new SeriesRichRelationalModelHash(model);
        SeriesRichRelationalModelHash actual = new SeriesRichRelationalModelHash(
            new DeterminedHash(id),
            chartId,
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).Legend),
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).XAxisSource),
            yAxisSource);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromChartIdHashLegendHashXAxisSourceHash()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new RandomString();
        IString xAxisSource = new RandomString();
        IString yAxisSource = new RandomString();

        ISeriesRichRelationalModel model = new SeriesRichRelationalModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource);

        SeriesRichRelationalModelHash expected = new SeriesRichRelationalModelHash(model);
        SeriesRichRelationalModelHash actual = new SeriesRichRelationalModelHash(
            id,
            new DeterminedHash(chartId),
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).Legend),
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).XAxisSource),
            yAxisSource);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromIdHashChartIdHashLegendHashXAxisSourceHash()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new RandomString();
        IString xAxisSource = new RandomString();
        IString yAxisSource = new RandomString();

        ISeriesRichRelationalModel model = new SeriesRichRelationalModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource);

        SeriesRichRelationalModelHash expected = new SeriesRichRelationalModelHash(model);
        SeriesRichRelationalModelHash actual = new SeriesRichRelationalModelHash(
            new DeterminedHash(id),
            new DeterminedHash(chartId),
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).Legend),
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).XAxisSource),
            yAxisSource);

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromYAxisSourceHash()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new RandomString();
        IString xAxisSource = new RandomString();
        IString yAxisSource = new RandomString();

        ISeriesRichRelationalModel model = new SeriesRichRelationalModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource);

        SeriesRichRelationalModelHash expected = new SeriesRichRelationalModelHash(model);
        SeriesRichRelationalModelHash actual = new SeriesRichRelationalModelHash(
            id,
            chartId,
            legend,
            xAxisSource,
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).YAxisSource));

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromIdHashYAxisSourceHash()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new RandomString();
        IString xAxisSource = new RandomString();
        IString yAxisSource = new RandomString();

        ISeriesRichRelationalModel model = new SeriesRichRelationalModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource);

        SeriesRichRelationalModelHash expected = new SeriesRichRelationalModelHash(model);
        SeriesRichRelationalModelHash actual = new SeriesRichRelationalModelHash(
            new DeterminedHash(id),
            chartId,
            legend,
            xAxisSource,
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).YAxisSource));

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromChartIdHashYAxisSourceHash()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new RandomString();
        IString xAxisSource = new RandomString();
        IString yAxisSource = new RandomString();

        ISeriesRichRelationalModel model = new SeriesRichRelationalModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource);

        SeriesRichRelationalModelHash expected = new SeriesRichRelationalModelHash(model);
        SeriesRichRelationalModelHash actual = new SeriesRichRelationalModelHash(
            id,
            new DeterminedHash(chartId),
            legend,
            xAxisSource,
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).YAxisSource));

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromIdHashChartIdHashYAxisSourceHash()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new RandomString();
        IString xAxisSource = new RandomString();
        IString yAxisSource = new RandomString();

        ISeriesRichRelationalModel model = new SeriesRichRelationalModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource);

        SeriesRichRelationalModelHash expected = new SeriesRichRelationalModelHash(model);
        SeriesRichRelationalModelHash actual = new SeriesRichRelationalModelHash(
            new DeterminedHash(id),
            new DeterminedHash(chartId),
            legend,
            xAxisSource,
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).YAxisSource));

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromLegendHashYAxisSourceHash()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new RandomString();
        IString xAxisSource = new RandomString();
        IString yAxisSource = new RandomString();

        ISeriesRichRelationalModel model = new SeriesRichRelationalModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource);

        SeriesRichRelationalModelHash expected = new SeriesRichRelationalModelHash(model);
        SeriesRichRelationalModelHash actual = new SeriesRichRelationalModelHash(
            id,
            chartId,
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).Legend),
            xAxisSource,
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).YAxisSource));

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromIdHashLegendHashYAxisSourceHash()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new RandomString();
        IString xAxisSource = new RandomString();
        IString yAxisSource = new RandomString();

        ISeriesRichRelationalModel model = new SeriesRichRelationalModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource);

        SeriesRichRelationalModelHash expected = new SeriesRichRelationalModelHash(model);
        SeriesRichRelationalModelHash actual = new SeriesRichRelationalModelHash(
            new DeterminedHash(id),
            chartId,
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).Legend),
            xAxisSource,
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).YAxisSource));

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromChartIdHashLegendHashYAxisSourceHash()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new RandomString();
        IString xAxisSource = new RandomString();
        IString yAxisSource = new RandomString();

        ISeriesRichRelationalModel model = new SeriesRichRelationalModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource);

        SeriesRichRelationalModelHash expected = new SeriesRichRelationalModelHash(model);
        SeriesRichRelationalModelHash actual = new SeriesRichRelationalModelHash(
            id,
            new DeterminedHash(chartId),
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).Legend),
            xAxisSource,
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).YAxisSource));

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromIdHashChartIdHashLegendHashYAxisSourceHash()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new RandomString();
        IString xAxisSource = new RandomString();
        IString yAxisSource = new RandomString();

        ISeriesRichRelationalModel model = new SeriesRichRelationalModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource);

        SeriesRichRelationalModelHash expected = new SeriesRichRelationalModelHash(model);
        SeriesRichRelationalModelHash actual = new SeriesRichRelationalModelHash(
            new DeterminedHash(id),
            new DeterminedHash(chartId),
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).Legend),
            xAxisSource,
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).YAxisSource));

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromXAxisSourceHashYAxisSourceHash()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new RandomString();
        IString xAxisSource = new RandomString();
        IString yAxisSource = new RandomString();

        ISeriesRichRelationalModel model = new SeriesRichRelationalModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource);

        SeriesRichRelationalModelHash expected = new SeriesRichRelationalModelHash(model);
        SeriesRichRelationalModelHash actual = new SeriesRichRelationalModelHash(
            id,
            chartId,
            legend,
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).XAxisSource),
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).YAxisSource));

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromIdHashXAxisSourceHashYAxisSourceHash()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new RandomString();
        IString xAxisSource = new RandomString();
        IString yAxisSource = new RandomString();

        ISeriesRichRelationalModel model = new SeriesRichRelationalModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource);

        SeriesRichRelationalModelHash expected = new SeriesRichRelationalModelHash(model);
        SeriesRichRelationalModelHash actual = new SeriesRichRelationalModelHash(
            new DeterminedHash(id),
            chartId,
            legend,
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).XAxisSource),
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).YAxisSource));

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromChartIdHashXAxisSourceHashYAxisSourceHash()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new RandomString();
        IString xAxisSource = new RandomString();
        IString yAxisSource = new RandomString();

        ISeriesRichRelationalModel model = new SeriesRichRelationalModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource);

        SeriesRichRelationalModelHash expected = new SeriesRichRelationalModelHash(model);
        SeriesRichRelationalModelHash actual = new SeriesRichRelationalModelHash(
            id,
            new DeterminedHash(chartId),
            legend,
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).XAxisSource),
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).YAxisSource));

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromIdHashChartIdHashXAxisSourceHashYAxisSourceHash()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new RandomString();
        IString xAxisSource = new RandomString();
        IString yAxisSource = new RandomString();

        ISeriesRichRelationalModel model = new SeriesRichRelationalModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource);

        SeriesRichRelationalModelHash expected = new SeriesRichRelationalModelHash(model);
        SeriesRichRelationalModelHash actual = new SeriesRichRelationalModelHash(
            new DeterminedHash(id),
            new DeterminedHash(chartId),
            legend,
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).XAxisSource),
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).YAxisSource));

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromLegendHashXAxisSourceHashYAxisSourceHash()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new RandomString();
        IString xAxisSource = new RandomString();
        IString yAxisSource = new RandomString();

        ISeriesRichRelationalModel model = new SeriesRichRelationalModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource);

        SeriesRichRelationalModelHash expected = new SeriesRichRelationalModelHash(model);
        SeriesRichRelationalModelHash actual = new SeriesRichRelationalModelHash(
            id,
            chartId,
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).Legend),
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).XAxisSource),
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).YAxisSource));

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromIdHashLegendHashXAxisSourceHashYAxisSourceHash()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new RandomString();
        IString xAxisSource = new RandomString();
        IString yAxisSource = new RandomString();

        ISeriesRichRelationalModel model = new SeriesRichRelationalModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource);

        SeriesRichRelationalModelHash expected = new SeriesRichRelationalModelHash(model);
        SeriesRichRelationalModelHash actual = new SeriesRichRelationalModelHash(
            new DeterminedHash(id),
            chartId,
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).Legend),
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).XAxisSource),
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).YAxisSource));

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromChartIdHashLegendHashXAxisSourceHashYAxisSourceHash()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new RandomString();
        IString xAxisSource = new RandomString();
        IString yAxisSource = new RandomString();

        ISeriesRichRelationalModel model = new SeriesRichRelationalModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource);

        SeriesRichRelationalModelHash expected = new SeriesRichRelationalModelHash(model);
        SeriesRichRelationalModelHash actual = new SeriesRichRelationalModelHash(
            id,
            new DeterminedHash(chartId),
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).Legend),
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).XAxisSource),
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).YAxisSource));

        Assert.True(expected.SequenceEqual(actual));
    }

    [Fact]
    public void ProduceCorrectHashFromHashes()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new RandomString();
        IString xAxisSource = new RandomString();
        IString yAxisSource = new RandomString();

        ISeriesRichRelationalModel model = new SeriesRichRelationalModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource);

        SeriesRichRelationalModelHash expected = new SeriesRichRelationalModelHash(model);
        SeriesRichRelationalModelHash actual = new SeriesRichRelationalModelHash(
            new DeterminedHash(id),
            new DeterminedHash(chartId),
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).Legend),
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).XAxisSource),
            new DeterminedHash((model as RelationalModel.Abstractions.ISeriesRelationalModel).YAxisSource));

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
