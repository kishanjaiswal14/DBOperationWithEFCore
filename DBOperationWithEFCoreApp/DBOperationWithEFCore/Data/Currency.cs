namespace DBOperationWithEFCore.Data
{
    public class Currency
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }

        public List<BookPrice> BookPrices { get; set; } 

    }
}
