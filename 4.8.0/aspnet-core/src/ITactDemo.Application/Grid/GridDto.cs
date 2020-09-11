using System.Collections.Generic;

namespace ITactDemo.Grid
{
    public class GridOutputDto<TModel>
    {
        public int Total { get; set; }

        public int Page { get; set; }

        public int Records { get; set; }

        public List<TModel> Rows = new List<TModel>();

        public dynamic Userdata { get; set; }
    }
}
