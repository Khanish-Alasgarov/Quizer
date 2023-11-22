using System.Collections;

namespace Models.Common.Paging;

public interface IPaginate
{
    int Page { get; }
    int Size { get; }
    int Count { get; }
    int Pages { get; }
    bool HasPrevious { get; }
    bool HasNext { get; }
    IEnumerable Items { get; }

}
