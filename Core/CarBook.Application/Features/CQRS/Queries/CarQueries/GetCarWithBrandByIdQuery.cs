namespace CarBook.Application.Features.CQRS.Queries.CarQueries
{
    public class GetCarWithBrandByIdQuery
    {
        public int id { get; set; }

        public GetCarWithBrandByIdQuery(int id)
        {
            this.id = id;
        }
    }
}
