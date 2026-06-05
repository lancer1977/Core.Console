using PolyhydraGames.Core.Console.Display;
using PolyhydraGames.Core.Console.Extensions;
using PolyhydraGames.Core.Console.Helpers;
using PolyhydraGames.Core.Global.Collection;
using DialogResults = PolyhydraGames.Core.Console.Helpers.DialogResults;

namespace PolyhydraGames.Core.Console.Tests;

[TestFixture]
public sealed class ConsoleUtilityTests
{
    [Test]
    public async Task Page_ProcessRunsMatchingMenuItemAndReportsInvalidOrEmptySelection()
    {
        var ran = false;
        var page = new Page
        {
            Title = "Menu",
            Details = "Choose",
            Menu =
            [
                new ConsoleMenuItem("1", "Run", () =>
                {
                    ran = true;
                    return Task.CompletedTask;
                })
            ]
        };

        await page.Process(null);
        Assert.That(ran, Is.False);

        await page.Process("missing");
        Assert.That(page.LastMesage, Is.EqualTo("Invalid selection: missing"));

        await page.Process("1");
        Assert.That(ran, Is.True);
    }

    [Test]
    public void ConsoleMenuItem_ToStringCombinesShortcutAndTitle()
    {
        var item = new ConsoleMenuItem("x", "Exit", () => Task.CompletedTask);

        Assert.Multiple(() =>
        {
            Assert.That(item.ShortcutKey, Is.EqualTo("x"));
            Assert.That(item.Title, Is.EqualTo("Exit"));
            Assert.That(item.ToString(), Is.EqualTo("x - Exit"));
        });
    }

    [Test]
    public void FileData_StoresConstructorValuesAndAllowsMutation()
    {
        var data = new FileData("readme", "hello", ".txt")
        {
            FileName = "notes",
            Contents = "updated",
            Extension = ".md"
        };

        Assert.Multiple(() =>
        {
            Assert.That(data.FileName, Is.EqualTo("notes"));
            Assert.That(data.Contents, Is.EqualTo("updated"));
            Assert.That(data.Extension, Is.EqualTo(".md"));
        });
    }

    [Test]
    public void DialogResults_CreateExpectedOkAndCancelResults()
    {
#pragma warning disable CS0618
        var cancel = DialogResults.Cancel<string>();
        var result = DialogResults.Result("value");
        var yesValue = DialogResults.Yes("yes");
        var yes = DialogResults.Yes();
        var no = DialogResults.No();
#pragma warning restore CS0618

        Assert.Multiple(() =>
        {
            Assert.That(cancel.Ok, Is.False);
            Assert.That(cancel.Result, Is.Null);
            Assert.That(result.Ok, Is.True);
            Assert.That(result.Result, Is.EqualTo("value"));
            Assert.That(yesValue.Result, Is.EqualTo("yes"));
            Assert.That(yes.Ok, Is.True);
            Assert.That(yes.Result, Is.True);
            Assert.That(no.Ok, Is.True);
            Assert.That(no.Result, Is.False);
        });
    }

    [Test]
    public void GroupCollectionExtensions_BuildAlphabeticGroupsAndCanKeepEmptyGroups()
    {
        var items = new[] { "Alpha", "Beta", "Apricot", string.Empty };
        var simpleGroups = items.ToSimpleGroupedCollection(x => x);
        var criteria = GroupCollectionExtensions.ToGroupedCriteria<string, char>(new[] { 'A', 'B', 'Z' },
            (value, letter) => !string.IsNullOrEmpty(value) && value[0] == letter,
            letter => $"Letter {letter}",
            letter => letter.ToString());
        var explicitGroups = GroupCollectionExtensions.ToGroupedCollection(items, criteria, excludeEmptyGroups: false);

        Assert.Multiple(() =>
        {
            Assert.That(simpleGroups.Select(group => group.LongName), Does.Contain("A"));
            Assert.That(simpleGroups.First(group => group.LongName == "A"), Is.EquivalentTo(new[] { "Alpha", "Apricot" }));
            Assert.That(criteria.Select(group => group.LongName), Is.EqualTo(new[] { "Letter A", "Letter B", "Letter Z" }));
            Assert.That(explicitGroups, Has.Count.EqualTo(3));
            Assert.That(explicitGroups.Single(group => group.ShortName == "Z"), Is.Empty);
        });
    }
}
