using System.Collections;

namespace Models.Common.Paging;

public class Paginate : IPaginate
{
    public Paginate(int page, int size, int count)
    {
        Size = size;
        Count = count;
        Pages = (int)Math.Ceiling(this.Count * 1D / this.Size);

        Page = page > Pages ? this.Pages : page;
    }

    public int Page { get; }

    public int Size { get; }

    public int Count { get; }

    public int Pages { get; }

    public bool HasPrevious => this.Page > 1;

    public bool HasNext => this.Page < this.Pages;

    public IEnumerable Items { get; set; } 
}
