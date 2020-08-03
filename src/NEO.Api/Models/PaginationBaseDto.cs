namespace NEO.Api.Models
{
    public abstract class PaginationBaseDto
    {
        public PaginationBaseDto(int pageNumber, int registersNumber)
        {
            PageNumber = pageNumber;
            pageNumber = pageNumber < 1 ? 1 : pageNumber;
            registersNumber = registersNumber < 1 ? 0 : registersNumber;

            RegistersNumber = registersNumber;
            RegistersIgnored = (pageNumber - 1) * registersNumber;
        }

        public int RegistersIgnored { get; private set; }
        public int RegistersNumber { get; private set; }
        public int PageNumber { get; private set; }

    }
}
