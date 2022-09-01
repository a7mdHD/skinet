namespace Core.Specifications
{
    public class ProductSpecParams
    {
        public string Sort {get; set;}
        public int? BrandId {get; set;}
        public int? TypeId {get; set;}
        private const int _maxPageSize = 50;
        private int _pageSize = 6;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > _maxPageSize) ? _maxPageSize : value;
        }
        public int PageIndex { get; set; } = 1;
        private string _search;
        public string Search
        { 
            get => _search;
            set => _search = value.ToLower();
        }
    }
}