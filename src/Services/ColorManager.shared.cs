//IConstants constants, IVerbosePickerAsync verbosePicker, IItemModelPicker picker

namespace PolyhydraGames.Core.Console.Services;

public class VerbosePickerFake : IVerbosePickerAsync
{
    public async Task Show<T>(List<IGroupedCollection<T>> source, Func<T, string> getDescription, Action<T> onChoose)
    {
        throw new NotImplementedException();
    }

    public async Task Show(IEnumerable<string> items, Action<string> onChoose, Func<string, string> getDescription = null)
    {
        throw new NotImplementedException();
    }

    public async Task Show<T>(IEnumerable<T> items, Func<T, string> getTitle, Action<T> onChoose, Func<T, string> getDescription = null)
    {
        throw new NotImplementedException();
    }
}