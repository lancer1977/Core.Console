using PolyhydraGames.Core.Global.Model;

namespace PolyhydraGames.Core.Console.Helpers;

/// <summary>
/// MOVE TO GLOBAL
/// </summary>
[Obsolete("Move to GLOBAL")]
public static class DialogResults
{
    public static DialogResult<T> Cancel<T>()
    {
#pragma warning disable CS8604
        return new DialogResult<T>(false, default(T));
#pragma warning restore CS8604
    }
    public static DialogResult<T> Result<T>(T value)
    {
        return new DialogResult<T>(true, value);
    }
    public static DialogResult<T> Yes<T>(T value) => new DialogResult<T>(true, value);


    public static DialogResult<bool> Yes() => new DialogResult<bool>(true, true);

    public static DialogResult<bool> No() => new DialogResult<bool>(true, false);



}