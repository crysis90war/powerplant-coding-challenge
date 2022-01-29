namespace PowerplantUIL.Extensions;

public static class ListExtension
{
    public static IEnumerable<T> Sort<T, L>(this IEnumerable<T> data, Func<T, L> maxValueProvider, Func<T, L> pMWhProvider)
    {
        return data.OrderByDescending(item => maxValueProvider).OrderBy(item => pMWhProvider);
    }
}
